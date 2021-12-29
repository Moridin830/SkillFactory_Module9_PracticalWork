using System;

namespace Task2
{
    class Program
    {
        static void Main()
        {
            // Инициализируем новый объект списка имен
            ListOperations ListOfNames = new ();

            // Заполняем делегаты
            ListOfNames.ListComplete += ListFull;
            ListOfNames.SortModeSelected += AfterSelectingASortingMode;
            ListOfNames.SortComplete += AfterSortComplete;
            
            // ЗАпускаем процесс заполнение списка имен
            ListOfNames.InputNames();

         }

        /// <summary>
        /// Метод-перехватчик события "После заполнения списка имен"
        /// </summary>
        /// <param name="ListOfNames"></param>
        public static void ListFull(ListOperations ListOfNames)
        {
            ListOfNames.SortList();
        }

        /// <summary>
        /// Метод-перехватчик события "После выбора пользователем режима сортировки"
        /// </summary>
        /// <param name="ListOfNames"></param>
        public static void AfterSelectingASortingMode(ListOperations ListOfNames)
        {
            ListOfNames.PerformSort();
        }

        /// <summary>
        /// Метод-перехватчик события "После завершения сортировки"
        /// </summary>
        /// <param name="ListOfNames"></param>
        public static void AfterSortComplete(ListOperations ListOfNames)
        {
            Console.WriteLine("Result of sort:");

            byte NameNumber = 1;
            foreach (string CurrentName in ListOfNames.NameList)
            {
                Console.WriteLine(NameNumber + ". " + CurrentName);
            }
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
