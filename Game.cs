using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleships
{
    public class Game
    {
        private const int maxShips = 3; // creator defined max number of ships to be placed field
        public int shipsNumber;
        public int[] hitsCounter = new int[maxShips];
        public int[] shipSize = new int[maxShips];
        public int sunkCounter;

        public string newBattle = "New Battle has begun!";
        public string incorrectInput = "Incorrect input - formula for picking field should be: column [A - J], row [1 - 10] (without space), example: A1.";

        public string? lastAction;

        public static bool keepPlaying = true;

        Field[,] field = new Field[10, 10];

        public void Launch(params int[] ships)
        {

            // initating fields
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    field[i, j] = new Field(i+1, j+1);
                }
            }

            // getting info about ships
            shipsNumber = ships.Length;
            for (int i = 0; i < ships.Length; i++)
            {
                shipSize[i] = ships[i];
            }

            StartNewGame();

            PlayGame();

        }

        public void StartNewGame()
        {
            ResetGrid();

            sunkCounter = 0;

            for(int i = 0; i < shipsNumber; i++)
            {
                hitsCounter[i] = 0;

                PlaceShip(i, shipSize[i]);
            }
        }

        
        public void PlaceShip(int shipID, int shipSize)
        {
            int cond = 0; // condition checker if space for ship was found (possible when value changed to 1)
            
            while (cond == 0)
            {
                var rnd = new Random();

                int x = rnd.Next(11 - shipSize);
                int y = rnd.Next(11 - shipSize);
                int dir = rnd.Next(2);

                int fieldCheck = 0; // checking if all fields for being created ship are available
                
                for (int i = 0; i < shipSize; i++)
                {
                    switch(dir)
                    {
                        case 0: // horizontal
                        {
                            if (field[x + i, y].shipID >= 0) fieldCheck = 1; // an invalid field for ship
                        }
                        break;
                        
                        case 1: // vertical
                        {
                            if (field[x, y + i].shipID >= 0) fieldCheck = 1; // an invalid field for ship
                        }
                        break;
                    }
                }

                if (fieldCheck == 0) // all fields are avaialable tu put there ship
                {
                    cond = 1;

                    for (int i = 0; i < shipSize; i++)
                    {
                        switch (dir)
                        {
                            case 0: // horizontal
                                {
                                    field[x + i, y].shipID = shipID; // assigning fields with ship ID
                                    //field[x + i, y].status = 2; // quick visual check for placing ships
                                }
                                break;

                            case 1: // vertical
                                {
                                    field[x, y + i].shipID = shipID; // assigning fields with ship ID
                                    //field[x, y + i].status = 2; // quick visual check for placing ships
                                }
                                break;
                        }
                    }
                }
            }
        }
        

        public void PlayGame()
        {
            Console.Clear();

            DrawGrid();

            if (sunkCounter == shipsNumber) // winning game condition - ale ships destryoed
            {
                Console.WriteLine(lastAction);
                Console.WriteLine("ALL SHIPS SUNK! YOU WON!");
                Console.WriteLine("Play again? (y/n)");

                string? command = Console.ReadLine();

                if (command == "y") StartNewGame();
                else if (command == "n") CloseGame();
            }

            else
            {
                Console.WriteLine(lastAction);
                Console.WriteLine("Other commands: new - for starting a new game; exit - for closing the app;");
                Console.WriteLine("Select field to bombard (for example: A1):");

                string? command = Console.ReadLine();


                if (command == "new") StartNewGame();
                else if (command == "exit") CloseGame();

                else
                {
                    int x = -1;
                    int y = -1;

                    if (command.Length == 2)
                    {
                        int xCheck = (int)Char.GetNumericValue(command[1]); // checking if written x cord is in bounds
                        if (xCheck >= 1 && xCheck <= 9) x = xCheck - 1;
                        y = AssignColumn(command[0]);
                    }

                    else if (command.Length == 3)
                    {
                        if (command[1] == '1' && command[2] == '0') x = 9;
                        y = AssignColumn(command[0]);
                    }

                    if (x == -1 || y == -1) lastAction = incorrectInput;

                    else // correct input - check field
                    {
                        if (field[x, y].status == 0) // not bombarded yet
                        {
                            if (field[x, y].shipID == -1) // MISS
                            {
                                lastAction = "Selected field: (" + command + ") - MISS!";
                                field[x, y].status = 2;
                            }
                            else if (field[x, y].shipID > -1) // HIT / SINK
                            {
                                field[x, y].status = 1;
                                hitsCounter[field[x, y].shipID]++;

                                if (hitsCounter[field[x, y].shipID] == shipSize[field[x, y].shipID]) // SINK
                                {
                                    string shipName = GiveShipName(shipSize[field[x, y].shipID]);

                                    lastAction = "Selected field: (" + command + ") - SINK! (" + shipName + ")";
                                    sunkCounter++;
                                }
                                else // HIT (only, without SINK)
                                {
                                    lastAction = "Selected field: (" + command + ") - HIT!";
                                }
                            }
                        }
                        else
                        {
                            switch (field[x, y].status) // info about attempt of bombarding previously selected field
                            {
                                case 1:
                                    {
                                        lastAction = "Selected field (" + command + ") was already bombared. It was HIT.";
                                    }
                                    break;

                                case 2:
                                    {
                                        lastAction = "Selected field (" + command + ") was already bombared. It was MISS.";
                                    }
                                    break;
                            }
                        }
                    }

                }
            }

            if(keepPlaying)
            {
                PlayGame();
            }

        }

        public void ResetGrid()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    field[i, j].ClearField();
                }
            }

        }
        public void DrawGrid()
        {
            Console.WriteLine("     ----- BATTLESHIPS -----\n");
            Console.WriteLine("   1  2  3  4  5  6  7  8  9  10");

            for (int i = 0; i <= 9; i++)
            {
                string newGgridline = "";

                switch (i)
                {
                    case 0:
                    {
                        newGgridline = "A ";
                    }
                    break;
                    case 1:
                    {
                        newGgridline = "B ";
                    }
                    break;
                    case 2:
                    {
                        newGgridline = "C ";
                    }
                    break;
                    case 3:
                    {
                        newGgridline = "D ";
                    }
                    break;
                    case 4:
                    {
                        newGgridline = "E ";
                    }
                    break;
                    case 5:
                    {
                        newGgridline = "F ";
                    }
                    break;
                    case 6:
                    {
                        newGgridline = "G ";
                    }
                    break;
                    case 7:
                    {
                        newGgridline = "H ";
                    }
                    break;
                    case 8:
                    {
                        newGgridline = "I ";
                    }
                    break;
                    case 9:
                    {
                        newGgridline = "J ";
                    }
                    break;
                }

                for (int j = 0; j <= 9; j++)
                {
                    // swtich with "[-]" - unexplored (value 0), "[X]" - hit (value 1), "[0]" - miss (value 2)
                    switch (field[j, i].status)
                    {
                        case 0:
                        {
                            newGgridline += "[-]";
                        }
                        break;
                        case 1:
                        {
                            newGgridline += "[X]";
                        }
                        break;
                        case 2:
                        {
                            newGgridline += "[0]";
                        }
                        break;
                    }

                }

                Console.WriteLine(newGgridline);
            }

            Console.Write("\n");
        }

        public static int AssignColumn(char Letter)
        {
            int y = -1;

            switch (Letter)
            {
                case 'A':
                case 'a':
                    {
                        y = 0;
                    }
                    break;

                case 'B':
                case 'b':
                    {
                        y = 1;
                    }
                    break;

                case 'C':
                case 'c':
                    {
                        y = 2;
                    }
                    break;

                case 'D':
                case 'd':
                    {
                        y = 3;
                    }
                    break;

                case 'E':
                case 'e':
                    {
                        y = 4;
                    }
                    break;

                case 'F':
                case 'f':
                    {
                        y = 5;
                    }
                    break;

                case 'G':
                case 'g':
                    {
                        y = 6;
                    }
                    break;

                case 'H':
                case 'h':
                    {
                        y = 7;
                    }
                    break;

                case 'I':
                case 'i':
                    {
                        y = 8;
                    }
                    break;

                case 'J':
                case 'j':
                    {
                        y = 9;
                    }
                    break;
            }

            return y;
        }

        public static string GiveShipName(int shipSize)
        {
            string name;

            switch (shipSize)
            {
                case 2:
                    {
                        name = "Submarine";
                    }
                    break;

                case 3:
                    {
                        name = "Cruiser";
                    }
                    break;

                case 4:
                    {
                        name = "Destroyer";
                    }
                    break;

                case 5:
                    {
                        name = "Battleship";
                    }
                    break;

                default:
                    {
                        name = "Unidentified";
                    }
                    break;
            }

            name += " (" + shipSize + ")";

            return name;
        }

        public static void CloseGame()
        {
            keepPlaying = false;
        }
    }
}
