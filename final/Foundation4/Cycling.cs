using System;

public class Cycling : Activity
{
    private double speed;

    public Cycling(DateTime date, int duration, double speed) : base(date, duration)
    {
        this.speed = speed;
    }

    public override double GetDistance() => (speed * duration) / 60;
    public override double GetSpeed() => speed;
}
