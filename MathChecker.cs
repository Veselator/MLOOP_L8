namespace MLOOP_L8
{
    public class MathChecker
    {
        public static bool Check(Predicate<int> analyzeFunction, int number)
        {
            return analyzeFunction(number);
        }
    }
}
