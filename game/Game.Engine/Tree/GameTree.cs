using Game.Engine.Components;
using Game.Engine.Services;
using SFML.Graphics;
using SFML.System;

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
            foreach (var drawable in element.GetDrawables())
            {
                target.Draw(drawable, states);
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
            if (sender is RenderWindow rw)
            {
                foreach (var element in _gameObjects)
                {
                    if (element.Has<MouseInput>())
                    {
                        var pos = rw.MapPixelToCoords(new Vector2i(args.X, args.Y));
                        element.Get<MouseInput>().MousePressed(pos.X, pos.Y, args.Button, MouseEventKind.Pressed);
                    }
                }
            }
        };

        window.MouseButtonReleased += (sender, args) =>
        {
            if (sender is RenderWindow rw)
            {
                foreach (var element in _gameObjects)
                {
                    if (element.Has<MouseInput>())
                    {
                        var pos = rw.MapPixelToCoords(new Vector2i(args.X, args.Y));
                        element.Get<MouseInput>().MousePressed(pos.X, pos.Y, args.Button, MouseEventKind.Released);
                    }
                }
            }
        };
    }

    public void AttachCameraEvents(Camera camera)
    {
        camera.CameraMoved += position =>
        {
            foreach (var element in _gameObjects)
            {
                if (element.Has<CameraListener>())
                {
                    element.Get<CameraListener>().SetPosition(position);
                }
            }
        };
    }
}