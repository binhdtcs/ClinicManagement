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
    public class AppointmentController : ControllerBase
    {
        private AppointmentSvc appointmentSvc;
        public AppointmentController()
        {
            appointmentSvc = new AppointmentSvc();
        }
        [HttpGet("get-all")]
        public IActionResult getAllAppointment()
        {
            var res = new SingleRsp();
            res.Data = appointmentSvc.All;
            return Ok(res);
        }
        [HttpPost("get-by-id")]
        public IActionResult GetAppointmentByID([FromBody] AppointmentReq appointmentReq)
        {
            var res = new SingleRsp();
            res = appointmentSvc.Read(appointmentReq.AppointmentId);
            return Ok(res);
        }

        [HttpPost("create-appointment")]

        public IActionResult CreateAppointment([FromBody] AppointmentReq appointmentReq)
        {
            var res = new SingleRsp();
            res = appointmentSvc.CreateAppointment(appointmentReq);
            return Ok(res);
        }
        [HttpPost("search-appointment")]

        public IActionResult SearchAppointment([FromBody] SearchAppointmentReq searchAppointmentReq)
        {
            var res = new SingleRsp();
            res = appointmentSvc.SearchAppointment(searchAppointmentReq);
            return Ok(res);
        }

        [HttpPost("update-appointment")]
        public IActionResult UpdateAppointment([FromBody] AppointmentReq appointmentReq)
        {
            var res = appointmentSvc.UpdateAppointment(appointmentReq);
            return Ok(res);
        }


        [HttpDelete("delete-appointment")]
        public IActionResult DeleteAppointment([FromBody] AppointmentReq appointmentReq)
        {
            var res = appointmentSvc.DeleteAppointment(appointmentReq);
            return Ok(res);
        }
    }
}
