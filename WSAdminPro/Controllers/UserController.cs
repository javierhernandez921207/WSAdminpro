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
    public class UserController : ControllerBase
    {
        private AdminproContext adminproContext;

        public UserController()
        {
            this.adminproContext = new AdminproContext();
        }

        [HttpGet]
        public IActionResult get()
        {
            Response response = new Response();
            try
            {
                response.Success = 1;
                response.Data = adminproContext.User.ToList();
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Add(UserRequest userRequest)
        {
            Response response = new Response();
            try
            {
                User newUser = new User();
                newUser.UserName = userRequest.UserName;
                newUser.Name = userRequest.Name;
                newUser.LastName = userRequest.LastName;
                newUser.Age = userRequest.Age;
                adminproContext.User.Add(newUser);
                adminproContext.SaveChanges();
                response.Success = 1;
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Edit(UserRequest userRequest)
        {
            Response response = new Response();
            try
            {
                User editUser = adminproContext.User.Find(userRequest.Id);
                editUser.UserName = userRequest.UserName;
                editUser.Name = userRequest.Name;
                editUser.LastName = userRequest.LastName;
                editUser.Age = userRequest.Age;
                //indicar que el objeto fue modificado.
                adminproContext.Entry(editUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                adminproContext.SaveChanges();
                response.Success = 1;
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Response response = new Response();
            try {
                User deleteUser = adminproContext.User.Find(id);
                adminproContext.Remove(deleteUser);
                adminproContext.SaveChanges();
                response.Success = 1;
            } catch (Exception ex)
            {
                response.Msg = ex.Message;
            }           
            return Ok(response);
        }
    }
}