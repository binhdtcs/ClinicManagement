using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyPhongMach18.BLL.Service;
using QuanLyPhongMach18.Common.Req;
using QuanLyPhongMach18.Common.Rsp;

namespace QuanLyPhongMach18.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private DoctorSvc doctorSvc;
        public DoctorController()
        {
            doctorSvc = new DoctorSvc();
        }
        [HttpGet("get-all")]
        public IActionResult getAllDoctor()
        {
            var res = new SingleRsp();
            res.Data = doctorSvc.All;
            return Ok(res);
        }
        [HttpPost("get-by-id")]
        public IActionResult GetDoctorByID([FromBody] DoctorReq doctorReq)
        {
            var res = new SingleRsp();
            res = doctorSvc.Read(doctorReq.DoctorId);
            return Ok(res);
        }
        [HttpPost("create-doctor")]

        public IActionResult CreateDoctor([FromBody] DoctorReq doctorReq)
        {
            var res = new SingleRsp();
            res = doctorSvc.CreateDoctor(doctorReq);
            return Ok(res);
        }

        [HttpPost("search-doctor")]

        public IActionResult SearchDoctor([FromBody] SearchDoctorReq searchDoctorReq)
        {
            var res = new SingleRsp();
            res = doctorSvc.SearchDoctor(searchDoctorReq);
            return Ok(res);
        }

        [HttpPost("update-doctor")]
        public IActionResult UpdateDoctor([FromBody] DoctorReq doctorReq)
        {
            var res = doctorSvc.UpdateDoctor(doctorReq);
            return Ok(res);
        }


        [HttpDelete("delete-doctor")]
        public IActionResult DeleteDoctor([FromBody] DoctorReq doctorReq)
        {
            var res = doctorSvc.DeleteDoctor(doctorReq);
            return Ok(res);
        }

    }
}
