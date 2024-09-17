using MultiShop.Catalog.Dtos.WorkingCompanyDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Services.WorkingCompanyService
{
    public interface IWorkingCompanyService
    {
        public Task AddWorkingCompany(CreateWorkingCompanyDto createWorkingCompanyDto);
        public Task DeleteWorkingCompany(string id);
        public Task UpdateWorkingCompamy(UpdateWorkingCompanyDto updateWorkingCompanyDto);
        public Task<GetByIdWorkingCompanyDto> GetByIdWorkingCompany(string id);

        public Task<List<ResultWorkingCompanyDto>> WorkingCompanyList();
    }
}
