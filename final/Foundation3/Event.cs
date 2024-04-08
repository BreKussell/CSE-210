using System;

public abstract class Event
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime EventDate { get; set; }
    public string Time { get; set; }
    public Address Location { get; set; }

    protected Event(string title, string description, DateTime eventDate, string time, Address location)
    {
        Title = title;
        Description = description;
        EventDate = eventDate;
        Time = time;
        Location = location;
    }

    public string GetStandardDetails()
    {
        return $"{Title}\n{Description}\nDate: {EventDate.ToShortDateString()} at {Time}\nLocation: {Location}";
    }

    public abstract string GetFullDetails();

    public string GetShortDescription()
    {
        return $"{GetType().Name.Replace("Event", "")}: {Title} on {EventDate.ToShortDateString()}";
    }
}
