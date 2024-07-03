namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\Coding School\\Desktop\\C--orange-Task\\Task7\\ahmad_alzoubi.txt";
            string name = "Ahmad Alzoubi";
            string specialization = "Network and Security Engineering";
            int age = 25;
            string description = "I have a passion for programming, development, and web technologies.";

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Name: {name}");
                writer.WriteLine($"Specialization: {specialization}");
                writer.WriteLine($"Age: {age}");
                writer.WriteLine($"Description: {description}");
            }

            // Reading from the file and processing the content
            int totalCharacters = 0;
            int totalWords = 0;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    totalCharacters += CountCharacters(line);
                    totalWords += CountWords(line);
                }
            }

            Console.WriteLine($"Total number of characters (excluding spaces): {totalCharacters}");
            Console.WriteLine($"Total number of words: {totalWords}");
        }

        static int CountCharacters(string line)
        {
            int characterCount = 0;
            foreach (char c in line)
            {
                if (!char.IsWhiteSpace(c))
                {
                    characterCount++;
                }
            }
            return characterCount;
        }

        static int CountWords(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                return 0;
            }

            string[] words = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }
    }
}

