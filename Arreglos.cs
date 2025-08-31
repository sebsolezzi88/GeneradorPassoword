namespace NArreglos
{
    class RandomData
    {
        public static string[] symbols = ["#", "/", "(", ")", "[", "]", "{", "}", "*", "-", "+", "=", "!",
            "@", "$", "%", "^", "&", "?", "<", ">", "|", "~", "`", ",", ".", ";", ":", "\"", "_"];
        public static string[] numbers = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"];
        public static string[] mayusLetters = [
             "A", "B", "C", "D", "E", "F", "G", "H", "I", "J",
            "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T",
            "U", "V", "W", "X", "Y", "Z"
         ];

        // Letras minúsculas
        public static string[] minusLetters = [
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j",
            "k", "l", "m", "n", "o", "p", "q", "r", "s", "t",
            "u", "v", "w", "x", "y", "z"
        ];
        public static List<string> GetRamdonMayusLetters(int number)
        {
            List<string> mayusLetterList = [];
            Random random = new();
            for (int i = 0; i < number; i++)
            {
                int indiceAleatorio = random.Next(0, mayusLetters.Length);
                mayusLetterList.Add(mayusLetters[indiceAleatorio]);
            }
            return mayusLetterList;
        }
        public static List<string> GetRamdonMinusLetters(int number)
        {
            List<string> minusLetterList = [];
            Random random = new();
            for (int i = 0; i < number; i++)
            {
                int indiceAleatorio = random.Next(0, minusLetters.Length);
                minusLetterList.Add(minusLetters[indiceAleatorio]);
            }
            return minusLetterList;
        }
        public static List<string> GetRamdonSymbols(int number)
        {
            List<string> symbolList = [];
            Random random = new();
            for (int i = 0; i < number; i++)
            {
                int indiceAleatorio = random.Next(0, symbols.Length);
                symbolList.Add(symbols[indiceAleatorio]);
            }
            return symbolList;
        }
        public static List<string> GetRamdonNumber(int number)
        {
            List<string> numberList = [];
            Random random = new();
            for (int i = 0; i < number; i++)
            {
                int indiceAleatorio = random.Next(0, numbers.Length);
                numberList.Add(numbers[indiceAleatorio]);
            }
            return numberList;
        }
        public static string GeneratePassword(List<string> symbols, List<string> numbers, List<string> mayus, List<string> minus)
        {
            symbols.AddRange(numbers);
            symbols.AddRange(mayus);
            symbols.AddRange(minus);

            // Desordenar (Fisher-Yates shuffle)
            Random random = new();
            for (int i = symbols.Count - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                (symbols[i], symbols[j]) = (symbols[j], symbols[i]); // intercambio de posiciones
            }

            string combinedList = string.Join("", symbols); //Unimos la lista en un string
            return combinedList; //Retornamos la contraseña
        }


    }
}
