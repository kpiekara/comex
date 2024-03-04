using Game;
using SFML.System;

var mode = new SFML.Window.VideoMode(1680, 1050);
var window = new SFML.Graphics.RenderWindow(mode, "SFML works!");
var tree = new GameTree();
tree.AddCircle();

var clock = new Clock();
var timeSinceLastUpdate = Time.Zero;
while (window.IsOpen)
{
    var dt = clock.Restart();
    timeSinceLastUpdate += dt;
    while (timeSinceLastUpdate > GameConfig.TimePerFrame)
    {
        timeSinceLastUpdate -= GameConfig.TimePerFrame;
        tree.Update(GameConfig.TimePerFrameInSeconds);
    }

    window.DispatchEvents();
    window.Draw(tree);
    window.Display();
}