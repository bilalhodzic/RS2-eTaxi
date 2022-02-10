using Microsoft.EntityFrameworkCore;
using Model.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Paging
{
    public  partial class Paging<T, Tsearch, TDb, TInsert, TUpdate>
    {
        public virtual PagingModel<T> GetAll(PagingParameters Parameters, Tsearch search=null)
        {
            IQueryable<TDb> List=getList();
            if(List==null)
              List = _context.Set<TDb>().AsQueryable();
 
            var Tmodel = PagedList<TDb>.ToPagedList(List,
            Parameters.PageNumber,
            Parameters.PageSize);

            var obj = _mapper.Map<PagingModel<T>>(Tmodel);
            obj.list = _mapper.Map<IEnumerable<T>>(Tmodel);
            return obj;
        }
    }
}
