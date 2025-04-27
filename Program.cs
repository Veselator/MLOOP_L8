using System.Text;
using System.Drawing;

namespace MLOOP_L8
{
    internal class Program
    {
        static bool isPrime(int number)
        {
            if (number < 2) return false;
            else
            {
                for (int a = 2; a <= number / 2; a++)
                {
                    if (number % a == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        static bool IsFibonacci(int number)
        {
            if (number == 0 || number == 1)
                return true;

            return IsPerfectSquare(5 * (long)number * number + 4) ||
                   IsPerfectSquare(5 * (long)number * number - 4);
        }

        static bool IsPerfectSquare(long number)
        {
            long sqrt = (long)Math.Sqrt(number);
            return sqrt * sqrt == number;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Для переходу між завданнями використовуйте Ctrl+f ЗАВДАННЯ
            // ЗАВДАННЯ №8.1

            Window window = new Window("Вікно", 120, 350, 1200, 800);
            Console.WriteLine(" До:\t" + window.ToString());

            DatePrinter.PrintCurrentHour(Console.WriteLine);
            DatePrinter.PrintCurrentTime(x => window.Title = x);

            Console.WriteLine(" Після:\t" + window.ToString());
            Console.WriteLine();

            for (int i = 0; i < 30; i++)
            {
                // Перевіряємо для перших 30 значень, чи є вони простими
                Console.WriteLine($" Число {i}{(MathChecker.Check(isPrime, i) ? "" : " не")} є простим;");
                Console.WriteLine($" Число {i}{(MathChecker.Check(IsFibonacci, i) ? "" : " не")} є числом фібоначчі;\n");
            }

            Func<double, double, double, double> triangleArea = (a, b, c) =>
            {
                double s = (a + b + c) / 2;
                return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            };

            Func<double, double, double> rectangleCalculator = (a, b) =>
            {
                return a * b;
            };

            Console.WriteLine(" Площа трикутника:" + triangleArea(4, 3, 5));
            Console.WriteLine(" Площа прямокутника:" + rectangleCalculator(10, 20));

            // ЗАВДАННЯ №8.2
            Suitcase valiza = new Suitcase("EuroHome", 4.1, 93, Color.Yellow, TexturePattern.Solid);
            valiza.OnItemAdded += () => Console.WriteLine(" Додано новий предмет");
            valiza.OnItemRemoved += (Item i) => Console.WriteLine($" Предмет {i.Name} видалено з валізи");

            Item Book = new Item("Книга \"1984\", автор Джордж Орвелл", 0.32, 4);
            valiza.AddItem(Book);
            valiza.AddItem(new Item("Яблуко", 0.12, 2));
            valiza.AddItem(new Item("Сік \"Садочок\"", 1.22, 1));

            Console.WriteLine("\n" + valiza.ToString());

            // Пробуємо запіхнути слона у валізу
            if (!valiza.AddItem(new Item("Слон", 10000, 480)))
            {
                Console.WriteLine(" Слона у валізу запіхнути не вийшло :(");
            }
            else
            {
                Console.WriteLine(" Слона запіхнули у валізу! :)");
            }

            valiza.Remove(Book);

            // ЗАВДАННЯ №8.3
            Func<int[], int, int> countMultipliesOfNumber = (a, b) =>
            {
                int count = 0;
                foreach (int i in a)
                {
                    if (i % b == 0) count++;
                }
                return count;
            };

            Func<int[], int> countIfPositive = (a) =>
            {
                int count = 0;
                foreach (int i in a)
                {
                    if (i > 0) count++;
                }
                return count;
            };

            Predicate<int> isProgrDay = (day) =>
            {
                return day == 256;
            };

            Func<string?, string?, bool> isWordInText = (originalText, word) =>
            {
                if (originalText is null || word is null) return false;
                if (word == string.Empty) return true;

                word = word.ToLower();
                string[] splittedText = originalText.ToLower().Split();

                foreach (string currentWord in splittedText)
                {
                    if (currentWord == word) return true;
                }
                return false;
            };

            Func<string?, string?, bool> isTextInText = (originalWords, searchWords) =>
            {
                if (originalWords is null || searchWords is null) return false;

                string[] splittedText = originalWords.ToLower().Split();
                if (searchWords == string.Empty) return true;

                string[] splittedSearchWords = searchWords.ToLower().Split();

                foreach (string searchWord in splittedSearchWords)
                {
                    if (searchWord is null) continue;

                    if (!isWordInText(originalWords, searchWord)) return false;
                }

                return true;
            };

            int[] arr = { 1, 4, 89643, 7, 9, 14, 22 };

            Console.WriteLine();
            Console.WriteLine(" " + countMultipliesOfNumber(arr, 7));
            Console.WriteLine(" " + countIfPositive(arr));
            Console.WriteLine(" " + isProgrDay(DateTime.Now.Day));
            Console.WriteLine(" " + isWordInText("Мама мила раму", "мама"));
            Console.WriteLine(" " + isTextInText("І день іде, і ніч іде, і голову схопивши в руки", "Слон"));

            Console.ReadLine();
        }
    }
}
