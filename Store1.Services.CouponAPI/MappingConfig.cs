using AutoMapper;
using Store1.Services.CouponAPI.Models;
using Store1.Services.CouponAPI.Models.DTO;

namespace Store1.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDTO, Coupon>();
                config.CreateMap<Coupon, CouponDTO>();
            });

            return mappingConfig;
        }
    }
}
