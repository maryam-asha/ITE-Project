using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTables.Entity.pagining
{
    public class PagingInfo
    {
        public int Totalrwcord { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }

        public int Recordperpage { get; private set; }
        public string Urlparam { get; private set; }
        public int TotalPages => (int)Math.Ceiling((decimal)Totalrwcord / Recordperpage);
    }
}
