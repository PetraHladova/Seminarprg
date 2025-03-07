using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBlast
{
    internal class Program
    {
        
        //
        static void Main(string[] args)
        {
            void Print2DArray(char[,] arrayToPrint)
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


            char[,] playingField =
            {
                { '0','0','0','0','0','0','0','0'},
                { '0','0','0','0','0','0','0','0'},
                { '0','0','0','0','0','0','0','0'},
                { '0','0','0','0','0','0','0','0'},
                { '0','0','0','0','0','0','0','0'},
                { '0','0','0','0','0','0','0','0'},
                { '0','0','0','0','0','0','0','0'},
                { '0','0','0','0','0','0','0','0'},
            };

            //použité proměnné
            char empty = '0';
            char block = '/';
            int chosenBlock;
            int squareSize;
            int LSize;
            int lineLength;
            int blockType;
            int smallLOrientation;
            int mediumLOrientation;
            int bigLOrientation;
            int line1Orientation;
            int line2Orientation;
            int line3Orientation;
            int line4Orientation;
            int blockTOrientation;
            int blockSOrientation;
            int rectangleOrientation;
            int notPossible = 0;
            int score = 0;
            int coordinationX;
            int coordinationY;

            //Uvedení hráče do hry
            Console.WriteLine("Vítej ve hře block blast!");
            Console.ReadKey();
            Console.WriteLine("V této hře ti budou náhodně vygenerovány blocky, které musíš umístit blocky do hracího pole.");
            Console.ReadKey();
            Console.WriteLine("Tvým cílem je, abys nasbíral co největší score, to se zvyšuje, když položíš nový block, nebo když ,,zničíš” řadu nebo sloupec osmi políček.");
            Console.ReadKey();
            Console.WriteLine("Hodně štěstí!!");
            Console.ReadKey();
            Print2DArray(playingField);
            Console.ReadKey();

            while (notPossible == 0)
            {
                Random rnd = new Random();
                chosenBlock = rnd.Next(1, 5);

                while (true)
                {
                    Console.WriteLine("Umístěte tento block!");
                    if (chosenBlock == 1)
                    {
                        squareSize = rnd.Next(1, 4);
                        if (squareSize == 1)
                        {
                            char[,] smallSquare =
                            {
                                { '/'},
                            };
                            Print2DArray(smallSquare);
                            Console.WriteLine("Je block možné v poli umístit?");
                            string possibility = Convert.ToString(Console.ReadLine());
                            if (possibility == "ano")
                            {
                                while (true)
                                {
                                    Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                    string firstCoordination = Console.ReadLine().Trim();
                                    if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 8)
                                    {
                                        string secondCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 8)
                                        {
                                            coordinationX = Convert.ToInt32(firstCoordination);
                                            coordinationY = Convert.ToInt32(secondCoordination);
                                            if (playingField[coordinationX, coordinationY] == block)
                                            {
                                                Console.WriteLine("Nevidíš, že už tam máš block???");
                                            }
                                            else
                                            {
                                                playingField[coordinationX, coordinationY] = block;
                                                Square square = new Square(1);
                                                int newScore = score + square.CalculateScoreForBlock();
                                                score = newScore;
                                                if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                {
                                                    playingField[coordinationX, 0] = empty;
                                                    playingField[coordinationX, 1] = empty;
                                                    playingField[coordinationX, 2] = empty;
                                                    playingField[coordinationX, 3] = empty;
                                                    playingField[coordinationX, 4] = empty;
                                                    playingField[coordinationX, 5] = empty;
                                                    playingField[coordinationX, 6] = empty;
                                                    playingField[coordinationX, 7] = empty;
                                                    playingField[coordinationX, coordinationY] = block;
                                                    newScore = score + 10;
                                                    score = newScore;

                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        Print2DArray(playingField);
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    else
                                                    {
                                                        Print2DArray(playingField);
                                                        playingField[coordinationX, coordinationY] = empty;
                                                    }
                                                }
                                                else if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                {
                                                    playingField[0, coordinationY] = empty;
                                                    playingField[1, coordinationY] = empty;
                                                    playingField[2, coordinationY] = empty;
                                                    playingField[3, coordinationY] = empty;
                                                    playingField[4, coordinationY] = empty;
                                                    playingField[5, coordinationY] = empty;
                                                    playingField[6, coordinationY] = empty;
                                                    playingField[7, coordinationY] = empty;
                                                    Print2DArray(playingField);
                                                    newScore = score + 10;
                                                    score = newScore;
                                                }
                                                else
                                                {
                                                    Print2DArray(playingField);
                                                }
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Musí se jednat o číslo od 0 do 7");
                                    }
                                }
                                break;
                            }
                            else if (possibility == "ne")
                            {
                                notPossible = 1;
                            }
                            else
                            {
                                Console.WriteLine("Napiš ano nebo ne!");
                            }
                    }
                        else if (squareSize == 2)
                        {
                            char[,] mediumSquare =
                            {
                            { '/','/' },
                            { '/','/' },
                        };
                            Print2DArray(mediumSquare);
                            Console.WriteLine("Je block možné v poli umístit?");
                            string possibility = Convert.ToString(Console.ReadLine());
                            if (possibility == "ano")
                            {
                                while (true)
                                {
                                    Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                    string firstCoordination = Console.ReadLine().Trim();
                                    if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 7)
                                    {
                                        string secondCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 7)
                                        {
                                            coordinationX = Convert.ToInt32(firstCoordination);
                                            coordinationY = Convert.ToInt32(secondCoordination);
                                            if (playingField[coordinationX, coordinationY] == block || playingField[coordinationX + 1, coordinationY] == block || playingField[coordinationX, coordinationY + 1] == block || playingField[coordinationX + 1, coordinationY + 1] == block)
                                            {
                                                Console.WriteLine("Nevidíš, že už tam máš block???");
                                            }
                                            else
                                            {
                                                playingField[coordinationX, coordinationY] = block;
                                                playingField[coordinationX + 1, coordinationY] = block;
                                                playingField[coordinationX, coordinationY + 1] = block;
                                                playingField[coordinationX + 1, coordinationY + 1] = block;
                                                Square square = new Square(2);
                                                int newScore = score + square.CalculateScoreForBlock();
                                                score = newScore;
                                                if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                {
                                                    playingField[coordinationX, 0] = empty;
                                                    playingField[coordinationX, 1] = empty;
                                                    playingField[coordinationX, 2] = empty;
                                                    playingField[coordinationX, 3] = empty;
                                                    playingField[coordinationX, 4] = empty;
                                                    playingField[coordinationX, 5] = empty;
                                                    playingField[coordinationX, 6] = empty;
                                                    playingField[coordinationX, 7] = empty;
                                                    newScore = score + 10;
                                                    score = newScore;
                                                }
                                                if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                {
                                                    playingField[coordinationX + 1, 0] = empty;
                                                    playingField[coordinationX + 1, 1] = empty;
                                                    playingField[coordinationX + 1, 2] = empty;
                                                    playingField[coordinationX + 1, 3] = empty;
                                                    playingField[coordinationX + 1, 4] = empty;
                                                    playingField[coordinationX + 1, 5] = empty;
                                                    playingField[coordinationX + 1, 6] = empty;
                                                    playingField[coordinationX + 1, 7] = empty;
                                                    newScore = score + 10;
                                                    score = newScore;
                                                }
                                                if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                {
                                                    playingField[0, coordinationY] = empty;
                                                    playingField[1, coordinationY] = empty;
                                                    playingField[2, coordinationY] = empty;
                                                    playingField[3, coordinationY] = empty;
                                                    playingField[4, coordinationY] = empty;
                                                    playingField[5, coordinationY] = empty;
                                                    playingField[6, coordinationY] = empty;
                                                    playingField[7, coordinationY] = empty;
                                                    newScore = score + 10;
                                                    score = newScore;
                                                }
                                                if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                {
                                                    playingField[0, coordinationY + 1] = empty;
                                                    playingField[1, coordinationY + 1] = empty;
                                                    playingField[2, coordinationY + 1] = empty;
                                                    playingField[3, coordinationY + 1] = empty;
                                                    playingField[4, coordinationY + 1] = empty;
                                                    playingField[5, coordinationY + 1] = empty;
                                                    playingField[6, coordinationY + 1] = empty;
                                                    playingField[7, coordinationY + 1] = empty;
                                                    newScore = score + 10;
                                                    score = newScore;
                                                }
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Musí se jednat o číslo od 0 do 6");
                                    }
                                }
                                break;
                            }
                            else if (possibility == "ne")
                            {
                                notPossible = 1;
                            }
                            else
                            {
                                Console.WriteLine("Napiš ano nebo ne!");
                            }
                        }
                        else
                        {
                            char[,] bigSquare =
                            {
                            { '/','/','/' },
                            { '/','/','/' },
                            { '/','/','/' },
                        };
                            Print2DArray(bigSquare);
                            Console.WriteLine("Je block možné v poli umístit?");
                            string possibility = Convert.ToString(Console.ReadLine());
                            if (possibility == "ano")
                            {
                                while (true)
                                {
                                    Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                    string firstCoordination = Console.ReadLine().Trim();
                                    if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 6)
                                    {
                                        string secondCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 6)
                                        {
                                            coordinationX = Convert.ToInt32(firstCoordination);
                                            coordinationY = Convert.ToInt32(secondCoordination);
                                            if (playingField[coordinationX, coordinationY] == block || playingField[coordinationX + 1, coordinationY] == block || playingField[coordinationX, coordinationY + 1] == block || playingField[coordinationX + 1, coordinationY + 1] == block || playingField[coordinationX + 2, coordinationY] == block || playingField[coordinationX + 2, coordinationY + 1] == block || playingField[coordinationX, coordinationY + 2] == block || playingField[coordinationX + 1, coordinationY + 2] == block || playingField[coordinationX + 2, coordinationY + 2] == block)
                                            {
                                                Console.WriteLine("Nevidíš, že už tam máš block???");
                                            }
                                            else
                                            {
                                                playingField[coordinationX, coordinationY] = block;
                                                playingField[coordinationX + 1, coordinationY] = block;
                                                playingField[coordinationX, coordinationY + 1] = block;
                                                playingField[coordinationX + 1, coordinationY + 1] = block;
                                                playingField[coordinationX + 2, coordinationY] = block;
                                                playingField[coordinationX, coordinationY + 2] = block;
                                                playingField[coordinationX + 2, coordinationY + 1] = block;
                                                playingField[coordinationX + 1, coordinationY + 2] = block;
                                                playingField[coordinationX + 2, coordinationY + 2] = block;

                                                Square square = new Square(3);
                                                int newScore = score + square.CalculateScoreForBlock();
                                                score = newScore;
                                                if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                {
                                                    playingField[coordinationX, 0] = empty;
                                                    playingField[coordinationX, 1] = empty;
                                                    playingField[coordinationX, 2] = empty;
                                                    playingField[coordinationX, 3] = empty;
                                                    playingField[coordinationX, 4] = empty;
                                                    playingField[coordinationX, 5] = empty;
                                                    playingField[coordinationX, 6] = empty;
                                                    playingField[coordinationX, 7] = empty;
                                                    newScore = score + 10;
                                                    score = newScore;
                                                }
                                                if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                {
                                                    playingField[coordinationX + 1, 0] = empty;
                                                    playingField[coordinationX + 1, 1] = empty;
                                                    playingField[coordinationX + 1, 2] = empty;
                                                    playingField[coordinationX + 1, 3] = empty;
                                                    playingField[coordinationX + 1, 4] = empty;
                                                    playingField[coordinationX + 1, 5] = empty;
                                                    playingField[coordinationX + 1, 6] = empty;
                                                    playingField[coordinationX + 1, 7] = empty;
                                                    newScore = score + 10;
                                                    score = newScore;
                                                }
                                                if (playingField[coordinationX + 2, 0] == block && playingField[coordinationX + 2, 1] == block && playingField[coordinationX + 2, 2] == block && playingField[coordinationX + 2, 3] == block && playingField[coordinationX + 2, 4] == block && playingField[coordinationX + 2, 5] == block && playingField[coordinationX + 2, 6] == block && playingField[coordinationX + 2, 7] == block)
                                                {
                                                    playingField[coordinationX + 2, 0] = empty;
                                                    playingField[coordinationX + 2, 1] = empty;
                                                    playingField[coordinationX + 2, 2] = empty;
                                                    playingField[coordinationX + 2, 3] = empty;
                                                    playingField[coordinationX + 2, 4] = empty;
                                                    playingField[coordinationX + 2, 5] = empty;
                                                    playingField[coordinationX + 2, 6] = empty;
                                                    playingField[coordinationX + 2, 7] = empty;
                                                    newScore = score + 10;
                                                    score = newScore;
                                                }
                                                if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                {
                                                    playingField[0, coordinationY] = empty;
                                                    playingField[1, coordinationY] = empty;
                                                    playingField[2, coordinationY] = empty;
                                                    playingField[3, coordinationY] = empty;
                                                    playingField[4, coordinationY] = empty;
                                                    playingField[5, coordinationY] = empty;
                                                    playingField[6, coordinationY] = empty;
                                                    playingField[7, coordinationY] = empty;
                                                    newScore = score + 10;
                                                    score = newScore;
                                                }
                                                if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                {
                                                    playingField[0, coordinationY + 1] = empty;
                                                    playingField[1, coordinationY + 1] = empty;
                                                    playingField[2, coordinationY + 1] = empty;
                                                    playingField[3, coordinationY + 1] = empty;
                                                    playingField[4, coordinationY + 1] = empty;
                                                    playingField[5, coordinationY + 1] = empty;
                                                    playingField[6, coordinationY + 1] = empty;
                                                    playingField[7, coordinationY + 1] = empty;
                                                    newScore = score + 10;
                                                    score = newScore;
                                                }
                                                if (playingField[0, coordinationY + 2] == block && playingField[1, coordinationY + 2] == block && playingField[2, coordinationY + 2] == block && playingField[3, coordinationY + 2] == block && playingField[4, coordinationY + 2] == block && playingField[5, coordinationY + 2] == block && playingField[6, coordinationY + 2] == block && playingField[7, coordinationY + 2] == block)
                                                {
                                                    playingField[0, coordinationY + 2] = empty;
                                                    playingField[1, coordinationY + 2] = empty;
                                                    playingField[2, coordinationY + 2] = empty;
                                                    playingField[3, coordinationY + 2] = empty;
                                                    playingField[4, coordinationY + 2] = empty;
                                                    playingField[5, coordinationY + 2] = empty;
                                                    playingField[6, coordinationY + 2] = empty;
                                                    playingField[7, coordinationY + 2] = empty;
                                                    newScore = score + 10;
                                                    score = newScore;
                                                }
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Musí se jednat o číslo od 0 do 5");
                                    }
                                }
                                break;
                            }
                            else if (possibility == "ne")
                            {
                                notPossible = 1;
                            }
                            else
                            {
                                Console.WriteLine("Napiš ano nebo ne!");
                            }
                        }
                    }
                    else if (chosenBlock == 2)
                    {
                        LSize = rnd.Next(1, 4);
                        if (LSize == 1)
                        {
                            smallLOrientation = rnd.Next(1, 5);
                            if (smallLOrientation == 1)
                            {
                                char[,] smallL1 =
                                {
                                { '/','0'},
                                { '/','/'},
                            };
                                Print2DArray(smallL1);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 7)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 7)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY] == block || playingField[coordinationX + 1, coordinationY] == block || playingField[coordinationX, coordinationY + 1] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY] = block;
                                                    playingField[coordinationX + 1, coordinationY] = block;
                                                    playingField[coordinationX, coordinationY + 1] = block;
              
                                                    BlockL lblock = new BlockL(1);
                                                    int newScore = score + lblock.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Musí se jednat o číslo od 0 do 6");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                            else if (smallLOrientation == 2)
                            {
                                char[,] smallL2 =
                                {
                                { '0','/'},
                                { '/','/'},
                            };
                                Print2DArray(smallL2);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 7)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 7)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY] == block || playingField[coordinationX + 1, coordinationY] == block || playingField[coordinationX + 1, coordinationY + 1] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY] = block;
                                                    playingField[coordinationX + 1, coordinationY] = block;
                                                    playingField[coordinationX + 1, coordinationY + 1] = block;
                                                    BlockL lblock = new BlockL(1);
                                                    int newScore = score + lblock.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Musí se jednat o číslo od 0 do 6");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                            else if (smallLOrientation == 3)
                            {
                                char[,] smallL3 =
                                {
                                { '/','/'},
                                { '0','/'},
                            };
                                Print2DArray(smallL3);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 7)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 7)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX + 1, coordinationY] == block || playingField[coordinationX, coordinationY + 1] == block || playingField[coordinationX + 1, coordinationY + 1] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX + 1, coordinationY] = block;
                                                    playingField[coordinationX, coordinationY + 1] = block;
                                                    playingField[coordinationX + 1, coordinationY + 1] = block;
                                                    BlockL lblock = new BlockL(1);
                                                    int newScore = score + lblock.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Musí se jednat o číslo od 0 do 6");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                            else
                            {
                                char[,] smallL4 =
                                {
                                { '/','/'},
                                { '/','0'},
                            };
                                Print2DArray(smallL4);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 7)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 7)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY] == block || playingField[coordinationX, coordinationY + 1] == block || playingField[coordinationX + 1, coordinationY + 1] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY] = block;
                                                    playingField[coordinationX, coordinationY + 1] = block;
                                                    playingField[coordinationX + 1, coordinationY + 1] = block;
                                                    BlockL lblock = new BlockL(1);
                                                    int newScore = score + lblock.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Musí se jednat o číslo od 0 do 6");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                        }
                        else if (LSize == 2)
                        {
                            mediumLOrientation = rnd.Next(1, 9);
                            if (mediumLOrientation == 1)
                            {
                                char[,] mediumL1 =
                                {
                                { '/','0'},
                                { '/','0'},
                                { '/','/'},
                            };
                                Print2DArray(mediumL1);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 7)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 6)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY] == block || playingField[coordinationX + 1, coordinationY] == block || playingField[coordinationX, coordinationY + 1] == block || playingField[coordinationX, coordinationY + 2] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY] = block;
                                                    playingField[coordinationX + 1, coordinationY] = block;
                                                    playingField[coordinationX, coordinationY + 1] = block;
                                                    playingField[coordinationX, coordinationY + 2] = block;
                                                    BlockL lblock = new BlockL(2);
                                                    int newScore = score + lblock.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 2] == block && playingField[1, coordinationY + 2] == block && playingField[2, coordinationY + 2] == block && playingField[3, coordinationY + 2] == block && playingField[4, coordinationY + 2] == block && playingField[5, coordinationY + 2] == block && playingField[6, coordinationY + 2] == block && playingField[7, coordinationY + 2] == block)
                                                    {
                                                        playingField[0, coordinationY + 2] = empty;
                                                        playingField[1, coordinationY + 2] = empty;
                                                        playingField[2, coordinationY + 2] = empty;
                                                        playingField[3, coordinationY + 2] = empty;
                                                        playingField[4, coordinationY + 2] = empty;
                                                        playingField[5, coordinationY + 2] = empty;
                                                        playingField[6, coordinationY + 2] = empty;
                                                        playingField[7, coordinationY + 2] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Y musí být číslo od 0 do 6 a X od 0 do 5");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                            else if (mediumLOrientation == 2)
                            {
                                char[,] mediumL2 =
                                {
                                { '0','/'},
                                { '0','/'},
                                { '/','/'},
                            };
                                Print2DArray(mediumL2);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 7)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 6)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY] == block || playingField[coordinationX + 1, coordinationY] == block || playingField[coordinationX + 1, coordinationY + 1] == block || playingField[coordinationX + 1, coordinationY + 2] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY] = block;
                                                    playingField[coordinationX + 1, coordinationY] = block;
                                                    playingField[coordinationX + 1, coordinationY + 1] = block;
                                                    playingField[coordinationX + 1, coordinationY + 2] = block;
                                                    BlockL lblock = new BlockL(2);
                                                    int newScore = score + lblock.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 2] == block && playingField[1, coordinationY + 2] == block && playingField[2, coordinationY + 2] == block && playingField[3, coordinationY + 2] == block && playingField[4, coordinationY + 2] == block && playingField[5, coordinationY + 2] == block && playingField[6, coordinationY + 2] == block && playingField[7, coordinationY + 2] == block)
                                                    {
                                                        playingField[0, coordinationY + 2] = empty;
                                                        playingField[1, coordinationY + 2] = empty;
                                                        playingField[2, coordinationY + 2] = empty;
                                                        playingField[3, coordinationY + 2] = empty;
                                                        playingField[4, coordinationY + 2] = empty;
                                                        playingField[5, coordinationY + 2] = empty;
                                                        playingField[6, coordinationY + 2] = empty;
                                                        playingField[7, coordinationY + 2] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Y musí být číslo od 0 do 6 a X od 0 do 5");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                            else if (mediumLOrientation == 3)
                            {
                                char[,] mediumL3 =
                                {
                                { '/','/'},
                                { '/','0'},
                                { '/','0'},
                            };
                                Print2DArray(mediumL3);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 7)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 6)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY] == block || playingField[coordinationX + 1, coordinationY + 2] == block || playingField[coordinationX, coordinationY + 1] == block || playingField[coordinationX, coordinationY + 2] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY] = block;
                                                    playingField[coordinationX + 1, coordinationY + 2] = block;
                                                    playingField[coordinationX, coordinationY + 1] = block;
                                                    playingField[coordinationX, coordinationY + 2] = block;
                                                    BlockL lblock = new BlockL(2);
                                                    int newScore = score + lblock.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 2] == block && playingField[1, coordinationY + 2] == block && playingField[2, coordinationY + 2] == block && playingField[3, coordinationY + 2] == block && playingField[4, coordinationY + 2] == block && playingField[5, coordinationY + 2] == block && playingField[6, coordinationY + 2] == block && playingField[7, coordinationY + 2] == block)
                                                    {
                                                        playingField[0, coordinationY + 2] = empty;
                                                        playingField[1, coordinationY + 2] = empty;
                                                        playingField[2, coordinationY + 2] = empty;
                                                        playingField[3, coordinationY + 2] = empty;
                                                        playingField[4, coordinationY + 2] = empty;
                                                        playingField[5, coordinationY + 2] = empty;
                                                        playingField[6, coordinationY + 2] = empty;
                                                        playingField[7, coordinationY + 2] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Y musí být číslo od 0 do 6 a X od 0 do 5");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                            else if (mediumLOrientation == 4)
                            {
                                char[,] mediumL4 =
                                {
                                { '/','/'},
                                { '0','/'},
                                { '0','/'},
                            };
                                Print2DArray(mediumL4);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 7)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 6)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX + 1, coordinationY] == block || playingField[coordinationX + 1, coordinationY + 1] == block || playingField[coordinationX + 1, coordinationY + 2] == block || playingField[coordinationX, coordinationY + 2] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX + 1, coordinationY] = block;
                                                    playingField[coordinationX + 1, coordinationY + 1] = block;
                                                    playingField[coordinationX + 1, coordinationY + 2] = block;
                                                    playingField[coordinationX, coordinationY + 2] = block;
                                                    BlockL lblock = new BlockL(2);
                                                    int newScore = score + lblock.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 2] == block && playingField[1, coordinationY + 2] == block && playingField[2, coordinationY + 2] == block && playingField[3, coordinationY + 2] == block && playingField[4, coordinationY + 2] == block && playingField[5, coordinationY + 2] == block && playingField[6, coordinationY + 2] == block && playingField[7, coordinationY + 2] == block)
                                                    {
                                                        playingField[0, coordinationY + 2] = empty;
                                                        playingField[1, coordinationY + 2] = empty;
                                                        playingField[2, coordinationY + 2] = empty;
                                                        playingField[3, coordinationY + 2] = empty;
                                                        playingField[4, coordinationY + 2] = empty;
                                                        playingField[5, coordinationY + 2] = empty;
                                                        playingField[6, coordinationY + 2] = empty;
                                                        playingField[7, coordinationY + 2] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Y musí být číslo od 0 do 6 a X od 0 do 5");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                            else if (mediumLOrientation == 5)
                            {
                                char[,] mediumL5 =
                                {
                                { '/','0','0'},
                                { '/','/','/'},
                            };
                                Print2DArray(mediumL5);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 6)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 7)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY] == block || playingField[coordinationX + 1, coordinationY] == block || playingField[coordinationX, coordinationY + 1] == block || playingField[coordinationX + 2, coordinationY] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY] = block;
                                                    playingField[coordinationX + 1, coordinationY] = block;
                                                    playingField[coordinationX, coordinationY + 1] = block;
                                                    playingField[coordinationX + 2, coordinationY] = block;
                                                    BlockL lblock = new BlockL(2);
                                                    int newScore = score + lblock.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 2] == block && playingField[1, coordinationY + 2] == block && playingField[2, coordinationY + 2] == block && playingField[3, coordinationY + 2] == block && playingField[4, coordinationY + 2] == block && playingField[5, coordinationY + 2] == block && playingField[6, coordinationY + 2] == block && playingField[7, coordinationY + 2] == block)
                                                    {
                                                        playingField[coordinationX + 2, 0] = empty;
                                                        playingField[coordinationX + 2, 1] = empty;
                                                        playingField[coordinationX + 2, 2] = empty;
                                                        playingField[coordinationX + 2, 3] = empty;
                                                        playingField[coordinationX + 2, 4] = empty;
                                                        playingField[coordinationX + 2, 5] = empty;
                                                        playingField[coordinationX + 2, 6] = empty;
                                                        playingField[coordinationX + 2, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Y musí být číslo od 0 do 5 a X od 0 do 6");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                            else if (mediumLOrientation == 6)
                            {
                                char[,] mediumL6 =
                                {
                                { '0','0','/'},
                                { '/','/','/'},
                            };
                                Print2DArray(mediumL6);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 6)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 7)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY] == block || playingField[coordinationX + 1, coordinationY] == block || playingField[coordinationX + 2, coordinationY + 1] == block || playingField[coordinationX + 2, coordinationY] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY] = block;
                                                    playingField[coordinationX + 1, coordinationY] = block;
                                                    playingField[coordinationX + 2, coordinationY + 1] = block;
                                                    playingField[coordinationX + 2, coordinationY] = block;
                                                    BlockL lblock = new BlockL(2);
                                                    int newScore = score + lblock.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 2] == block && playingField[1, coordinationY + 2] == block && playingField[2, coordinationY + 2] == block && playingField[3, coordinationY + 2] == block && playingField[4, coordinationY + 2] == block && playingField[5, coordinationY + 2] == block && playingField[6, coordinationY + 2] == block && playingField[7, coordinationY + 2] == block)
                                                    {
                                                        playingField[coordinationX + 2, 0] = empty;
                                                        playingField[coordinationX + 2, 1] = empty;
                                                        playingField[coordinationX + 2, 2] = empty;
                                                        playingField[coordinationX + 2, 3] = empty;
                                                        playingField[coordinationX + 2, 4] = empty;
                                                        playingField[coordinationX + 2, 5] = empty;
                                                        playingField[coordinationX + 2, 6] = empty;
                                                        playingField[coordinationX + 2, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Y musí být číslo od 0 do 5 a X od 0 do 6");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                            else if (mediumLOrientation == 7)
                            {
                                char[,] mediumL7 =
                                {
                                { '/','/','/'},
                                { '/','0','0'},
                            };
                                Print2DArray(mediumL7);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 6)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 7)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY] == block || playingField[coordinationX + 1, coordinationY + 1] == block || playingField[coordinationX, coordinationY + 1] == block || playingField[coordinationX + 2, coordinationY + 1] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY] = block;
                                                    playingField[coordinationX + 1, coordinationY + 1] = block;
                                                    playingField[coordinationX, coordinationY + 1] = block;
                                                    playingField[coordinationX + 2, coordinationY + 1] = block;
                                                    BlockL lblock = new BlockL(2);
                                                    int newScore = score + lblock.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 2] == block && playingField[1, coordinationY + 2] == block && playingField[2, coordinationY + 2] == block && playingField[3, coordinationY + 2] == block && playingField[4, coordinationY + 2] == block && playingField[5, coordinationY + 2] == block && playingField[6, coordinationY + 2] == block && playingField[7, coordinationY + 2] == block)
                                                    {
                                                        playingField[coordinationX + 2, 0] = empty;
                                                        playingField[coordinationX + 2, 1] = empty;
                                                        playingField[coordinationX + 2, 2] = empty;
                                                        playingField[coordinationX + 2, 3] = empty;
                                                        playingField[coordinationX + 2, 4] = empty;
                                                        playingField[coordinationX + 2, 5] = empty;
                                                        playingField[coordinationX + 2, 6] = empty;
                                                        playingField[coordinationX + 2, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Y musí být číslo od 0 do 5 a X od 0 do 6");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                            else
                            {
                                char[,] mediumL8 =
                                {
                                { '/','/','/'},
                                { '0','0','/'},
                            };
                                Print2DArray(mediumL8);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 6)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 7)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY + 1] == block || playingField[coordinationX + 1, coordinationY + 1] == block || playingField[coordinationX + 2, coordinationY + 1] == block || playingField[coordinationX + 2, coordinationY] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY + 1] = block;
                                                    playingField[coordinationX + 1, coordinationY + 1] = block;
                                                    playingField[coordinationX + 2, coordinationY + 1] = block;
                                                    playingField[coordinationX + 2, coordinationY] = block;
                                                    BlockL lblock = new BlockL(2);
                                                    int newScore = score + lblock.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 2] == block && playingField[1, coordinationY + 2] == block && playingField[2, coordinationY + 2] == block && playingField[3, coordinationY + 2] == block && playingField[4, coordinationY + 2] == block && playingField[5, coordinationY + 2] == block && playingField[6, coordinationY + 2] == block && playingField[7, coordinationY + 2] == block)
                                                    {
                                                        playingField[coordinationX + 2, 0] = empty;
                                                        playingField[coordinationX + 2, 1] = empty;
                                                        playingField[coordinationX + 2, 2] = empty;
                                                        playingField[coordinationX + 2, 3] = empty;
                                                        playingField[coordinationX + 2, 4] = empty;
                                                        playingField[coordinationX + 2, 5] = empty;
                                                        playingField[coordinationX + 2, 6] = empty;
                                                        playingField[coordinationX + 2, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Y musí být číslo od 0 do 5 a X od 0 do 6");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                        }
                        else
                        {
                            bigLOrientation = rnd.Next(1, 5);
                            if (bigLOrientation == 1)
                            {
                                char[,] bigL1 =
                                {
                                    { '/','0','0'},
                                    { '/','0','0'},
                                    { '/','/','/'},
                                };
                                Print2DArray(bigL1);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 6)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 6)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY] == block || playingField[coordinationX + 1, coordinationY] == block || playingField[coordinationX + 2, coordinationY] == block || playingField[coordinationX, coordinationY + 1] == block || playingField[coordinationX, coordinationY + 2] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY] = block;
                                                    playingField[coordinationX + 1, coordinationY] = block;
                                                    playingField[coordinationX + 2, coordinationY] = block;
                                                    playingField[coordinationX, coordinationY + 1] = block;
                                                    playingField[coordinationX, coordinationY + 2] = block;
                                                    BlockL lblock = new BlockL(3);
                                                    int newScore = score + lblock.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 2, 0] == block && playingField[coordinationX + 2, 1] == block && playingField[coordinationX + 2, 2] == block && playingField[coordinationX + 2, 3] == block && playingField[coordinationX + 2, 4] == block && playingField[coordinationX + 2, 5] == block && playingField[coordinationX + 2, 6] == block && playingField[coordinationX + 2, 7] == block)
                                                    {
                                                        playingField[coordinationX + 2, 0] = empty;
                                                        playingField[coordinationX + 2, 1] = empty;
                                                        playingField[coordinationX + 2, 2] = empty;
                                                        playingField[coordinationX + 2, 3] = empty;
                                                        playingField[coordinationX + 2, 4] = empty;
                                                        playingField[coordinationX + 2, 5] = empty;
                                                        playingField[coordinationX + 2, 6] = empty;
                                                        playingField[coordinationX + 2, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 2] == block && playingField[1, coordinationY + 2] == block && playingField[2, coordinationY + 2] == block && playingField[3, coordinationY + 2] == block && playingField[4, coordinationY + 2] == block && playingField[5, coordinationY + 2] == block && playingField[6, coordinationY + 2] == block && playingField[7, coordinationY + 2] == block)
                                                    {
                                                        playingField[0, coordinationY + 2] = empty;
                                                        playingField[1, coordinationY + 2] = empty;
                                                        playingField[2, coordinationY + 2] = empty;
                                                        playingField[3, coordinationY + 2] = empty;
                                                        playingField[4, coordinationY + 2] = empty;
                                                        playingField[5, coordinationY + 2] = empty;
                                                        playingField[6, coordinationY + 2] = empty;
                                                        playingField[7, coordinationY + 2] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Číslo od 0 do 5!");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                            else if (bigLOrientation == 2)
                            {
                                char[,] bigL2 =
                                {
                                    { '0','0','/'},
                                    { '0','0','/'},
                                    { '/','/','/'},
                                };
                                Print2DArray(bigL2);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 6)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 6)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY] == block || playingField[coordinationX + 1, coordinationY] == block || playingField[coordinationX + 2, coordinationY] == block || playingField[coordinationX + 2, coordinationY + 1] == block || playingField[coordinationX + 2, coordinationY + 2] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY] = block;
                                                    playingField[coordinationX + 1, coordinationY] = block;
                                                    playingField[coordinationX + 2, coordinationY] = block;
                                                    playingField[coordinationX + 2, coordinationY + 1] = block;
                                                    playingField[coordinationX + 2, coordinationY + 2] = block;
                                                    BlockL lblock = new BlockL(3);
                                                    int newScore = score + lblock.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 2, 0] == block && playingField[coordinationX + 2, 1] == block && playingField[coordinationX + 2, 2] == block && playingField[coordinationX + 2, 3] == block && playingField[coordinationX + 2, 4] == block && playingField[coordinationX + 2, 5] == block && playingField[coordinationX + 2, 6] == block && playingField[coordinationX + 2, 7] == block)
                                                    {
                                                        playingField[coordinationX + 2, 0] = empty;
                                                        playingField[coordinationX + 2, 1] = empty;
                                                        playingField[coordinationX + 2, 2] = empty;
                                                        playingField[coordinationX + 2, 3] = empty;
                                                        playingField[coordinationX + 2, 4] = empty;
                                                        playingField[coordinationX + 2, 5] = empty;
                                                        playingField[coordinationX + 2, 6] = empty;
                                                        playingField[coordinationX + 2, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 2] == block && playingField[1, coordinationY + 2] == block && playingField[2, coordinationY + 2] == block && playingField[3, coordinationY + 2] == block && playingField[4, coordinationY + 2] == block && playingField[5, coordinationY + 2] == block && playingField[6, coordinationY + 2] == block && playingField[7, coordinationY + 2] == block)
                                                    {
                                                        playingField[0, coordinationY + 2] = empty;
                                                        playingField[1, coordinationY + 2] = empty;
                                                        playingField[2, coordinationY + 2] = empty;
                                                        playingField[3, coordinationY + 2] = empty;
                                                        playingField[4, coordinationY + 2] = empty;
                                                        playingField[5, coordinationY + 2] = empty;
                                                        playingField[6, coordinationY + 2] = empty;
                                                        playingField[7, coordinationY + 2] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Číslo od 0 do 5!");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                            else if (bigLOrientation == 3)
                            {
                                char[,] bigL3 =
                                {
                                    { '/','/','/'},
                                    { '0','0','/'},
                                    { '0','0','/'},
                                };
                                Print2DArray(bigL3);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 6)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 6)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY + 2] == block || playingField[coordinationX + 1, coordinationY + 2] == block || playingField[coordinationX + 2, coordinationY + 2] == block || playingField[coordinationX + 2, coordinationY + 1] == block || playingField[coordinationX + 2, coordinationY] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY + 2] = block;
                                                    playingField[coordinationX + 1, coordinationY + 2] = block;
                                                    playingField[coordinationX + 2, coordinationY + 2] = block;
                                                    playingField[coordinationX + 2, coordinationY + 1] = block;
                                                    playingField[coordinationX + 2, coordinationY] = block;
                                                    BlockL lblock = new BlockL(3);
                                                    int newScore = score + lblock.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 2, 0] == block && playingField[coordinationX + 2, 1] == block && playingField[coordinationX + 2, 2] == block && playingField[coordinationX + 2, 3] == block && playingField[coordinationX + 2, 4] == block && playingField[coordinationX + 2, 5] == block && playingField[coordinationX + 2, 6] == block && playingField[coordinationX + 2, 7] == block)
                                                    {
                                                        playingField[coordinationX + 2, 0] = empty;
                                                        playingField[coordinationX + 2, 1] = empty;
                                                        playingField[coordinationX + 2, 2] = empty;
                                                        playingField[coordinationX + 2, 3] = empty;
                                                        playingField[coordinationX + 2, 4] = empty;
                                                        playingField[coordinationX + 2, 5] = empty;
                                                        playingField[coordinationX + 2, 6] = empty;
                                                        playingField[coordinationX + 2, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 2] == block && playingField[1, coordinationY + 2] == block && playingField[2, coordinationY + 2] == block && playingField[3, coordinationY + 2] == block && playingField[4, coordinationY + 2] == block && playingField[5, coordinationY + 2] == block && playingField[6, coordinationY + 2] == block && playingField[7, coordinationY + 2] == block)
                                                    {
                                                        playingField[0, coordinationY + 2] = empty;
                                                        playingField[1, coordinationY + 2] = empty;
                                                        playingField[2, coordinationY + 2] = empty;
                                                        playingField[3, coordinationY + 2] = empty;
                                                        playingField[4, coordinationY + 2] = empty;
                                                        playingField[5, coordinationY + 2] = empty;
                                                        playingField[6, coordinationY + 2] = empty;
                                                        playingField[7, coordinationY + 2] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Číslo od 0 do 5!");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                            else
                            {
                                char[,] bigL4 =
                                {
                                    { '/','/','/'},
                                    { '/','0','0'},
                                    { '/','0','0'},
                                };
                                Print2DArray(bigL4);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 6)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 6)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY + 2] == block || playingField[coordinationX + 1, coordinationY + 2] == block || playingField[coordinationX + 2, coordinationY + 2] == block || playingField[coordinationX, coordinationY + 1] == block || playingField[coordinationX, coordinationY] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY + 2] = block;
                                                    playingField[coordinationX + 1, coordinationY + 2] = block;
                                                    playingField[coordinationX + 2, coordinationY + 2] = block;
                                                    playingField[coordinationX, coordinationY + 1] = block;
                                                    playingField[coordinationX, coordinationY] = block;
                                                    BlockL lblock = new BlockL(3);
                                                    int newScore = score + lblock.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 2, 0] == block && playingField[coordinationX + 2, 1] == block && playingField[coordinationX + 2, 2] == block && playingField[coordinationX + 2, 3] == block && playingField[coordinationX + 2, 4] == block && playingField[coordinationX + 2, 5] == block && playingField[coordinationX + 2, 6] == block && playingField[coordinationX + 2, 7] == block)
                                                    {
                                                        playingField[coordinationX + 2, 0] = empty;
                                                        playingField[coordinationX + 2, 1] = empty;
                                                        playingField[coordinationX + 2, 2] = empty;
                                                        playingField[coordinationX + 2, 3] = empty;
                                                        playingField[coordinationX + 2, 4] = empty;
                                                        playingField[coordinationX + 2, 5] = empty;
                                                        playingField[coordinationX + 2, 6] = empty;
                                                        playingField[coordinationX + 2, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 2] == block && playingField[1, coordinationY + 2] == block && playingField[2, coordinationY + 2] == block && playingField[3, coordinationY + 2] == block && playingField[4, coordinationY + 2] == block && playingField[5, coordinationY + 2] == block && playingField[6, coordinationY + 2] == block && playingField[7, coordinationY + 2] == block)
                                                    {
                                                        playingField[0, coordinationY + 2] = empty;
                                                        playingField[1, coordinationY + 2] = empty;
                                                        playingField[2, coordinationY + 2] = empty;
                                                        playingField[3, coordinationY + 2] = empty;
                                                        playingField[4, coordinationY + 2] = empty;
                                                        playingField[5, coordinationY + 2] = empty;
                                                        playingField[6, coordinationY + 2] = empty;
                                                        playingField[7, coordinationY + 2] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Číslo od 0 do 5!");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                        }
                    }
                    else if (chosenBlock == 3)
                    {
                        lineLength = rnd.Next(1, 5);
                        if (lineLength == 1)
                        {
                            line1Orientation = rnd.Next(2);
                            if (line1Orientation == 1)
                            {
                                char[,] line1Horizontal =
                                {
                                    { '/','/'},
                                };
                                Print2DArray(line1Horizontal);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 7)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 8)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY] == block || playingField[coordinationX + 1, coordinationY] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY] = block;
                                                    playingField[coordinationX + 1, coordinationY] = block;
                                                    Line line = new Line(1);
                                                    int newScore = score + line.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Číslo x musí být od 0 do 6 a Y od 0 do 7!");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                            else
                            {
                                char[,] line1Vertical =
                                {
                                { '/'},
                                { '/'},
                            };
                                Print2DArray(line1Vertical);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 8)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 7)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY] == block || playingField[coordinationX, coordinationY + 1] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY] = block;
                                                    playingField[coordinationX, coordinationY + 1] = block;
                                                    Line line = new Line(1);
                                                    int newScore = score + line.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Číslo x musí být od 0 do 7 a Y od 0 do 6!");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                        }
                        else if (lineLength == 2)
                        {
                            line2Orientation = rnd.Next(2);
                            if (line2Orientation == 1)
                            {
                                char[,] line2Horizontal =
                                {
                                { '/','/','/'},
                            };
                                Print2DArray(line2Horizontal);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 6)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 8)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY] == block || playingField[coordinationX + 1, coordinationY] == block || playingField[coordinationX + 2, coordinationY] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY] = block;
                                                    playingField[coordinationX + 1, coordinationY] = block;
                                                    playingField[coordinationX + 2, coordinationY] = block;
                                                    Line line = new Line(2);
                                                    int newScore = score + line.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 2, 0] == block && playingField[coordinationX + 2, 1] == block && playingField[coordinationX + 2, 2] == block && playingField[coordinationX + 2, 3] == block && playingField[coordinationX + 2, 4] == block && playingField[coordinationX + 2, 5] == block && playingField[coordinationX + 2, 6] == block && playingField[coordinationX + 2, 7] == block)
                                                    {
                                                        playingField[coordinationX + 2, 0] = empty;
                                                        playingField[coordinationX + 2, 1] = empty;
                                                        playingField[coordinationX + 2, 2] = empty;
                                                        playingField[coordinationX + 2, 3] = empty;
                                                        playingField[coordinationX + 2, 4] = empty;
                                                        playingField[coordinationX + 2, 5] = empty;
                                                        playingField[coordinationX + 2, 6] = empty;
                                                        playingField[coordinationX + 2, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Číslo x musí být od 0 do 5 a Y od 0 do 7!");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                            else
                            {
                                char[,] line2Vertical =
                                {
                                { '/'},
                                { '/'},
                                { '/'},
                            };
                                Print2DArray(line2Vertical);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 8)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 6)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY] == block || playingField[coordinationX, coordinationY + 1] == block || playingField[coordinationX, coordinationY + 2] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY] = block;
                                                    playingField[coordinationX, coordinationY + 1] = block;
                                                    playingField[coordinationX, coordinationY + 2] = block;
                                                    Line line = new Line(2);
                                                    int newScore = score + line.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 2] == block && playingField[1, coordinationY + 2] == block && playingField[2, coordinationY + 2] == block && playingField[3, coordinationY + 2] == block && playingField[4, coordinationY + 2] == block && playingField[5, coordinationY + 2] == block && playingField[6, coordinationY + 2] == block && playingField[7, coordinationY + 2] == block)
                                                    {
                                                        playingField[0, coordinationY + 2] = empty;
                                                        playingField[1, coordinationY + 2] = empty;
                                                        playingField[2, coordinationY + 2] = empty;
                                                        playingField[3, coordinationY + 2] = empty;
                                                        playingField[4, coordinationY + 2] = empty;
                                                        playingField[5, coordinationY + 2] = empty;
                                                        playingField[6, coordinationY + 2] = empty;
                                                        playingField[7, coordinationY + 2] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Číslo x musí být od 0 do 7 a Y od 0 do 5!");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                        }
                        else if (lineLength == 3)
                        {
                            line3Orientation = rnd.Next(2);
                            if (line3Orientation == 1)
                            {
                                char[,] line3Horizontal =
                                {
                                { '/','/','/','/'},
                            };
                                Print2DArray(line3Horizontal);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 5)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 8)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY] == block || playingField[coordinationX + 1, coordinationY] == block || playingField[coordinationX + 2, coordinationY] == block || playingField[coordinationX + 3, coordinationY] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY] = block;
                                                    playingField[coordinationX + 1, coordinationY] = block;
                                                    playingField[coordinationX + 2, coordinationY] = block;
                                                    playingField[coordinationX + 3, coordinationY] = block;
                                                    Line line = new Line(3);
                                                    int newScore = score + line.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 2, 0] == block && playingField[coordinationX + 2, 1] == block && playingField[coordinationX + 2, 2] == block && playingField[coordinationX + 2, 3] == block && playingField[coordinationX + 2, 4] == block && playingField[coordinationX + 2, 5] == block && playingField[coordinationX + 2, 6] == block && playingField[coordinationX + 2, 7] == block)
                                                    {
                                                        playingField[coordinationX + 2, 0] = empty;
                                                        playingField[coordinationX + 2, 1] = empty;
                                                        playingField[coordinationX + 2, 2] = empty;
                                                        playingField[coordinationX + 2, 3] = empty;
                                                        playingField[coordinationX + 2, 4] = empty;
                                                        playingField[coordinationX + 2, 5] = empty;
                                                        playingField[coordinationX + 2, 6] = empty;
                                                        playingField[coordinationX + 2, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 3, 0] == block && playingField[coordinationX + 3, 1] == block && playingField[coordinationX + 3, 2] == block && playingField[coordinationX + 3, 3] == block && playingField[coordinationX + 3, 4] == block && playingField[coordinationX + 3, 5] == block && playingField[coordinationX + 3, 6] == block && playingField[coordinationX + 3, 7] == block)
                                                    {
                                                        playingField[coordinationX + 3, 0] = empty;
                                                        playingField[coordinationX + 3, 1] = empty;
                                                        playingField[coordinationX + 3, 2] = empty;
                                                        playingField[coordinationX + 3, 3] = empty;
                                                        playingField[coordinationX + 3, 4] = empty;
                                                        playingField[coordinationX + 3, 5] = empty;
                                                        playingField[coordinationX + 3, 6] = empty;
                                                        playingField[coordinationX + 3, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Číslo x musí být od 0 do 4 a Y od 0 do 7!");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                            else
                            {
                                char[,] line3Vertical =
                                {
                                { '/'},
                                { '/'},
                                { '/'},
                                { '/'},
                            };
                                Print2DArray(line3Vertical);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 8)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 5)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY] == block || playingField[coordinationX, coordinationY + 1] == block || playingField[coordinationX, coordinationY + 2] == block || playingField[coordinationX, coordinationY + 3] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY] = block;
                                                    playingField[coordinationX, coordinationY + 1] = block;
                                                    playingField[coordinationX, coordinationY + 2] = block;
                                                    playingField[coordinationX, coordinationY + 3] = block;
                                                    Line line = new Line(3);
                                                    int newScore = score + line.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 2] == block && playingField[1, coordinationY + 2] == block && playingField[2, coordinationY + 2] == block && playingField[3, coordinationY + 2] == block && playingField[4, coordinationY + 2] == block && playingField[5, coordinationY + 2] == block && playingField[6, coordinationY + 2] == block && playingField[7, coordinationY + 2] == block)
                                                    {
                                                        playingField[0, coordinationY + 2] = empty;
                                                        playingField[1, coordinationY + 2] = empty;
                                                        playingField[2, coordinationY + 2] = empty;
                                                        playingField[3, coordinationY + 2] = empty;
                                                        playingField[4, coordinationY + 2] = empty;
                                                        playingField[5, coordinationY + 2] = empty;
                                                        playingField[6, coordinationY + 2] = empty;
                                                        playingField[7, coordinationY + 2] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 3] == block && playingField[1, coordinationY + 3] == block && playingField[2, coordinationY + 3] == block && playingField[3, coordinationY + 3] == block && playingField[4, coordinationY + 3] == block && playingField[5, coordinationY + 3] == block && playingField[6, coordinationY + 3] == block && playingField[7, coordinationY + 3] == block)
                                                    {
                                                        playingField[0, coordinationY + 3] = empty;
                                                        playingField[1, coordinationY + 3] = empty;
                                                        playingField[2, coordinationY + 3] = empty;
                                                        playingField[3, coordinationY + 3] = empty;
                                                        playingField[4, coordinationY + 3] = empty;
                                                        playingField[5, coordinationY + 3] = empty;
                                                        playingField[6, coordinationY + 3] = empty;
                                                        playingField[7, coordinationY + 3] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Číslo x musí být od 0 do 7 a Y od 0 do 4!");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                        }
                        else
                        {
                            line4Orientation = rnd.Next(2);
                            if (line4Orientation == 1)
                            {
                                char[,] line4Horizontal =
                                {
                                { '/','/','/','/','/'},
                            };
                                Print2DArray(line4Horizontal);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 4)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 8)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY] == block || playingField[coordinationX + 1, coordinationY] == block || playingField[coordinationX + 2, coordinationY] == block || playingField[coordinationX + 3, coordinationY] == block || playingField[coordinationX + 4, coordinationY] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY] = block;
                                                    playingField[coordinationX + 1, coordinationY] = block;
                                                    playingField[coordinationX + 2, coordinationY] = block;
                                                    playingField[coordinationX + 3, coordinationY] = block;
                                                    playingField[coordinationX + 4, coordinationY] = block;
                                                    Line line = new Line(4);
                                                    int newScore = score + line.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 2, 0] == block && playingField[coordinationX + 2, 1] == block && playingField[coordinationX + 2, 2] == block && playingField[coordinationX + 2, 3] == block && playingField[coordinationX + 2, 4] == block && playingField[coordinationX + 2, 5] == block && playingField[coordinationX + 2, 6] == block && playingField[coordinationX + 2, 7] == block)
                                                    {
                                                        playingField[coordinationX + 2, 0] = empty;
                                                        playingField[coordinationX + 2, 1] = empty;
                                                        playingField[coordinationX + 2, 2] = empty;
                                                        playingField[coordinationX + 2, 3] = empty;
                                                        playingField[coordinationX + 2, 4] = empty;
                                                        playingField[coordinationX + 2, 5] = empty;
                                                        playingField[coordinationX + 2, 6] = empty;
                                                        playingField[coordinationX + 2, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 3, 0] == block && playingField[coordinationX + 3, 1] == block && playingField[coordinationX + 3, 2] == block && playingField[coordinationX + 3, 3] == block && playingField[coordinationX + 3, 4] == block && playingField[coordinationX + 3, 5] == block && playingField[coordinationX + 3, 6] == block && playingField[coordinationX + 3, 7] == block)
                                                    {
                                                        playingField[coordinationX + 3, 0] = empty;
                                                        playingField[coordinationX + 3, 1] = empty;
                                                        playingField[coordinationX + 3, 2] = empty;
                                                        playingField[coordinationX + 3, 3] = empty;
                                                        playingField[coordinationX + 3, 4] = empty;
                                                        playingField[coordinationX + 3, 5] = empty;
                                                        playingField[coordinationX + 3, 6] = empty;
                                                        playingField[coordinationX + 3, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 4, 0] == block && playingField[coordinationX + 4, 1] == block && playingField[coordinationX + 4, 2] == block && playingField[coordinationX + 4, 3] == block && playingField[coordinationX + 4, 4] == block && playingField[coordinationX + 4, 5] == block && playingField[coordinationX + 4, 6] == block && playingField[coordinationX + 4, 7] == block)
                                                    {
                                                        playingField[coordinationX + 4, 0] = empty;
                                                        playingField[coordinationX + 4, 1] = empty;
                                                        playingField[coordinationX + 4, 2] = empty;
                                                        playingField[coordinationX + 4, 3] = empty;
                                                        playingField[coordinationX + 4, 4] = empty;
                                                        playingField[coordinationX + 4, 5] = empty;
                                                        playingField[coordinationX + 4, 6] = empty;
                                                        playingField[coordinationX + 4, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Číslo x musí být od 0 do 3 a Y od 0 do 7!");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                            else
                            {
                                char[,] line4Vertical =
                                {
                                { '/'},
                                { '/'},
                                { '/'},
                                { '/'},
                                { '/'},
                            };
                                Print2DArray(line4Vertical);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 8)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 3)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY] == block || playingField[coordinationX, coordinationY + 1] == block || playingField[coordinationX, coordinationY + 2] == block || playingField[coordinationX, coordinationY + 3] == block || playingField[coordinationX, coordinationY + 4] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY] = block;
                                                    playingField[coordinationX, coordinationY + 1] = block;
                                                    playingField[coordinationX, coordinationY + 2] = block;
                                                    playingField[coordinationX, coordinationY + 3] = block;
                                                    playingField[coordinationX, coordinationY + 4] = block;
                                                    Line line = new Line(4);
                                                    int newScore = score + line.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 2] == block && playingField[1, coordinationY + 2] == block && playingField[2, coordinationY + 2] == block && playingField[3, coordinationY + 2] == block && playingField[4, coordinationY + 2] == block && playingField[5, coordinationY + 2] == block && playingField[6, coordinationY + 2] == block && playingField[7, coordinationY + 2] == block)
                                                    {
                                                        playingField[0, coordinationY + 2] = empty;
                                                        playingField[1, coordinationY + 2] = empty;
                                                        playingField[2, coordinationY + 2] = empty;
                                                        playingField[3, coordinationY + 2] = empty;
                                                        playingField[4, coordinationY + 2] = empty;
                                                        playingField[5, coordinationY + 2] = empty;
                                                        playingField[6, coordinationY + 2] = empty;
                                                        playingField[7, coordinationY + 2] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 3] == block && playingField[1, coordinationY + 3] == block && playingField[2, coordinationY + 3] == block && playingField[3, coordinationY + 3] == block && playingField[4, coordinationY + 3] == block && playingField[5, coordinationY + 3] == block && playingField[6, coordinationY + 3] == block && playingField[7, coordinationY + 3] == block)
                                                    {
                                                        playingField[0, coordinationY + 3] = empty;
                                                        playingField[1, coordinationY + 3] = empty;
                                                        playingField[2, coordinationY + 3] = empty;
                                                        playingField[3, coordinationY + 3] = empty;
                                                        playingField[4, coordinationY + 3] = empty;
                                                        playingField[5, coordinationY + 3] = empty;
                                                        playingField[6, coordinationY + 3] = empty;
                                                        playingField[7, coordinationY + 3] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 4] == block && playingField[1, coordinationY + 4] == block && playingField[2, coordinationY + 4] == block && playingField[3, coordinationY + 4] == block && playingField[4, coordinationY + 4] == block && playingField[5, coordinationY + 4] == block && playingField[6, coordinationY + 4] == block && playingField[7, coordinationY + 4] == block)
                                                    {
                                                        playingField[0, coordinationY + 4] = empty;
                                                        playingField[1, coordinationY + 4] = empty;
                                                        playingField[2, coordinationY + 4] = empty;
                                                        playingField[3, coordinationY + 4] = empty;
                                                        playingField[4, coordinationY + 4] = empty;
                                                        playingField[5, coordinationY + 4] = empty;
                                                        playingField[6, coordinationY + 4] = empty;
                                                        playingField[7, coordinationY + 4] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Číslo x musí být od 0 do 7 a Y od 0 do 3!");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                        }
                    }
                    else
                    {
                        blockType = rnd.Next(1, 4);
                        if (blockType == 1)
                        {
                            blockTOrientation = rnd.Next(1, 5);
                            if (blockTOrientation == 1)
                            {
                                char[,] blockT1 =
                                {
                                { '0','/','0'},
                                { '/','/','/'},
                            };
                                Print2DArray(blockT1);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 6)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 7)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY] == block || playingField[coordinationX + 1, coordinationY] == block || playingField[coordinationX + 1, coordinationY + 1] == block || playingField[coordinationX + 2, coordinationY] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY] = block;
                                                    playingField[coordinationX + 1, coordinationY] = block;
                                                    playingField[coordinationX + 1, coordinationY + 1] = block;
                                                    playingField[coordinationX + 2, coordinationY] = block;
                                                    OtherBlocks blockT = new OtherBlocks(1);
                                                    int newScore = score + blockT.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 2] == block && playingField[1, coordinationY + 2] == block && playingField[2, coordinationY + 2] == block && playingField[3, coordinationY + 2] == block && playingField[4, coordinationY + 2] == block && playingField[5, coordinationY + 2] == block && playingField[6, coordinationY + 2] == block && playingField[7, coordinationY + 2] == block)
                                                    {
                                                        playingField[coordinationX + 2, 0] = empty;
                                                        playingField[coordinationX + 2, 1] = empty;
                                                        playingField[coordinationX + 2, 2] = empty;
                                                        playingField[coordinationX + 2, 3] = empty;
                                                        playingField[coordinationX + 2, 4] = empty;
                                                        playingField[coordinationX + 2, 5] = empty;
                                                        playingField[coordinationX + 2, 6] = empty;
                                                        playingField[coordinationX + 2, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Y musí být číslo od 0 do 5 a X od 0 do 6");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                            else if (blockTOrientation == 2)
                            {
                                char[,] blockT2 =
                                {
                                { '/','/','/'},
                                { '0','/','0'},
                            };
                                Print2DArray(blockT2);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 6)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 7)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY + 1] == block || playingField[coordinationX + 1, coordinationY + 1] == block || playingField[coordinationX + 2, coordinationY + 1] == block || playingField[coordinationX + 1, coordinationY] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY + 1] = block;
                                                    playingField[coordinationX + 1, coordinationY + 1] = block;
                                                    playingField[coordinationX + 2, coordinationY + 1] = block;
                                                    playingField[coordinationX + 1, coordinationY] = block;
                                                    OtherBlocks blockT = new OtherBlocks(1);
                                                    int newScore = score + blockT.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 2] == block && playingField[1, coordinationY + 2] == block && playingField[2, coordinationY + 2] == block && playingField[3, coordinationY + 2] == block && playingField[4, coordinationY + 2] == block && playingField[5, coordinationY + 2] == block && playingField[6, coordinationY + 2] == block && playingField[7, coordinationY + 2] == block)
                                                    {
                                                        playingField[coordinationX + 2, 0] = empty;
                                                        playingField[coordinationX + 2, 1] = empty;
                                                        playingField[coordinationX + 2, 2] = empty;
                                                        playingField[coordinationX + 2, 3] = empty;
                                                        playingField[coordinationX + 2, 4] = empty;
                                                        playingField[coordinationX + 2, 5] = empty;
                                                        playingField[coordinationX + 2, 6] = empty;
                                                        playingField[coordinationX + 2, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Y musí být číslo od 0 do 5 a X od 0 do 6");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                            else if (blockTOrientation == 3)
                            {
                                char[,] blockT3 =
                                {
                                { '/','0'},
                                { '/','/'},
                                { '/','0'},
                            };
                                Print2DArray(blockT3);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 7)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 6)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY] == block || playingField[coordinationX, coordinationY + 1] == block || playingField[coordinationX, coordinationY + 2] == block || playingField[coordinationX + 1, coordinationY + 1] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY] = block;
                                                    playingField[coordinationX, coordinationY + 1] = block;
                                                    playingField[coordinationX, coordinationY + 2] = block;
                                                    playingField[coordinationX + 1, coordinationY + 1] = block;
                                                    OtherBlocks blockT = new OtherBlocks(1);
                                                    int newScore = score + blockT.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 2] == block && playingField[1, coordinationY + 2] == block && playingField[2, coordinationY + 2] == block && playingField[3, coordinationY + 2] == block && playingField[4, coordinationY + 2] == block && playingField[5, coordinationY + 2] == block && playingField[6, coordinationY + 2] == block && playingField[7, coordinationY + 2] == block)
                                                    {
                                                        playingField[0, coordinationY + 2] = empty;
                                                        playingField[1, coordinationY + 2] = empty;
                                                        playingField[2, coordinationY + 2] = empty;
                                                        playingField[3, coordinationY + 2] = empty;
                                                        playingField[4, coordinationY + 2] = empty;
                                                        playingField[5, coordinationY + 2] = empty;
                                                        playingField[6, coordinationY + 2] = empty;
                                                        playingField[7, coordinationY + 2] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Y musí být číslo od 0 do 6 a X od 0 do 5");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                            else
                            {
                                char[,] blockT4 =
                                {
                                { '0','/'},
                                { '/','/'},
                                { '0','/'},
                            };
                                Print2DArray(blockT4);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 7)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 6)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX + 1, coordinationY] == block || playingField[coordinationX + 1, coordinationY + 1] == block || playingField[coordinationX + 1, coordinationY + 2] == block || playingField[coordinationX, coordinationY + 1] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX + 1, coordinationY] = block;
                                                    playingField[coordinationX + 1, coordinationY + 1] = block;
                                                    playingField[coordinationX + 1, coordinationY + 2] = block;
                                                    playingField[coordinationX, coordinationY + 1] = block;
                                                    OtherBlocks blockT = new OtherBlocks(1);
                                                    int newScore = score + blockT.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 2] == block && playingField[1, coordinationY + 2] == block && playingField[2, coordinationY + 2] == block && playingField[3, coordinationY + 2] == block && playingField[4, coordinationY + 2] == block && playingField[5, coordinationY + 2] == block && playingField[6, coordinationY + 2] == block && playingField[7, coordinationY + 2] == block)
                                                    {
                                                        playingField[0, coordinationY + 2] = empty;
                                                        playingField[1, coordinationY + 2] = empty;
                                                        playingField[2, coordinationY + 2] = empty;
                                                        playingField[3, coordinationY + 2] = empty;
                                                        playingField[4, coordinationY + 2] = empty;
                                                        playingField[5, coordinationY + 2] = empty;
                                                        playingField[6, coordinationY + 2] = empty;
                                                        playingField[7, coordinationY + 2] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Y musí být číslo od 0 do 6 a X od 0 do 5");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                        }
                        else if (blockType == 2)
                        {
                            blockSOrientation = rnd.Next(1, 5);
                            if (blockSOrientation == 1)
                            {
                                char[,] blockS1 =
                                {
                                { '/','/','0'},
                                { '0','/','/'},
                            };
                                Print2DArray(blockS1);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 6)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 7)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY + 1] == block || playingField[coordinationX + 1, coordinationY] == block || playingField[coordinationX + 1, coordinationY + 1] == block || playingField[coordinationX + 2, coordinationY] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY + 1] = block;
                                                    playingField[coordinationX + 1, coordinationY] = block;
                                                    playingField[coordinationX + 1, coordinationY + 1] = block;
                                                    playingField[coordinationX + 2, coordinationY] = block;
                                                    OtherBlocks blockS = new OtherBlocks(2);
                                                    int newScore = score + blockS.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 2] == block && playingField[1, coordinationY + 2] == block && playingField[2, coordinationY + 2] == block && playingField[3, coordinationY + 2] == block && playingField[4, coordinationY + 2] == block && playingField[5, coordinationY + 2] == block && playingField[6, coordinationY + 2] == block && playingField[7, coordinationY + 2] == block)
                                                    {
                                                        playingField[coordinationX + 2, 0] = empty;
                                                        playingField[coordinationX + 2, 1] = empty;
                                                        playingField[coordinationX + 2, 2] = empty;
                                                        playingField[coordinationX + 2, 3] = empty;
                                                        playingField[coordinationX + 2, 4] = empty;
                                                        playingField[coordinationX + 2, 5] = empty;
                                                        playingField[coordinationX + 2, 6] = empty;
                                                        playingField[coordinationX + 2, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Y musí být číslo od 0 do 5 a X od 0 do 6");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                            else if (blockSOrientation == 2)
                            {
                                char[,] blockS2 =
                                {
                                { '0','/','/'},
                                { '/','/','0'},
                            };
                                Print2DArray(blockS2);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 6)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 7)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY] == block || playingField[coordinationX + 1, coordinationY] == block || playingField[coordinationX + 1, coordinationY + 1] == block || playingField[coordinationX + 2, coordinationY + 1] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY] = block;
                                                    playingField[coordinationX + 1, coordinationY] = block;
                                                    playingField[coordinationX + 1, coordinationY + 1] = block;
                                                    playingField[coordinationX + 2, coordinationY + 1] = block;
                                                    OtherBlocks blockS = new OtherBlocks(2);
                                                    int newScore = score + blockS.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 2] == block && playingField[1, coordinationY + 2] == block && playingField[2, coordinationY + 2] == block && playingField[3, coordinationY + 2] == block && playingField[4, coordinationY + 2] == block && playingField[5, coordinationY + 2] == block && playingField[6, coordinationY + 2] == block && playingField[7, coordinationY + 2] == block)
                                                    {
                                                        playingField[coordinationX + 2, 0] = empty;
                                                        playingField[coordinationX + 2, 1] = empty;
                                                        playingField[coordinationX + 2, 2] = empty;
                                                        playingField[coordinationX + 2, 3] = empty;
                                                        playingField[coordinationX + 2, 4] = empty;
                                                        playingField[coordinationX + 2, 5] = empty;
                                                        playingField[coordinationX + 2, 6] = empty;
                                                        playingField[coordinationX + 2, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Y musí být číslo od 0 do 5 a X od 0 do 6");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                            else if (blockSOrientation == 3)
                            {
                                char[,] blockS3 =
                                {
                                { '/','0'},
                                { '/','/'},
                                { '0','/'},
                            };
                                Print2DArray(blockS3);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 7)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 6)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY + 1] == block || playingField[coordinationX, coordinationY + 2] == block || playingField[coordinationX + 1, coordinationY + 1] == block || playingField[coordinationX + 1, coordinationY] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY + 1] = block;
                                                    playingField[coordinationX, coordinationY + 2] = block;
                                                    playingField[coordinationX + 1, coordinationY + 1] = block;
                                                    playingField[coordinationX + 1, coordinationY] = block;
                                                    OtherBlocks blockS = new OtherBlocks(2);
                                                    int newScore = score + blockS.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 2] == block && playingField[1, coordinationY + 2] == block && playingField[2, coordinationY + 2] == block && playingField[3, coordinationY + 2] == block && playingField[4, coordinationY + 2] == block && playingField[5, coordinationY + 2] == block && playingField[6, coordinationY + 2] == block && playingField[7, coordinationY + 2] == block)
                                                    {
                                                        playingField[0, coordinationY + 2] = empty;
                                                        playingField[1, coordinationY + 2] = empty;
                                                        playingField[2, coordinationY + 2] = empty;
                                                        playingField[3, coordinationY + 2] = empty;
                                                        playingField[4, coordinationY + 2] = empty;
                                                        playingField[5, coordinationY + 2] = empty;
                                                        playingField[6, coordinationY + 2] = empty;
                                                        playingField[7, coordinationY + 2] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Y musí být číslo od 0 do 6 a X od 0 do 5");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                            else
                            {
                                char[,] blockS4 =
                                {
                                { '0','/'},
                                { '/','/'},
                                { '/','0'},
                            };
                                Print2DArray(blockS4);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 7)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 6)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY] == block || playingField[coordinationX, coordinationY + 1] == block || playingField[coordinationX + 1, coordinationY + 1] == block || playingField[coordinationX + 1, coordinationY + 2] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY] = block;
                                                    playingField[coordinationX, coordinationY + 1] = block;
                                                    playingField[coordinationX + 1, coordinationY + 1] = block;
                                                    playingField[coordinationX + 1, coordinationY + 2] = block;
                                                    OtherBlocks blockS = new OtherBlocks(2);
                                                    int newScore = score + blockS.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 2] == block && playingField[1, coordinationY + 2] == block && playingField[2, coordinationY + 2] == block && playingField[3, coordinationY + 2] == block && playingField[4, coordinationY + 2] == block && playingField[5, coordinationY + 2] == block && playingField[6, coordinationY + 2] == block && playingField[7, coordinationY + 2] == block)
                                                    {
                                                        playingField[0, coordinationY + 2] = empty;
                                                        playingField[1, coordinationY + 2] = empty;
                                                        playingField[2, coordinationY + 2] = empty;
                                                        playingField[3, coordinationY + 2] = empty;
                                                        playingField[4, coordinationY + 2] = empty;
                                                        playingField[5, coordinationY + 2] = empty;
                                                        playingField[6, coordinationY + 2] = empty;
                                                        playingField[7, coordinationY + 2] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Y musí být číslo od 0 do 6 a X od 0 do 5");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                        }
                        else
                        {
                            rectangleOrientation = rnd.Next(2);
                            if (rectangleOrientation == 1)
                            {
                                char[,] rectangleHorizontal =
                                {
                                { '/','/','/'},
                                { '/','/','/'},
                            };
                                Print2DArray(rectangleHorizontal);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 6)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 7)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX, coordinationY] == block || playingField[coordinationX + 1, coordinationY] == block || playingField[coordinationX + 2, coordinationY] == block || playingField[coordinationX, coordinationY + 1] == block || playingField[coordinationX + 1, coordinationY + 1] == block || playingField[coordinationX + 2, coordinationY + 1] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX, coordinationY] = block;
                                                    playingField[coordinationX + 1, coordinationY] = block;
                                                    playingField[coordinationX + 2, coordinationY] = block;
                                                    playingField[coordinationX, coordinationY + 1] = block;
                                                    playingField[coordinationX + 1, coordinationY + 1] = block;
                                                    playingField[coordinationX + 2, coordinationY + 1] = block;
                                                    OtherBlocks rectangle = new OtherBlocks(3);
                                                    int newScore = score + rectangle.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 2] == block && playingField[1, coordinationY + 2] == block && playingField[2, coordinationY + 2] == block && playingField[3, coordinationY + 2] == block && playingField[4, coordinationY + 2] == block && playingField[5, coordinationY + 2] == block && playingField[6, coordinationY + 2] == block && playingField[7, coordinationY + 2] == block)
                                                    {
                                                        playingField[coordinationX + 2, 0] = empty;
                                                        playingField[coordinationX + 2, 1] = empty;
                                                        playingField[coordinationX + 2, 2] = empty;
                                                        playingField[coordinationX + 2, 3] = empty;
                                                        playingField[coordinationX + 2, 4] = empty;
                                                        playingField[coordinationX + 2, 5] = empty;
                                                        playingField[coordinationX + 2, 6] = empty;
                                                        playingField[coordinationX + 2, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Y musí být číslo od 0 do 5 a X od 0 do 6");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                            else
                            {
                                char[,] rectangleVertical =
                                {
                                    { '/','/'},
                                    { '/','/'},
                                    { '/','/'},
                                };
                                Print2DArray(rectangleVertical);
                                Console.WriteLine("Je block možné v poli umístit?");
                                string possibility = Convert.ToString(Console.ReadLine());
                                if (possibility == "ano")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Zadej souřadnice levého dolního rohu blocku a to nejprve x a poté y.");
                                        string firstCoordination = Console.ReadLine().Trim();
                                        if (double.TryParse(firstCoordination, out _) && 0 <= Convert.ToInt32(firstCoordination) && Convert.ToInt32(firstCoordination) < 7)
                                        {
                                            string secondCoordination = Console.ReadLine().Trim();
                                            if (double.TryParse(secondCoordination, out _) && 0 <= Convert.ToInt32(secondCoordination) && Convert.ToInt32(secondCoordination) < 6)
                                            {
                                                coordinationX = Convert.ToInt32(firstCoordination);
                                                coordinationY = Convert.ToInt32(secondCoordination);
                                                if (playingField[coordinationX + 1, coordinationY] == block || playingField[coordinationX + 1, coordinationY + 1] == block || playingField[coordinationX + 1, coordinationY + 2] == block || playingField[coordinationX, coordinationY + 2] == block)
                                                {
                                                    Console.WriteLine("Nevidíš, že už tam máš block???");
                                                }
                                                else
                                                {
                                                    playingField[coordinationX + 1, coordinationY] = block;
                                                    playingField[coordinationX + 1, coordinationY + 1] = block;
                                                    playingField[coordinationX + 1, coordinationY + 2] = block;
                                                    playingField[coordinationX, coordinationY] = block;
                                                    playingField[coordinationX, coordinationY + 1] = block;
                                                    playingField[coordinationX, coordinationY + 2] = block;
                                                    OtherBlocks rectangle = new OtherBlocks(3);
                                                    int newScore = score + rectangle.CalculateScoreForBlock();
                                                    score = newScore;
                                                    if (playingField[coordinationX, 0] == block && playingField[coordinationX, 1] == block && playingField[coordinationX, 2] == block && playingField[coordinationX, 3] == block && playingField[coordinationX, 4] == block && playingField[coordinationX, 5] == block && playingField[coordinationX, 6] == block && playingField[coordinationX, 7] == block)
                                                    {
                                                        playingField[coordinationX, 0] = empty;
                                                        playingField[coordinationX, 1] = empty;
                                                        playingField[coordinationX, 2] = empty;
                                                        playingField[coordinationX, 3] = empty;
                                                        playingField[coordinationX, 4] = empty;
                                                        playingField[coordinationX, 5] = empty;
                                                        playingField[coordinationX, 6] = empty;
                                                        playingField[coordinationX, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[coordinationX + 1, 0] == block && playingField[coordinationX + 1, 1] == block && playingField[coordinationX + 1, 2] == block && playingField[coordinationX + 1, 3] == block && playingField[coordinationX + 1, 4] == block && playingField[coordinationX + 1, 5] == block && playingField[coordinationX + 1, 6] == block && playingField[coordinationX + 1, 7] == block)
                                                    {
                                                        playingField[coordinationX + 1, 0] = empty;
                                                        playingField[coordinationX + 1, 1] = empty;
                                                        playingField[coordinationX + 1, 2] = empty;
                                                        playingField[coordinationX + 1, 3] = empty;
                                                        playingField[coordinationX + 1, 4] = empty;
                                                        playingField[coordinationX + 1, 5] = empty;
                                                        playingField[coordinationX + 1, 6] = empty;
                                                        playingField[coordinationX + 1, 7] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY] == block && playingField[1, coordinationY] == block && playingField[2, coordinationY] == block && playingField[3, coordinationY] == block && playingField[4, coordinationY] == block && playingField[5, coordinationY] == block && playingField[6, coordinationY] == block && playingField[7, coordinationY] == block)
                                                    {
                                                        playingField[0, coordinationY] = empty;
                                                        playingField[1, coordinationY] = empty;
                                                        playingField[2, coordinationY] = empty;
                                                        playingField[3, coordinationY] = empty;
                                                        playingField[4, coordinationY] = empty;
                                                        playingField[5, coordinationY] = empty;
                                                        playingField[6, coordinationY] = empty;
                                                        playingField[7, coordinationY] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 1] == block && playingField[1, coordinationY + 1] == block && playingField[2, coordinationY + 1] == block && playingField[3, coordinationY + 1] == block && playingField[4, coordinationY + 1] == block && playingField[5, coordinationY + 1] == block && playingField[6, coordinationY + 1] == block && playingField[7, coordinationY + 1] == block)
                                                    {
                                                        playingField[0, coordinationY + 1] = empty;
                                                        playingField[1, coordinationY + 1] = empty;
                                                        playingField[2, coordinationY + 1] = empty;
                                                        playingField[3, coordinationY + 1] = empty;
                                                        playingField[4, coordinationY + 1] = empty;
                                                        playingField[5, coordinationY + 1] = empty;
                                                        playingField[6, coordinationY + 1] = empty;
                                                        playingField[7, coordinationY + 1] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    if (playingField[0, coordinationY + 2] == block && playingField[1, coordinationY + 2] == block && playingField[2, coordinationY + 2] == block && playingField[3, coordinationY + 2] == block && playingField[4, coordinationY + 2] == block && playingField[5, coordinationY + 2] == block && playingField[6, coordinationY + 2] == block && playingField[7, coordinationY + 2] == block)
                                                    {
                                                        playingField[0, coordinationY + 2] = empty;
                                                        playingField[1, coordinationY + 2] = empty;
                                                        playingField[2, coordinationY + 2] = empty;
                                                        playingField[3, coordinationY + 2] = empty;
                                                        playingField[4, coordinationY + 2] = empty;
                                                        playingField[5, coordinationY + 2] = empty;
                                                        playingField[6, coordinationY + 2] = empty;
                                                        playingField[7, coordinationY + 2] = empty;
                                                        newScore = score + 10;
                                                        score = newScore;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Y musí být číslo od 0 do 6 a X od 0 do 5");
                                        }
                                    }
                                    break;
                                }
                                else if (possibility == "ne")
                                {
                                    notPossible = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Napiš ano nebo ne!");
                                }
                            }
                        }
                    }
                }
                Print2DArray(playingField);
                Console.WriteLine("Tvé score je: " + score + ".");
            }
        }
    }
}

//Zdroje
//2DArrayPlayground
