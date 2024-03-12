using Game.Engine.Components;
using Game.Engine.Tree;
using SFML.Graphics;

namespace Game.Prefabs;

public class MapTile : GameObject
{
    private readonly bool _isBlocker;
    private readonly bool _isPlayer;
    private readonly Visual _visual;

    public MapTile(float x, float y, float width, float height, bool isBlocker, bool isPlayer)
    {
        _isBlocker = isBlocker;
        _isPlayer = isPlayer;
        
        _visual = Add(new Visual(width, height, isBlocker ? Color.Black : Color.Blue));
        _visual.SetPosition(x, y);

        if (_isPlayer)
        {
            _visual.SetColor(Color.Red);
        }
        
        if (!isBlocker && !_isPlayer)
        {
            var mInput = Add(new MouseInput(_visual.GetGlobalBounds()));

            mInput.Click += (x, y) =>
            {
                _visual.SetColor(Color.Yellow);
            };
        
            mInput.UnClick += () =>
            {
                _visual.SetColor(Color.Blue);
            };
        }
    }
}