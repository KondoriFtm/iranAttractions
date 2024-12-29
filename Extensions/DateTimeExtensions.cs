
using System;
using System.Globalization;

namespace iranAttractions.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToShamsi(this DateTime dateTime, bool includeTime = false)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            int year = persianCalendar.GetYear(dateTime);
            int month = persianCalendar.GetMonth(dateTime);
            int day = persianCalendar.GetDayOfMonth(dateTime);

            string shamsiDate = $"{year}/{month:D2}/{day:D2}";

            if (includeTime)
            {
                string time = dateTime.ToString("HH:mm:ss"); // Format the time as HH:mm:ss
                shamsiDate = $"{shamsiDate} {time}";
            }

            return shamsiDate;
        }
    }
}
