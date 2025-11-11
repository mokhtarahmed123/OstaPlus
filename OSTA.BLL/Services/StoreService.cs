using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OSTA.BLL.DTOs.StoreDTOs;
using OSTA.BLL.Exceptions;
using OSTA.BLL.Interfaces;
using OSTA.DAL.Entities;
using OSTA.DAL.Interfaces;

namespace OSTA.BLL.Services
{
    public class StoreService : IStoreService
    {
        private readonly IMapper mapper;
        private readonly IStoreRepository storeRepository;
        private readonly IValidator<UpdateStoreDTO> updateValidate;
        private readonly IValidator<AddStoreDTO> addvalidator;
        private readonly IAuthRepository authRepository;

        public StoreService(IMapper mapper, IStoreRepository storeRepository, IValidator<UpdateStoreDTO> UpdateValidate, IValidator<AddStoreDTO> Addvalidator, IAuthRepository authRepository)
        {
            this.mapper = mapper;
            this.storeRepository = storeRepository;
            updateValidate = UpdateValidate;
            addvalidator = Addvalidator;
            this.authRepository = authRepository;
        }
        public async Task<StoreDetailsDTO> AddStoreAsync(AddStoreDTO model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var validationResult = await addvalidator.ValidateAsync(model);
            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult.Errors);
            var storeEntity = mapper.Map<Store>(model);

            var Merchant = await authRepository.GetByEmail(model.MerchantEmail);
            if (Merchant == null)
                throw new KeyNotFoundException($"Merchant with email '{model.MerchantEmail}' not found.");
            if (Merchant.RoleApplication.Name != "Merchant")
            {
                throw new BadRequestException("The provided email does not belong to a merchant.");
            }
            storeEntity.Merchantid = Merchant.Id;
            var createdStore = await storeRepository.AddAsync(storeEntity);
            var storeDetailsDto = mapper.Map<StoreDetailsDTO>(createdStore);
            return storeDetailsDto;
        }


        public async Task<int> CountStoresAsync()
        {
            return await storeRepository.CountAsync();
        }

        public async Task<bool> DeleteStoreAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));
            var IsFound = await storeRepository.GetStoreByIdsAsync(id);
            if (IsFound == null)
                throw new NotFoundException($"Store with id '{id}' not found.");
            await storeRepository.DeleteAsync(IsFound);
            return true;
        }
        public async Task<IEnumerable<StoreDetailsDTO>> FilterAsync(StoreFilterDTO filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            var query = storeRepository.GetTableNoTracking().Include(a => a.User).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Country))
            {
                var country = filter.Country.Trim().ToLower();
                query = query.Where(s => s.Country.ToLower().Contains(country));
            }

            if (!string.IsNullOrWhiteSpace(filter.City))
            {
                var city = filter.City.Trim().ToLower();
                query = query.Where(s => s.City.ToLower().Contains(city));
            }

            if (!string.IsNullOrWhiteSpace(filter.Region))
            {
                var region = filter.Region.Trim().ToLower();
                query = query.Where(s => s.Region.ToLower().Contains(region));
            }

            if (!string.IsNullOrWhiteSpace(filter.PostalCode))
            {
                var postal = filter.PostalCode.Trim();
                query = query.Where(s => s.PostalCode.Contains(postal));
            }

            if (!string.IsNullOrWhiteSpace(filter.MerchantEmail))
            {
                var merchantId = filter.MerchantEmail.Trim();
                query = query.Where(s => s.Merchantid == merchantId);
            }

            var stores = await query.ToListAsync();

            return stores.Select(s => mapper.Map<StoreDetailsDTO>(s));
        }


        public async Task<IEnumerable<StoreDetailsDTO>> GetAllAsync()
        {
            var Lists = await storeRepository.GetAllAsync();
            var Mapped = mapper.Map<IEnumerable<StoreDetailsDTO>>(Lists);
            return Mapped;
        }

        public async Task<StoreDetailsDTO?> GetByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));
            var Store = await storeRepository.GetStoreByIdsAsync(id);
            if (Store == null)
                return null;
            var Mapped = mapper.Map<StoreDetailsDTO>(Store);
            return Mapped;
        }

        public async Task<bool> UpdateStoreAsync(string id, UpdateStoreDTO model)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var store = await storeRepository.GetStoreByIdsAsync(id);
            if (store == null)
                throw new NotFoundException($"Store with id '{id}' not found.");

            var validationResult = await updateValidate.ValidateAsync(model);
            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult.Errors);

            var isNameTaken = await storeRepository.GetWithNamNotRepeatAndNotTheSameIdAsync(model.Name, id);
            if (isNameTaken != null)
                throw new BadRequestException($"Store name '{model.Name}' is already in use.");

            mapper.Map(model, store);

            await storeRepository.UpdateAsync(store);

            return true;
        }
    }
}
