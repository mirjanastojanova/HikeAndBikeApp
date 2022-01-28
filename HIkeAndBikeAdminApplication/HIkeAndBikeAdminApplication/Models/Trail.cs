using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIkeAndBikeAdminApplication.Models
{
    public class Trail
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Double Price { get; set; }
        public DateTime Date { get; set; }
        public string Guide { get; set; }
    }
}
