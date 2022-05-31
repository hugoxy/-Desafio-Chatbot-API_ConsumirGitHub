using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Mid_Github.DTO
{
    public class Repositorio
    {
        public string name { get; set; }
        public string language { get; set; }
        public string description { get; set; }
        public DateTime created_at { get; set; }
        public string url { get; set; }

    }
}
