using Aribilgi.BankApp.Web.Data.Contexts;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;

namespace Aribilgi.BankApp.Web.TagHelpers
{
    [HtmlTargetElement("getAccountCount")]
    public class GetBankAccountCount:TagHelper
    {
        public int ApplicationUserId { get; set; }
        private readonly BankContext _context;
        public GetBankAccountCount(BankContext context)
        {
            _context = context;
        }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var html = _context.Accounts.Count(x=>x.ApplicationUserId==ApplicationUserId).ToString();
            output.Content.SetHtmlContent(html);
        }
    }
}
