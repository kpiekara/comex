using SFML.Graphics;

namespace Game.Components;

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

    public void SetColor(Color color)
    {
        _circle.FillColor = color;
    }
    
    public void Draw(RenderTarget target, RenderStates states)
    {
        target.Draw(_circle, states);
    }
}