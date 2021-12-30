using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Класс для описания списка имен, вводимых пользователем
    /// </summary>
    public class ListOperations
    {

        // Объявляем события
        // При завершении заполнения списка имен
        public event NotifyOnInputNames ListComplete;
        // При выборе пользователем порядка сортировки
        public event NotifyOnSelectOption SortModeSelected;
        // При завершении сортировки
        public event NotifyOnSortComplete SortComplete;

        // Список имен
        public List<string> NameList { get; set; } = new List<string>();

        // Текущий порядок сортировки
        private SortOptions SortOption { get; set; } = SortOptions.Asc;

        /// <summary>
        /// Метод для заполнения списка имен пользователем
        /// </summary>
        public void InputNames()
        {
            // Предварительно очистим список
            NameList.Clear();

            for (byte NameIndex = 1; NameIndex <= 5; NameIndex++)
            {
                Console.WriteLine($"Input name #{NameIndex}:");
                try
                {
                    string CurrentName = Console.ReadLine();
                    if (CurrentName.Length == 0)
                    {
                        throw new ExceptionForTask("The name cannot be empty");
                    }
                    NameList.Add(CurrentName);
                }
                catch (Exception ex) when (ex is ExceptionForTask)
                {
                    Console.WriteLine(ex.Message);
                    NameIndex--;
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    NameIndex--;
                }
            }

            // Посылаем оповещение о завершении заполнения списка
            OnComletionOfInput();
        }

        /// <summary>
        /// Метод для запроса у пользователя порядка сортировки списка имен
        /// </summary>
        public void SortList()
        {
            try
            {
                // Запрашиваем выбор способа сортировки
                Console.WriteLine("Select sorting option ('1' - ASC, '2' - DESC)");

                // Получаем ответ пользователя
                string CustomerAnswer = Console.ReadLine();

                // Преобразуем в значение внутреннего перечисления
                SortOption = StringToSortOptions(CustomerAnswer);

            }
            catch (Exception ex) when (ex is ExceptionForTask)
            {
                // Если пользователем введено некорректное значение, запрашиваем необходимость повторного ввода
                Console.WriteLine(ex.Message);
                Console.WriteLine("Try again? (yes/no)");

                string UserAnswer = Console.ReadLine();

                // Если пользователь запрашивает повторный ввод - продолжаем. В обратном случае завершаем работу программы
                if(UserAnswer.ToLower() == "yes")
                {
                    SortList();
                }
                else
                {
                    return;
                }
            }
            // Непредвиденное исключение
            catch (Exception ex) when (ex is Exception)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            // Посылаем оповещение о выборе порядка сортировки
            OnCompletionOfSelection();
        }

        /// <summary>
        /// Метод, выполняющий сортировку списка имен
        /// </summary>
        public void PerformSort()
        {
           
            // Выполняем сортировку в алфавитном порядке
            NameList.Sort();

            // Если пользователь выбрал обратный порядок сортировки - переворачиваем список
            if(SortOption == SortOptions.Desc)
             {
                 NameList.Reverse();
             }

            // Посылаем оповещение о завершении сортировки списка
            OnCompletionOfSort();
            
        }

        /// <summary>
        /// Метод, преобразующий введенную пользователем строку в значение внутреннего перечисления "SortOptions"
        /// </summary>
        /// <param name="Option"></param>
        /// <returns></returns>
        private static SortOptions StringToSortOptions(string Option)
        {
            return Option switch
            {
                "1" => SortOptions.Asc,
                "2" => SortOptions.Desc,
                // При вводе значения, отличного от ожидаемых, генерируем исключение
                _ => throw new ExceptionForTask("Incorrect sorting options"),
            };
        }

        /// <summary>
        /// Метод, вызывающий все методы обработчика событий, зарегистрированные в "ListComplete"
        /// </summary>
        protected virtual void OnComletionOfInput()
        {
            ListComplete?.Invoke(this);
        }

        /// <summary>
        /// Метод, вызывающий все методы обработчика событий, зарегистрированные в "SortModeSelected"
        /// </summary>
        protected virtual void OnCompletionOfSelection()
        {
            SortModeSelected?.Invoke(this);
        }

        /// <summary>
        /// Метод, вызывающий все методы обработчика событий, зарегистрированные в "SortComplete"
        /// </summary>
        protected virtual void OnCompletionOfSort()
        {
            SortComplete?.Invoke(this);
        }

    }
}
