namespace Game.Engine.Numeric;

public class Randomization
{
    public static bool Bool(float chance)
    {
        var rand = Random.Shared.NextDouble();
        return rand < chance;
    }
}