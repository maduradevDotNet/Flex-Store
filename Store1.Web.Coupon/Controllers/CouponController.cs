using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Store1.Web.Coupon.Models;
using Store1.Web.Coupon.Service.IService;
using System.Collections.Generic;

namespace Store1.Web.Coupon.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService=couponService;
        }
        public async Task<IActionResult> Index()
        {

            List<CouponDTO>? List = new();

            ResponseDto? response= await _couponService.GetAllCouponAsync();
            if (response != null && response.ISSuccess)
            {
                List = JsonConvert.DeserializeObject<List<CouponDTO>>(Convert.ToString(response.Result));
            }
            return View(List);
        }


        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDTO couponDto)
        {
            if (ModelState.IsValid)
            {

                ResponseDto? response = await _couponService.CreateCouponAsync(couponDto);

                if (response != null && response.ISSuccess)
                {
                    TempData["success"] = "Coupon Created SuccessFully";
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    TempData["error"] = response?.Message;
                }

            }
            return View(couponDto);
        }
    }
}
