using System;

// Base class holding data and behavior common to every event type:
// title, description, date, time, and address, plus the three
// marketing message methods that every event must be able to produce.
public class Event
{
    // Member variables use _camelCase.
    private string _title;
    private string _description;
    private string _date;
    private string _time;
    private Address _address;

    // Constructor parameters use camelCase.
    public Event(string title, string description, string date, string time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    // Get/Set methods are used instead of properties, per assignment rules.
    public string GetTitle()
    {
        return _title;
    }

    public void SetTitle(string title)
    {
        _title = title;
    }

    public string GetDescription()
    {
        return _description;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }

    public string GetDate()
    {
        return _date;
    }

    public void SetDate(string date)
    {
        _date = date;
    }

    public string GetTime()
    {
        return _time;
    }

    public void SetTime(string time)
    {
        _time = time;
    }

    public Address GetAddress()
    {
        return _address;
    }

    public void SetAddress(Address address)
    {
        _address = address;
    }

    // Marked virtual so derived classes can override it to report
    // their own specific type (Lecture, Reception, Outdoor Gathering).
    public virtual string GetEventType()
    {
        return "Event";
    }

    // 1. Standard details: title, description, date, time, address.
    // This is the same for every event type, so it lives entirely in
    // the base class and is not overridden anywhere.
    public string GetStandardDetails()
    {
        string result = "Title: " + _title + "\n";
        result = result + "Description: " + _description + "\n";
        result = result + "Date: " + _date + "\n";
        result = result + "Time: " + _time + "\n";
        result = result + "Address: " + _address.ToString();
        return result;
    }

    // 2. Full details: standard details plus event type. Derived
    // classes override this, call the base version with base.GetFullDetails(),
    // and append their own type-specific information.
    public virtual string GetFullDetails()
    {
        string result = GetStandardDetails() + "\n";
        result = result + "Event Type: " + GetEventType();
        return result;
    }

    // 3. Short description: type, title, and date.
    public string GetShortDescription()
    {
        string result = "[" + GetEventType() + "] " + _title + " - " + _date;
        return result;
    }
}
