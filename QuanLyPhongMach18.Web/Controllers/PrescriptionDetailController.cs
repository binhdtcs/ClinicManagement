using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyPhongMach18.Common.Req;
using QuanLyPhongMach18.Common.Rsp;
using QuanLyPhongMach18.DAL.Models;
using QuanLyPhongMach18.DAL;
using QuanLyPhongMach18.BLL.Service;

namespace QuanLyPhongMach18.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionDetailController : ControllerBase
    {
        private PrescriptionDetailSvc prescriptionDetailSvc;
        public PrescriptionDetailController()
        {
            prescriptionDetailSvc = new PrescriptionDetailSvc();
        }
        [HttpGet("get-all")]
        public IActionResult getAllPrescriptionDetail()
        {
            var res = new SingleRsp();
            res.Data = prescriptionDetailSvc.All;
            return Ok(res);
        }
        [HttpPost("get-by-id")]
        public IActionResult GetPrescriptionDetailByID([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = prescriptionDetailSvc.Read(simpleReq.Id);
            return Ok(res);
        }

        [HttpPost("create-prescriptionDetail")]

        public IActionResult CreatePrescriptionDetail([FromBody] PrescriptionDetailReq prescriptionDetailReq)
        {
            var res = new SingleRsp();
            res = prescriptionDetailSvc.CreatePrescriptionDetail(prescriptionDetailReq);
            return Ok(res);
        }

        [HttpPost("update-prescriptionDetail")]
        public IActionResult UpdatePrescriptionDetail([FromBody] PrescriptionDetailReq prescriptionDetailReq)
        {
            var res = prescriptionDetailSvc.UpdatePrescriptionDetail(prescriptionDetailReq);
            return Ok(res);
        }


        [HttpDelete("delete-prescriptionDetail")]
        public IActionResult DeletePrescriptionDetail([FromBody] PrescriptionDetailReq prescriptionDetailReq)
        {
            var res = prescriptionDetailSvc.DeletePrescriptionDetail(prescriptionDetailReq);
            return Ok(res);
        }
    }
}
