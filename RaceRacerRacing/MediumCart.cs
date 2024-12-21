
class MediumCart : Vehicle
{
    public MediumCart() 
    {
        Name = "Average shopping cart";
        Description = "Just your run of the mill shopping cart, nothing crazy";
        AbilityName = "Slipstream";
        AbilityDescription = "The air around you starts to shift, opening up a straight path without resistance";
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