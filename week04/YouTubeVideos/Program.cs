
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create the first video
        Video video1 = new Video(
            "The Power of Consistency",
            "Success Mindset",
            600
        );

        video1.AddComment(new Comment("John", "Consistency is the key to success."));
        video1.AddComment(new Comment("Mary", "I really needed this message."));
        video1.AddComment(new Comment("David", "This video motivates me to keep going."));
        video1.AddComment(new Comment("Grace", "Great lesson!"));

        // Create the second video
        Video video2 = new Video(
            "Learn C# Programming",
            "Code Academy",
            900
        );

        video2.AddComment(new Comment("Peter", "Very helpful tutorial."));
        video2.AddComment(new Comment("Sarah", "I finally understand classes."));
        video2.AddComment(new Comment("Michael", "Please make more videos like this."));
        video2.AddComment(new Comment("Esther", "Excellent explanation!"));

        // Create the third video
        Video video3 = new Video(
            "How to Manage Your Money",
            "Smart Finance",
            750
        );

        video3.AddComment(new Comment("Daniel", "Everyone should learn financial literacy."));
        video3.AddComment(new Comment("Blessing", "I have learned a lot."));
        video3.AddComment(new Comment("James", "Saving and investing are important."));
        video3.AddComment(new Comment("Faith", "Thank you for sharing this."));

        // Store all videos in a list
        List<Video> videos = new List<Video>
        {
            video1,
            video2,
            video3
        };

        // Display information about each video and its comments
        foreach (Video video in videos)
        {
            video.DisplayVideo();
        }
    }
}
