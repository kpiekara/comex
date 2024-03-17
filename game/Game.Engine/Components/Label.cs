using SFML.Graphics;
using SFML.System;

namespace Game.Engine.Components;

public class Label : Drawable
{
    private readonly Text _text;

    public Label(Font font, uint size = 30)
    {
        _text = new Text("", font, size);
    }

    public void SetPosition(float x, float y)
    {
        _text.Position = new Vector2f(x, y);
    }

    public void SetSize(uint size)
    {
        _text.CharacterSize = size;
    }
    
    public void SetColor(Color color)
    {
        _text.FillColor = color;
    }

    public void SetBold(bool isBold)
    {
        if (isBold)
        {
            _text.Style |= Text.Styles.Bold;
        }
        else
        {
            _text.Style  &= ~Text.Styles.Bold;
        }
    }

    public void SetText(string text)
    {
        _text.DisplayedString = text;
    }

    public void Draw(RenderTarget target, RenderStates states)
    {
        target.Draw(_text, states);
    }
}