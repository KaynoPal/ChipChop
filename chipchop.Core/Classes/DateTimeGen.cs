using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Globalization;

namespace chipchop.Core.Classes
{
    public class DateTimeGen
    {
        public string GetPersianTime()
        {
            var datetime = DateTime.Now;
            var persian = new PersianCalendar();
            var Pdate = $"{persian.GetYear(datetime)}/{persian.GetMonth(datetime)}/{persian.GetDayOfMonth(datetime)}";
            return Pdate;
        }
    }
}
