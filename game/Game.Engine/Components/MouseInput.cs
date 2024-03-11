using SFML.Graphics;
using SFML.Window;

namespace Game.Engine.Components;

public enum MouseEventKind
{
    Pressed,
    Released
}

public delegate void ClickEventHandler(float x, float y);
public delegate void UnClickEventHandler();

public class MouseInput
{
    private FloatRect _area;
    private bool _pressedIn = false;
    private bool _clicked = false;

    public event ClickEventHandler? Click;
    public event UnClickEventHandler? UnClick;

    public MouseInput(FloatRect area)
    {
        _area = area;
    }
    
    public bool MousePressed(float x, float y,Mouse.Button button, MouseEventKind eventKind)
    {
        var clickIn = _area.Contains(x, y);
        if (!clickIn)
        {
            _pressedIn = false;
            UnClick?.Invoke();
            return false;
        }
        
        if (eventKind == MouseEventKind.Pressed)
        {
            _pressedIn = true;
        }
        
        if (eventKind == MouseEventKind.Released)
        {
            if (_pressedIn)
            {
                Click?.Invoke(x, y);
                _pressedIn = false;
                return true;
            }
        }
        
        return false;
    }
}