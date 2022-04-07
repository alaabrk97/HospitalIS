using System.Text.RegularExpressions;
using FluentValidation;
namespace HospitalInfoSystem.Application.Features.Palients.Command.CreatePalient
{
    public class CreateCommandValidator : AbstractValidator<CreatePatientCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(p => p.Name)
                  .NotEmpty().WithMessage("The namespace cannot be empty!")
                  .Length(3, 60).WithMessage("The namespace must be between 5 and 60 characters!")
                  .Matches(new Regex(@"^[a-zA-Z]+"));

            RuleFor(p => p.FileNo)
                  .NotEmpty().WithMessage("The namespace cannot be empty!")
                  .GreaterThan(0).WithMessage("other must be great than 0");

            RuleFor(p => p.CitizenId)
                  .NotEmpty().WithMessage("The namespace cannot be empty!");

            RuleFor(p => p.Birthdate)
                  .NotEmpty().WithMessage("The namespace cannot be empty!")
                  .LessThan(p => DateTime.Now).WithMessage("the date must be in the past");

            RuleFor(p => p.Gender).IsInEnum();

            RuleFor(p => p.Natinality)
                 .NotEmpty().WithMessage("The namespace cannot be empty!")
                 .Length(3, 40).WithMessage("The namespace must be between 5 and 60 characters!")
                  .Matches(new Regex(@"^[a-zA-Z]+$"));

            RuleFor(p => p.PhoneNumber)
                .NotEmpty().WithMessage("The namespace cannot be empty!")
                .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
                .MaximumLength(15).WithMessage("PhoneNumber must not exceed 15 characters.")
                .Matches(new Regex(@"^[\+\0-9]+$"));

            RuleFor(p => p.Email)
               .EmailAddress().WithMessage("email is Valid");

            RuleFor(p => p.Country)
                 .NotEmpty().WithMessage("The namespace cannot be empty!")
                 .Length(3, 60).WithMessage("The namespace must be between 5 and 60 characters!")
                  .Matches(new Regex(@"^[a-zA-Z]+$"));

            RuleFor(p => p.City)
                 .NotEmpty().WithMessage("The namespace cannot be empty!")
                 .Length(3, 60).WithMessage("The namespace must be between 5 and 60 characters!")
                  .Matches(new Regex(@"^[a-zA-Z]+$"));

            RuleFor(p => p.Street)
                 .NotEmpty().WithMessage("The namespace cannot be empty!")
                 .Length(3, 60).WithMessage("The namespace must be between 5 and 60 characters!")
                  .Matches(new Regex(@"^[a-zA-Z]+$"));

            RuleFor(p => p.Address1)
                 .NotEmpty().WithMessage("The namespace cannot be empty!")
                 .Length(3, 60).WithMessage("The namespace must be between 5 and 60 characters!")
                  .Matches(new Regex(@"^[a-zA-Z]+$"));

            RuleFor(p => p.Address2)
               .NotEmpty().WithMessage("The namespace cannot be empty!")
               .Length(3, 60).WithMessage("The namespace must be between 5 and 60 characters!")
                .Matches(new Regex(@"^[a-zA-Z]+$"));


            RuleFor(p => p.ContactPerson)
                 .NotEmpty().WithMessage("The namespace cannot be empty!")
                 .Length(3, 100).WithMessage("The namespace must be between 5 and 60 characters!")
                  .Matches(new Regex(@"^[a-zA-Z]+$"));

            RuleFor(p => p.ContactRelation)
                 .NotEmpty().WithMessage("The namespace cannot be empty!")
                 .Length(3, 100).WithMessage("The namespace must be between 5 and 60 characters!")
                  .Matches(new Regex(@"^[a-zA-Z]+$"));

            RuleFor(p => p.ContactPhone)
            .NotEmpty().WithMessage("The namespace cannot be empty!")
            .Length(10, 20).WithMessage("The namespace must be between 5 and 60 characters!")
            .Matches(new Regex(@"^[\+\0-9]+$"));


            RuleFor(p => p.FirstVisitDate)
                .NotEmpty().WithMessage("The namespace cannot be empty!")
                .LessThan(p => DateTime.Now).WithMessage("the date must be in the past");
        }
    }
}
