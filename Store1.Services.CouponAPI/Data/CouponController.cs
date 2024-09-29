using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Store1.Services.CouponAPI.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly AppDbContext _Db;

        public CouponController(AppDbContext Db)
        {
            _Db=Db; 
        }


    }
}
