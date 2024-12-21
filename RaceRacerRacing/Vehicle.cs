

abstract class Vehicle
{
    public string Name { get; protected set; }
    public string? Description { get; protected set; }
    public string AbilityName { get; protected set; }
    public string? AbilityDescription { get; protected set; }
    public double MaxSpeed { get; protected set; }
    public double Acceleration { get; protected set; }
    public int Strength { get; protected set; }
    public double Style { get; protected set; }
    public bool AbilityEnabled { get; set; }
    public int AbilityTick { get; set; }
    public Vehicle()
    {
        AbilityEnabled = false;
        AbilityTick = 0;
    }

    public abstract void AbilityOn();
    public abstract void AbilityOff();
}