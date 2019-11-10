using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace reversi //1.feladat
{
    class Tabla 
    {
        // 2.feladat
        public char[,] t;

        //3.feladat
        public Tabla(string fajlnev)
        {
            //3.a. feladat
            t = new char[8, 8];
            //3.b feladat
            StreamReader olvas = new StreamReader(fajlnev);

            while (!olvas.EndOfStream)
            {

                for (int i = 0; i < 8; i++)
                {
                    string seged = olvas.ReadLine();
                    char[] seged2 = seged.ToCharArray();
                    for (int j = 0; j < 8; j++)
                    {
                        t[i, j] = seged2[j];
                    }
                }
            }
            olvas.Close();
        }
        // 5.feladat
        public void Megjelenit()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (j == 0)
                    {
                        Console.Write("\t"+ t[i, j]);
                    }

                    else if (j % 7 == 0 && j != 0)
                    {
                        Console.WriteLine(t[i, j]);
                    }
                    else
                    {
                        Console.Write(t[i, j]);
                    }
                }

            }
        }

        public void Osszegzes(char [,] t)
        {
            int feherekSzama = 0;
            int kekekSzama = 0;
            int keresztelSzama = 0;
            foreach (var item in t)
            {
                if (item.Equals('F'))
                {
                    feherekSzama++;
                }
                else if (item.Equals('K'))
                {
                    kekekSzama++;
                }
                else if (item.Equals('#'))
                {
                    keresztelSzama++;
                }
            }
            Console.WriteLine("6.feladat: Összegzés");
            Console.WriteLine($"\tKék korongok száma: {kekekSzama}");
            Console.WriteLine($"\tFehér korongok száma: {feherekSzama}");
            Console.WriteLine($"\tÜres mezők száma: {keresztelSzama}");
        }
        //7.feladat
        public bool VanForditas(char jatekos,int sor, int oszlop, int iranySor, int iranyOszlop)
        {
            int aktSor;
            int aktOszlop;
            bool nincsEllenfel;

            aktSor = sor + iranySor;
            aktOszlop = oszlop + iranyOszlop;

            char ellenfel = 'K';
            if (jatekos == 'K')
            {
                ellenfel = 'F';
            }
            nincsEllenfel = true;

            while (aktSor > 0 && aktSor < 8 && aktOszlop > 0 && aktOszlop < 8 && t[aktSor, aktOszlop] == ellenfel)
            {
                aktSor = aktSor + iranySor;
                aktOszlop = aktOszlop + iranyOszlop;
                nincsEllenfel = false;
            }

            if (nincsEllenfel || aktSor < 0 || aktSor > 7 || aktOszlop < 0 || aktOszlop > 7 || t[aktSor, aktOszlop] != jatekos)
            {
                return false;
            }
            else
            {
            return true;      

            }
        }

        public bool SzabalyosVizsgalat(char jatekos, int sor, int oszlop)
        {
            bool szabalyos = false;
            if (t[sor,oszlop].Equals('#'))
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (VanForditas(jatekos, i, j, sor, oszlop))
                        {
                            szabalyos = true;
                        }
                        
                    }
                }
               
            }
            else
            {
                szabalyos = false;
            }
            return szabalyos;
        }

    }

    
}
