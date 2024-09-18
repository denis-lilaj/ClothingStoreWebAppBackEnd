using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.Business
{
    public class BusinessInfo
    {
        private BusinessInfo() { 
        
        }
        public string BusinessName { get; private set; }
        public double Longitude { get; private set; }
        public double Latitude { get; private set; }
        public string Address { get; private set; }
    }
}
