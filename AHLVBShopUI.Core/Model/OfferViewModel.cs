using AHLVBShopUI.Core.DTO.Offer;
using AHLVBShopUI.Core.DTO.Request;
using AHLVBShopUI.Core.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShopUI.Core.Model
{
    public class OfferViewModel
    {
        public List<OfferDTO> Offers { get; set; }
        public List<UserDTO> Users { get; set; }
        public List<RequestDTO> Requests { get; set; }
    }
}
