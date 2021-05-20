using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSAdminPro.Models.Request
{
    public class UsuarioRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string User { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
    }
}
