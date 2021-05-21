using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSAdminPro.Models.Request
{
    public class UserRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
