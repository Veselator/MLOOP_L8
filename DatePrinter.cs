namespace MLOOP_L8
{
    public class DatePrinter
    {
        public static void PrintCurrentTime(Action<string> PrintFunction)
        {
            PrintFunction(DateTime.Now.ToString());
        }

        public static void PrintCurrentHour(Action<string> PrintFunction)
        {
            PrintFunction(DateTime.Now.Hour.ToString());
        }

        public static void PrintCurrentDayOfWeek(Action<string> PrintFunction)
        {
            PrintFunction(DateTime.Now.DayOfWeek.ToString());
        }
    }
}
