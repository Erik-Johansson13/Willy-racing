
class MediumCart : Vehicle
{
    public MediumCart() 
    {
        Name = "Average shopping cart";
        AbilityName = "Slipstream";
        MaxSpeed = 7;
        Acceleration = 1;
        Strength = 10;
        Style = 20;
    }

    public override void AbilityOn()
    {
        MaxSpeed *= 1.3;
    }

    public override void AbilityOff()
    {
        MaxSpeed /= 1.3 ;
    }
}