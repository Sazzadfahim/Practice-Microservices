using AutoMapper;
using Services.CouponAPI.Entity.Dto;
using Services.CouponAPI.Entity.Models;

namespace Services.CouponAPI.Mapping
{
    public class MappingConfiguration
    {
        public static MapperConfiguration MapConfig() 
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>().ReverseMap();
            });
             
        }
    }
}
