using System;

// An OutdoorGathering is an Event with no attendee limit, but it needs
// to track a weather forecast.
public class OutdoorGathering : Event
{
    // Member variable uses _camelCase.
    private string _weatherForecast;

    // Constructor parameters use camelCase.
    public OutdoorGathering(string title, string description, string date, string time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        _weatherForecast = weatherForecast;
    }

    public string GetWeatherForecast()
    {
        return _weatherForecast;
    }

    public void SetWeatherForecast(string weatherForecast)
    {
        _weatherForecast = weatherForecast;
    }

    public override string GetEventType()
    {
        return "Outdoor Gathering";
    }

    // Extends the base full details with the weather forecast.
    public override string GetFullDetails()
    {
        string baseDetails = base.GetFullDetails();
        string result = baseDetails + "\n";
        result = result + "Weather Forecast: " + _weatherForecast;
        return result;
    }
}
