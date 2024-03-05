using Game.Components;
using Game.Prefabs;
using SFML.Graphics;

namespace Game.Tree;

public class GameTree : Drawable
{
    private readonly List<GameObject> _gameObjects = new();

    public void AddCircle()
    {
        _gameObjects.Add(new Circle());
    }

    public void Update(float time)
    {
        // todo
    }

    public void Draw(RenderTarget target, RenderStates states)
    {
        foreach (var element in _gameObjects)
        {
            if (element.Has<Visual>())
            {
                target.Draw(element.Get<Visual>(), states);
            }
        }
    }

    public void AttachEvents(RenderWindow window)
    {
        window.KeyPressed += (sender, args) =>
        {
            
        };

        window.KeyReleased += (sender, args) =>
        {

        };

        window.MouseButtonPressed += (sender, args) =>
        {
            foreach (var element in _gameObjects)
            {
                if (element.Has<MouseInput>())
                {
                    element.Get<MouseInput>().MousePressed(args.X, args.Y, args.Button, MouseEventKind.Pressed);
                }
            }
        };

        window.MouseButtonReleased += (sender, args) =>
        {
            foreach (var element in _gameObjects)
            {
                if (element.Has<MouseInput>())
                {
                    element.Get<MouseInput>().MousePressed(args.X, args.Y, args.Button, MouseEventKind.Released);
                }
            }
        };
    }
}