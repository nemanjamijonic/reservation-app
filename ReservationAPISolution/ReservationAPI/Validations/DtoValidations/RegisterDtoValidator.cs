using FluentValidation;
using ReservationAPI.Models.Dtos.Request;
using System.Text.RegularExpressions;

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required.")
            .MaximumLength(50).WithMessage("Username cannot exceed 50 characters.")
            .Matches("^[a-zA-Z0-9_]+$").WithMessage("Username can only contain letters, numbers, and underscores.")
            .Must(username => !int.TryParse(username, out _)).WithMessage("Username cannot be a numeric value.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .MaximumLength(100).WithMessage("Password cannot exceed 100 characters.")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches("[0-9]").WithMessage("Password must contain at least one digit.")
            .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.")
            .Matches("^[a-zA-Z]+$").WithMessage("First name can only contain letters."); // Samo slova

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.")
            .Matches("^[a-zA-Z]+$").WithMessage("Last name can only contain letters."); // Samo slova

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.")
            .Must(email => Regex.IsMatch(email, @"^[\w\-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            .WithMessage("Email must have a valid domain name.");

        RuleFor(x => x.DateOfBirth)
            .NotEmpty().WithMessage("Date of birth is required.")
            .LessThan(DateTime.UtcNow).WithMessage("Date of birth must be in the past.")
            .GreaterThan(DateTime.UtcNow.AddYears(-120)).WithMessage("Date of birth must be realistic (less than 120 years ago).");

        RuleFor(x => x)
            .Custom((dto, context) =>
            {
                if (bool.TryParse(dto.Username, out _))
                {
                    context.AddFailure("Username cannot be a boolean value.");
                }
            });
    }
}
