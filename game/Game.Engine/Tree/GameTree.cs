using Game.Engine.Components;
using SFML.Graphics;

namespace Game.Engine.Tree;

public interface IGameTree
{
    GameObject Add(GameObject gameObject);
}

class GameTree : Drawable, IGameTree
{
    private readonly List<GameObject> _gameObjects = new();

    public GameObject Add(GameObject gameObject)
    {
        _gameObjects.Add(gameObject);
        return gameObject;
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