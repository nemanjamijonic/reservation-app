using FluentValidation;
using ReservationAPI.Models.Dtos.Request;

public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required.")
            .MaximumLength(50).WithMessage("Username cannot exceed 50 characters.")
            .Matches("^[a-zA-Z0-9_]+$").WithMessage("Username can only contain letters, numbers, and underscores.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MaximumLength(100).WithMessage("Password cannot exceed 100 characters.")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches("[0-9]").WithMessage("Password must contain at least one digit.")
            .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");

       
        RuleFor(x => x)
            .Custom((dto, context) =>
            {
                if (bool.TryParse(dto.Username, out _))
                {
                    context.AddFailure("Username cannot be a boolean value.");
                }
            });

        // Dodao primer za validaciju broja
        RuleFor(x => x.Username)
            .Must(username =>
            {
                return !int.TryParse(username, out _);
            })
            .WithMessage("Username cannot be a numeric value.");
    }
}
