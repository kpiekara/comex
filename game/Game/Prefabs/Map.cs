using Game.Engine.Assets;
using Game.Engine.Components;
using Game.Engine.Tree;
using Game.Resources;
using Game.Utils;
using SFML.System;

namespace Game.Prefabs;

public class Map : GameObject
{
    public TileMap TileMap { get; set; }
    
    public Map(MapFile mapFile, IAssetManager assetManager)
    {
        var tileSize = new Vector2u(64, 64);
        
        var tiles = new List<uint>();
        for (uint i = 0; i < mapFile.X; i++)
        {
            for (uint j = 0; j < mapFile.Y; j++)
            {
                var node = mapFile.Nodes[i, j];
                if (node.IsStone)
                {
                    tiles.Add(2);
                }
                else if (node.IsWater)
                {
                    tiles.Add(1);
                }
                else
                {
                    throw new Exception("Find me!");
                }
            }
        }

        var texture = assetManager.GetTexture(TileSets.BaseTileSet.Name);
        TileMap = Add(new TileMap(texture, tileSize, new Vector2u(mapFile.X, mapFile.Y), tiles));
    }
}