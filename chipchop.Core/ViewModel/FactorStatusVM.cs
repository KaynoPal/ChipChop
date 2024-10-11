using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chipchop.Core.ViewModels
{
    public class FactorStatusVM
    {
        public string[] StatusArray { get; } =
            { "پرداخت نشده", "پرداخت شده", "در حال آماده سازی", "ارسال شده", "بسته شده" };

    }
}
