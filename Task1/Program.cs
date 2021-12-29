using System;

namespace Task1
{
    class Program
    {
        static void Main()
        {

            // Получаем массив исключений
            Exception[] OurExceptions = ExceptionForTask.ArrayOfExceptions();

            // Проходим в цикле по каждому из исключений и выводим сообщение
            foreach(var CurrentException in OurExceptions)
            {

                try
                {
                    throw CurrentException;
                }
                catch (Exception ex) when (ex is ArgumentException)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex) when (ex is ArgumentNullException)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex) when (ex is ArgumentOutOfRangeException)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex) when (ex is IndexOutOfRangeException)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex) when (ex is ExceptionForTask)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            Console.WriteLine("Press any key...");
            Console.ReadKey();

        }
    }

    
}
