using Microsoft.AspNetCore.Mvc;
using SalesDashboard.Models;
using SalesDashboard.Service;
using System.Diagnostics;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace SalesDashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;       
        private readonly ISalesService _salesService;

        public HomeController(ILogger<HomeController> logger, ISalesService salesService)
        {
            _logger = logger;            
            _salesService = salesService;
        }

        public IActionResult Index()
        {
            SalesViewModel salesViewModel = new SalesViewModel();
            salesViewModel.Sales = _salesService.GetSales();
            return View(salesViewModel);
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