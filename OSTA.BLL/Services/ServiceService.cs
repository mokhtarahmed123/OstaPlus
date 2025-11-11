using AutoMapper;
using FluentValidation;
using OSTA.BLL.DTOs.ServiceDTOs;
using OSTA.BLL.Exceptions;
using OSTA.BLL.Interfaces;
using OSTA.DAL.Entities;
using OSTA.DAL.Interfaces;

namespace OSTA.BLL.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IValidator<AddServiceDTO> _addValidator;
        private readonly IMapper _mapper;
        private readonly ICategoryRepo categoryRepo;
        private readonly IValidator<UpdateServiceDTO> updateValidator;

        public ServiceService(
            IServiceRepository serviceRepository,
            IValidator<AddServiceDTO> addValidator,
            IMapper mapper, ICategoryRepo categoryRepo, IValidator<UpdateServiceDTO> UpdateValidator)
        {
            _serviceRepository = serviceRepository;
            _addValidator = addValidator;
            _mapper = mapper;
            this.categoryRepo = categoryRepo;
            updateValidator = UpdateValidator;
        }
        public async Task<string> Add(AddServiceDTO addService)
        {
            var validationResult = await _addValidator.ValidateAsync(addService);
            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult.Errors);

            var category = await categoryRepo.GetByName(addService.CategoryName);
            if (category == null)
                throw new NotFoundException($"Category '{addService.CategoryName}' not found.");

            var service = _mapper.Map<Service>(addService);
            service.CategoryId = category.Id;
            await _serviceRepository.AddAsync(service);

            return $"Service '{service.Description}' added successfully.";
        }
        public Task<int> CountOfServices()
        {
            return _serviceRepository.CountOfServices();
        }
        public async Task<string> Delete(string id)
        {
            var service = await _serviceRepository.GetByIdAsync(id);
            if (service == null)
                throw new NotFoundException($"Service with ID '{id}' not found.");

            await _serviceRepository.DeleteAsync(service);
            return $"Service '{service.Description}' deleted successfully.";
        }
        public async Task<List<AllServicesDTO>> GetByCategory(string categoryName)
        {
            var List = await _serviceRepository.GetByCategoryAsync(categoryName);
            return _mapper.Map<List<AllServicesDTO>>(List);

        }
        public async Task<List<AllServicesDTO>> ShowAll()
        {
            var services = await _serviceRepository.GetAllAsync();
            return _mapper.Map<List<AllServicesDTO>>(services);
        }
        public async Task<List<AllServicesDTO>> Filter(ServiceFilter serviceFilter)
        {
            var services = await _serviceRepository.GetAllAsync();

            var query = services.AsQueryable();

            if (serviceFilter.Price.HasValue)
                query = query.Where(s => s.BasePrice >= serviceFilter.Price.Value);

            if (serviceFilter.duration.HasValue)
                query = query.Where(s => s.Duration == serviceFilter.duration.Value);

            if (!string.IsNullOrEmpty(serviceFilter.CategoryName))
                query = query.Where(s => s.Category.Name == serviceFilter.CategoryName);

            var filteredServices = query.ToList();

            return _mapper.Map<List<AllServicesDTO>>(filteredServices);

        }
        public async Task<string> Update(string id, UpdateServiceDTO updateService)
        {
            var existingService = await _serviceRepository.GetByIdAsync(id);
            if (existingService == null)
                throw new NotFoundException($"Service with ID '{id}' not found.");
            var validationResult = await updateValidator.ValidateAsync(updateService);
            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult.Errors);
            _mapper.Map(updateService, existingService);

            await _serviceRepository.UpdateAsync(existingService);

            return $"Service with ID '{id}' updated successfully.";
        }

    }
}
