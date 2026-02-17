namespace GoldenBarbers.Client.Helpers
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int difference = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * difference).Date;
        }
    }
}
