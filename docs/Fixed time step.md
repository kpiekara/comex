# Fixed time step lopp

## Overview
A fixed time step loop in a 2D game is a method where the game logic updates at a constant rate, regardless of how fast the game is being rendered or how quickly the hardware can perform calculations. Here's a simplified explanation of the advantages and disadvantages of using a fixed time step loop:

## Advantages

### Consistency
One of the biggest advantages of a fixed time step loop is that it ensures consistent game behavior across different devices. No matter the performance of the hardware, the game logic updates at the same rate, making the gameplay experience uniform for all players.

### Predictability
For developers, a fixed time step makes the game's behavior more predictable. This can simplify the development process, especially for physics simulations and timing-based mechanics, as they can reliably predict how the game will respond over time.

## Code change

Let's check the code in our main loop changed:

```cs
var timeSinceLastUpdate = Time.Zero;
while (window.IsOpen)
{
    var dt = clock.Restart();
    timeSinceLastUpdate += dt;
    while (timeSinceLastUpdate > GameConfig.TimePerFrame)
    {
        timeSinceLastUpdate -= GameConfig.TimePerFrame;
        tree.Update(GameConfig.TimePerFrameInSeconds);
    }

    window.DispatchEvents();
    window.Draw(tree);
    window.Display();
}
```

`clock.Restart()` and `dt`: Here, a timer is used to measure the time elapsed (`dt`) since the last frame. This value is then used to update `timeSinceLastUpdate`, which tracks how much time has accumulated since the last game logic update.

`timeSinceLastUpdate > GameConfig.TimePerFrame`: This condition checks if the accumulated time since the last update exceeds a predefined time per frame (`GameConfig.TimePerFrame`). This predefined time is the fixed time step, ensuring the game logic updates at a consistent rate.

`timeSinceLastUpdate -= GameConfig.TimePerFrame`: Once an update is processed, the time for one frame is subtracted from the accumulated time, ensuring that multiple updates can occur back to back if the loop is lagging behind the intended update rate.

`tree.Update(GameConfig.TimePerFrameInSeconds)`: The game logic, in this case updating all object in tree, is executed with the fixed time step as an argument. This ensures consistent physics and game mechanics calculations.