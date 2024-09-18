using MultiShop.Catalog.Dtos.AboutDtos;

namespace MultiShop.Catalog.Services.AboutService
{
    public interface IAboutService
    {
        public Task CreateAbout(CreateAboutDto about);
        public Task UpdateAbout(UpdateAboutDto about);
        public Task DeleteAbout(string id);
        public Task<ResultAboutDto> GetByIdAbout(string id);
        public Task<List<ResultAboutDto>> GetAllAbout();
    }
}
