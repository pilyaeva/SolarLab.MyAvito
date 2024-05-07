using FluentValidation;
using SolarLab.MyAvito.Api.Models;

namespace SolarLab.MyAvito.Api.Validators
{
    public class AdvertisementDtoInValidator : AbstractValidator<AdvertisementDtoIn>
    {
        public AdvertisementDtoInValidator()
        {
            RuleFor(advertisementDtoIn => advertisementDtoIn.Photos)
                .Must(photos => photos.Count <= 10)
                .WithMessage("Количество фотографий должно быть не больше 10 шт");
        }
    }
}
