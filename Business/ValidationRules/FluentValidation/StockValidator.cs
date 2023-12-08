using Entities.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class StockValidator: AbstractValidator<Stock>
    {
        public StockValidator()
        {
            RuleFor(x => x.StockType).NotNull().NotEmpty();
            RuleFor(x => x.StockUnit).NotNull().NotEmpty();
            RuleFor(x => x.Quantity).NotNull().NotEmpty();
            RuleFor(x => x.CriticalQuantity).NotNull().NotEmpty();
            RuleFor(x => x.ShelfInfo).MaximumLength(100);
            RuleFor(x => x.CabinetInfo).MaximumLength(100);

        }
    }
}
