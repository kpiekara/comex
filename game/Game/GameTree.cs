using SFML.Graphics;

namespace Game;

public class GameTree : Drawable
{
    private readonly List<Drawable> _drawables = new();

    public void AddCircle()
    {
        var circle = new CircleShape(100f)
        {
            FillColor = Color.Blue
        };
        
        _drawables.Add(circle);
    }

    public void Update(float time)
    {
        // todo
    } 

    public void Draw(RenderTarget target, RenderStates states)
    {
        foreach (var drawable in _drawables)
        {
            target.Draw(drawable, states);
        }
    }
}