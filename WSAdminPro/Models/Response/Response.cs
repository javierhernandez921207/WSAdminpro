using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSAdminPro.Models.Response
{
    public class Response
    {
        public int Success { get; set; }

        public string Msg { get; set; }

        public Object Data { get; set; }

        public Response()
        {
            this.Success = 0;
        }
    }
}
