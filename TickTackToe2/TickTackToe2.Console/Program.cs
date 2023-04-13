using TickTackToe2.Console;

var game = new Game();

do
{
    Console.Clear();
    Console.WriteLine(game.PrintBoard());

    Console.Write("Enter coordinates for X: ");
    var coordinateX = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter coordinates for Y: ");
    var coordinateY = Convert.ToInt32(Console.ReadLine());

    game.Play(coordinateX, coordinateY);
} while (true);
