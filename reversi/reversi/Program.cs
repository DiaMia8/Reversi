using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reversi
{
    class Program
    {
        static void Main(string[] args)
        {
            // 4. feladat
            Tabla tabla = new Tabla("allas.txt");
            // 5.feladat
            Console.WriteLine("5. feladat: A betöltött tábla");
            tabla.Megjelenit();

            // 6. feladat
            tabla.Osszegzes(tabla.t);

            //8. feladat
            string parameterLista = "F;4;1;0;1";
            string[] parameter = parameterLista.Split(';');

            Console.WriteLine($"8. feladat: [jatekos;sor;oszlop;iranySor;iranyOszlop] = {parameterLista}");

            if (tabla.VanForditas(Char.Parse(parameter[0]), int.Parse(parameter[1]), int.Parse(parameter[2]), int.Parse(parameter[3]), int.Parse(parameter[4])))
            {
                Console.WriteLine("\tVan fordítás!");
            }
            else
            {
                Console.WriteLine("\tNincs fordítás!");
            }
            //8.feladat
            string parameterLista2 = "K;1;3";
            string[] parameter2 = parameterLista2.Split(';');

            Console.WriteLine($"9. feladat: [jatekos;sor;oszlop] = {parameterLista2}");

            if (tabla.SzabalyosVizsgalat(Char.Parse(parameter2[0]), int.Parse(parameter2[1]), int.Parse(parameter2[2])) == true)
            {
                Console.WriteLine("\tSzabályos lépés!");
            }
            else
            {
                Console.WriteLine("\tNem szabályos!");
            }

            Console.ReadKey();
        }
    }
}
