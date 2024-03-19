using System.Globalization;
using Game.Engine.Components;
using Game.Engine.Tree;
using SFML.Graphics;

namespace Game.Prefabs;

public class FpsCounter : GameObject
{
    private readonly Label _label;
    
    public FpsCounter(Font font)
    {
        _label = Add(new Label(font));
        _label.SetPosition(0, 0);
        _label.SetColor(Color.Red);
        _label.SetBold(true);
    }

    public override void Update(float dt)
    {
        _label.SetText(Math.Floor(1 / dt).ToString(CultureInfo.InvariantCulture));
    }
}