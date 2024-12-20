abstract class Pusher
{
    public string? PusherName { get; protected set; }
    public string PusherDescription { get; protected set; }
    public string? PusherAbilityName { get; protected set; }
    public double PusherSpeedBoost { get; protected set; }
    public double PusherAccelerationBoost { get; protected set; }
    public int PusherStrengthBoost { get; protected set; }
    public int PusherStyleBoost { get; protected set; }
    public bool AbilityEnabled { get; set; }
    public int AbilityTick { get; set; }
    public Pusher()
    {
        AbilityEnabled = false;
        AbilityTick = 0;
    }


    public abstract void AbilityOn();
    public abstract void AbilityOff();
}