﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Blog.Infrastructure.Data
{
    /// <summary>
    /// 分页数据
    /// </summary>
    /// <typeparam name="TData">分页数据的类型</typeparam>
    public class PagingData<TData>
    {
        /// <summary>
        /// 总数据量
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 分页结果数据
        /// </summary>
        public IList<TData> Data { get; set; }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public PagingData()
            : this(0)
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_totalCount">总数据量</param>
        /// <param name="_data">数据</param>
        public PagingData(int _totalCount, List<TData> _data = null)
        {
            TotalCount = _totalCount;
            Data = _data;
        }
    }
}
