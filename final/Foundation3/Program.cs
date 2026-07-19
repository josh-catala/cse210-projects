using System;

// NOTE: Your course provides a Program.cs file already placed inside the
// student template, and the instructions say to use that provided file
// as your starting point rather than creating a new one. This file shows
// where the assignment logic goes; copy the relevant code below into
// your actual provided Program.cs in the correct spot the assignment
// specifies, rather than replacing the whole file.
public class Program
{
    public static void Main(string[] args)
    {
        // Create one address per event (Address class reused for all of them).
        Address lectureAddress = new Address("100 University Ave", "Springfield", "IL", "62701");
        Address receptionAddress = new Address("55 Grand Ballroom Dr", "Metropolis", "NY", "10001");
        Address outdoorAddress = new Address("1 Riverside Park", "Lakeview", "CA", "90210");

        // Create one event of each type and set all of its values
        // through the constructor.
        Lecture lecture = new Lecture(
            "The Future of Renewable Energy",
            "A deep dive into solar, wind, and battery innovations shaping the next decade.",
            "2026-09-14",
            "6:00 PM",
            lectureAddress,
            "Dr. Elena Vasquez",
            150
        );

        Reception reception = new Reception(
            "Annual Founders' Gala",
            "An elegant evening celebrating this year's award-winning entrepreneurs.",
            "2026-10-02",
            "7:30 PM",
            receptionAddress,
            "rsvp@foundersgala.com"
        );

        OutdoorGathering outdoorGathering = new OutdoorGathering(
            "Community Summer Festival",
            "A free, family-friendly festival with live music, food trucks, and games.",
            "2026-07-25",
            "11:00 AM",
            outdoorAddress,
            "Sunny, high of 82F with light winds"
        );

        // Store each event as its base Event type in an array to show
        // that a single loop can call each one's methods polymorphically.
        Event[] events = new Event[3];
        events[0] = lecture;
        events[1] = reception;
        events[2] = outdoorGathering;

        int i = 0;
        while (i < events.Length)
        {
            PrintEventMessages(events[i]);
            i = i + 1;
        }
    }

    // Prints all three marketing messages for a single event.
    // Parameter name uses camelCase; "event" itself is a reserved
    // keyword in C#, so currentEvent is used instead.
    public static void PrintEventMessages(Event currentEvent)
    {
        string divider = "--------------------------------------------------";

        Console.WriteLine(divider);
        Console.WriteLine("SHORT DESCRIPTION");
        Console.WriteLine(divider);
        Console.WriteLine(currentEvent.GetShortDescription());
        Console.WriteLine("");

        Console.WriteLine(divider);
        Console.WriteLine("STANDARD DETAILS");
        Console.WriteLine(divider);
        Console.WriteLine(currentEvent.GetStandardDetails());
        Console.WriteLine("");

        Console.WriteLine(divider);
        Console.WriteLine("FULL DETAILS");
        Console.WriteLine(divider);
        Console.WriteLine(currentEvent.GetFullDetails());
        Console.WriteLine("");
        Console.WriteLine("");
    }
}
