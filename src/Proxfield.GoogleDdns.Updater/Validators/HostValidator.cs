using FluentValidation;
using Proxfield.GoogleDdns.Updater.Domain.Models;

namespace Proxfield.GoogleDdns.Updater.Validators
{
    public class HostValidator : AbstractValidator<Domain.Models.Host>
    {
        public HostValidator()
        {
            RuleFor(x => x.User)
                .NotEmpty()
                .WithMessage("Username should not be empty");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password should not be empty");

            RuleFor(x => x.Endpoint)
                .NotEmpty()
                .WithMessage("Endpoint should not be empty");
        }
    }
}
