using System;

// A Reception is an Event that requires people to RSVP by email beforehand.
public class Reception : Event
{
    // Member variable uses _camelCase.
    private string _rsvpEmail;

    // Constructor parameters use camelCase.
    public Reception(string title, string description, string date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        _rsvpEmail = rsvpEmail;
    }

    public string GetRsvpEmail()
    {
        return _rsvpEmail;
    }

    public void SetRsvpEmail(string rsvpEmail)
    {
        _rsvpEmail = rsvpEmail;
    }

    public override string GetEventType()
    {
        return "Reception";
    }

    // Extends the base full details with the RSVP email.
    public override string GetFullDetails()
    {
        string baseDetails = base.GetFullDetails();
        string result = baseDetails + "\n";
        result = result + "RSVP by emailing: " + _rsvpEmail;
        return result;
    }
}
