using SFML.System;

namespace Game.Engine.Configs;

public static class Config
{
    public static Time TimePerFrame { get; }
    public static float TimePerFrameInSeconds { get; }
    
    public static float CameraSpeed => 800f;
    public static float WorldZoomSpeed => 0.3f;
    public static float WorldZoomMin => 0.5f;
    public static float WorldZoomMax => 8f;
    
    public static uint ScreenWidth => 1680;
    public static uint ScreenHeight => 1050;
    

    static Config()
    {
        TimePerFrame = Time.FromSeconds(1.0f / 60.0f);
        TimePerFrameInSeconds = TimePerFrame.AsSeconds();
    }
}