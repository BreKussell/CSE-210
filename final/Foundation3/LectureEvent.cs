public class LectureEvent : Event
{
    public string Speaker { get; set; }
    public int Capacity { get; set; }

    public LectureEvent(string title, string description, DateTime eventDate, string time, Address location, string speaker, int capacity)
        : base(title, description, eventDate, time, location)
    {
        Speaker = speaker;
        Capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Lecture\nSpeaker: {Speaker}\nCapacity: {Capacity}";
    }
}