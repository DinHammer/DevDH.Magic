using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevDH.Magic.Abstractions.Staff
{
    public partial class SimpleTools
    {
        public List<DateTime> mgcDataGetMonthAllDateTime(DateTime dateTime)
            => mgcDataGetMonthAllDateTime(dateTime.Year, dateTime.Month);
        public List<DateTime> mgcDataGetMonthAllDateTime(int year, int month)
        {            
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                .Select(day => new DateTime(year, month, day))
                .ToList();
        }
    }
}
