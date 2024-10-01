using Store1.Web.Coupon.Models;
using Store1.Web.Coupon.Service.IService;

namespace Store1.Web.Coupon.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;

        public CouponService(IBaseService baseService)
        {
            _baseService=baseService;
        }
        public Task<ResponseDto?> CreateCouponAsync(CouponDTO couponDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> GetAllCouponAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> GetCouponAsync(string CouponCode)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> GetCouponByCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> UpdateCouponAsync(CouponDTO couponDto)
        {
            throw new NotImplementedException();
        }
    }
}
