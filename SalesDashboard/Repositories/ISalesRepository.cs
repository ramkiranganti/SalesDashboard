using SalesDashboard.Domain;

namespace SalesDashboard.Repositories
{
    public interface ISalesRepository
    {
        List<Sale> GetAll(string filePath);
    }
}
