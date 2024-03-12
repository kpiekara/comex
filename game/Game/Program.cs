using Game.Engine.Services;
using Game.Prefabs;

var gameRunner = new GameBuilder().BuildRunner();

gameRunner.GameTree.Add(new Map(100, 100, gameRunner.GameTree));

gameRunner.Run();