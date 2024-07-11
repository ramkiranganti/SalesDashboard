using SalesDashboard.Domain;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata.Ecma335;

namespace SalesDashboard.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        public List<Sale> GetAll(string filePath)
        {
            List<Sale> sales = new List<Sale>();
            bool isHeaderRow = true;
            int count = 1;
            //Read the contents of CSV file.
            string salesData = File.ReadAllText(filePath);
           
            foreach (string row in salesData.Split('\n'))
            {
                if (isHeaderRow) {
                    isHeaderRow = false;
                    continue; 
                }
                count++;
                if (!string.IsNullOrEmpty(row) && !isHeaderRow)
                {
                    sales.Add(new Sale
                    {
                        Segment = row.Split(',')[0],
                        Country = row.Split(',')[1],
                        Product = row.Split(',')[2],
                        Discount = row.Split(',')[3],
                        UnitsSold = (string.IsNullOrEmpty(row.Split(',')[4].Trim())) ? 0 : decimal.Parse(row.Split(',')[4].Trim().Substring(1).Replace(" ", string.Empty)),
                        ManufacturingPrice = (string.IsNullOrEmpty(row.Split(',')[5].Trim())) ? 0 : decimal.Parse(row.Split(',')[5].Trim().Substring(1).Replace(" ", string.Empty)),
                        SalePrice = (string.IsNullOrEmpty(row.Split(',')[6].Trim())) ? 0 : decimal.Parse(row.Split(',')[6].Trim().Substring(1).Replace(" ", string.Empty)),
                        SaleDate = (string.IsNullOrEmpty(row.Split(',')[7].Trim())) ? null : DateTime.ParseExact(row.Split(',')[7].Trim(),"MM/dd/yyyy", null)
                    });
                }
            }
            return sales;
        }

    }
}
