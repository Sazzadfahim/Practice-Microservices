using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.CouponAPI.Data;
using Services.CouponAPI.Models;
using Services.CouponAPI.Models.Dto;

namespace Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly ResponseDto _response;

        public CouponAPIController(DBContext context) 
        {
            _context = context;
            _response = new ResponseDto();

        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> couponsList = _context.Coupons.ToList();
                _response.Result = couponsList;
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
                _response.Result = coupon;
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
        [Route("{name}")]
        public ResponseDto GetByName(string name)
        {
            try
            {
                Coupon coupon = _context.Coupons.First(u => u.CouponCode == name);
                _response.Result = coupon;
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
