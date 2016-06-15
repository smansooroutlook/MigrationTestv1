using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class ConfigCS : IConfigCS
    {
        public string DBServer { get; set; }
        public string Provider { get; set; }

    }

    public interface IConfigCS
    {
        string DBServer { get; set; }
        string Provider { get; set; }

    }
}

