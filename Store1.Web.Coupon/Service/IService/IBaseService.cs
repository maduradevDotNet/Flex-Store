using Store1.Web.Coupon.Models;

namespace Store1.Web.Coupon.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto);
    }
}
