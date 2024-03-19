using Game.Engine.Services;
using Game.Prefabs;
using Game.Resources;

var gameRunner = new GameBuilder().BuildRunner();

gameRunner.AssetManager.AddTileSet(@"..\..\..\..\..\resources\tileset1.bmp", TileSets.BaseTileSet.Name, TileSets.BaseTileSet.TileSize);
gameRunner.AssetManager.AddFont(@"..\..\..\..\..\resources\ShareTechMono-Regular.ttf", Fonts.Basic);

gameRunner.GameTree.Add(new Map(200, 200, gameRunner.AssetManager));
gameRunner.GameCanvas.Add(new FpsCounter(gameRunner.AssetManager.GetFont(Fonts.Basic)));

gameRunner.Run();