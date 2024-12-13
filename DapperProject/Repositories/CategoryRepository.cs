using Dapper;
using DapperProject.Context;
using DapperProject.Dtos;

namespace DapperProject.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DapperContext _context;

        public CategoryRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            string query = "insert into Categories (CategoryName) values (@categoryName)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", createCategoryDto.CategoryName);
            var connection= _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            string query = "Delete From Categories Where CategoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId",id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * From Categories";
            var connection=_context.CreateConnection();
            var values=await connection.QueryAsync<ResultCategoryDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(int id)
        {
            string query = "Select * From Categories Where CategoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categortId", id);
            var connection = _context.CreateConnection();
            var values=await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query);
            return values;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            string query = "update Categories Set CategoryName=@categoryName where CategoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categortId", updateCategoryDto.CategoryId);
            parameters.Add("@categortName", updateCategoryDto.CategoryName);
            var connection=_context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);


        }
    }
}
