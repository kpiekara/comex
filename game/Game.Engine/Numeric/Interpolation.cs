namespace Game.Engine.Numeric;

public static class Interpolation
{
    public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed, float deltaTime)
    {
        smoothTime = Math.Max(0.0001F, smoothTime);
        var omega = 2F / smoothTime;

        var x = omega * deltaTime;
        var exp = 1F / (1F + x + 0.48F * x * x + 0.235F * x * x * x);
        var change = current - target;
        var originalTo = target;
        
        var maxChange = maxSpeed * smoothTime;
        change = Math.Clamp(change, -maxChange, maxChange);
        target = current - change;

        var temp = (currentVelocity + omega * change) * deltaTime;
        currentVelocity = (currentVelocity - omega * temp) * exp;
        var output = target + (change + temp) * exp;
        
        if (originalTo - current > 0.0F == output > originalTo)
        {
            output = originalTo;
            currentVelocity = (output - originalTo) / deltaTime;
        }

        return output;
    }
}