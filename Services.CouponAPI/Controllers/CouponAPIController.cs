using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.CouponAPI.Data;
using Services.CouponAPI.Entity.Models;
using Services.CouponAPI.Entity.Dto;
using AutoMapper;

namespace Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly ResponseDto _response;
        private readonly IMapper _mapper;

        public CouponAPIController(DBContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
            _response = new ResponseDto();

        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                List<Coupon> couponsList = _context.Coupons.ToList();
                _response.Result = _mapper.Map<List<CouponDto>>(couponsList);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = e.Message;
                
            }
            return _response;
        }

        //Get Coupon by ID
        [HttpGet]
        [Route("{id:int}")]

        public ResponseDto GetById(int id)
        {
            try
            {
                Coupon coupon = _context.Coupons.First(u => u.CouponId == id);
                
                _response.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = e.Message;
            }
            return _response;
        }


        //Get Coupon by Name
        [HttpGet]
        [Route("GetByCode/{name}")]
        public ResponseDto GetByName(string name)
        {
            try
            {
                Coupon coupon = _context.Coupons.First(u => u.CouponCode.ToLower() == name.ToLower());
                //if(coupon == null)
                //{
                //    _response.IsSuccess = false;
                //    _response.DisplayMessage = "Coupon Not Available";
                //    return _response;
                //}
                _response.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception e) 
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = e.Message;

            }
            return _response;
        }

        //Create Coupon

        [HttpPost]
        public ResponseDto Post([FromBody] CouponDto couponDto)
        {
            try
            {
                
                Coupon coupon = _mapper.Map<Coupon>(couponDto);
                _context.Coupons.Add(coupon);
                _context.SaveChanges();
                _response.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = e.Message;

            }
            return _response;
        }

    }
}
