using Game.Engine.Configs;
using Game.Engine.Numeric;
using Game.Engine.Tree;

namespace Game.Prefabs;

public class Map : GameObject
{
    public Map(int height, int width, IGameTree tree)
    {
        const float tileSize = 32;
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
                if (i == width / 2 && j == height / 2)
                {
                    map[i][j] = new MapTile(-centerX + j * tileSize, -centerY + i * tileSize, tileSize, tileSize, true, true);
                }
                else if (Randomization.Bool(0.1f))
                {
                    map[i][j] = new MapTile(-centerX + j * tileSize, -centerY + i * tileSize, tileSize, tileSize, true, false);
                }
                else
                {
                    map[i][j] = new MapTile(-centerX + j * tileSize, -centerY + i * tileSize, tileSize, tileSize, false, false);
                }
                
                tree.Add(map[i][j]);
            }
        }
    }
}