using Game.Engine.Assets;
using Game.Engine.Components;
using Game.Engine.Numeric;
using Game.Engine.Tree;
using Game.Resources;
using SFML.System;

namespace Game.Prefabs;

public class Map : GameObject
{
    public TileMap TileMap { get; set; }
    
    public Map(uint width, uint height, IAssetManager assetManager)
    {
        var tileSize = new Vector2u(64, 64);
        var mapSize = new Vector2u(height, width);

        var tiles = new List<uint>();
        for (uint i = 0; i < mapSize.X; i++)
        {
            for (uint j = 0; j < mapSize.Y; j++)
            {
                if (Randomization.Bool(0.1f))
                {
                    tiles.Add(2);
                }
                else
                {
                    tiles.Add(1);
                }
            }
        }

        var texture = assetManager.GetTexture(TileSets.BaseTileSet.Name);
        TileMap = Add(new TileMap(texture, tileSize, mapSize, tiles));
    }
}