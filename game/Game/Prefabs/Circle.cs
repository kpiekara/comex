using Game.Components;
using Game.Tree;
using SFML.Graphics;

namespace Game.Prefabs;

public class Circle : GameObject
{
    public Circle()
    {
        var visual = Add(new Visual(Color.Blue));
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