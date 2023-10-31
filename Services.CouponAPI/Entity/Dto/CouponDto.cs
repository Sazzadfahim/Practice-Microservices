using System.ComponentModel.DataAnnotations;

namespace Services.CouponAPI.Entity.Dto
{
    public class CouponDto
    {
        //coupon dto
        
        public int CouponId { get; set; }

       
        public string CouponCode { get; set; }

       
        public double DiscountAmount { get; set; }

        public int MinAmount { get; set; }




    }
}
