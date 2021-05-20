using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSAdminPro.Models;
using WSAdminPro.Models.Response;
using WSAdminPro.Models.Request;

namespace WSAdminPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public IActionResult get()
        {
            Respuesta respuesta = new Respuesta();            
            try{
                using (adminproContext db = new adminproContext())
                {
                    respuesta.Exito = 1;
                    respuesta.Data = db.Usuario.ToList();
                }
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;   
            }
            return Ok(respuesta.Data);
        }

        [HttpPost]
        public IActionResult Add(UsuarioRequest usuarioRequest) {
            Respuesta respuesta = new Respuesta();
            try {
                using (adminproContext db = new adminproContext())
                {
                    Usuario usuario = new Usuario();

                    usuario.User = usuarioRequest.User;
                    usuario.Nombre = usuarioRequest.Nombre;
                    usuario.Apellidos = usuarioRequest.Apellidos;
                    usuario.Edad = usuarioRequest.Edad;
                    db.Usuario.Add(usuario);
                    db.SaveChanges();
                    respuesta.Exito = 1;
                }
            }
            catch (Exception ex) {
                
                respuesta.Mensaje = ex.Message;
            }
            return Ok( respuesta.Data);
        }
    }
}