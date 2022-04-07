using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospotalIS.Persistence.Repositories
{
    public class Paginator
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
  
        public Paginator()
        {
            this.PageNumber =1;
            this.PageSize = 10;
        }
        public Paginator(int pageNumber, int pageSize, int count)
        {
            int max = PageNumber * PageSize;
            PageNumber = pageNumber;
            PageSize = pageSize;
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageNumber = max > count ? count/ pageSize+1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
 

    }
