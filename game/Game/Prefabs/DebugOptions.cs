using Game.Engine.Components;
using Game.Engine.Configs;
using Game.Engine.Tree;
using SFML.Window;

namespace Game.Prefabs;

public class DebugOptions : GameObject
{
    public DebugOptions(IGameSettings settings)
    {
        var keyboard = Add(new KeyboardInput());
        keyboard.Released += code =>
        {
            switch (code)
            {
                case Keyboard.Key.F1:
                    settings.LimitCameraToMap = !settings.LimitCameraToMap;
                    break;
                default:
                    break;
            }
        };
    }
}