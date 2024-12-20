

class AnisDonDemina : Pusher
{
    public AnisDonDemina()
    {
        PusherName = "Anis Don Demina";
        PusherDescription = "Sh sh sh shurrrrda";
        PusherAbilityName = "Shurrrrrda";
        PusherSpeedBoost = 5;
        PusherAccelerationBoost = 0.6;
        PusherStrengthBoost = 10;
        PusherStyleBoost = 10;
    }
    public override void AbilityOn()
    {
        PusherStrengthBoost += 10;
    }
    public override void AbilityOff()
    {
        PusherStrengthBoost -= 10;
    }
}