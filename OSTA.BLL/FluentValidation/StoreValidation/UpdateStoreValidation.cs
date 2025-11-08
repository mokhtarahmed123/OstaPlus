using FluentValidation;
using OSTA.BLL.DTOs.StoreDTOs;
using OSTA.DAL.Interfaces;

namespace OSTA.BLL.FluentValidation.StoreValidation
{
    public class UpdateStoreValidation : AbstractValidator<UpdateStoreDTO>
    {
        private readonly IStoreRepository _storeRepository;

        public UpdateStoreValidation(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
            ApplyBasicRules();
        }
        public void ApplyBasicRules()
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("Store name is required.")
                .MaximumLength(100).WithMessage("Store name cannot exceed 100 characters.");

            RuleFor(s => s.Country)
                .NotEmpty().WithMessage("Country is required.")
                .MaximumLength(50).WithMessage("Country name cannot exceed 50 characters.");

            RuleFor(s => s.City)
                .NotEmpty().WithMessage("City is required.")
                .MaximumLength(50).WithMessage("City name cannot exceed 50 characters.");

            RuleFor(s => s.Region)
                .NotEmpty().WithMessage("Region is required.")
                .MaximumLength(50).WithMessage("Region name cannot exceed 50 characters.");

            RuleFor(s => s.PostalCode)
                .NotEmpty().WithMessage("Postal code is required.")
                .Matches(@"^\d{3,10}$").WithMessage("Postal code must be between 3 and 10 digits.");

            RuleFor(s => s.MerchantEmail)
                .NotEmpty().WithMessage("Merchant email is required.")
                .EmailAddress().WithMessage("Merchant email must be a valid email address.");
        }

    }
}
