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

    try
    {
        game.Play(new Coordinates(coordinateX, coordinateY));
    }
    catch (Exception _)
    {
        Console.WriteLine("The move cannot be performed due to an error. Try again.");
        Console.ReadLine();
    }
} while (game.GetStatus() == Status.NotFinished);


Console.Clear();
Console.WriteLine(game.PrintBoard());
