using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyPhongMach18.BLL.Service;
using QuanLyPhongMach18.Common.Req;
using QuanLyPhongMach18.Common.Rsp;
using QuanLyPhongMach18.DAL;

namespace QuanLyPhongMach18.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private PatientSvc patientSvc;
        public PatientController()
        {
            patientSvc = new PatientSvc();
        }
        [HttpGet("get-all")]
        public IActionResult getAllPatient()
        {
            var res = new SingleRsp();
            res.Data = patientSvc.All;
            return Ok(res);
        }
        [HttpPost("get-by-id")]
        public IActionResult GetPatientByID([FromBody] PatientReq patientReq)
        {
            var res = new SingleRsp();
            res = patientSvc.Read(patientReq.PatientId);
            return Ok(res);
        }

        [HttpPost("create-patient")]

        public IActionResult CreatePatient([FromBody] PatientReq patientReq)
        {
            var res = new SingleRsp();
            res = patientSvc.CreatePatient(patientReq);
            return Ok(res);
        }

        [HttpPost("update-patient")]

        public IActionResult UpdatePatient([FromBody] PatientReq patientReq)
        {
            
            var res = patientSvc.UpdatePatient(patientReq);
            return Ok(res);
        }

        [HttpDelete("delete-patient")]

        public IActionResult DeletePatient([FromBody] PatientReq patientReq)
        {
           
            var res = patientSvc.DeletePatient(patientReq);
            return Ok(res);
        }
    }
}
