namespace Game.Engine.Configs;

public interface IGameSettings
{
    bool LimitCameraToMap { get; set; }
}

class GameSettings : IGameSettings
{
    public bool LimitCameraToMap { get; set; } = true;
}