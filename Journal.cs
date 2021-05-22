using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13Var4
{
    public class Journal
    {
        List<JournalEntry> Journal1;//встроенная коллекция, которая хранит запсии об изменениях в пользовательской коллекции
        public Journal()
        {
            Journal1 = new List<JournalEntry>();
        }
        public void CollectionCountChanged(object origin, CollectionHandlerEventArgs CHA)
        {
            JournalEntry jour = new JournalEntry(CHA.NameCollection, CHA.TypeOFChange, CHA.Object.ToString());
            Journal1.Add(jour);
        }
        public void CollectionReferenceChanged(object origin, CollectionHandlerEventArgs CHA)
        {
            JournalEntry jour = new JournalEntry(CHA.NameCollection, CHA.TypeOFChange, CHA.Object.ToString());
            Journal1.Add(jour);
        }
        public override string ToString()
        {
            foreach (var item in Journal1)
            {
                Console.WriteLine(item.ToString());
            }
            return "";
        }
    }
    class JournalEntry
    {
        public string Name { get; set; }
        public string TypeOfChange { get; set; }
        public string Object { get; set; }

        public JournalEntry(string name, string change, string data)
        {
            Name = name;//имя коллекции
            TypeOfChange = change;//информация о типе изменений
            Object = data;//данные объекта, с которым связаны изменения в коллекции
        }

        public override string ToString()
        {
            return "Имя коллекции: " + Name + "\nТип изменения: " + TypeOfChange + "\nОбъект: " + Object;
        }
    }
}

