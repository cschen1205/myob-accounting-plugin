using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoWebApp.Library.code
{
    public static class DataSource_Products
    {

        public static List<Product> getDataSource()
        {

            List<Product> lResult = new List<Product>();
            for (int i = 0; i < 50; i++)
            {
                Product lProduct = new Product();
                lProduct.ID = i.ToString();
                lProduct.Name = "Product " + i.ToString();
                lProduct.UnitPrice = (i * 0.256 + i);
                lProduct.Category = "Category " + (i % 2).ToString();
                lProduct.Manufacturer = "Fabrikam Intl";
                lProduct.Stock = (i * 20);
                lResult.Add(lProduct);
            }

            return lResult;
        }

    }
}
