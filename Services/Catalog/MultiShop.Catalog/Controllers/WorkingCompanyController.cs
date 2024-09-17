using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.WorkingCompanyDtos;
using MultiShop.Catalog.Services.WorkingCompanyService;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingCompanyController : ControllerBase
    {
        private readonly IWorkingCompanyService _workingCompanyService;

        public WorkingCompanyController(IWorkingCompanyService workingCompanyService)
        {
            _workingCompanyService = workingCompanyService;
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkingCompany(CreateWorkingCompanyDto company)
        {
            await _workingCompanyService.AddWorkingCompany(company);
            return Ok("Şirket ekleme işlemi başarılı");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdWorkingCompany(string id)
        {
            var resultWorkingCompany = await _workingCompanyService.GetByIdWorkingCompany(id); 
            return Ok(resultWorkingCompany);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkingCompany()
        {
            var resultWorkingCompanyList = await _workingCompanyService.WorkingCompanyList();   
            return Ok(resultWorkingCompanyList);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWorkingCompany(UpdateWorkingCompanyDto company)
        {
            await _workingCompanyService.UpdateWorkingCompamy(company);
            return Ok("Şirket güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkingCompany(string id)
        {
            await _workingCompanyService.DeleteWorkingCompany(id);
            return Ok("Şirket silme işlemi başarılı");
        }

    }
}
