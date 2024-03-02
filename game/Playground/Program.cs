using Playground.Examples;
using Playground.System;

RunExample<SimpleWindowExample>();

static void RunExample<T>() where T : IRunnable, new()
{
    var window = new T();
    window.Run();
}