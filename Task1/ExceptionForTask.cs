using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Исключение для выполнения задания
    /// </summary>
    public class ExceptionForTask : Exception
    {
        public ExceptionForTask()
        {
            
        }

        public ExceptionForTask(string Message) : base(Message)
        {
            
        }

        /// <summary>
        /// Метод, возвращающий массив из 5 исключений разных типов
        /// </summary>
        /// <returns></returns>
        public static Exception[] ArrayOfExceptions()
        {
            Exception[] OurArray = new Exception[5];

            ArgumentException Ex1           = new ();
            ArgumentNullException Ex2       = new ();
            ArgumentOutOfRangeException Ex3 = new ();
            IndexOutOfRangeException Ex4    = new ();
            ExceptionForTask Ex5            = new ();

            OurArray[0] = Ex1;
            OurArray[1] = Ex2;
            OurArray[2] = Ex3;
            OurArray[3] = Ex4;
            OurArray[4] = Ex5;

            return OurArray;
        }
    }
}
