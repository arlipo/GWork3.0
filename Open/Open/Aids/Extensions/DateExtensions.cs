// (c) https://www.codeproject.com/articles/774228/mvc-html-table-helper-part-display-tables

using System;
namespace Open.Aids.Extensions
{
    public static class DateExtensions
    {

        public static DateTime FirstOfMonth(this DateTime d) => new DateTime(d.Year, d.Month, 1);

        public static DateTime LastOfYear(this DateTime d) => new DateTime(d.Year, 12, 31);

        public static DateTime LastOfMonth(this DateTime d) => new DateTime(d.Year, d.Month, 1).AddMonths(1).AddDays(-1);

        public static DateTime FirstOfWorkingWeek(this DateTime d) => new DateTime(d.Year, d.Month, d.Day).AddDays(DayOfWeek.Monday - d.DayOfWeek);

        public static DateTime LastOfWorkingWeek(this DateTime d) => new DateTime(d.Year, d.Month, d.Day).AddDays(DayOfWeek.Friday - d.DayOfWeek);

        public static DateTime FirstOfWeek(this DateTime d) => new DateTime(d.Year, d.Month, d.Day).AddDays(DayOfWeek.Sunday - d.DayOfWeek);

        public static DateTime LastOfWeek(this DateTime d) => new DateTime(d.Year, d.Month, d.Day).AddDays(DayOfWeek.Saturday - d.DayOfWeek);

        public static bool IsWeekEnd(this DateTime d) => d.DayOfWeek == DayOfWeek.Saturday || d.DayOfWeek == DayOfWeek.Sunday;

    }
}
