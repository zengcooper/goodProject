using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Template1.Common.Configuration;
using Template1.Entity.DemoDotNetCore;
using Template1.Repository.DemoDotNetCore.Base;

namespace Template1.Repository.DemoDotNetCore
{
    public interface IMicroserviceRepository : IRepository<MicroserviceEntity>
    {
        Task<Tuple<int, IList<MicroserviceEntity>>> GetListByPageAsync(MicroserviceEntity entity, int pageIndex, int pageSize);
    }

    public class MicroserviceRepository : Repository<MicroserviceEntity>, IMicroserviceRepository
    {
        public MicroserviceRepository(IDemoDotNetCoreDatabaseFactory databaseFactory,
            IDemoConfiguration demoConfiguration)
            : base(databaseFactory, demoConfiguration) { }

        public async Task<Tuple<int, IList<MicroserviceEntity>>> GetListByPageAsync(MicroserviceEntity entity, int pageIndex, int pageSize)
        {
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageSize = pageSize < 1 ? 10 : pageSize;
            var skip = (pageIndex - 1) * pageSize;
            //var query = DbSet.AsQueryable();
            var query = DbSet.Where(k => true);
            if (entity != null)
            {
                if (!string.IsNullOrWhiteSpace(entity.Name))
                    query = query.Where(k => k.Name.Contains(entity.Name));
                if (!string.IsNullOrWhiteSpace(entity.Description))
                    query = query.Where(k => k.Description.Contains(entity.Description));
                if (!string.IsNullOrWhiteSpace(entity.ServiceCode))
                    query = query.Where(k => k.ServiceCode.Contains(entity.ServiceCode));
                if (!string.IsNullOrWhiteSpace(entity.ServiceAliasName))
                    query = query.Where(k => k.ServiceAliasName.Contains(entity.ServiceAliasName));
                if (!string.IsNullOrWhiteSpace(entity.ServiceChineseName))
                    query = query.Where(k => k.ServiceChineseName.Contains(entity.ServiceChineseName));
                if (!string.IsNullOrWhiteSpace(entity.ServiceCategory))
                    query = query.Where(k => k.ServiceCategory.Contains(entity.ServiceCategory));
                if (!string.IsNullOrWhiteSpace(entity.Dependencies))
                    query = query.Where(k => k.Dependencies.Contains(entity.Dependencies));
                if (!string.IsNullOrWhiteSpace(entity.CodingLanguage))
                    query = query.Where(k => k.CodingLanguage.Contains(entity.CodingLanguage));
                if (!string.IsNullOrWhiteSpace(entity.ResponsibleTeam))
                    query = query.Where(k => k.ResponsibleTeam.Contains(entity.ResponsibleTeam));
                if (!string.IsNullOrWhiteSpace(entity.ProductOwner))
                    query = query.Where(k => k.ProductOwner.Contains(entity.ProductOwner));
                if (!string.IsNullOrWhiteSpace(entity.TechniqueOwner))
                    query = query.Where(k => k.TechniqueOwner.Contains(entity.TechniqueOwner));
                if (!string.IsNullOrWhiteSpace(entity.ScrumMaster))
                    query = query.Where(k => k.ScrumMaster.Contains(entity.ScrumMaster));
                if (!string.IsNullOrWhiteSpace(entity.Developers))
                    query = query.Where(k => k.Developers.Contains(entity.Developers));
                if (!string.IsNullOrWhiteSpace(entity.ServiceConfluenceUrl))
                    query = query.Where(k => k.ServiceConfluenceUrl.Contains(entity.ServiceConfluenceUrl));
                if (!string.IsNullOrWhiteSpace(entity.RepositoryName))
                    query = query.Where(k => k.RepositoryName.Contains(entity.RepositoryName));
                if (!string.IsNullOrWhiteSpace(entity.AzureResourceType))
                    query = query.Where(k => k.AzureResourceType.Contains(entity.AzureResourceType));
            }
            query = query.OrderByDescending(k => k.Name);
            var count = await query.CountAsync();
            var list = await query.Skip(skip).Take(pageSize).ToListAsync();


            return new Tuple<int, IList<MicroserviceEntity>>(count, list == null ? new List<MicroserviceEntity>() : list.ToList());
        }
    }
}
