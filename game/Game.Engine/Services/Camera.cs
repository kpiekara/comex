using Game.Engine.Configs;
using Game.Engine.Numeric;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Game.Engine.Services;

public delegate void CameraMovedEventHandler(Vector2f position);

public interface ICamera
{
    public void SetCameraAreaSize(float x, float y);
}

public class Camera : ICamera
{
    public event CameraMovedEventHandler? CameraMoved;
    
    private readonly View _view;

    private float _wheelDelta = 0f;
    private float _currentZoom = 1f;
    private float _zoomTarget = 1f;
    private float _zoomVelocity = 0f;
    private readonly float _zoomSmoothTime = 0.25f;

    private float _currentMoveX = 0f;
    private float _moveTargetX = 0f;
    private float _moveVelocityX = 0f;
    private float _currentMoveY = 0f;
    private float _moveTargetY = 0f;
    private float _moveVelocityY = 0f;
    private readonly float _moveSmoothTime = 0.1f;
    
    private readonly Vector2f _size;

    private Vector2f _areaSize;

    public Camera(View view)
    {
        _view = new View(view);
        _size = view.Size;
    }

    public void Update(float time)
    {
        var move = new Vector2f();
        var step = Config.CameraSpeed * time;
        if (Keyboard.IsKeyPressed(Keyboard.Key.A))
        {
            move.X -= step;
        }
        
        if (Keyboard.IsKeyPressed(Keyboard.Key.D))
        {
            move.X += step;
        }
        
        if (Keyboard.IsKeyPressed(Keyboard.Key.W))
        {
            move.Y -= step;
        }
        
        if (Keyboard.IsKeyPressed(Keyboard.Key.S))
        {
            move.Y += step;
        }

        _moveTargetX = move.X * _currentZoom;
        _currentMoveX = Interpolation.SmoothDamp(_currentMoveX, _moveTargetX, ref _moveVelocityX, _moveSmoothTime, float.MaxValue, Config.TimePerFrameInSeconds);
        
        _moveTargetY = move.Y * _currentZoom;
        _currentMoveY = Interpolation.SmoothDamp(_currentMoveY, _moveTargetY, ref _moveVelocityY, _moveSmoothTime, float.MaxValue, Config.TimePerFrameInSeconds);
        
        _view.Move(new Vector2f(_currentMoveX, _currentMoveY));
        CameraMoved?.Invoke(_view.Center);
        
        _zoomTarget -= _wheelDelta * Config.WorldZoomSpeed;
        _zoomTarget = Math.Clamp(_zoomTarget, Config.WorldZoomMin, Config.WorldZoomMax);
        _currentZoom = Interpolation.SmoothDamp(_currentZoom, _zoomTarget, ref _zoomVelocity, _zoomSmoothTime, float.MaxValue, Config.TimePerFrameInSeconds);
        
        _view.Size = _size * _currentZoom;
        _wheelDelta = 0;
    }

    public void LimitCamera(RenderWindow window)
    {
        var topLeft = window.MapPixelToCoords(new Vector2i(0, 0), _view);
        var fix = new Vector2f();
        if (topLeft.X < 0)
        {
            fix.X = -(topLeft.X - 0);
        }
        
        if (topLeft.Y < 0)
        {
            fix.Y = -(topLeft.Y - 0);
        }
        
        var bottomRight = window.MapPixelToCoords(new Vector2i((int)window.Size.X, (int)window.Size.Y), _view);
        
        if (bottomRight.X > _areaSize.X)
        {
            fix.X = -(bottomRight.X - _areaSize.X);
        }
        
        if (bottomRight.Y > _areaSize.Y)
        {
            fix.Y = -(bottomRight.Y - _areaSize.Y);
        }
        
        _view.Move(fix);
    }
    
    public View GetView()
    {
        return _view;
    }

    public void AttachEvents(RenderWindow window)
    {
        window.MouseWheelScrolled += (sender, args) =>
        {
            if (args.Wheel == Mouse.Wheel.VerticalWheel)
            {
                _wheelDelta += args.Delta;
            }
        };
    }

    public void SetCameraAreaSize(float x, float y)
    {
        _areaSize = new Vector2f(x, y);
        _view.Move(new Vector2f(x / 2, y / 2));
    }
}