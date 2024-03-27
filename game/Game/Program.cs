using Game.Engine.Services;
using Game.Prefabs;
using Game.Resources;
using Game.Utils;

var gameRunner = new GameBuilder().BuildRunner();

gameRunner.AssetManager.AddTileSet(@"..\..\..\..\..\resources\tileset1.bmp", TileSets.BaseTileSet.Name, TileSets.BaseTileSet.TileSize);
gameRunner.AssetManager.AddFont(@"..\..\..\..\..\resources\ShareTechMono-Regular.ttf", Fonts.Basic);


var mapEditor = new MapEditor();
var randomMap = mapEditor.Load("..\\..\\..\\..\\..\\resources\\example.area");

gameRunner.GameTree.Add(new Map(randomMap, gameRunner.AssetManager));
gameRunner.GameTree.Add(new DebugOptions(gameRunner.Settings));
gameRunner.GameCanvas.Add(new FpsCounter(gameRunner.AssetManager.GetFont(Fonts.Basic)));

gameRunner.Camera.SetCameraAreaSize(19200, 19200);

gameRunner.Run();