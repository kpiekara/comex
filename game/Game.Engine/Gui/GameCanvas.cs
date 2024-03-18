using Game.Engine.Tree;
using SFML.Graphics;
using SFML.System;

namespace Game.Engine.Gui;

public interface IGameCanvas
{
    GameObject Add(GameObject gameObject);
}

class GameCanvas : IGameCanvas, Drawable
{
    private readonly List<GameObject> _gameObjects = new();
    private readonly View _view;

    public GameCanvas(float x, float y)
    {
        _view = new View(new Vector2f(x/2, y/2), new Vector2f(x, y));
    }

    public GameObject Add(GameObject gameObject)
    {
        _gameObjects.Add(gameObject);
        return gameObject;
    }

    public void UpdateFixed(float time)
    {
        foreach (var element in _gameObjects)
        {
            element.UpdateFixed(time);
        }
    }

    public void Update(float time)
    {
        foreach (var element in _gameObjects)
        {
            element.Update(time);
        }
    }
    
    public View GetView()
    {
        return _view;
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
}