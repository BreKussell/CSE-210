using System;

public abstract class Activity
{
    private DateTime date;
    public int duration;

    public Activity(DateTime date, int duration)
    {
        this.date = date;
        this.duration = duration;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public double GetPace() => 60 / GetSpeed();

    public virtual string GetSummary()
    {
        return $"{date:dd MMM yyyy} ({duration} min) - Distance: {GetDistance():F2} km, Speed: {GetSpeed():F2} kph, Pace: {GetPace():F2} min per km";
    }
}
