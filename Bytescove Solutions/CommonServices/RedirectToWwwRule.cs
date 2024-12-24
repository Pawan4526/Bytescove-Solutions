using Microsoft.AspNetCore.Rewrite;
using System.Text;

namespace Bytescove_Solutions.CommonServices
{
    public class RedirectToWwwRule : IRule
    {
        public void ApplyRule(RewriteContext context)
        {
            var req = context.HttpContext.Request;
            var currentHost = req.Host;
            if (!currentHost.Host.StartsWith("www."))
            {
                var newHost = new HostString($"www.{req.Host.Value}");
                var newUrl = new StringBuilder().Append("https://").Append(newHost).Append(req.PathBase).Append(req.Path).Append(req.QueryString);
                context.HttpContext.Response.Redirect(newUrl.ToString(), true);
                context.Result = RuleResult.EndResponse;
            }
        }
    }
}
