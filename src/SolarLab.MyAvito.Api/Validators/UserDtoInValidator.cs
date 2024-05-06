using FluentValidation;
using SolarLab.MyAvito.Api.Models;

namespace SolarLab.MyAvito.Api.Validators
{
    public class UserDtoInValidator : AbstractValidator<UserDtoIn>
    {
        public UserDtoInValidator()
        {
            RuleFor(userDtoIn => userDtoIn.Login)
                .NotNull()
                .Length(3, 20)
                .WithMessage("Логин должен быть от 3 до 20 символов")
                .Matches(@"[a-zA-Z0-9]{3,20}")
                .WithMessage("Логин должен состоять только из символов латинского алфавита и цифр");

            RuleFor(userDtoIn => userDtoIn.Password)
                .NotNull()
                .Length(6, 32);
        }
    }
}
