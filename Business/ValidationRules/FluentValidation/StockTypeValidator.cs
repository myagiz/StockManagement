using Entities.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class StockTypeValidator:AbstractValidator<StockType>
    {
        public StockTypeValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(100);

        }
    }
}
