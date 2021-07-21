using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIServer.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string UserPassword { get; set; }
        public string Role { get; set; }
        public string SuperUser { get; set; }
    }
}
