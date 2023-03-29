using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace OFT.BankApp.Web.Models
{
    public class SendMoneyModel
    {
        public int SenderId { get; set; }
        public int AccountId { get; set; }
        public int Amount { get; set; }
    }
}
