using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13Var4
{
    class Program
    {
        public static void WriteChangesAdd(int nom, string Name)//номер элемента, который добавили
        {
            Console.WriteLine($"В список c именем {Name} добавили элемент c номером {nom}");
        }
        public static void WriteChengesDel(int nom, string Name)//номер удаленного элемента
        {
            Console.WriteLine($"Из списка c именем {Name} удалили элемент с номером {nom}");
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
            NewDoubleListConnection<Organization> Ndc = new NewDoubleListConnection<Organization>("Новая коллекция",Mas);
            Ndc.AddTo += WriteChangesAdd;
            Ndc.DelFrom += WriteChengesDel;
            foreach (var b in Mas)
                b.Show();
            Console.WriteLine($"Название коллекции - {Ndc.NameColl}");
            Organization org = new Organization();
            org = (Organization)org.Init();
            Ndc.Add(4, org, Ndc.NameColl);
            Ndc.Delete(3, Ndc.NameColl);
            Ndc.AddDefault(3, Ndc.NameColl);
            NewDoubleListConnection<Organization> Ndc1 = new NewDoubleListConnection<Organization>("Новая коллекция 1", Mas);//создаем коллекию
            NewDoubleListConnection<Organization> Ndc2 = new NewDoubleListConnection<Organization>("Новая коллекция 2", Mas);//создаем коллекцию
            Journal FirstChange = new Journal();
            Journal SecondChange = new Journal();
            //оформляем подписку
            Ndc1.CollectionCountChanged += FirstChange.CollectionCountChanged;
            Ndc1.CollectionReferenceChanged += FirstChange.CollectionReferenceChanged;
            Ndc2.CollectionCountChanged += SecondChange.CollectionReferenceChanged;
            Ndc2.CollectionReferenceChanged += SecondChange.CollectionReferenceChanged;
            Ndc1.AddTo += WriteChangesAdd;
            Ndc1.DelFrom += WriteChengesDel;
            Ndc2.AddTo += WriteChangesAdd;
            Ndc2.DelFrom += WriteChengesDel;
            Organization org1 = new Organization();
            org = (Organization)org.Init();
            Factory Fac1 = new Factory();
            Fac1 = (Factory)Fac1.Init();
            Ndc1.Add(3, org1, Ndc1.NameColl);//добавим элемент в первую коллекцию
            Ndc1.Delete(2, Ndc1.NameColl);//удалим элемент из первой коллекции
            Ndc2.Add(5, Fac1, Ndc2.NameColl );//Добавим элемент во вторую коллекцию
            Ndc2.Delete(1, Ndc2.NameColl);//Удалим элемент из второй коллекции
            //Проверим наши журналы
            Console.Clear();
            Console.WriteLine("Посмотрим наши журналы");
            Console.WriteLine(FirstChange);
            Console.WriteLine(SecondChange);
            Console.ReadKey();
        }
    }
}
