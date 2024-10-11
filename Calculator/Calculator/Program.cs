using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pokud chcete mocnit, první číslo mocníte druhým." + "\n ");

            while (true)
            {
                Console.WriteLine("Zadejte první číslo");
                double number1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Zadejte druhé číslo");
                double number2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Napište jakou číselnou operaci chcete provést ve formě soucet, rozdil...");
                string operation = Convert.ToString(Console.ReadLine());
                double result = 0;
                if (operation == "soucet")
                {
                    result = number1 + number2;
                    Console.WriteLine("Výsledek se rovná " + result);
                }
                else if (operation == "rozdil")
                {
                    result = number1 - number2;
                    Console.WriteLine("Výsledek se rovná " + result);
                }
                else if (operation == "soucin")
                {
                    result = number1 * number2;
                    Console.WriteLine("Výsledek se rovná " + result);
                }
                else if (operation == "podil")
                {
                    if (number2 == 0)
                    {
                        Console.WriteLine("Nelze dělit nulou.");
                    }
                    else
                    {
                        result = number1 / number2;
                        Console.WriteLine("Výsledek se rovná " + result);
                    }
                }
                else if (operation == "mocnina")
                {
                    if (number2 > 1)
                    {
                        double karel = number1;
                        while (number2 > 1)
                        {
                            result = karel * number1;
                            number2--;
                            karel = result;
                        }
                        Console.WriteLine("Výsledek se rovná " + result);
                    }
                    else if (number2 == 1)
                    {
                        result = number1;
                        Console.WriteLine("Výsledek se rovná " + result);
                    }
                    else if (number2 == 0)
                    {
                        result = 1;
                        Console.WriteLine("Výsledek se rovná " + result);
                    }
                    else
                    {
                        double jan = number1;
                        double lukas = 0;
                         while (number2 < -1)
                        {
                            lukas = jan * number1;
                            number2--;
                            jan = lukas;
                        }
                        result = 1 / lukas;
                        Console.WriteLine("Výsledek se rovná 1/" + lukas + ", což se zaokrouhlí na " + result);
                    }
                }
                else
                {
                    Console.WriteLine("Nebyla zadaná operace :(");
                }

                Console.WriteLine(" ");
            }
            /*
             * ZADANI
             * Vytvor program ktery bude fungovat jako kalkulacka. Kroky programu budou nasledujici:
             * 1) Nacte vstup pro prvni cislo od uzivatele (vyuzijte metodu Console.ReadLine() - https://learn.microsoft.com/en-us/dotnet/api/system.console.readline?view=netframework-4.8.
             * 2) Zkonvertuje vstup od uzivatele ze stringu do integeru - https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number.
             * 3) Nacte vstup pro druhe cislo od uzivatele a zkonvertuje ho do integeru. (zopakovani kroku 1 a 2 pro druhe cislo)
             * 4) Nacte vstup pro ciselnou operaci. Rozmysli si, jak operace nazves. Muze to byt "soucet", "rozdil" atd. nebo napr "+", "-", nebo jakkoliv jinak.
             * 5) Nadefinuj integerovou promennou result a prirad ji prozatimne hodnotu 0.
             * 6) Vytvor podminky (if statement), podle kterych urcis, co se bude s cisly dit podle zadane operace
             *    a proved danou operaci - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements.
             * 7) Vypis promennou result do konzole
             * 
             * Rozsireni programu pro rychliky / na doma (na poradi nezalezi):
             * 1) Vypis do konzole pred nactenim kazdeho uzivatelova vstupu co po nem chces (aby vedel, co ma zadat)
             * 2) a) Kontroluj, ze uzivatel do vstupu zadal, co mel (cisla, popr. ciselnou operaci). Pokud zadal neco jineho, napis mu, co ma priste zadat a program ukoncete.
             * 2) b) To same, co a) ale misto ukonceni programu opakovane cti vstup, dokud uzivatel nezada to, co ma
             *       - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-while-statement
             * 3) Umozni uzivateli zadavat i desetinna cisla, tedy prekopej kalkulacku tak, aby umela pracovat s floaty
             */

            Console.ReadKey(); //Toto nech jako posledni radek, aby se program neukoncil ihned, ale cekal na stisk klavesy od uzivatele.
        }
    }
}
