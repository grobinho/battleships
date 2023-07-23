using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleships
{
    public class MainMenu
    {
        public static void ShowMenu()
        {
            Console.Clear();

            DrawLogo();
            Console.WriteLine("Main Menu - type number and press ENTER:");
            Console.WriteLine("1 - PLAY");
            Console.WriteLine("2 - HELP");
            Console.WriteLine("3 - QUIT");

            string? command = Console.ReadLine();

            switch(command)
            {
                case "1": // start game
                {
                    Game game = new();
                    game.Launch(5, 4, 4);
                }
                break;
                case "2":
                {
                    ShowAboutInfo();
                }
                break;
                case "3":
                {
                    Environment.Exit(0);
                }
                break;
                default:
                {

                }
                break;
            }

            ShowMenu();
        }

        public static void DrawLogo()
        {
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|  BBBBBB       AA     TTTTTTTT  TTTTTTTT  LL        EEEEEEEE    SSSS    HH    HH  II  PPPPPP      SSSS    |");
            Console.WriteLine("|  BB    BB    A  A       TT        TT     LL        EE        SS    SS  HH    HH  II  PP    P   SS    SS  |");
            Console.WriteLine("|  BB    BB    A  A       TT        TT     LL        EE        SS        HH    HH  II  PP    PP  SS        |");
            Console.WriteLine("|  BBBBBB     A    A      TT        TT     LL        EEEEEEEE    SS      HHHHHHHH  II  PP    P     SS      |");
            Console.WriteLine("|  BBBBBB     AAAAAA      TT        TT     LL        EEEEEEEE      SS    HHHHHHHH  II  PPPPPP        SS    |");
            Console.WriteLine("|  BB    BB   A    A      TT        TT     LL        EE              SS  HH    HH  II  PP              SS  |");
            Console.WriteLine("|  BB    BB  A      A     TT        TT     LL        EE        SS    SS  HH    HH  II  PP        SS    SS  |");
            Console.WriteLine("|  BBBBBB    A      A     TT        TT     LLLLLLLL  EEEEEEEE    SSSS    HH    HH  II  PP          SSSS    |");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("\n");
        }

        public static void ShowAboutInfo()
        {
            Console.Clear();

            Console.WriteLine("BATTLESHIPS - HELP\n\n");
            Console.WriteLine("- you will see battlefield as 10 x 10 grid in top part of the console;");
            Console.WriteLine("- it will be randomly placed 3 ships:");
            Console.WriteLine("     - 1x Battleship (5 fields);");
            Console.WriteLine("     - 2x Destroyers(4 fields); ");
            Console.WriteLine("- by typing field coordinates in console: column [A - J], row [1 - 10] (without space, for example: B3) and pressing enter you declare to bombard certain field;");
            Console.WriteLine("- be defualt fields are not bombarded and look like [-];");
            Console.WriteLine("- bombarded field where there was not hit ship will be marked as [0];");
            Console.WriteLine("- bombarded field where there was hit ship will be marked as [X];");
            Console.WriteLine("- you will be notified about result of bombarding: MISS, HIT or SINK;");
            Console.WriteLine("- once you destroy all ships you will get notified about victory and asked if you want to play again or close app.");

            Console.WriteLine("\n\nPress any key to return to menu.");
            Console.ReadKey();
        }
    }
}
