using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ElectronNETWebAppFrontend.Pages
{
    public class Help : PageModel
    {
        private readonly ILogger<Help> _logger;

        public Help(ILogger<Help> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}