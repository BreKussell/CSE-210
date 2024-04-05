using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>
        {
            new Video("Proactively Avoiding Flanks", "Squid School", 387),
            new Video("원위(ONEWE) 하린 🎉HaRin's The healing day🎂", "ONEWE", 1131),
            new Video("《Thunderbolt Fantasy 東離劍遊紀４》官方前導預告", "PILI 霹靂布袋戲", 95)
        };

        // Adding comments to each video
        videos[0].AddComment(new Comment("user-ld7bc2ep4l", "Bold of you to assume Splatoon 3 has flanks."));
         videos[0].AddComment(new Comment("eeveemaster243", "Very wise and helpful. Thank you Gem."));

        videos[1].AddComment(new Comment("SilentNight99", "Making gifts for his parents was such a cute gesture! 🥹 It’s nice to see he had fun and got to eat lots of delicious food.Happy birthday, Harin! 💚🎉"));
        videos[1].AddComment(new Comment("2_4_5", "우리 하린이 생일 너무너무 축하해🥹💚🖤"));

        videos[2].AddComment(new Comment("sarahsander785", "I am hyped beyond words!"));
        videos[2].AddComment(new Comment("Tsukigasa", "Thunderbolt Fantasy 4 とても楽しみです！　霹靂布袋戲の皆様の素晴らしい技術に期待しています。好期待！."));

        // Displaying video information and comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}, Author: {video.Author}, Length: {video.LengthInSeconds} seconds, Comments: {video.NumberOfComments()}");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"\t{comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine(); // For better readability
        }
    }
}