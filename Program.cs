using System.Collections.Immutable;
using static System.Console;

namespace Home_Work_7
{
    class Program
    {
        public static void Main(string[] args)
        {
            var book = FileReader("C:\\Beet_lessons\\Home_Work_7\\PhoneBook.txt");
    
            WriteLine("Search: ");
            WriteLine($"Input abonent's name or number: ");
            var list = Search(ReadLine(), book);
            WriteLine("Search result: ");

            WriteLine(
                $"{(list.Any() ? $"{string.Join("\r\n", list.ToImmutableSortedSet())}" : "No result with this parameters")}");
                // пробував зробити сортування виводу через list.Sort або перетворення list до масиву
                // нічого не вийшло
                // ToImmutableSortedSet - це чисто методом научного тику
                // переглядав усе, що було доступне після крапки ( list. ----- )
                

            (string, string, string)[] Search(
                string input,
                List<(string, string, string)> collection) =>
                collection.Where(person =>
                    person.Item1.Contains(input, StringComparison.OrdinalIgnoreCase) ||
                    person.Item2.Contains(input, StringComparison.OrdinalIgnoreCase) ||
                    person.Item3.Contains(input)).ToArray();
        }

        private static List<(string Name, string Surname, string Number)> FileReader(string path)
        {
            var book = new List<(string Name, string Surname, string Number)>();
            var lines = File.ReadAllLines("C:\\Beet_lessons\\Home_Work_7\\PhoneBook.txt");
            foreach (var line in lines)
            {
                var split = line.Split(",");
                book.Add((split[0], split[1], split[2]));
            }
            return book;
        }
    }
}