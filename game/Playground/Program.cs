using Examples;
using Playground.Examples;
using Playground.System;

//RunExample<SimpleWindowExample>();
RunExample<VertexArrayExample>();

static void RunExample<T>() where T : IRunnable, new()
{
    var window = new T();
    window.Run();
}