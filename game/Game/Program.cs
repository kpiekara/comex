using Game.Engine.Services;
using Game.Prefabs;
using Game.Resources;

var gameRunner = new GameBuilder().BuildRunner();

gameRunner.AssetManager.AddTileSet(@"..\..\..\..\..\resources\tileset1.bmp", TileSets.BaseTileSet.Name, TileSets.BaseTileSet.TileSize);

gameRunner.GameTree.Add(new Map(100, 100, gameRunner.GameTree, gameRunner.AssetManager));

gameRunner.Run();