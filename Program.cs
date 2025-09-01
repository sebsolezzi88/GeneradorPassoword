using NArreglos;
using SqliteApp;

bool run = true;
string userInput;
SqliteApp.SqliteApp.Init(); //Creacion de la tabla si no existe

while (run)
{
    Console.WriteLine("--- Generador de contraseñas C# ---");
    Console.WriteLine("Ingrese 1-Crear contraseña | 2-Salir");
    Console.Write("Opción: ");

    userInput = Console.ReadLine() ?? "";

    if (string.IsNullOrEmpty(userInput))
    {
        Console.WriteLine("Deber seleccioanar una opción.");
    }
    switch (userInput)
    {
        case "1": //Creando contraseña
            try
            {
                Console.WriteLine("Ahora deberá ingresar la cantidad de letras, números y simbolos que tendrá su contraseña");
                Console.Write("Ingrese la cantidad de simbolos. Mínimo 1, Máximo 6: ");
                int numberOfSymbols = Convert.ToInt32(Console.ReadLine() ?? "1");
                Console.Write("Ingrese la cantidad de letras mayusculas. Mínimo 1, Máximo 6: ");
                int numberOfMayusLetters = Convert.ToInt32(Console.ReadLine() ?? "1");
                Console.Write("Ingrese la cantidad de letras minusculas. Mínimo 1, Máximo 6: ");
                int numberOfMinusLetters = Convert.ToInt32(Console.ReadLine() ?? "1");
                Console.Write("Ingrese la cantidad de números. Mínimo 1, Máximo 6: ");
                int numberOfNumbers = Convert.ToInt32(Console.ReadLine() ?? "1");

                if (numberOfMayusLetters < 0 || numberOfSymbols < 0 ||
                numberOfMinusLetters < 0 || numberOfNumbers < 0)
                {
                    Console.WriteLine("Error: Las cantidades no puede ser negativas.");
                }
                if (numberOfMayusLetters > 6 || numberOfSymbols > 6 ||
                numberOfMinusLetters > 6 || numberOfNumbers > 6)
                {
                    Console.WriteLine("Error: Las cantidad no puede ser mayor a 6.");
                }

                //Generando contraseña
                var symbols = RandomData.GetRamdonSymbols(numberOfSymbols); //Obtenes lista de symbolos aleatorios
                var mayus = RandomData.GetRamdonMayusLetters(numberOfMayusLetters); //Obtenes lista de mayusculas aleatorios
                var minus = RandomData.GetRamdonMinusLetters(numberOfMinusLetters); //Obtenes lista de minus aleatorios
                var numbers = RandomData.GetRamdonNumber(numberOfNumbers); //Obtenes lista de numbers aleatorios

                string password = RandomData.GeneratePassword(symbols, numbers, mayus, minus); //Generamos la contraseña

                //Mostramos la contraseña en pantala
                Console.WriteLine($"La contraseña generada: {password}");
                Console.Write("¿Desea guardar la contraseña generada? S/N: ");
                userInput = Console.ReadLine() ?? "N";
                if (string.Equals(userInput.ToUpper(), "S"))
                {
                    bool inputEmpty = true;
                    while (inputEmpty)
                    {
                        Console.Write("Ingrese un nombre para guardar la contraseña: ");
                        string name = Console.ReadLine() ?? "";
                        if (string.IsNullOrWhiteSpace(name))
                        {
                            Console.WriteLine("Debe ingresar un nombre primero.");
                            continue;
                        }
                        if (name.Length > 20)
                        {
                            Console.WriteLine("El nombre no puede ser mayor a 20 caracteres.");
                            continue;
                        }
                        inputEmpty = false; //Si pasa las validaciones para salir del while
                        if (SqliteApp.SqliteApp.AddPassword(name, password)) //Guardamos el password
                        {
                            Console.WriteLine("Password guardado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("El Password NO fue guardado.");
                        }
                        
                    }
                    
                }
                
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: 1Formato no valido.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: Formato no soportado");
            }
            break;
        case "2": //Cerrar programa
            run = false;
            break;

        default:
            Console.WriteLine("Opción no valida");
            break;
    }


}
