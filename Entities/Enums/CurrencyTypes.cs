using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enums
{
    public enum CurrencyTypes
    {
        [Description("Turkish Lira")]
        TurkishLira = 1,

        [Description("Euro")]
        Euro = 2,

        [Description("USD")]
        USD = 3,

        [Description("Sterlin")]
        Sterlin = 4
    }
}
