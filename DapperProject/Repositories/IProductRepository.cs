using DapperProject.Dtos.ProductDtos;

namespace DapperProject.Repositories
{
	public interface IProductRepository
	{
		Task<List<ResultProductDto>> GetAllProductAsync();
		Task CreateProductAsync(CreateProductDto createProductDto);
		Task UpdateProductAsync(UpdateProductDto updateProductDto);
		Task DeleteProductAsync(int id);
		Task<GetByIdProductDto> GetByIdProductAsync(int id);
	}
}
