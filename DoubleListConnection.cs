using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13Var4
{
    public class DoubleListConnection<T> : IEnumerable<T>
    {
        class MyNumerator<T> : IEnumerator<T>
        {
            DoublePointConnection<T> beg;
            DoublePointConnection<T> current;
            public MyNumerator(DoubleListConnection<T> collection)
            {
                //beg = collection.beg;
                current = null;
            }
            public T Current
            {
                get { return current.data; }
            }
            object IEnumerator.Current
            {
                get { return current; }
            }

            //T IEnumerator<T>.Current => throw new NotImplementedException();
            //T IEnumerator<T>.Current
            //{
            //    get { throw  new NotImplementedException(); }
            //}

            public void Dispose()
            { }
            public bool MoveNext()
            {
                if (current == null)
                    current = beg;
                else
                    current = current.next;
                return current != null;
            }
            public void Reset()
            {
                current = this.beg;
            }
        }
        public DoublePointConnection<Organization> beg = null;
        public class DoublePointConnection<T>
        {
            public DoublePointConnection<T> Clone()
            {
                return new DoublePointConnection<T> { data = this.data, next = this.next, pred = this.pred };
            }
            public object ClonePoverx()
            {
                return this.MemberwiseClone();
            }
            public T data;
            public DoublePointConnection<T> next;
            public DoublePointConnection<T> pred;
            public DoublePointConnection()
            {
                data = default;
                next = null;
                pred = null;
            }
            public DoublePointConnection(T d)
            {
                next = null;
                data = d;
                pred = null;
            }

            public override string ToString()
            {
                return data.ToString() + " ";
            }
            public DoublePointConnection(T data, DoublePointConnection<T> next, DoublePointConnection<T> pred)
            {
                this.data = data;
                this.next = next;
                this.pred = pred;
            }
        }
        public DoubleListConnection()
        { }
        public DoubleListConnection(params Organization[] mas)
        {
            DoublePointConnection<Organization> r;
            beg = new DoublePointConnection<Organization>(mas[0]);
            DoublePointConnection<Organization> p = beg;
            for (int i = 1; i < mas.Length; i++)
            {
                DoublePointConnection<Organization> temp = new DoublePointConnection<Organization>(mas[i]);
                DoublePointConnection<Organization> vr = new DoublePointConnection<Organization>(mas[i - 1]);
                p.next = temp;
                p = temp;
                p.pred = vr;
                if (i == mas.Length - 1)
                {
                    r = p;
                    p.next = beg;
                    p = beg;
                    p.pred = r;
                }
            }
        }
        public int Count
        {
            get
            {
                DoublePointConnection<Organization> k = beg;
                int count = 1;
                while (k != beg)
                {
                    count++;
                    k = k.next;
                }
                return count;
            }
        }
        public void Delete(int nom)
        {
            DoublePointConnection<Organization> dp1;
            DoublePointConnection<Organization> dp = beg;
            for (int t = 0; t < nom; t++)
            {
                dp = dp.next;
            }
            dp.next = dp.next.next;
            dp1 = dp;
            dp = dp.next.next;
            dp.pred = dp1;
        }
        static Random rnd = new Random();
        public void Add(int nom, params Organization[] mas)
        {
            DoublePointConnection<Organization> p1 = beg;
            DoublePointConnection<Organization> temp1 = new DoublePointConnection<Organization>(mas[rnd.Next(0, mas.Length - 1)]);
            DoublePointConnection<Organization> vr1;
            DoublePointConnection<Organization> vr2;
            DoublePointConnection<Organization> p2 = beg;
            for (int i = 1; i < nom; i++)
                p2 = p2.next;
            vr2 = p2;
            for (int i = 1; i < nom - 1; i++)
                p1 = p1.next;
            vr1 = p1;
            p1.next = temp1;
            p1 = p1.next;
            p1.pred = vr1;
            p1.next = vr2;
        }
        public void DeleteCollection(T beg)//нужно передать корень коллекции
        {
            this.beg = null;
        }
        public void FindInColl(T beg1, int employee)
        {
            DoublePointConnection<Organization> p = beg;
            while (p != null)
                if (p.data.Number_of_employees == employee)
                    Console.WriteLine(p.ToString());
            p = p.next;
        }
        //методы для нумератора
        public IEnumerator<T> GetEnumerator()
        {
            return new MyNumerator<T>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}
        //конец методов для нумератора
    }
}
