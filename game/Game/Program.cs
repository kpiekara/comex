using Game.Engine.Services;
using Game.Prefabs;

var gameRunner = new GameBuilder().BuildRunner();

gameRunner.GameTree.Add(new Circle());
gameRunner.Run();