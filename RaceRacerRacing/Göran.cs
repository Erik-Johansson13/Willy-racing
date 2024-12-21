class Göran : Pusher
{
    // Göran is ugly as all hell, but has standard strength and demon legs.
    public Göran()
    {
        PusherName = "Göran";
        PusherDescription = "Göran is ugly, but he is good at running";
        PusherAbilityName = "Double run";
        PusherAbilityDescription = "Start running while you are running, run twice once";
        PusherSpeedBoost = 10;
        PusherAccelerationBoost = 1;
        PusherStrengthBoost = 4;
        PusherStyleBoost = -20;
    }

    public override void AbilityOn()
    {
        PusherSpeedBoost = 15;
    }

    public override void AbilityOff()
    {
        PusherSpeedBoost = 10;
    }
}