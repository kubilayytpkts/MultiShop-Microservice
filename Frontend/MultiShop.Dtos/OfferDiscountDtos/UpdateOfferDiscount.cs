using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Dtos.OfferDiscountDtos
{
	public class UpdateOfferDiscount
	{
		public string OfferDiscountId { get; set; }
		public string OfferDiscountTitle { get; set; }
		public string OfferDiscountSubTitle { get; set; }
		public string OfferDiscountImage { get; set; }
	}
}
