using Game.Engine.Services;
using Game.Prefabs;
using Game.Resources;

var gameRunner = new GameBuilder().BuildRunner();

gameRunner.AssetManager.AddTileSet(@"..\..\..\..\..\resources\tileset1.bmp", TileSets.BaseTileSet.Name, TileSets.BaseTileSet.TileSize);
gameRunner.AssetManager.AddFont(@"..\..\..\..\..\resources\ShareTechMono-Regular.ttf", Fonts.Basic);

gameRunner.GameTree.Add(new Map(300, 300, gameRunner.AssetManager));
gameRunner.GameTree.Add(new DebugOptions(gameRunner.Settings));
gameRunner.GameCanvas.Add(new FpsCounter(gameRunner.AssetManager.GetFont(Fonts.Basic)));

gameRunner.Camera.SetCameraAreaSize(19200, 19200);

gameRunner.Run();