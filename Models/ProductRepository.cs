namespace LittleFormApp.Models
{
    public static class ProductRepository
    {
        private static List<Product> _products;
        static ProductRepository()
        {
            _products = new List<Product>() {
            new Product()
            {
                Id = 1,
                Name="Ürün1",
                Description="Description 1",
                Price=123,
                isApproved=true,
            },new Product()
            {
                Id = 2,
                Name="Ürün2",
                Description="Description 2",
                Price=12,
                isApproved=false,
            },new Product()
            {
                Id = 3,
                Name="Ürün3",
                Description="Description 3",
                Price=23,
                isApproved=true,
            },new Product()
            {
                Id = 4,
                Name="Ürün4",
                Description="Description 4",
                Price=13,
                isApproved=true,
            },new Product()
            {
                Id = 5,
                Name="Ürün5",
                Description="Description 5",
                Price=1234,
                isApproved=false,
            },
            };
        }
    public static List<Product> Products 
        { 
            get { return _products; }
        }
        public static void AddProduct(Product product)
        {
            _products.Add(product);
        }
        public static void UpdateProduct(Product entity)
        {
            var product = _products.Where(x=>x.Id == entity.Id).Single();

            product.Name = entity.Name;
            product.Price = entity.Price;
        }
    }
}
