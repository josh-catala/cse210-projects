// Program.cs
//
// NOTE: Your instructor provides an actual Program.cs file already placed in
// the correct spot within the student template for each assignment (see
// requirement #9). Copy the code below into THAT provided file rather than
// using this one as a new starting point -- do not create a new project or
// a new Program.cs from scratch.
//
// HOW I EXCEEDED THE REQUIREMENTS:
// (Replace this comment with your own explanation of what you did beyond
// the base assignment, e.g. extra validation, additional sample data,
// a formatted/aligned console display, etc.)

using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        List<Video> videoList = BuildSampleVideos();
        DisplayVideos(videoList);
    }

    // Creates 4 sample Video objects, each with 3-4 Comment objects,
    // and returns them all in a single list.
    private static List<Video> BuildSampleVideos()
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Unboxing the New Wireless Headphones", "TechReviewsDaily", 612);
        video1.AddComment(new Comment("Sarah_M", "Great review, I just ordered a pair!"));
        video1.AddComment(new Comment("gamerguy22", "Are these worth the price though?"));
        video1.AddComment(new Comment("Lisa Chen", "The sound quality looks amazing."));
        video1.AddComment(new Comment("David P", "Can you compare these to the older model?"));
        videos.Add(video1);

        Video video2 = new Video("10 Minute Full Body Workout", "FitWithJamie", 605);
        video2.AddComment(new Comment("HealthNut99", "This workout kicked my butt this morning!"));
        video2.AddComment(new Comment("Marcus T", "Perfect length for a quick lunch break workout."));
        video2.AddComment(new Comment("Anna K", "Do you have a beginner version of this?"));
        videos.Add(video2);

        Video video3 = new Video("How Coffee Is Made: Farm to Cup", "WorldOfFoodExplained", 845);
        video3.AddComment(new Comment("CoffeeLover88", "I never knew it was this complicated!"));
        video3.AddComment(new Comment("Ben Rodriguez", "Great cinematography in this one."));
        video3.AddComment(new Comment("TravelBug_Sam", "This makes me want to visit a coffee farm."));
        video3.AddComment(new Comment("Priya S", "Subscribed after watching this!"));
        videos.Add(video3);

        Video video4 = new Video("Learn C# in 20 Minutes", "CodeCraftAcademy", 1204);
        video4.AddComment(new Comment("newbie_coder", "This finally made loops make sense to me."));
        video4.AddComment(new Comment("Jordan W", "Wish I found this video months ago."));
        video4.AddComment(new Comment("Emily R", "Can you do a follow-up on classes?"));
        videos.Add(video4);

        return videos;
    }

    // Iterates through the list of videos and displays the title, author,
    // length, number of comments, and all comments for each one.
    private static void DisplayVideos(List<Video> videos)
    {
        int videoNumber = 1;

        foreach (Video video in videos)
        {
            Console.WriteLine("============================================================");
            Console.WriteLine("Video #" + videoNumber);
            Console.WriteLine("============================================================");
            Console.WriteLine("Title:          " + video.GetTitle());
            Console.WriteLine("Author:         " + video.GetAuthor());
            Console.WriteLine("Length:         " + FormatLength(video.GetLength()));
            Console.WriteLine("# of Comments:  " + video.GetNumberOfComments());
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine("  - " + comment.ToString());
            }

            Console.WriteLine();
            videoNumber = videoNumber + 1;
        }
    }

    // Formats a length given in seconds as minutes:seconds for readability.
    private static string FormatLength(int seconds)
    {
        int minutes = seconds / 60;
        int remainingSeconds = seconds % 60;
        string secondsText = remainingSeconds.ToString("D2");
        string result = minutes + ":" + secondsText + " (" + seconds + " seconds)";
        return result;
    }
}
