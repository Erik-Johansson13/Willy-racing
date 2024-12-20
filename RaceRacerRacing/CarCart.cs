

class CarCart : Vehicle
{
    public CarCart()
    {
        Name = "Car Cart";
        AbilityName = "Style On Em";
        MaxSpeed = 5;
        Acceleration = 2;
        Strength = 7;
        Style = 50;

    }
    public override void AbilityOn()
    {
        Style *= 1.5;
    }
    public override void AbilityOff()
    {
        Style /= 1.5;
    }
}