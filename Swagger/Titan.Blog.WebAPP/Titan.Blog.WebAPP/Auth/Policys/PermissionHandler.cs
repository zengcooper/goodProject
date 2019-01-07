﻿using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Titan.Blog.AppService.DomainService;

namespace Titan.Blog.WebAPP.Auth.Policys
{
    /// <summary>
    /// 权限授权处理器
    /// </summary>
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        /// <summary>
        /// 验证方案提供对象
        /// </summary>
        public IAuthenticationSchemeProvider Schemes { get; set; }

        /// <summary>
        /// services 层注入
        /// </summary>
        public AuthorDomainSvc _authorDomainSvc { get; set; }

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="schemes"></param>
        /// <param name="roleModulePermissionServices"></param>
        public PermissionHandler(IAuthenticationSchemeProvider schemes, AuthorDomainSvc authorDomainSvc)
        {
            Schemes = schemes;
            _authorDomainSvc = authorDomainSvc;
        }

        // 重载异步处理程序--这个是自定义的权限拦截器，[Authorize("Permission")] 标记了这个特性的所有接口都走这个里面验证接口权限
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            // 将最新的角色和接口列表更新
            var data = _authorDomainSvc.GeRoleModule();
            var list = (from item in data
                        select new Permission
                        {
                            Url = item.SysModule?.LinkUrl,
                            Role = item.SysRole?.RoleName,
                        }).ToList();
            //var list=new List<Permission>();
            requirement.Permissions = list;

            //从AuthorizationHandlerContext转成HttpContext，以便取出表求信息
            var httpContext = (context.Resource as Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext).HttpContext;
            //请求Url
            var questUrl = httpContext.Request.Path.Value.ToLower();
            //判断请求是否停止
            var handlers = httpContext.RequestServices.GetRequiredService<IAuthenticationHandlerProvider>();
            foreach (var scheme in await Schemes.GetRequestHandlerSchemesAsync())
            {
                var handler = await handlers.GetHandlerAsync(httpContext, scheme.Name) as IAuthenticationRequestHandler;
                if (handler != null && await handler.HandleRequestAsync())
                {
                    context.Fail();
                    throw new UnauthorizedAccessException("请求已停止！");
                }
            }
            //判断请求是否拥有凭据，即有没有登录
            var defaultAuthenticate = await Schemes.GetDefaultAuthenticateSchemeAsync();
            if (defaultAuthenticate != null)
            {
                var result = await httpContext.AuthenticateAsync(defaultAuthenticate.Name);
                if (result.Failure!=null && result.Failure.Message.Contains("The token is expired."))
                {
                    context.Fail();
                    throw new UnauthorizedAccessException("令牌已过期，请重新获取授权！");
                }
                //result?.Principal不为空即登录成功
                if (result?.Principal != null)
                {

                    httpContext.User = result.Principal;
                    //权限中是否存在请求的url
                    if (requirement.Permissions.GroupBy(g => g.Url).Where(w => w.Key?.ToLower() == questUrl).Count() > 0)
                    {
                        // 获取当前用户的角色信息
                        var currentUserRoles = (from item in httpContext.User.Claims
                                                where item.Type == requirement.ClaimType
                                                select item.Value).ToList();


                        //验证权限
                        if (currentUserRoles.Count <= 0 || requirement.Permissions.Where(w => currentUserRoles.Contains(w.Role) && w.Url.ToLower() == questUrl).Count() <= 0)
                        {

                            context.Fail();
                            throw new UnauthorizedAccessException("没有使用这个接口的权限！");
                            // 可以在这里设置跳转页面，不过还是会访问当前接口地址的
                            //httpContext.Response.Redirect(requirement.DeniedAction);
                        }
                    }
                    else
                    {
                        context.Fail();
                        throw new UnauthorizedAccessException("这个接口不在权限系统中，请联系管理员添加接口权限！");

                    }
                    //判断过期时间
                    if ((httpContext.User.Claims.SingleOrDefault(s => s.Type == ClaimTypes.Expiration)?.Value) != null && DateTime.Parse(httpContext.User.Claims.SingleOrDefault(s => s.Type == ClaimTypes.Expiration)?.Value) >= DateTime.Now)
                    {
                        context.Succeed(requirement);
                        return;
                    }
                    else
                    {
                        context.Fail();
                        throw new UnauthorizedAccessException("令牌已过期，请重新获取授权！");
                    }
                }
                else
                {
                    context.Fail();
                    throw new UnauthorizedAccessException("请先登录！");
                }
            }
            //判断没有登录时，是否访问登录的url,并且是Post请求，并且是form表单提交类型，否则为失败
            if (!questUrl.Equals(requirement.LoginPath.ToLower(), StringComparison.Ordinal) && (!httpContext.Request.Method.Equals("POST")
               || !httpContext.Request.HasFormContentType))
            {
                context.Fail();
                throw new UnauthorizedAccessException("未经授权的访问！");
            }
            context.Succeed(requirement);
        }
    }
}
