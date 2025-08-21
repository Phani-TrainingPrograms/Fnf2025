using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SampleWebFormsApp.App_Code
{
    public class ProductInfo
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductCost { get; set; }
        public int ProductCount { get; set; }
        public string ProductImage { get; set; }
    }

    public class ProductDatabase
    {
        private List<ProductInfo> products = new List<ProductInfo>();

        private void createProducts(string dirName)
        {
             
            HashSet<ProductInfo> products = new HashSet<ProductInfo>();
            var files = Directory.GetFiles(dirName);
            Random random = new Random();
            int index = 0;
            foreach(var file in files)
            {
                var fileInfo = new FileInfo(file);
                var fileName = fileInfo.Name.Split('.')[0];
                var product = new ProductInfo();
                product.ProductName = fileName;
                product.ProductCost = random.Next(50, 100);
                product.ProductImage = $"\\Images\\{fileInfo.Name}";
                product.ProductId = ++index;
                products.Add(product);
            }
            products.ToList().Sort();
            return products;
        }
        }
        public List<ProductInfo> GetAllProducts(){ 
            return products;
        }
    }
}