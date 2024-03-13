using SFML.Graphics;
using SFML.System;

namespace Game.Engine.Components;

public class Tile : Drawable
{
    private readonly Sprite _sprite;
    
    public Tile(Sprite sprite)
    {
        _sprite = sprite;
    }

    public FloatRect GetGlobalBounds()
    {
        return _sprite.GetGlobalBounds();
    }

    public void SetPosition(float x, float y)
    {
        _sprite.Position = new Vector2f(x, y);
    }
    
    public void SetColor(Color color)
    {
        // nah, ignore it
    }
    
    public void Draw(RenderTarget target, RenderStates states)
    {
        target.Draw(_sprite, states);
    }
}