using Entities.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class StockUnitValidator:AbstractValidator<StockUnit>
    {
        public StockUnitValidator()
        {
            RuleFor(x => x.Code).NotNull().NotEmpty().MaximumLength(20);
            RuleFor(x => x.StockType).NotNull().NotEmpty();
            RuleFor(x => x.UnitId).NotNull().NotEmpty();
            RuleFor(x => x.Description).NotNull().NotEmpty().MaximumLength(255);
            RuleFor(x => x.Paperweight);
            RuleFor(x => x.PurchaseCurrencyId).NotNull().NotEmpty();
            RuleFor(x => x.SaleCurrencyId).NotNull().NotEmpty();
            RuleFor(x => x.PurchasePrice);
            RuleFor(x => x.SalePrice);

        }
    }
}
