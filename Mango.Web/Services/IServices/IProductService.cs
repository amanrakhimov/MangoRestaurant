namespace Mango.Web.Services.IServices
{
    public interface IProductService
    {
        Task<T> GetAllProductsAsync<T>();

        Task<T> GetProductByIdAsync<T>(int id);

        Task<T> CreateProductAsync<T>();
        Task<T> UpdateProductAsync<T>();
        Task<T> DeleteProductAsync<T>(int id);
    }
}
