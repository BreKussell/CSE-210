public class OutdoorGatheringEvent : Event
{
    public string Weather { get; set; }

    public OutdoorGatheringEvent(string title, string description, DateTime eventDate, string time, Address location, string weather)
        : base(title, description, eventDate, time, location)
    {
        Weather = weather;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Outdoor Gathering\nWeather Forecast: {Weather}";
    }
}