using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Dtos.SpecialOfferDtos
{
    public class GetByIdSepacialOfferDto
    {
        public string SpecialOfferId { get; set; }
        public string SpecialOfferTitle { get; set; }
        public string SpecialOfferSubTitle { get; set; }
        public string SpecialOfferImage { get; set; }
    }
}
