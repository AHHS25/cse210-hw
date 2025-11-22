using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to store the videos
            List<Video> videos = new List<Video>();

            // --------- Video 1 ----------
            Video video1 = new Video("Learning C# Classes", "CodeWithAlan", 600);
            video1.AddComment(new Comment("Maria", "This explanation was very clear, thank you!"));
            video1.AddComment(new Comment("John", "I finally understand classes now."));
            video1.AddComment(new Comment("Sofia", "Could you make a video about inheritance next?"));
            videos.Add(video1);

            // --------- Video 2 ----------
            Video video2 = new Video("Beginner Guitar Tutorial", "MusicWorld", 900);
            video2.AddComment(new Comment("Alex", "My fingers hurt but this was very helpful."));
            video2.AddComment(new Comment("Luis", "Great pace and very easy to follow."));
            video2.AddComment(new Comment("Carla", "I played my first song today, thanks!"));
            videos.Add(video2);

            // --------- Video 3 ----------
            Video video3 = new Video("Easy Mexican Recipes", "CookingWithLove", 750);
            video3.AddComment(new Comment("Pedro", "The tacos were delicious!"));
            video3.AddComment(new Comment("Ana", "I made this for my family and they loved it."));
            video3.AddComment(new Comment("Diego", "Please make a video about desserts."));
            videos.Add(video3);

            // --------- Video 4 (optional, but 3–4 are required) ----------
            Video video4 = new Video("Home Workout Without Equipment", "FitAtHome", 480);
            video4.AddComment(new Comment("Karen", "Perfect for small apartments, thank you!"));
            video4.AddComment(new Comment("Miguel", "I was sweating a lot, great routine."));
            video4.AddComment(new Comment("Laura", "I will try this every morning."));
            videos.Add(video4);

            // Display all the information for each video
            foreach (Video video in videos)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
                Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
                Console.WriteLine("Comments:");

                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine($" - {comment.Name}: {comment.Text}");
                }

                Console.WriteLine(); // Blank line between videos
            }

            Console.WriteLine("End of program. Press any key to close...");
            Console.ReadKey();
        }
    }
}
