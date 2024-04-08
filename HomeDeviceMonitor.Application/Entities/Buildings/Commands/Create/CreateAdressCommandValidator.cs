using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDeviceMonitor.Application.Entities.Buildings.Commands.Create
{
    public class CreateAdressCommandValidator : AbstractValidator<CreateAdressCommand>
    {
        public CreateAdressCommandValidator()
        {
            RuleFor(x => x.Street).NotNull().NotEmpty().MaximumLength(255);
            RuleFor(x => x.No).MaximumLength(10);
            RuleFor(x => x.Code).MaximumLength(6);
            RuleFor(x => x.City).MaximumLength(255);
            RuleFor(x => x.Country).MaximumLength(255);
            RuleFor(x => x.Location.Longitude).GreaterThan(0);
            RuleFor(x => x.Location.Latitude).GreaterThan(0);
        }
    }
}
