using Game.Engine.Configs;
using Game.Engine.Tree;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Game.Engine.Services;

public interface IGameRunner
{
    public IGameTree GameTree { get; }
    public void Run();
}

class GameRunner : IGameRunner
{
    public IGameTree GameTree => _gameTree;
    readonly GameTree _gameTree = new();
    
    public void Run()
    {
        var mode = new VideoMode(1680, 1050);
        var window = new RenderWindow(mode, "SFML works!");
        
        _gameTree.AttachEvents(window);

        var clock = new Clock();
        var timeSinceLastUpdate = Time.Zero;
        while (window.IsOpen)
        {
            var dt = clock.Restart();
            timeSinceLastUpdate += dt;
            while (timeSinceLastUpdate > Config.TimePerFrame)
            {
                timeSinceLastUpdate -= Config.TimePerFrame;
                _gameTree.Update(Config.TimePerFrameInSeconds);
            }

            window.DispatchEvents();
            window.Draw(_gameTree);
            window.Display();
        }
    }
}