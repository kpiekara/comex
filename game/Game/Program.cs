using Game;
using Game.Tree;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

var mode = new VideoMode(1680, 1050);
var window = new RenderWindow(mode, "SFML works!");

var tree = new GameTree();
tree.AttachEvents(window);
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