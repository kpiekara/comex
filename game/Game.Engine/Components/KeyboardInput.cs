using SFML.Window;

namespace Game.Engine.Components;

public enum KeyboardEventKind
{
    Pressed,
    Released
}

public delegate void PressKeyEventHandler(Keyboard.Key code);

public delegate void ReleaseKeyEventHandler(Keyboard.Key code);

public class KeyboardInput
{
    public PressKeyEventHandler Pressed;
    public ReleaseKeyEventHandler Released;
    
    public void KeyEvent(Keyboard.Key code, KeyboardEventKind eventKind)
    {
        if (eventKind == KeyboardEventKind.Pressed)
        {
            Pressed?.Invoke(code);
        }

        if (eventKind == KeyboardEventKind.Released)
        {
            Released?.Invoke(code);
        }
    }
}