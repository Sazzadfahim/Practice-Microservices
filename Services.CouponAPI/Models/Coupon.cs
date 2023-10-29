using System.ComponentModel.DataAnnotations;

namespace Services.CouponAPI.Models
{
    public class Coupon
    {

        public int CouponId { get; set; }
        [Required]
        public string CouponCode { get; set; }
        [Required]

        public double DiscountAmount { get; set; }

        public int MinAmount { get; set; }

        //public bool IsActive { get; set; }

        //public Coupon() { }

        /* public Coupon(string couponCode, double discountAmount, int minAmount, bool isActive)
         {
             CouponCode = couponCode;
             DiscountAmount = discountAmount;
             MinAmount = minAmount;
             IsActive = isActive;
         }*/


    }
}
