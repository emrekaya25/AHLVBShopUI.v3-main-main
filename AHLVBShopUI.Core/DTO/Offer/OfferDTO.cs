using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShopUI.Core.DTO.Offer
{
    public class OfferDTO
    {
        public Guid Id { get; set; }
        public string OfferDescription { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
    }
}
