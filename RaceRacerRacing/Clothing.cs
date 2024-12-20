class Clothing
{
    public string Name { get; set; }
    public int Warmth { get; set; }
    public int SpeedReduction { get; set; }
    public int Defence { get; set; }
    public double StyleBoostMult { get; set; }

    public Clothing(string name, int warmth, int speedReduction, int defence, double styleBoostMult)
    {
        Name = name;
        Warmth = warmth;
        SpeedReduction = speedReduction;
        Defence = defence;
        StyleBoostMult = styleBoostMult;
    }
}
