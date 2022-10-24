namespace battleships

{
    internal class MainProgram
    {
        static void Main(string[] args) // app starts here
        {
            Game game = new();
            game.Launch(5, 4, 4); // launch the game with given ships
        }
    }
}