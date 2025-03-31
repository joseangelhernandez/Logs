using log4net;
using Logs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Logs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILog _logger;

        public HomeController(ILog logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IActionResult Index()
        {
            _logger.Info("Index page visited");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
