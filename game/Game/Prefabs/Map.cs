using Game.Engine.Assets;
using Game.Engine.Configs;
using Game.Engine.Numeric;
using Game.Engine.Tree;
using Game.Resources;

namespace Game.Prefabs;

public class Map : GameObject
{
    public Map(int height, int width, IGameTree tree, IAssetManager assetManager)
    {
        const float tileSize = 64;
        var mapWidth = width * tileSize;
        var mapHeight = height * tileSize;
        var centerX = mapWidth / 2.0f - Config.ScreenWidth / 2.0f;
        var centerY = mapHeight / 2.0f - Config.ScreenHeight / 2.0f;
        
        var map = new MapTile[height][];
        for (var i = 0; i < height; i++)
        {
            map[i] = new MapTile[width];
            for (var j = 0; j < width; j++)
            {
                if (Randomization.Bool(0.1f))
                {
                    var stoneTile = assetManager.CreateTile(TileSets.BaseTileSet.Name, 2);
                    map[i][j] = new MapTile(-centerX + j * tileSize, -centerY + i * tileSize, true, stoneTile);
                }
                else
                {
                    var waterTile = assetManager.CreateTile(TileSets.BaseTileSet.Name, 1);
                    map[i][j] = new MapTile(-centerX + j * tileSize, -centerY + i * tileSize, false, waterTile);
                }
                
                tree.Add(map[i][j]);
            }
        }
    }
}