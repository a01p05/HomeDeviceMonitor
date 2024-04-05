using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDeviceMonitor.Application.Entities.Buildings.Commands.Create
{
    public class CreateBuildingCommandValidator : AbstractValidator<CreateBuildingCommand>
    {
        public CreateBuildingCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(255);
            RuleFor(x => x.Description).MaximumLength(3000);
            RuleFor(x => x.Type).MaximumLength(255);
        }
    }
}
