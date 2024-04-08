public class ReceptionEvent : Event
{
    public string EmailForRSVP { get; set; }

    public ReceptionEvent(string title, string description, DateTime eventDate, string time, Address location, string emailForRSVP)
        : base(title, description, eventDate, time, location)
    {
        EmailForRSVP = emailForRSVP;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Reception\nRSVP at: {EmailForRSVP}";
    }
}