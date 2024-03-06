namespace Game.Engine.Services;

public class GameBuilder
{
    public IGameRunner BuildRunner()
    {
        return new GameRunner();
    }
}