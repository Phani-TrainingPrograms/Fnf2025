using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SampleWebFormsApp
{
    public class ProductInfo : IComparable<ProductInfo>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductCost { get; set; }
        public int ProductCount { get; set; }
        public string ProductImage { get; set; }

        public int CompareTo(ProductInfo other)
        {
            return this.ProductName.CompareTo(other.ProductName);
        }
    }

    public class ProductDatabase
    {
        //Set the File Property to Compile instead of Content->F4
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
                product.ProductImage = $"{fileInfo.Name}";
                product.ProductId = ++index;
                products.Add(product);
            }
            products.ToList().Sort();
            this.products = products.ToList();
        
        }
        public List<ProductInfo> GetAllProducts(string dirName){
            createProducts(dirName);
            return this.products;
        }
    }
}