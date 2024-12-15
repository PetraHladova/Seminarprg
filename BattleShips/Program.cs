using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

internal class Program
{
//program pole

char[,] ourBattleField = new char[11, 11];
    ourBattleField = {
{0,A,B,C,D,E,F,G,H,I,J},
{1,0,0,0,0,0,0,0,0,0,0},
{2,0,0,0,0,0,0,0,0,0,0},
{3,0,0,0,0,0,0,0,0,0,0},
{4,0,0,0,0,0,0,0,0,0,0},
{5,0,0,0,0,0,0,0,0,0,0},
{6,0,0,0,0,0,0,0,0,0,0},
{7,0,0,0,0,0,0,0,0,0,0},
{8,0,0,0,0,0,0,0,0,0,0},
{9,0,0,0,0,0,0,0,0,0,0},
{10,0,0,0,0,0,0,0,0,0,0},
}

char[,] computerBattleField = new char[11, 11];
computerBattleField = {
{ 0,A,B,C,D,E,F,G,H,I,J},
{ 1,0,0,0,0,0,0,0,0,0,0},
{ 2,0,0,0,0,0,0,0,0,0,0},
{ 3,0,0,0,0,0,0,0,0,0,0},
{ 4,0,0,0,0,0,0,0,0,0,0},
{ 5,0,0,0,0,0,0,0,0,0,0},
{ 6,0,0,0,0,0,0,0,0,0,0},
{ 7,0,0,0,0,0,0,0,0,0,0},
{ 8,0,0,0,0,0,0,0,0,0,0},
{ 9,0,0,0,0,0,0,0,0,0,0},
{ 10,0,0,0,0,0,0,0,0,0,0},
}

char[,] computerBattleFieldMyWiew = new char[11, 11];
computerBattleFieldMyWiew = {
{ 0,A,B,C,D,E,F,G,H,I,J},
{ 1,0,0,0,0,0,0,0,0,0,0},
{ 2,0,0,0,0,0,0,0,0,0,0},
{ 3,0,0,0,0,0,0,0,0,0,0},
{ 4,0,0,0,0,0,0,0,0,0,0},
{ 5,0,0,0,0,0,0,0,0,0,0},
{ 6,0,0,0,0,0,0,0,0,0,0},
{ 7,0,0,0,0,0,0,0,0,0,0},
{ 8,0,0,0,0,0,0,0,0,0,0},
{ 9,0,0,0,0,0,0,0,0,0,0},
{ 10,0,0,0,0,0,0,0,0,0,0},
}

static char nothing = '0';
static char boat = '/';
static char miss = '-';
static char hit = '*';
int coordinationX;
int coordinationY;
int shipsUser = 17;
int shipsComputer = 17;

Console.WriteLine("Na začátek hry na pole 10x10 umísti Letadlovou loď 5x1, Bitevní ld 4x1, Křižník 3x1, Ponorka 3x1, Torpédoborec 2x1.");
Console.Readkey();
Console.Writeline();


    while (true)
    {
        //střílí hráč
        Console.Writeline("Vystřelte na souřadnice x a y, nejprve zapište X")
        string firstCoordination = Console.ReadLine();
        coordinationX = Convert.ToInt32(firstCoordination);
        Console.WriteLine("Nyní zapište Y");
        string secondCoordination = Console.ReadLine();
        coordinationY = Convert.ToInt32(secondCoordination);
        if (computerBattleField[coordinationX, coordinationY] = boat
        {
            computerBattleFieldMyWiew[coordinationX, coordinationY] = hit;
            shipsComputer--;
        }
        else
        {
            computerBattleFieldMyWiew[coordinationX, coordinationY] = miss;
        }
        Print2DArray(computerBattleFieldMyWiew);

    //Střílí počítač
    Random rnd = new Random();
    coordinationX = rnd.Next(1, 10);
    coordinationY = rnd.Next(1,10)


        //Konec hry
        if (shipsComputer = 0)
        {
            Console.WriteLine("Vyhráli jste!");
            break;
        }
        else if (shipsUser = 0)
        {
            Console.Writeline("Prohráli jste! :(");
            break;
        }
    }
}