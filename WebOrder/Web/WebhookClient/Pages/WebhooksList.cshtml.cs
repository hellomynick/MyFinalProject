using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebhookClient.Models;
using WebhookClient.Services;

namespace WebhookClient.Pages
{
    public class WebhooksListModel : PageModel
    {
        private readonly IWebhooksClient _webhooksClient;

        public IEnumerable<WebhookResponse> Webhooks { get; private set; }

        public WebhooksListModel(IWebhooksClient webhooksClient)
        {
            _webhooksClient = webhooksClient;
        }

        public async Task OnGet()
        {
            Webhooks = await _webhooksClient.LoadWebhooks();
        }
    }
}