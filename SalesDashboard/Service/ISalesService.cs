using SalesDashboard.Domain;

namespace SalesDashboard.Service
{
    public interface ISalesService
    {
        List<Sale> GetSales();
    }
}
