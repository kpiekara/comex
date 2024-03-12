using SFML.System;

namespace Game.Engine.Components;

public class CameraListener
{
    private Vector2f _position = new();
    
    public CameraListener()
    {
        
    }

    public void SetPosition(Vector2f position)
    {
        _position = position;
    }

    public Vector2f GetPosition()
    {
        return _position;
    }
}