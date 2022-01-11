using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Entities
{
    public class Customer
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public int Id { get; internal set; }
    }
}
