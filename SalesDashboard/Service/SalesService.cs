using Microsoft.Extensions.Hosting;
using SalesDashboard.Controllers;
using SalesDashboard.Domain;
using SalesDashboard.Repositories;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace SalesDashboard.Service
{
    public class SalesService: ISalesService
    {
        private const string CSV_FILE_PATH = "\\DataFiles\\Data.csv";
        private readonly ILogger<HomeController> _logger;
        private readonly IHostingEnvironment _hostEnvironment;
        private readonly ISalesRepository _salesRepository;

        public SalesService(ILogger<HomeController> logger, IHostingEnvironment hostEnvironment, ISalesRepository salesRepository)
        {
            _logger = logger;
            _hostEnvironment = hostEnvironment;
            _salesRepository = salesRepository;
        }

        public List<Sale> GetSales()
        {
            string filePath = _hostEnvironment.ContentRootPath + CSV_FILE_PATH;
            return _salesRepository.GetAll(filePath);
        }

    }
}
