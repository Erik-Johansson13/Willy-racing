
class BigCart : Vehicle
{
    public BigCart() 
    {
        Name = "Large shopping cart";
        AbilityName = "Rage";
        MaxSpeed = 10;
        Acceleration = 0.5;
        Strength = 20;
        Style = 20;
    }

    public override void AbilityOn()
    {
        Strength *= 2;
    }

    public override void AbilityOff()
    {
        Strength /= 2;
    }
}