using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using OFT.BankApp.Web.Data.Context;

namespace OFT.BankApp.Web.TagHelpers
{
    [HtmlTargetElement("getAccountAcount")]
    public class GetAccountCount : TagHelper
    {
        public int ApplicationUserId { get; set; }
        private readonly BankContext _context;

        public GetAccountCount(BankContext context)
        {
            _context = context;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var accountCount = _context.Accounts.Count(x => x.ApplicationUserId == ApplicationUserId);
            var html = $"<span class='badge bg-danger'>{accountCount}</span>";
            output.Content.SetHtmlContent(html);
            await Task.CompletedTask;
        }
    }
}

