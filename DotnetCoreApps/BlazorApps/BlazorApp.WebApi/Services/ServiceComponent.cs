using BlazorApp.Shared;

namespace BlazorApp.WebApi.Services
{
    public interface IServiceComponent
    {
        List<Product> GetProducts();
        Product GetProduct(int id);

        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
    public class ServiceComponent : IServiceComponent
    {
        private readonly Data.ApplicationDbContext _context;
        public ServiceComponent(Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
        public Product GetProduct(int id)
        {
            return _context.Products.Find(id);
        }
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void UpdateProduct(Product product)
        {
            var existingProduct = _context.Products.Find(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Quantity = product.Quantity;
                _context.SaveChanges();
            }
        }
        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
