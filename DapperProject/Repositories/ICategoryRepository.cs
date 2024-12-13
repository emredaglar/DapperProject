using DapperProject.Dtos;

namespace DapperProject.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto categoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto categoryDto);
        Task DeleteCategoryAsync(int id);
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(int id);

    }
}
