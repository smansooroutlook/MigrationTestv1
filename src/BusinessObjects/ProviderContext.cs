using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public struct ProviderContext : IProviderContext
    {
        public string ProviderName { get; set; }
        public string ProviderConnectionString { get; set; }
        public string IDbContext { get; set; }
    }
}
