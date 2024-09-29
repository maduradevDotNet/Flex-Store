using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store1.Services.CouponAPI.Data;
using Store1.Services.CouponAPI.Models.DTO;
using Store1.Services.CouponAPI.Models;

namespace Store1.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly AppDbContext _Db;
        private readonly ResponseDto _response;

        public CouponController(AppDbContext Db)
        {
            _Db = Db;
            _response = new ResponseDto();
        }


        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _Db.coupons.ToList();
                _response.Result = objList;

            }
            catch (Exception ex)
            {
                _response.ISSuccess = false;
                _response.Message = ex.Message;

            }
            return _response;
        }


        [HttpGet("{id}")]
        //[Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                var obj = _Db.coupons.FirstOrDefault(u => u.CouponId == id);
                _response.Result = obj;

            }
            catch (Exception ex)
            {
                _response.ISSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
