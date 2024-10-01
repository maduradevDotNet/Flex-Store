using System.Security.AccessControl;
using static Store1.Web.Coupon.Utility.SD;

namespace Store1.Web.Coupon.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
