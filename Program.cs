using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13Var4
{
    class Program
    {
        public static void WriteChangesAdd(int nom)//номер элемента, который добавили
        {
            Console.WriteLine($"В список добавили элемент c номером {nom}");
        }
        public static void WriteChengesDel(int nom)//номер удаленного элемента
        {
            Console.WriteLine($"Из списка удалили элемент с номером {nom}");
        }
        static void Main(string[] args)
        {
            //подписываем методы на события
            int CheckOnInteger(string c)//проверка числа на целое, в качестве параметра входит число или цифра
            {
                bool o = int.TryParse(c, out int number);
                while (!o)
                {
                    Console.WriteLine("Введите целое число");
                    o = int.TryParse(c, out number);
                }
                return number; 
            }
            Console.WriteLine("Введите размер пользовательской коллекции");
            int size = CheckOnInteger(Console.ReadLine());
            Factory[] Mas;
            Mas = NewDoubleListConnection<Organization>.RandomFactory(size);
            NewDoubleListConnection<Organization> Ndc = new NewDoubleListConnection<Organization>(Mas);
            Ndc.AddTo += WriteChangesAdd;
            Ndc.DelFrom += WriteChengesDel;
            foreach (var b in Mas)
                b.Show();
            Ndc.Add(4);
            Ndc.Delete(3);
            Console.ReadKey();
        }
    }
}
