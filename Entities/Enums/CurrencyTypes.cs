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
        [Description("₺")]
        TurkishLira = 1,

        [Description("€")]
        Euro = 2,

        [Description("$")]
        USD = 3,

        [Description("£")]
        Sterlin = 4
    }
}
