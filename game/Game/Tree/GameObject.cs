namespace Game.Tree;

public class GameObject
{
    private readonly Dictionary<string, object> _components = new();
    
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
        if (_components.ContainsKey(name))
        {
            throw new Exception("Find me!");
        }
        
        _components.Add(name, component);
        return component;
    }

    public T Get<T>()
    {
        return (T)_components[typeof(T).Name];
    }
}