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
            Response response = new Response();
            try
            {
                using (AdminproContext db = new AdminproContext())
                {
                    response.Success = 1;
                    response.Data = db.User.ToList();
                }
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }
            return Ok(response.Data);
        }

        [HttpPost]
        public IActionResult Add(UserRequest userRequest) {
            Response response = new Response();
            try
            {
                using (AdminproContext db = new AdminproContext())
                {
                    User newUser = new User();

                    newUser.Id = userRequest.Id;
                    newUser.UserName = userRequest.UserName;
                    newUser.Name = userRequest.Name;
                    newUser.Age = userRequest.Age;
                    db.User.Add(newUser);
                    db.SaveChanges();
                    response.Success = 1;
                }
            }
            catch (Exception ex)
            {

                response.Msg = ex.Message;
            }
            return Ok( response.Data);
        }
    }
}