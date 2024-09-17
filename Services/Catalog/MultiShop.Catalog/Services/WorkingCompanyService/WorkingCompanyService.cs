using Amazon.Util;
using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.WorkingCompanyDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.WorkingCompanyService
{
    public class WorkingCompanyService : IWorkingCompanyService
    {
        private readonly IMongoCollection<WorkingCompany> _workingCompanymongoCollection;
        private IMapper _mapper;
        public WorkingCompanyService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var mongoClient = new MongoClient(databaseSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.DatabaseName);
            _workingCompanymongoCollection = mongoDatabase.GetCollection<WorkingCompany>(databaseSettings.WorkingCompanyCollectionName);
            _mapper = mapper;
        }
        public async Task AddWorkingCompany(CreateWorkingCompanyDto createWorkingCompanyDto)
        {
            var mappedWorkingCompany = _mapper.Map<WorkingCompany>(createWorkingCompanyDto);
            await _workingCompanymongoCollection.InsertOneAsync(mappedWorkingCompany);
        }

        public async Task DeleteWorkingCompany(string id)
        {
            await _workingCompanymongoCollection.DeleteOneAsync(x => x.CompanyId == id);
        }

        public async Task<GetByIdWorkingCompanyDto> GetByIdWorkingCompany(string id)
        {
            var result = await _workingCompanymongoCollection.Find(x => x.CompanyId == id).FirstOrDefaultAsync();
            var mappedResult = _mapper.Map<GetByIdWorkingCompanyDto>(result);

            return mappedResult;
        }

        public async Task UpdateWorkingCompamy(UpdateWorkingCompanyDto updateWorkingCompanyDto)
        {
            var data = _mapper.Map<WorkingCompany>(updateWorkingCompanyDto);
            await _workingCompanymongoCollection.ReplaceOneAsync(x => x.CompanyId == updateWorkingCompanyDto.CompanyId, data);
        }

        public async Task<List<ResultWorkingCompanyDto>> WorkingCompanyList()
        {
            var resultWorkingCompany = await _workingCompanymongoCollection.Find(x => true).ToListAsync();
            var mappedData = _mapper.Map<List<ResultWorkingCompanyDto>>(resultWorkingCompany);
            return mappedData;
        }
    }
}
