using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyPhongMach18.BLL.Service;
using QuanLyPhongMach18.Common.Req;
using QuanLyPhongMach18.Common.Rsp;

namespace QuanLyPhongMach18.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       
        private UserSvc userSvc;
        public UserController()
        {
            userSvc = new UserSvc();
        }
        [HttpGet("get-all")]
        public IActionResult getAllUser()
        {
            var res = new SingleRsp();
            res.Data = userSvc.All;
            return Ok(res);
        }
        [HttpPost("get-by-id")]
        public IActionResult GetUserByID([FromBody] UserReq userReq)
        {
            var res = new SingleRsp();
            res = userSvc.Read(userReq.UserId);
            return Ok(res);
        }
        [HttpPost("create-user")]

        public IActionResult CreateUser([FromBody] UserReq userReq)
        {
            var res = new SingleRsp();
            res = userSvc.CreateUser(userReq);
            return Ok(res);
        }

        [HttpPost("search-user")]

        public IActionResult SearchUser([FromBody] SearchUserReq searchUserReq)
        {
            var res = new SingleRsp();
            res = userSvc.SearchUser(searchUserReq);
            return Ok(res);
        }

        [HttpPost("update-user")]
        public IActionResult UpdateUser([FromBody] UserReq userReq)
        {
            var res = userSvc.UpdateUser(userReq);
            return Ok(res);
        }


        [HttpDelete("delete-user")]
        public IActionResult DeleteUser([FromBody] UserReq userReq)
        {
            var res = userSvc.DeleteUser(userReq);
            return Ok(res);
        }


    }
}
