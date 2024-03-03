using SFML.Graphics;
using SFML.Window;

var mode = new VideoMode(800, 600);
var window = new RenderWindow(mode, "SFML works!");

var circle = new CircleShape(100)
{
    FillColor = Color.Blue
};

while (window.IsOpen)
{
    window.DispatchEvents();
    window.Clear();
    window.Draw(circle);
    window.Display();
}