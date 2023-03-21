using GeekShopping.Web.Models;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services.IServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/product";

        public ProductService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<ProductModel>> FindAllProducts()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContextAs<List<ProductModel>>();
        }

        public async Task<ProductModel> FindProductById(long Id)
        {
            var response = await _client.GetAsync($"{BasePath}/{Id}");
            return await response.ReadContextAs<ProductModel>();
        }

        public async Task<ProductModel> CreateProduct(ProductModel product)
        {
            var response = await _client.PostAsJsonAsync(BasePath, product);
            if (response.IsSuccessStatusCode)
                return await response.ReadContextAs<ProductModel>();
            else
                throw new Exception("Somenthing went wrong when calling API");
        }

        public async Task<ProductModel> UpdateProduct(ProductModel product)
        {
            var response = await _client.PutAsJsonAsync(BasePath, product);
            if (response.IsSuccessStatusCode)
                return await response.ReadContextAs<ProductModel>();
            else
                throw new Exception("Somenthing went wrong when calling API");
        }

        public async Task<bool> DeleteProductById(long Id)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{Id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContextAs<bool>();
            else
                throw new Exception("Somenthing went wrong when calling API");
        }
    }
}