using SFML.Graphics;
using SFML.System;

namespace Game.Engine.Components;

public class Shape2d : Drawable
{
    private readonly Shape _shape;
    
    public Shape2d(float radius, Color color)
    {
        _shape = new CircleShape(radius)
        {
            FillColor = color
        };
    }

    public Shape2d(float width, float height, Color color)
    {
        _shape = new RectangleShape(new Vector2f(width, height))
        {
            FillColor = color
        };
    }

    public FloatRect GetGlobalBounds()
    {
        return _shape.GetGlobalBounds();
    }

    public void SetPosition(float x, float y)
    {
        _shape.Position = new Vector2f(x, y);
    }

    public void SetColor(Color color)
    {
        _shape.FillColor = color;
    }
    
    public void Draw(RenderTarget target, RenderStates states)
    {
        target.Draw(_shape, states);
    }
}