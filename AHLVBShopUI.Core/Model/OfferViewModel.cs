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
		public Guid Id { get; set; }
		public string OfferDescription { get; set; }
		public string Price { get; set; }
		public string Status { get; set; }
		public Guid UserId { get; set; }
		public string UserName { get; set; }

		public string RequestName { get; set; }
		public Guid RequestId { get; set; }
	}
}
