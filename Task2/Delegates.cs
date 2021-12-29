using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Делегат для указания метода, запускающего запрос пользователя о порядке сортировки
    /// </summary>
    /// <param name="ListOfNames"></param>
    public delegate void NotifyOnInputNames(ListOperations ListOfNames);

    /// <summary>
    ///  Делегат для указания метода, запускающего процесс сортировки списка имен
    /// </summary>
    /// <param name="ListOfNames"></param>
    public delegate void NotifyOnSelectOption(ListOperations ListOfNames);

    /// <summary>
    ///  Делегат для указания метода, запускаемого после завершения сортировки списка имен
    /// </summary>
    /// <param name="ListOfNames"></param>
    public delegate void NotifyOnSortComplete(ListOperations ListOfNames);
}
