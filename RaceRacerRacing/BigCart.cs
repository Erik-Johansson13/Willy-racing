
class BigCart : Vehicle
{
    public BigCart() 
    {
        Name = "Large shopping cart";
        Description = "A large heavy-duty shopping cart used in department stores";
        AbilityName = "Rage";
        AbilityDescription = "'Video games are making the younger generation violent', Damn straight!";
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