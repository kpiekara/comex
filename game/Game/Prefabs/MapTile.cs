using Game.Engine.Components;
using Game.Engine.Tree;

namespace Game.Prefabs;

public class MapTile : GameObject
{
    private readonly bool _isBlocker;
    private readonly Tile _tile;

    public MapTile(float x, float y, bool isBlocker, Tile tile)
    {
        _isBlocker = isBlocker;
        
        _tile = Add(tile);
        _tile.SetPosition(x, y);
        
        if (!isBlocker)
        {
            var mInput = Add(new MouseInput(_tile.GetGlobalBounds()));

            mInput.Click += (x, y) =>
            {
                // todo
            };
        
            mInput.UnClick += () =>
            {
                // todo
            };
        }
    }
}