using Game.Engine.Components;
using Game.Engine.Tree;
using SFML.Graphics;

namespace Game.Prefabs;

public class Circle : GameObject
{
    public Circle(int x, int y)
    {
        var visual = Add(new Visual(Color.Blue));
        visual.SetPosition(x, y);
        var mInput = Add(new MouseInput(visual.GetGlobalBounds()));

        mInput.Click += (x, y) =>
        {
            visual.SetColor(Color.Red);
        };
        
        mInput.UnClick += () =>
        {
            visual.SetColor(Color.Blue);
        };
    }
}