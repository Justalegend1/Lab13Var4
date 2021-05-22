using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13Var4
{
    public class CollectionHandlerEventArgs: System.EventArgs
    {   
            public string NameCollection { get; set; }
            public string TypeOFChange { get; set; }
            public object Object { get; set; }

            public CollectionHandlerEventArgs(string name, string type, object obj)//конструктор c именем коллекции, типом изменений и объектом изменения
            {
                NameCollection = name;//имя коллекции
                TypeOFChange = type;//тип изменения
                Object = obj;//сам элемент коллекции
            }
            public override string ToString()//перегрузка метода ToString
            {
                return "Имя коллекции: " + NameCollection + "\nТип изменения: " + TypeOFChange + "\nОбъект: " + Object.ToString();
            }
    }
}
