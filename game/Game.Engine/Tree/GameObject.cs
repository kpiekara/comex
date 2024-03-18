using SFML.Graphics;

namespace Game.Engine.Tree;

public class GameObject
{
    private readonly Dictionary<string, object> _components = new();
    private readonly List<Drawable> _drawables = new();
    
    public bool Has<T>()
    {
        return _components.ContainsKey(typeof(T).Name);
    }

    public T Add<T>(T component)
    {
        if (component is null)
        {
            throw new Exception("Find me!");
        }
        
        var name = typeof(T).Name;
        var success = _components.TryAdd(name, component);
        if (!success)
        {
            throw new Exception("Unable to add component to drawables");
        }

        if (component is Drawable d)
        {
            _drawables.Add(d);
        }
        
        return component;
    }

    public List<Drawable> GetDrawables()
    {
        return _drawables;
    }

    public T Get<T>()
    {
        return (T)_components[typeof(T).Name];
    }

    public virtual void Update(float dt)
    {
        
    }

    public virtual void UpdateFixed(float dt)
    {
        
    }
}