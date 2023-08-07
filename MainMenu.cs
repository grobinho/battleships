using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleships
{
    public class MainMenu
    {
        private static int[] shipParam = { 1, 1, 1, 0, 0 };
        private static string slotChosen = "0";

        public static void ShowMenu()
        {
            DrawLogo();
            Console.WriteLine("Main Menu - type number and press ENTER:");
            Console.WriteLine("1 - PLAY");
            Console.WriteLine("2 - SETTINGS");
            Console.WriteLine("3 - HELP");
            Console.WriteLine("4 - QUIT");

            switch(Console.ReadLine())
            {
                case "1": // start game
                {
                    Game game = new(shipParam[0], shipParam[1], shipParam[2], shipParam[3], shipParam[4]);
                }
                break;
                case "2": // get into settings
                {
                    GetIntoOptions();
                }
                break;
                case "3": // show some info
                {
                    ShowAboutInfo();
                }
                break;
                case "4": // close app
                {
                    Environment.Exit(0);
                }
                break;
            }

            ShowMenu();
        }

        public static void DrawLogo()
        {
            Console.Clear();
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
            ShowHeader("HELP");
            Console.WriteLine("The game resembles battleships baord game:");
            Console.WriteLine("- you will see battlefield as 10 x 10 grid:");
            Console.WriteLine("     - rows will be numbered in consecutive letters;");
            Console.WriteLine("     - columns will be numbered in consecutive digits;");
            Console.WriteLine("- as default setting there will be randomly placed 3 ships, with every having random length;");
            Console.WriteLine("- ships quantity can be adjusted - with minimum of 1 and maximum of 5;");
            Console.WriteLine("- ships length can be set as below or set to random (in that second case one from list below will be picked):");
            Console.WriteLine("     - Battleship (5 fields) - most powerful and largest ship;");
            Console.WriteLine("     - Destroyer (4 fields) - slightly smaller but still powerful;");
            Console.WriteLine("     - Cruiser (3 fields) - moderately powerful and versatile;");
            Console.WriteLine("     - Submarine (2 fields) - smallest but agile and capable of surprise attacks; ");
            Console.WriteLine("- by typing field coordinates in console: column [A - J], row [1 - 10] (without space, for example: B3) and pressing enter you declare to bombard certain field;");
            Console.WriteLine("- at the start of the battle fields are not bombarded and look like [-];");
            Console.WriteLine("- bombarded field where there was not hit ship will be marked as [0];");
            Console.WriteLine("- bombarded field where there was hit ship will be marked as [X];");
            Console.WriteLine("- you will be notified about result of bombarding: MISS, HIT or SINK (in third scenario you will also get notified about ship's length you sunk);");
            Console.WriteLine("- once you destroy all ships you will get notified about victory and asked if you want to play again or return to main menu.");

            Console.WriteLine("\n\nPress any key to return to menu.");
            Console.ReadKey();
        }

        public static void GetIntoOptions()
        {
            ShowHeader("SETTINGS");

            Console.WriteLine("Ships configuration on battlefield:\n");

            for (int i = 0; i < shipParam.Length; i++)
            {
                switch (shipParam[i])
                {
                    case 0:
                        {
                            Console.WriteLine($"SLOT {i + 1}: no ship");
                        }
                        break;
                    case 1:
                        {
                            Console.WriteLine($"SLOT {i + 1}: random ship");
                        }
                        break;
                    case var _ when shipParam[i] >= 2 && shipParam[i] <= 5:
                        {
                            Console.WriteLine($"SLOT {i + 1}: ship with {shipParam[i]} tiles");
                        }
                        break;
                }
            }

            bool keepSettinging = true;
            
            if (slotChosen == "0")
            {
                Console.WriteLine("\n\n1 - 5 - choose ship slot to adjust");
                Console.WriteLine("6 - exit");

                string? command = Console.ReadLine();

                switch (command)
                {
                    case var _ when command == "1" || command == "2" || command == "3" || command == "4" || command == "5":
                    {
                        slotChosen = command;
                    }
                    break;
                    case "6":
                    {
                        keepSettinging = false;
                    }
                    break;
                }
            }
            else
            {
                Console.WriteLine($"\n\nEditing SLOT {slotChosen}. Please input value you want to assign for:");
                Console.WriteLine("1 - random");
                Console.WriteLine("2 - 5 - define ship with such number of fields");
                Console.WriteLine("6 - return");

                string? command = Console.ReadLine();

                switch (command)
                {
                    case var _ when command == "1" || command == "2" || command == "3" || command == "4" || command == "5":
                    {
                        if(int.TryParse(command, out int resultValue) && int.TryParse(slotChosen, out int resultSlot))
                        {
                            shipParam[resultSlot - 1] = resultValue;
                        }
                        slotChosen = "0";
                    }
                    break;
                    case "6":
                    {
                        slotChosen = "0";
                    }
                    break;
                }
            }

            if(keepSettinging)
            {
                GetIntoOptions();
            }
            
        }

        private static void ShowHeader(string title)
        {
            Console.Clear();
            Console.WriteLine("BATTLESHIPS - " + title + "\n\n");
        }
    }
}
