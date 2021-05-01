using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13Var4
{
    class Program
    {
        static void Main(string[] args)
        {
            Organization Org = new Organization("Организация", 235);
            Factory Fac = new Factory("Фабрика", 450, 35, "Лондон");
            Insurance_Company Ins = new Insurance_Company("Страховая компания", 600, 1990, 98);
            Library Lib = new Library("Библиотека", 500, 7, 700);
            Shipbuilding_company Ship = new Shipbuilding_company("Кораблестроительная фирма", 490, 900000, 35);
            Organization[] mas = new Organization[5] { Org, Fac, Ins, Lib, Ship };
            NewDoubleListConnection<Organization> n1 = new NewDoubleListConnection<Organization>(mas);
        }
    }
}
