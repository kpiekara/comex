using SFML.System;

namespace Game.Engine.Configs;

public static class Config
{
    public static Time TimePerFrame { get; }
    public static float TimePerFrameInSeconds { get; }

    static Config()
    {
        TimePerFrame = Time.FromSeconds(1.0f / 60.0f);
        TimePerFrameInSeconds = TimePerFrame.AsSeconds();
    }
}