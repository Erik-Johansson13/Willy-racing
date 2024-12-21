

class CarCart : Vehicle
{
    public CarCart()
    {
        Name = "Car Cart";
        Description = "A cart with a car design, extremely cool";
        AbilityName = "Style On Em";
        AbilityDescription = "Deja vú, I've just been in this place before. Pull off some magnificent drifts to get some style-points";
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