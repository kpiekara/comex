using Playground.System;

namespace Playground.Examples;

class SimpleWindowExample : IRunnable
{
    public void Run()
    {
        var mode = new SFML.Window.VideoMode(800, 600);
        var window = new SFML.Graphics.RenderWindow(mode, "SFML works!");
        window.KeyPressed += Window_KeyPressed;

        var circle = new SFML.Graphics.CircleShape(100f)
        {
            FillColor = SFML.Graphics.Color.Blue
        };
        
        while (window.IsOpen)
        {
            window.DispatchEvents();
            window.Draw(circle);
            
            window.Display();
        }
    }
    
    private void Window_KeyPressed(object? sender, SFML.Window.KeyEventArgs e)
    {
        var window = sender as SFML.Window.Window;
        if (window is null)
            return;
        
        if (e.Code == SFML.Window.Keyboard.Key.Escape)
        {
            window.Close();
        }
    }
}