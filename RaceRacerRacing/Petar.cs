﻿

class Petar : Pusher
{
    public Petar()
    {
        PusherName = "Petar";
        PusherDescription = "Petar knows how to design in Inventor proffesional";
        PusherAbilityName = "Inventor Pro";
        PusherSpeedBoost = 7;
        PusherAccelerationBoost = 0.8;
        PusherStrengthBoost = 6;
        PusherStyleBoost = 100;
    }
    public override void AbilityOn()
    {
        PusherStyleBoost *= 2;
    }
    public override void AbilityOff()
    {
        PusherStyleBoost /= 2;
    }
}