using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

static void Print2DArray(char[,] arrayToPrint)
{
    for (int i = 0; i < arrayToPrint.GetLength(0); i++)
    {
        for (int j = 0; j < arrayToPrint.GetLength(1); j++)
        {
            Console.Write(arrayToPrint[i, j] + " ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

//program pole

char[,] ourBattleField = {
{'0','A','B','C','D','E','F','G','H','I','J'},
{'1','0','0','0','0','0','0','0','0','0','0'},
{'2','0','0','0','0','0','0','0','0','0','0'},
{'3','0','0','0','0','0','0','0','0','0','0'},
{'4','0','0','0','0','0','0','0','0','0','0'},
{'5','0','0','0','0','0','0','0','0','0','0'},
{'6','0','0','0','0','0','0','0','0','0','0'},
{'7','0','0','0','0','0','0','0','0','0','0'},
{'8','0','0','0','0','0','0','0','0','0','0'},
{'9','0','0','0','0','0','0','0','0','0','0'},
{'X','0','0','0','0','0','0','0','0','0','0'},
};

char[,] computerBattleField = {
{'0','A','B','C','D','E','F','G','H','I','J'},
{'1','0','0','0','0','0','0','0','0','0','0'},
{'2','0','0','0','0','0','0','0','0','0','0'},
{'3','0','0','0','0','0','0','0','0','0','0'},
{'4','0','0','0','0','0','0','0','0','0','0'},
{'5','0','0','0','0','0','0','0','0','0','0'},
{'6','0','0','0','0','0','0','0','0','0','0'},
{'7','0','0','0','0','0','0','0','0','0','0'},
{'8','0','0','0','0','0','0','0','0','0','0'},
{'9','0','0','0','0','0','0','0','0','0','0'},
{'X','0','0','0','0','0','0','0','0','0','0'},
};

char[,] computerBattleFieldMyWiew = {
{'0','A','B','C','D','E','F','G','H','I','J'},
{'1','0','0','0','0','0','0','0','0','0','0'},
{'2','0','0','0','0','0','0','0','0','0','0'},
{'3','0','0','0','0','0','0','0','0','0','0'},
{'4','0','0','0','0','0','0','0','0','0','0'},
{'5','0','0','0','0','0','0','0','0','0','0'},
{'6','0','0','0','0','0','0','0','0','0','0'},
{'7','0','0','0','0','0','0','0','0','0','0'},
{'8','0','0','0','0','0','0','0','0','0','0'},
{'9','0','0','0','0','0','0','0','0','0','0'},
{'X','0','0','0','0','0','0','0','0','0','0'},
};

Print2DArray(ourBattleField);

char nothing = '0';
char boat = '/';
char miss = '-';
char hit = '*';
int coordinationX;
int coordinationY;
int shipsUser = 17;
int shipsComputer = 17;
int orientationComputer;

//Hráč rozmisťuje své lodě
Console.WriteLine("Na začátek hry na pole 10x10 umísti Letadlovou loď 5x1, Bitevní loď 4x1, Křižník 3x1, Ponorka 3x1, Torpédoborec 2x1.");
Console.ReadKey();
Console.WriteLine("První začni největší lodí a pokračuj až po nejmenší");
Console.ReadKey();

//Umístění první lodě
while (true)
{
    Console.WriteLine("Chcete aby loď ležela vodorovně, nebo svisle? (Zadejte vodorovne nebo svisle)");
    string orientation = Convert.ToString(Console.ReadLine());
    if (orientation == "vodorovne")
    {
        Console.WriteLine("Nejprve zadej levou horní krajní sořadnici nejdelší lodě.");
        string firstCoordination = Console.ReadLine();
        if (double.TryParse(firstCoordination, out _))
        {
            coordinationX = Convert.ToInt32(firstCoordination);
            if (6 < coordinationX || coordinationX < 1)
            {
                Console.WriteLine("Souřadnice musí být číslo od jedné do šesti.");
            }
            else
            {
                string secondCoordination = Console.ReadLine();
                if (double.TryParse(secondCoordination, out _))
                {
                    coordinationY = Convert.ToInt32(secondCoordination);
                    if (10 < coordinationY || coordinationY < 1)
                    {
                        Console.WriteLine("Souřadnice musí být číslo od jedné do deseti.");
                    }
                    else
                    {
                        ourBattleField[coordinationX, coordinationY] = boat;
                        for (int i = 0; i < 5; i++)
                        {
                            coordinationX++;
                            ourBattleField[coordinationX, coordinationY] = boat;
                        }
                        Print2DArray(ourBattleField);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Souřadnice musí být číslo.");
                }
            }
        }
        else
        {
            Console.WriteLine("Souřadnice musí být číslo.");
        }
        break;
    }
    else if (orientation == "svisle")
    {
        Console.WriteLine("Nejprve zadej levou horní krajní sořadnici nejdelší lodě.");
        string firstCoordination = Console.ReadLine();
        if (double.TryParse(firstCoordination, out _))
        {
            coordinationX = Convert.ToInt32(firstCoordination);
            if (10 < coordinationX || coordinationX < 1)
            {
                Console.WriteLine("Souřadnice musí být číslo od jedné do deseti.");
            }
            else
            {
                string secondCoordination = Console.ReadLine();
                if (double.TryParse(secondCoordination, out _))
                {
                    coordinationY = Convert.ToInt32(secondCoordination);
                    if (6 < coordinationY || coordinationY < 1)
                    {
                        Console.WriteLine("Souřadnice musí být číslo od jedné do šesti.");
                    }
                    else
                    {
                        ourBattleField[coordinationX, coordinationY] = boat;
                        for (int i = 0; i < 5; i++)
                        {
                            coordinationY++;
                            ourBattleField[coordinationX, coordinationY] = boat;
                        }
                        Print2DArray(ourBattleField);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Souřadnice musí být číslo.");
                }
            }
        }
        else
        {
            Console.WriteLine("Souřadnice musí být číslo.");
        }
    }
    else
    {
        Console.WriteLine("Zadejte vodorovne nebo svisle.");
    }
}

//Umístění druhé lodě
while (true)
{
    Console.WriteLine("Nyní umístěte druhou loď. Chcete aby loď ležela vodorovně, nebo svisle? (Zadejte vodorovne nebo svisle)");
    string orientation2 = Convert.ToString(Console.ReadLine());
    if (orientation2 == "vodorovne")
    {
        Console.WriteLine("Nejprve zadej levou horní krajní sořadnici druhé lodě.");
        string firstCoordination = Console.ReadLine();
        if (int.TryParse(firstCoordination, out _))
        {
            coordinationX = Convert.ToInt32(firstCoordination);
            if (7 < coordinationX || coordinationX < 1)
            {
                Console.WriteLine("Souřadnice musí být číslo od jedné do sedmi.");
            }
            else
            {
                string secondCoordination = Console.ReadLine();
                if (int.TryParse(secondCoordination, out _))
                {
                    coordinationY = Convert.ToInt32(secondCoordination);
                    if (10 < coordinationY || coordinationY < 1)
                    {
                        Console.WriteLine("Souřadnice musí být číslo od jedné do deseti.");
                    }
                    else
                    {
                        if (ourBattleField[coordinationX, coordinationY] == boat || ourBattleField[coordinationX + 1, coordinationY] == boat || ourBattleField[coordinationX + 2, coordinationY] == boat || ourBattleField[coordinationX + 3, coordinationY] == boat)
                        {
                            Console.WriteLine("Lodě se nesmí překrývat!");
                        }
                        else
                        {
                            ourBattleField[coordinationX, coordinationY] = boat;
                            for (int i = 0; i < 4; i++)
                            {
                                coordinationX++;
                                ourBattleField[coordinationX, coordinationY] = boat;
                            }
                            Print2DArray(ourBattleField);
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Souřadnice musí být číslo.");
                }
            }
        }
        else
        {
            Console.WriteLine("Souřadnice musí být číslo.");
        }
    }
    else if (orientation2 == "svisle")
    {
        Console.WriteLine("Nejprve zadej levou horní krajní sořadnici druhé lodě.");
        string firstCoordination = Console.ReadLine();
        if (int.TryParse(firstCoordination, out _))
        {
            coordinationX = Convert.ToInt32(firstCoordination);
            if (10 < coordinationX || coordinationX < 1)
            {
                Console.WriteLine("Souřadnice musí být číslo od jedné do deseti.");
            }
            else
            {
                string secondCoordination = Console.ReadLine();
                if (int.TryParse(secondCoordination, out _))
                {
                    coordinationY = Convert.ToInt32(secondCoordination);
                    if (7 < coordinationY || coordinationY < 1)
                    {
                        Console.WriteLine("Souřadnice musí být číslo od jedné do sedmi.");
                    }
                    else
                    {
                        if (ourBattleField[coordinationX, coordinationY] == boat || ourBattleField[coordinationX, coordinationY + 1] == boat || ourBattleField[coordinationX, coordinationY + 2] == boat || ourBattleField[coordinationX, coordinationY + 3] == boat)
                        {
                            Console.WriteLine("Lodě se nesmí překrývat!");
                        }
                        else
                        {
                            ourBattleField[coordinationX, coordinationY] = boat;
                            for (int i = 0; i < 4; i++)
                            {
                                coordinationY++;
                                ourBattleField[coordinationX, coordinationY] = boat;
                            }
                            Print2DArray(ourBattleField);
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Souřadnice musí být číslo.");
                }
            }
        }
        else
        {
            Console.WriteLine("Souřadnice musí být číslo.");
        }
    }
    else
    {
        Console.WriteLine("Zadejte vodorovne nebo svisle.");
    }
}

//Umístění třetí lodě
while (true)
{
    Console.WriteLine("Nyní umístěte třetí loď. Chcete aby loď ležela vodorovně, nebo svisle? (Zadejte vodorovne nebo svisle)");
    string orientation3 = Convert.ToString(Console.ReadLine());
    if (orientation3 == "vodorovne")
    {
        Console.WriteLine("Nejprve zadej levou horní krajní sořadnici třetí lodě.");
        string firstCoordination = Console.ReadLine();
        if (int.TryParse(firstCoordination, out _))
        {
            coordinationX = Convert.ToInt32(firstCoordination);
            if (8 < coordinationX || coordinationX < 1)
            {
                Console.WriteLine("Souřadnice musí být číslo od jedné do osmi.");
            }
            else
            {
                string secondCoordination = Console.ReadLine();
                if (int.TryParse(secondCoordination, out _))
                {
                    coordinationY = Convert.ToInt32(secondCoordination);
                    if (10 < coordinationY || coordinationY < 1)
                    {
                        Console.WriteLine("Souřadnice musí být číslo od jedné do deseti.");
                    }
                    else
                    {
                        if (ourBattleField[coordinationX, coordinationY] == boat || ourBattleField[coordinationX + 1, coordinationY] == boat || ourBattleField[coordinationX + 2, coordinationY] == boat)
                        {
                            Console.WriteLine("Lodě se nesmí překrývat!");
                        }
                        else
                        {
                            ourBattleField[coordinationX, coordinationY] = boat;
                            for (int i = 0; i < 3; i++)
                            {
                                coordinationX++;
                                ourBattleField[coordinationX, coordinationY] = boat;
                            }
                            Print2DArray(ourBattleField);
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Souřadnice musí být číslo.");
                }
            }
        }
        else
        {
            Console.WriteLine("Souřadnice musí být číslo.");
        }
    }
    else if (orientation3 == "svisle")
    {
        Console.WriteLine("Nejprve zadej levou horní krajní sořadnici třetí lodě.");
        string firstCoordination = Console.ReadLine();
        if (int.TryParse(firstCoordination, out _))
        {
            coordinationX = Convert.ToInt32(firstCoordination);
            if (10 < coordinationX || coordinationX < 1)
            {
                Console.WriteLine("Souřadnice musí být číslo od jedné do deseti.");
            }
            else
            {
                string secondCoordination = Console.ReadLine();
                if (int.TryParse(secondCoordination, out _))
                {
                    coordinationY = Convert.ToInt32(secondCoordination);
                    if (8 < coordinationY || coordinationY < 1)
                    {
                        Console.WriteLine("Souřadnice musí být číslo od jedné do osmi.");
                    }
                    else
                    {
                        if (ourBattleField[coordinationX, coordinationY] == boat || ourBattleField[coordinationX, coordinationY + 1] == boat || ourBattleField[coordinationX, coordinationY + 2] == boat)
                        {
                            Console.WriteLine("Lodě se nesmí překrývat!");
                        }
                        else
                        {
                            ourBattleField[coordinationX, coordinationY] = boat;
                            for (int i = 0; i < 3; i++)
                            {
                                coordinationY++;
                                ourBattleField[coordinationX, coordinationY] = boat;
                            }
                            Print2DArray(ourBattleField);
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Souřadnice musí být číslo.");
                }
            }
        }
        else
        {
            Console.WriteLine("Souřadnice musí být číslo.");
        }
    }
    else
    {
        Console.WriteLine("Zadejte vodorovne nebo svisle.");
    }
}

//Umístění čtvrté lodě
while (true)
{
    Console.WriteLine("Nyní umístěte čtvrtou loď. Chcete aby loď ležela vodorovně, nebo svisle? (Zadejte vodorovne nebo svisle)");
    string orientation4 = Convert.ToString(Console.ReadLine());
    if (orientation4 == "vodorovne")
    {
        Console.WriteLine("Nejprve zadej levou horní krajní sořadnici čtvrté lodě.");
        string firstCoordination = Console.ReadLine();
        if (int.TryParse(firstCoordination, out _))
        {
            coordinationX = Convert.ToInt32(firstCoordination);
            if (8 < coordinationX || coordinationX < 1)
            {
                Console.WriteLine("Souřadnice musí být číslo od jedné do osmi.");
            }
            else
            {
                string secondCoordination = Console.ReadLine();
                if (int.TryParse(secondCoordination, out _))
                {
                    coordinationY = Convert.ToInt32(secondCoordination);
                    if (10 < coordinationY || coordinationY < 1)
                    {
                        Console.WriteLine("Souřadnice musí být číslo od jedné do deseti.");
                    }
                    else
                    {
                        if (ourBattleField[coordinationX, coordinationY] == boat || ourBattleField[coordinationX + 1, coordinationY] == boat || ourBattleField[coordinationX + 2, coordinationY] == boat)
                        {
                            Console.WriteLine("Lodě se nesmí překrývat!");
                        }
                        else
                        {
                            ourBattleField[coordinationX, coordinationY] = boat;
                            for (int i = 0; i < 3; i++)
                            {
                                coordinationX++;
                                ourBattleField[coordinationX, coordinationY] = boat;
                            }
                            Print2DArray(ourBattleField);
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Souřadnice musí být číslo.");
                }
            }
        }
        else
        {
            Console.WriteLine("Souřadnice musí být číslo.");
        }
    }
    else if (orientation4 == "svisle")
    {
        Console.WriteLine("Nejprve zadej levou horní krajní sořadnici čtvrté lodě.");
        string firstCoordination = Console.ReadLine();
        if (int.TryParse(firstCoordination, out _))
        {
            coordinationX = Convert.ToInt32(firstCoordination);
            if (10 < coordinationX || coordinationX < 1)
            {
                Console.WriteLine("Souřadnice musí být číslo od jedné do deseti.");
            }
            else
            {
                string secondCoordination = Console.ReadLine();
                if (int.TryParse(secondCoordination, out _))
                {
                    coordinationY = Convert.ToInt32(secondCoordination);
                    if (8 < coordinationY || coordinationY < 1)
                    {
                        Console.WriteLine("Souřadnice musí být číslo od jedné do osmi.");
                    }
                    else
                    {
                        if (ourBattleField[coordinationX, coordinationY] == boat || ourBattleField[coordinationX, coordinationY + 1] == boat || ourBattleField[coordinationX, coordinationY + 2] == boat)
                        {
                            Console.WriteLine("Lodě se nesmí překrývat!");
                        }
                        else
                        {
                            ourBattleField[coordinationX, coordinationY] = boat;
                            for (int i = 0; i < 3; i++)
                            {
                                coordinationY++;
                                ourBattleField[coordinationX, coordinationY] = boat;
                            }
                            Print2DArray(ourBattleField);
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Souřadnice musí být číslo.");
                }
            }
        }
        else
        {
            Console.WriteLine("Souřadnice musí být číslo.");
        }
    }
    else
    {
        Console.WriteLine("Zadejte vodorovne nebo svisle.");
    }
}

//Umístění páté lodě
while (true)
{
    Console.WriteLine("Nyní umístěte pátou loď. Chcete aby loď ležela vodorovně, nebo svisle? (Zadejte vodorovne nebo svisle)");
    string orientation5 = Convert.ToString(Console.ReadLine());
    if (orientation5 == "vodorovne")
    {
        Console.WriteLine("Nejprve zadej levou horní krajní sořadnici páté lodě.");
        string firstCoordination = Console.ReadLine();
        if (int.TryParse(firstCoordination, out _))
        {
            coordinationX = Convert.ToInt32(firstCoordination);
            if (9 < coordinationX || coordinationX < 1)
            {
                Console.WriteLine("Souřadnice musí být číslo od jedné do devíti.");
            }
            else
            {
                string secondCoordination = Console.ReadLine();
                if (int.TryParse(secondCoordination, out _))
                {
                    coordinationY = Convert.ToInt32(secondCoordination);
                    if (10 < coordinationY || coordinationY < 1)
                    {
                        Console.WriteLine("Souřadnice musí být číslo od jedné do deseti.");
                    }
                    else
                    {
                        if (ourBattleField[coordinationX, coordinationY] == boat || ourBattleField[coordinationX + 1, coordinationY] == boat)
                        {
                            Console.WriteLine("Lodě se nesmí překrývat!");
                        }
                        else
                        {
                            ourBattleField[coordinationX, coordinationY] = boat;
                            coordinationX++;
                            ourBattleField[coordinationX, coordinationY] = boat;
                            Print2DArray(ourBattleField);
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Souřadnice musí být číslo.");
                }
            }
        }
        else
        {
            Console.WriteLine("Souřadnice musí být číslo.");
        }
    }
    else if (orientation5 == "svisle")
    {
        Console.WriteLine("Nejprve zadej levou horní krajní sořadnici páté lodě.");
        string firstCoordination = Console.ReadLine();
        if (int.TryParse(firstCoordination, out _))
        {
            coordinationX = Convert.ToInt32(firstCoordination);
            if (10 < coordinationX || coordinationX < 1)
            {
                Console.WriteLine("Souřadnice musí být číslo od jedné do deseti.");
            }
            else
            {
                string secondCoordination = Console.ReadLine();
                if (int.TryParse(secondCoordination, out _))
                {
                    coordinationY = Convert.ToInt32(secondCoordination);
                    if (9 < coordinationY || coordinationY < 1)
                    {
                        Console.WriteLine("Souřadnice musí být číslo od jedné do devíti.");
                    }
                    else
                    {
                        if (ourBattleField[coordinationX, coordinationY] == boat || ourBattleField[coordinationX, coordinationY + 1] == boat)
                        {
                            Console.WriteLine("Lodě se nesmí překrývat!");
                        }
                        else
                        {
                            ourBattleField[coordinationX, coordinationY] = boat;
                            coordinationY++;
                            ourBattleField[coordinationX, coordinationY] = boat;
                            Print2DArray(ourBattleField);
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Souřadnice musí být číslo.");
                }
            }
        }
        else
        {
            Console.WriteLine("Souřadnice musí být číslo.");
        }
    }
    else
    {
        Console.WriteLine("Zadejte vodorovne nebo svisle.");
    }
}

//Počítač rozmisťuje své lodě
Random rnd = new Random();
//První loď
orientationComputer = rnd.Next(2);
if (orientationComputer ==1)
{
    coordinationX = rnd.Next(1, 6);
    coordinationY = rnd.Next(1, 10);
    computerBattleField[coordinationX, coordinationY] = boat;
    for (int i = 0; i < 4; i++)
    {
        coordinationX++;
        computerBattleField[coordinationX, coordinationY] = boat;
    }
}
else
{
    coordinationX = rnd.Next(1, 10);
    coordinationY = rnd.Next(1, 6);
    computerBattleField[coordinationX, coordinationY] = boat;
    for (int i = 0; i < 4; i++)
    {
        coordinationY++;
        computerBattleField[coordinationX, coordinationY] = boat;
    }
}

//Druhá loď
orientationComputer = rnd.Next(2);
if (orientationComputer == 1)
{
    coordinationX = rnd.Next(1, 7);
    coordinationY = rnd.Next(1, 10);
    while (true)
    {
        if (computerBattleField[coordinationX, coordinationY] == boat || computerBattleField[coordinationX + 1, coordinationY] == boat || computerBattleField[coordinationX + 2, coordinationY] == boat || computerBattleField[coordinationX + 3, coordinationY] == boat)
        {
            coordinationX = rnd.Next(1, 7);
            coordinationY = rnd.Next(1, 10);
        }
        else
        {
            computerBattleField[coordinationX, coordinationY] = boat;
            for (int i = 0; i < 3; i++)
            {
                coordinationX++;
                computerBattleField[coordinationX, coordinationY] = boat;
            }
            break;
        }
    }
}
else
{
    coordinationX = rnd.Next(1, 10);
    coordinationY = rnd.Next(1, 7);
    while (true)
    {
        if (computerBattleField[coordinationX, coordinationY] == boat || computerBattleField[coordinationX, coordinationY + 1] == boat || computerBattleField[coordinationX, coordinationY + 2] == boat || computerBattleField[coordinationX, coordinationY + 3] == boat)
        {
            coordinationX = rnd.Next(1, 10);
            coordinationY = rnd.Next(1, 7);
        }
        else
        {
            computerBattleField[coordinationX, coordinationY] = boat;
            for (int i = 0; i < 3; i++)
            {
                coordinationY++;
                computerBattleField[coordinationX, coordinationY] = boat;
            }
            break;
        }
    }
}

//Třetí loď a čtvrtá loď
for (int i = 0; i < 2; i++)
{
    orientationComputer = rnd.Next(2);
    if (orientationComputer == 1)
    {
        coordinationX = rnd.Next(1, 8);
        coordinationY = rnd.Next(1, 10);
        while (true)
        {
            if (computerBattleField[coordinationX, coordinationY] == boat || computerBattleField[coordinationX + 1, coordinationY] == boat || computerBattleField[coordinationX + 2, coordinationY] == boat)
            {
                coordinationX = rnd.Next(1, 8);
                coordinationY = rnd.Next(1, 10);
            }
            else
            {
                computerBattleField[coordinationX, coordinationY] = boat;
                for (int a = 0; a < 2; a++)
                {
                    coordinationX++;
                    computerBattleField[coordinationX, coordinationY] = boat;
                }
                break;
            }
        }
    }
    else
    {
        while (true)
        {
            if (computerBattleField[coordinationX, coordinationY] == boat || computerBattleField[coordinationX, coordinationY + 1] == boat || computerBattleField[coordinationX, coordinationY + 2] == boat)
            {
                coordinationX = rnd.Next(1, 10);
                coordinationY = rnd.Next(1, 8);
            }
            else
            {
                computerBattleField[coordinationX, coordinationY] = boat;
                for (int b = 0; b < 2; b++)
                {
                    coordinationY++;
                    computerBattleField[coordinationX, coordinationY] = boat;
                }
                break;
            }
        }
    }
}

//Pátá loď
orientationComputer = rnd.Next(2);
if (orientationComputer == 1)
{
    coordinationX = rnd.Next(1, 9);
    coordinationY = rnd.Next(1, 10);
    while (true)
    {
        if (computerBattleField[coordinationX, coordinationY] == boat || computerBattleField[coordinationX + 1, coordinationY] == boat)
        {
            coordinationX = rnd.Next(1, 9);
            coordinationY = rnd.Next(1, 10);
        }
        else
        {
            computerBattleField[coordinationX, coordinationY] = boat;
            computerBattleField[coordinationX + 1, coordinationY] = boat;
            break;
        }
    }
}
else
{
    while (true)
    {
        if (computerBattleField[coordinationX, coordinationY] == boat || computerBattleField[coordinationX, coordinationY + 1] == boat)
        {
            coordinationX = rnd.Next(1, 10);
            coordinationY = rnd.Next(1, 9);
        }
        else
        {
            computerBattleField[coordinationX, coordinationY] = boat;
            computerBattleField[coordinationX , coordinationY + 1] = boat;
            break;
        }
    }
}

//Začíná hra
while (true)
{
    //Střílí hráč
    while (true)
    {
        Console.WriteLine("Vystřelte na souřadnice x a y, nejprve zapište X");
        string firstCoordination = Console.ReadLine();
        if (double.TryParse(firstCoordination, out _))
        {
            coordinationX = Convert.ToInt32(firstCoordination);
            if (10 < coordinationX || coordinationX < 1)
            {
                Console.WriteLine("Souřadnice musí být od jedné do deseti.");
            }
            else
            {
                Console.WriteLine("Nyní zapište Y");
                string secondCoordination = Console.ReadLine();
                if (double.TryParse(secondCoordination, out _))
                {
                    coordinationY = Convert.ToInt32(secondCoordination);
                    if (10 < coordinationY || coordinationY < 1)
                    {
                        Console.WriteLine("Souřadnice musí být od jedné do deseti.");
                    }
                    else
                    {
                        if (computerBattleField[coordinationX, coordinationY] == boat)
                        {
                            computerBattleFieldMyWiew[coordinationX, coordinationY] = hit;
                            shipsComputer--;
                            Console.WriteLine("Trefa!");
                            break;
                        }
                        else
                        {
                            computerBattleFieldMyWiew[coordinationX, coordinationY] = miss;
                            Console.WriteLine("Mimo :(");
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Souřadnice musí být číslo.");
                }
            }
        }
        else
        {
            Console.WriteLine("Souřadnice musí být číslo.");
        }
    }
    //Střílí počítač
    Console.WriteLine("Nyní střílí počítač");
    coordinationX = rnd.Next(1, 10);
    coordinationY = rnd.Next(1, 10);
    if (ourBattleField[coordinationX, coordinationY] == boat)
    {
        ourBattleField[coordinationX, coordinationY] = hit;
        shipsUser--;
    }
    else
    {
        ourBattleField[coordinationX, coordinationY] = miss;
    }


    //Konec hry
    if (shipsUser == 0)
    {
        Console.WriteLine("Prohráli jste! :(");
    }
    else if (shipsComputer == 0)
    {
        Console.WriteLine("Vítězství!!! :D");
        break;
    }
    else
    {
        Console.WriteLine("Stav pole počítače");
        Print2DArray(computerBattleFieldMyWiew);
        Console.WriteLine("Stav tvého pole");
        Print2DArray(ourBattleField);
    }
}

//Zdroje
//2DArrayPlayground
