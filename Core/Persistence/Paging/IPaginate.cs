using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Paging
{
    public interface IPaginate<T>
        where T : IEntity, new()
    {
        public IQueryable<T> Items { get; }
        public PaginationInfo Pagination { get; }

        //List<global::Domain.Entities.Task> ToList();
    }
}
 