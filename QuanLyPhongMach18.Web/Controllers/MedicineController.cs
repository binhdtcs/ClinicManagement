using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyPhongMach18.BLL.Service;
using QuanLyPhongMach18.Common.Req;
using QuanLyPhongMach18.Common.Rsp;

namespace QuanLyPhongMach18.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private MedicineSvc medicineSvc;
        public MedicineController()
        {
            medicineSvc = new MedicineSvc();
        }
        [HttpGet("get-all")]
        public IActionResult getAllMedicine()
        {
            var res = new SingleRsp();
            res.Data = medicineSvc.All;
            return Ok(res);
        }
        [HttpPost("create-medicine")]

        public IActionResult CreateMedicine([FromBody] MedicineReq medicineReq)
        {
            var res = new SingleRsp();
            res = medicineSvc.CreateMedicine(medicineReq);
            return Ok(res);
        }
        [HttpPost("search-medicine")]

        public IActionResult SearchMedicine([FromBody] SearchMedicineReq searchMedicineReq)
        {
            var res = new SingleRsp();
            res = medicineSvc.SearchMedicine(searchMedicineReq);
            return Ok(res);
        }
        
        [HttpPost("update-medicine")]
        public IActionResult UpdateMedicine([FromBody] MedicineReq medicineReq)
        {
            var res = medicineSvc.UpdateMedicine(medicineReq);
            return Ok(res);
        }


        [HttpDelete("delete-medicine")]
        public IActionResult DeleteMedicine([FromBody] MedicineReq medicineReq)
        {
            var res = medicineSvc.DeleteMedicine(medicineReq);
            return Ok(res);
        }
    }
}
