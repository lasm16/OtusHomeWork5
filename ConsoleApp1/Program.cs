using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            var number = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите текст");
            var text = Console.ReadLine();

            Console.WriteLine();
            WriteTable(number, text);
        }

        private static void WriteTable(int number, string text)
        {
            if (CheckInt(number) && CheckString(text))
            {
                var border = CreateHorizontalBorder(number, text);

                Console.WriteLine(border);
                CreateFirstPicture(number, text);
                Console.WriteLine(border);
                CreateSecondPicture(number, text);
                Console.WriteLine(border);
                CreateThirdPicture(number, text);
                Console.WriteLine(border);
            }
        }

        private static bool CheckInt(int number)
        {
            if (number < 1 || number > 6)
            {
                Console.WriteLine("Введите число от 1 до 6");
                return false;
            }
            return true;
        }

        private static bool CheckString(string text)
        {
            if (text.Length == 0)
            {
                Console.WriteLine("Текст не может быть пустым");
                return false;
            }
            return true;
        }

        private static string CreateHorizontalBorder(int number, string text)
        {
            var lenght = GetLineLenght(number, text);
            var totalLenght = lenght + number;
            string line = "";
            for (int i = 0; i < totalLenght; i++)
            {
                line += "+";
            }
            return line;
        }

        private static void CreateFirstPicture(int number, string text)
        {
            var middle = 0;
            if (number % 2 != 0)
            {
                middle = number / 2;
            }
            else
            {
                middle = number / 2;
            }

            for (int i = 0; i < number; i++)
            {
                if (i == middle)
                {
                    PrintMessage(number, text);
                }
                else
                {
                    PrintEmptyLine(number, text);
                }
            }
        }

        private static void CreateSecondPicture(int number, string text)
        {
            for (int i = 0; i < number; i++)
            {
                var line = i % 2 == 0 ? GetChessStyleMesage(number, text, true) : GetChessStyleMesage(number, text, false); // Сложно читаемо, так делать нельзя. Только для ДЗ
                Console.WriteLine(line);
            }
        }

        private static string GetChessStyleMesage(int number, string text, bool isLastCharCross)
        {
            var line = "+";
            var lenght = GetLineLenght(number, text);
            var totalLenght = lenght + number - 1;
            do
            {
                if (isLastCharCross)
                {
                    line += " ";
                    isLastCharCross = false;
                }
                else
                {
                    line += "+";
                    isLastCharCross = true;
                }
            }
            while (line.Length < totalLenght);
            return line + "+";
        }

        private static void CreateThirdPicture(int number, string text)
        {

            PrintCross(number, text);
        }

        private static void PrintCross(int number, string text)
        {
            var maxIndex = GetLineLenght(number, text) + number;
            var step = maxIndex / number;
            var emptyLine = GetSpaceForMessage(maxIndex - 1);
            var emptyLineLenght = emptyLine.Length;
            var prevIndex = 1;
            for (var i = 0; i < number; i++)
            {
                char[] array = emptyLine.ToCharArray();
                array[i + prevIndex] = '+';
                array[emptyLineLenght - i - prevIndex - 2] = '+';
                prevIndex = i + step;
                var lineWithCross = new string(array);
                Console.WriteLine("+" + lineWithCross + "+");
            }
        }

        private static int GetLineLenght(int number, string text)
        {
            var lenght = text.Length;
            return lenght + number;
        }

        private static void PrintEmptyLine(int number, string text)
        {
            var line = "+";
            var lenght = GetLineLenght(number, text);
            var totalLenght = lenght + number - 1;
            do
            {
                line += " ";
            }
            while (line.Length < totalLenght);
            Console.WriteLine(line + "+");
        }

        private static void PrintMessage(int number, string text)
        {
            var emptyLine = GetSpaceForMessage(number);
            var line = "+" + emptyLine + text + emptyLine + "+";
            Console.WriteLine(line);
        }

        private static string GetSpaceForMessage(int number)
        {
            string line = "";
            for (int i = 0; i < number - 1; i++)
            {
                line = line + " ";
            }
            return line;
        }
    }
}
