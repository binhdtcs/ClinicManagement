using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyPhongMach18.BLL.Service;
using QuanLyPhongMach18.Common.Req;
using QuanLyPhongMach18.Common.Rsp;

namespace QuanLyPhongMach18.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private MedicalRecordSvc medicalRecordSvc;
        public MedicalRecordController()
        {
            medicalRecordSvc = new MedicalRecordSvc();
        }
        [HttpGet("get-all")]
        public IActionResult getAllMedicalRecord()
        {
            var res = new SingleRsp();
            res.Data = medicalRecordSvc.All;
            return Ok(res);
        }
        [HttpPost("get-by-id")]
        public IActionResult GetMedicalRecordByID([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = medicalRecordSvc.Read(simpleReq.Id);
            return Ok(res);
        }

        [HttpPost("create-medicalRecord")]

        public IActionResult CreateMedicalRecord([FromBody] MedicalRecordReq medicalRecordReq)
        {
            var res = new SingleRsp();
            res = medicalRecordSvc.CreateMedicalRecord(medicalRecordReq);
            return Ok(res);
        }

        [HttpPost("update-medicalRecord")]
        public IActionResult UpdateMedicalRecord([FromBody] MedicalRecordReq medicalRecordReq)
        {
            var res = medicalRecordSvc.UpdateMedicalRecord(medicalRecordReq);
            return Ok(res);
        }


        [HttpDelete("delete-medicalRecord")]
        public IActionResult DeleteMedicalRecord([FromBody] MedicalRecordReq medicalRecordReq)
        {
            var res = medicalRecordSvc.DeleteMedicalRecord(medicalRecordReq);
            return Ok(res);
        }
    }
}
