using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Extensions
{
    public static class MoneyExtensions
    {
        public static string ToMoney(this int money)
        {
            return money.ToString("#,0");
        }
    }
}
