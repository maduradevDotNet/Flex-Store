
using Store1.Web.Coupon.Models;

namespace Store1.Web.Coupon.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDto?> GetCouponAsync(string CouponCode);
        Task<ResponseDto?> GetAllCouponAsync();
        Task<ResponseDto?> GetCouponByCodeAsync(string code);
        Task<ResponseDto?> GetCouponByIdAsync(int id);
        Task<ResponseDto?> CreateCouponAsync(CouponDTO couponDto);
        Task<ResponseDto?> UpdateCouponAsync(CouponDTO couponDto);
        Task<ResponseDto?> DeleteCouponAsync(int id);
    }
}
