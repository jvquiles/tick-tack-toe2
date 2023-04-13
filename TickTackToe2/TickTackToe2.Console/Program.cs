using TickTackToe2.Console;

var game = new Game();
Console.WriteLine(game.PrintBoard());

Console.Write("X: ");
var coordinateX = Convert.ToInt32(Console.ReadLine());
Console.Write("Y: ");
var coordinateY = Convert.ToInt32(Console.ReadLine());

game.Play(coordinateX, coordinateY);
Console.Clear();
Console.WriteLine(game.PrintBoard());