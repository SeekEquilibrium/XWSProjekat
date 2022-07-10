using Common;

namespace Offers.Service.Model
{
    public class Offer
    {
        public Guid Id {get; set; }
        public String Job { get; set; }
        public String CompanyName { get; set; }
        public String Description { get; set; }
        public String Requirements { get; set; }
    }
}