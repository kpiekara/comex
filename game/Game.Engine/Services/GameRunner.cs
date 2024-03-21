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
    IGameSettings Settings { get; }
    ICamera Camera { get; }
    void Run();
}

class GameRunner : IGameRunner
{
    public IGameCanvas GameCanvas => _gameCanvas;
    private readonly GameCanvas _gameCanvas;
    
    public IGameTree GameTree => _gameTree;
    readonly GameTree _gameTree = new();

    public IAssetManager AssetManager => _assetManager;
    private readonly AssetManager _assetManager = new();

    public IGameSettings Settings => _settings;
    private readonly GameSettings _settings = new();

    public ICamera Camera => _camera;
    private readonly Camera _camera;
    private readonly RenderWindow _window;

    public GameRunner()
    {
        var mode = new VideoMode(1680, 1050);
        _window = new RenderWindow(mode, "SFML works!");
        
        _gameCanvas = new GameCanvas(_window.Size.X, _window.Size.Y);
        _gameTree.AttachEvents(_window);
        
        _camera = new Camera(_window.GetView());
        _camera.AttachEvents(_window);
        _gameTree.AttachCameraEvents(_camera);
    }
    
    public void Run()
    {
        var clockFixed = new Clock();
        var clock = new Clock();
        var timeSinceLastUpdate = Time.Zero;
        
        while (_window.IsOpen)
        {
            var dt = clockFixed.Restart();
            timeSinceLastUpdate += dt;
            while (timeSinceLastUpdate > Config.TimePerFrame)
            {
                timeSinceLastUpdate -= Config.TimePerFrame;
                _gameTree.UpdateFixed(Config.TimePerFrameInSeconds);
                _gameCanvas.UpdateFixed(Config.TimePerFrameInSeconds);
                _camera.Update(Config.TimePerFrameInSeconds);
            }

            var currentTime = clock.Restart().AsSeconds();
            _gameTree.Update(currentTime);
            _gameCanvas.Update(currentTime);
            
            _window.DispatchEvents();
            _window.Clear();

            if (_settings.LimitCameraToMap)
            {
                _camera.LimitCamera(_window);
            }
            
            _window.SetView(_camera.GetView());
            _window.Draw(_gameTree);
            _window.SetView(_gameCanvas.GetView());
            _window.Draw(_gameCanvas);
            _window.Display();
        }
    }
}