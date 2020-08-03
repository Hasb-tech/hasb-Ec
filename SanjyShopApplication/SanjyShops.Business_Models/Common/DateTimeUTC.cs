using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanjyShops.Business_Models.Common
{
    public static class DateTimeUTC
    {
    //    private static TimeZoneInfo timeZoneInfo
    //    {
    //        get
    //        {
    //         //   try { return System.Configuration.ConfigurationManager.AppSettings["TimeZone"] != null && System.Configuration.ConfigurationManager.AppSettings["TimeZone"] != "" ? TimeZoneInfo.FindSystemTimeZoneById(System.Configuration.ConfigurationManager.AppSettings["TimeZone"]) : TimeZoneInfo.Local; }
    //            //catch (Exception ex) { return TimeZoneInfo.Local; }
    //        }
    //    }
    //    public static DateTime Now { get { return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo); } }
    //    public static DateTime Tomorrow { get { return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo).AddDays(1); } }
    //    public static DateTime FinancialStart { get { return TimeZoneInfo.ConvertTimeFromUtc((DateTime.UtcNow.Month >= 4 ? new DateTime(DateTime.UtcNow.Year, 4, 1) : new DateTime(DateTime.UtcNow.AddYears(-1).Year, 4, 1)), timeZoneInfo); } }
    //    public static DateTime FinancialEnd { get { return TimeZoneInfo.ConvertTimeFromUtc((DateTime.UtcNow.Month >= 4 ? new DateTime(DateTime.UtcNow.AddYears(1).Year, 4, 1) : new DateTime(DateTime.UtcNow.Year, 4, 1)), timeZoneInfo); } }
    }
}
