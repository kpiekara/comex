# SFML 

SFML was created as a library for C++, but now it has several ports for different platforms. Since it's a library and not a framework or game engine, we have complete freedom to choose the solutions we want to apply. This is both a challenge and an opportunity to understand many interesting mechanisms.

## Starter
Let's start with a simple application:

```cs
var mode = new VideoMode(800, 600);
var window = new RenderWindow(mode, "SFML works!");

var circle = new CircleShape(100)
{
    FillColor = Color.Blue
};

while (window.IsOpen)
{
    window.DispatchEvents();
    window.Clear();
    window.Draw(circle);
    window.Display();
}
```
Let's break down the example piece by piece.

```cs
var mode = new VideoMode(800, 600);
```
We set the resolution of the window where the game will be rendered. The resolution will be crucial in many aspects of game development, but at this stage, we don't need to focus too much on it. We just need a resolution that will be comfortable for us to work with on the game.

```cs
var window = new RenderWindow(mode, "SFML works!");
```
Here, we create the window where the elements we draw will appear.

```cs
var circle = new CircleShape(100)
{
    FillColor = Color.Blue
};
```
This part defines one of the primitives - a blue circle with a radius of 100 pixels.

```cs
while (window.IsOpen)
{
    window.DispatchEvents();
    window.Clear();
    window.Draw(circle);
    window.Display();
}
```
Next, we have a loop that repeats four instructions frame by frame:

* sending events to all interested parties
* clearing the screen to the default color
* drawing the primitive on the screen
* transferring everything to the application

## Result
As a result, we have a simple application that displays a blue circle. That wasn't too hard, was it?
