using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyPhongMach18.BLL.Service;
using QuanLyPhongMach18.Common.Req;
using QuanLyPhongMach18.Common.Rsp;

namespace QuanLyPhongMach18.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private PrescriptionSvc prescriptionSvc;
        public PrescriptionController()
        {
          prescriptionSvc = new PrescriptionSvc();
        }
        [HttpGet("get-all")]
        public IActionResult getAllPrescription()
        {
            var res = new SingleRsp();
            res.Data = prescriptionSvc.All;
            return Ok(res);
        }
        [HttpPost("get-by-id")]
        public IActionResult GetPrescriptionByID([FromBody] PrescriptionReq prescriptionReq)
        {
            var res = new SingleRsp();
            res = prescriptionSvc.Read(prescriptionReq.PrescriptionId);
            return Ok(res);
        }
        [HttpPost("create-prescription")]

        public IActionResult CreatePrescription([FromBody] PrescriptionReq prescriptionReq)
        {
            var res = new SingleRsp();
            res = prescriptionSvc.CreatePrescription(prescriptionReq);
            return Ok(res);
        }

        [HttpPost("update-pescription")]
        public IActionResult UpdateMedicine([FromBody] PrescriptionReq prescriptionReq)
        {
            var res = prescriptionSvc.UpdatePrescription(prescriptionReq);
            return Ok(res);
        }


        [HttpDelete("delete-prescription")]
        public IActionResult DeleteMedicine([FromBody] PrescriptionReq prescriptionReq)
        {
            var res = prescriptionSvc.DeletePrescription(prescriptionReq);
            return Ok(res);
        }
    }
}
