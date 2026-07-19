using System;

// A Lecture is an Event that also has a speaker and a limited capacity.
public class Lecture : Event
{
    // Member variables use _camelCase.
    private string _speaker;
    private int _capacity;

    // Constructor parameters use camelCase. Shared fields are passed
    // up to the base Event constructor so they are not duplicated here.
    public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        _speaker = speaker;
        _capacity = capacity;
    }

    public string GetSpeaker()
    {
        return _speaker;
    }

    public void SetSpeaker(string speaker)
    {
        _speaker = speaker;
    }

    public int GetCapacity()
    {
        return _capacity;
    }

    public void SetCapacity(int capacity)
    {
        _capacity = capacity;
    }

    public override string GetEventType()
    {
        return "Lecture";
    }

    // Extends the base full details with speaker and capacity info.
    public override string GetFullDetails()
    {
        string baseDetails = base.GetFullDetails();
        string result = baseDetails + "\n";
        result = result + "Speaker: " + _speaker + "\n";
        result = result + "Capacity: " + _capacity + " attendees";
        return result;
    }
}
