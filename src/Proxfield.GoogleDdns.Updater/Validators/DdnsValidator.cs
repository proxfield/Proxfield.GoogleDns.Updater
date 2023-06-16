using FluentValidation;
using Proxfield.GoogleDdns.Updater.Domain.Models;

namespace Proxfield.GoogleDdns.Updater.Validators
{
    public class DdnsValidator : AbstractValidator<DdnsSettings>
    {
        public DdnsValidator() 
        {
            RuleFor(x => x.MaxParallelExecutions)
                .InclusiveBetween(0, 11)
                .WithMessage("Max parallel executions should be greater than 0 (zero) and lesser than 11 (eleven)");

            RuleFor(x => x.UpdateInterval)
                .GreaterThan(0)
                .WithMessage("Update interval should be greater than 0 (zero)");

            RuleForEach(x => x.Hosts).SetValidator(new HostValidator());
        }
    }
}
