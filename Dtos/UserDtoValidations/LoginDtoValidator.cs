using FluentValidation;

namespace Dtos.UserDtoValidations
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Email)
                       .NotEmpty();

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }

}
