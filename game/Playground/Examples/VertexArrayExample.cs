using Playground.System;
using SFML.Graphics;
using SFML.System;

namespace Examples;

class VaImage : Drawable
{
    private readonly VertexArray _array;
    private Texture _texture;
    public VaImage()
    {
        _texture = new Texture("..\\..\\..\\..\\..\\resources\\tileset1.bmp");
        _array = new VertexArray
        {
            PrimitiveType = PrimitiveType.Triangles
        };
        
        _array.Resize(6);

        _array[0] = new Vertex
        {
            Position = new Vector2f(0, 0),
            TexCoords = new Vector2f(0, 0),
            Color = Color.White
        };

        _array[1] = new Vertex
        {
            Position = new Vector2f(300, 0),
            TexCoords = new Vector2f(300, 0),
            Color = Color.White
        };

        _array[2] = new Vertex
        {
            Position = new Vector2f(300, 300),
            TexCoords = new Vector2f(300, 300),
            Color = Color.White
        };

        _array[3] = new Vertex
        {
            Position = new Vector2f(0, 0),
            TexCoords = new Vector2f(0, 0),
            Color = Color.Green
        };

        _array[4] = new Vertex
        {
            Position = new Vector2f(300, 300),
            TexCoords = new Vector2f(300, 300),
            Color = Color.Green
        };

        _array[5] = new Vertex
        {
            Position = new Vector2f(0, 300),
            TexCoords = new Vector2f(0, 300),
            Color = Color.Green
        };
    }

    public void Draw(RenderTarget target, RenderStates states)
    {
        states.Texture = _texture;
        target.Draw(_array, states);
    }
}

class VertexArrayExample : IRunnable
{
    public void Run()
    {
        var mode = new SFML.Window.VideoMode(800, 600);
        var window = new RenderWindow(mode, "SFML works!");
        window.KeyPressed += Window_KeyPressed;

        var circle = new CircleShape(100f)
        {
            FillColor = Color.Blue
        };

        var image = new VaImage();
        
        while (window.IsOpen)
        {
            window.DispatchEvents();
            window.Draw(circle);
            window.Draw(image);
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