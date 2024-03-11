using SFML.Graphics;
using SFML.System;

namespace Game.Engine.Components;

public class Visual : Drawable
{
    private readonly CircleShape _circle;
    
    public Visual(Color color)
    {
        _circle = new CircleShape(100f)
        {
            FillColor = color
        };
    }

    public FloatRect GetGlobalBounds()
    {
        return _circle.GetGlobalBounds();
    }

    public void SetPosition(int x, int y)
    {
        _circle.Position = new Vector2f(x, y);
    }

    public void SetColor(Color color)
    {
        _circle.FillColor = color;
    }
    
    public void Draw(RenderTarget target, RenderStates states)
    {
        target.Draw(_circle, states);
    }
}