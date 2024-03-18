using Game.Engine.Assets;
using Game.Engine.Configs;
using Game.Engine.Gui;
using Game.Engine.Tree;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Game.Engine.Services;

public interface IGameRunner
{
    IGameCanvas GameCanvas { get; }
    IGameTree GameTree { get; }
    IAssetManager AssetManager { get; }
    void Run();
}

class GameRunner : IGameRunner
{
    public IGameCanvas GameCanvas => _gameCanvas;
    private GameCanvas _gameCanvas;
    
    public IGameTree GameTree => _gameTree;
    readonly GameTree _gameTree = new();

    public IAssetManager AssetManager => _assetManager;
    private readonly AssetManager _assetManager = new();

    public GameRunner()
    {
        _gameCanvas = new GameCanvas(1680, 1050);
    }
    
    public void Run()
    {
        var mode = new VideoMode(1680, 1050);
        var window = new RenderWindow(mode, "SFML works!");
        
        _gameTree.AttachEvents(window);
        
        var camera = new Camera(window.GetView());
        camera.AttachEvents(window);
        _gameTree.AttachCameraEvents(camera);

        var clockFixed = new Clock();
        var clock = new Clock();
        var timeSinceLastUpdate = Time.Zero;
        
        while (window.IsOpen)
        {
            var dt = clockFixed.Restart();
            timeSinceLastUpdate += dt;
            while (timeSinceLastUpdate > Config.TimePerFrame)
            {
                timeSinceLastUpdate -= Config.TimePerFrame;
                _gameTree.UpdateFixed(Config.TimePerFrameInSeconds);
                _gameCanvas.UpdateFixed(Config.TimePerFrameInSeconds);
                camera.Update(Config.TimePerFrameInSeconds);
            }

            var currentTime = clock.Restart().AsSeconds();
            _gameTree.Update(currentTime);
            _gameCanvas.Update(currentTime);
            
            window.DispatchEvents();
            window.Clear();
            window.SetView(camera.GetView());
            window.Draw(_gameTree);
            window.SetView(_gameCanvas.GetView());
            window.Draw(_gameCanvas);
            window.Display();
        }
    }
}