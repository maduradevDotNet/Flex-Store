using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store1.Services.CouponAPI.Data;
using Store1.Services.CouponAPI.Models.DTO;
using Store1.Services.CouponAPI.Models;
using AutoMapper;

namespace Store1.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly AppDbContext _Db;
        private readonly ResponseDto _response;
        private readonly IMapper _Map;

        public CouponController(AppDbContext Db, IMapper mapper)
        {
            _Db = Db;
            _response = new ResponseDto();
            _Map = mapper;
        }


        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _Db.coupons.ToList();

                _response.Result = _Map.Map<IEnumerable<CouponDTO>>(objList);

            }
            catch (Exception ex)
            {
                _response.ISSuccess = false;
                _response.Message = ex.Message;

            }
            return _response;
        }


        [HttpGet]
        [Route("GetById/{id:int}")]
        public ResponseDto GetById(int id)
        {
            try
            {
                var obj = _Db.coupons.FirstOrDefault(u => u.CouponId == id);
                _response.Result = _Map.Map<CouponDTO>(obj);

            }
            catch (Exception ex)
            {
                _response.ISSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetCouponByCodeAsync(string code)
        {
            try
            {
                var obj = _Db.coupons.FirstOrDefault(u => u.CouponCode == code);
                _response.Result = _Map.Map<CouponDTO>(obj);

            }
            catch (Exception ex)
            {
                _response.ISSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public ResponseDto POST([FromBody] CouponDTO couponDto)
        {
            try
            {

                _Db.coupons.Add(_Map.Map<Coupon>(couponDto));
                var obj = _Map.Map<Coupon>(couponDto);
                _Db.SaveChanges();
                _response.Result = _Map.Map<CouponDTO>(obj);

            }
            catch (Exception ex)
            {
                _response.ISSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;

        }

        [HttpPut]
        public ResponseDto PUT([FromBody] CouponDTO couponDto)
        {
            try
            {

                _Db.coupons.Update(_Map.Map<Coupon>(couponDto));
                var obj = _Map.Map<Coupon>(couponDto);
                _Db.SaveChanges();

                _response.Result = _Map.Map<CouponDTO>(obj);
            }
            catch (Exception ex)
            {
                _response.ISSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }



        [HttpDelete]
        [Route("Delete/{id:int}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                var coupon=_Db.coupons.FirstOrDefault(u=>u.CouponId==id);
                _Db.coupons.Remove(coupon);
                _Db.SaveChanges();
                _response.Result = _Map.Map<CouponDTO>(coupon);
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
