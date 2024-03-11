using Game.Engine.Services;
using Game.Prefabs;

var gameRunner = new GameBuilder().BuildRunner();

gameRunner.GameTree.Add(new Circle(100, 200));
gameRunner.GameTree.Add(new Circle(300, 250));
gameRunner.GameTree.Add(new Circle(320, 120));
gameRunner.GameTree.Add(new Circle(900, 1200));
gameRunner.GameTree.Add(new Circle(1000, 400));

gameRunner.Run();