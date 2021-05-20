using System;
using System.Collections.Generic;

namespace WSAdminPro.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
    }
}
