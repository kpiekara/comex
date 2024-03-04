using SFML.System;

namespace Game;

public static class GameConfig
{
    public static Time TimePerFrame { get; }
    public static float TimePerFrameInSeconds { get; }

    static GameConfig()
    {
        TimePerFrame = Time.FromSeconds(1.0f / 60.0f);
        TimePerFrameInSeconds = TimePerFrame.AsSeconds();
    }
}