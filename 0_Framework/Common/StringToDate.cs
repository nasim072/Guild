namespace _0_Framework.Common
{
    public static class StringToDateOnly
    {
        public static DateOnly? ToDate(this string value)
        {
            return DateOnly.MaxValue;
        }
    }
    public static class DateOnlyToString
    {
        public static string ToMyString(this DateOnly? value)
        {
            return "DateOnly.MaxValue";
        }
    }
}
