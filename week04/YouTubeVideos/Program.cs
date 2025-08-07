using Week04.YouTubeVideos;

// Create sample videos and comments
var videos = new List<Video>();

var v1 = new Video("How to Bake Bread", "Olivia Martin", 540);
v1.AddComment(new Comment("Sofia", "Great tutorial!"));
v1.AddComment(new Comment("Liam", "I tried this and it turned out perfect."));
v1.AddComment(new Comment("Ethan", "Can you do a sourdough version?"));
videos.Add(v1);

var v2 = new Video("Intro to C# Classes", "Professor Dev", 780);
v2.AddComment(new Comment("Ava", "This made classes finally click. Thank you!"));
v2.AddComment(new Comment("Noah", "Please cover interfaces next."));
v2.AddComment(new Comment("Mia", "The examples were super clear."));
videos.Add(v2);

var v3 = new Video("Top 10 Productivity Tips", "FocusHub", 630);
v3.AddComment(new Comment("Lucas", "Tip #3 changed my routine."));
v3.AddComment(new Comment("Emma", "Loved the concise format."));
v3.AddComment(new Comment("Mason", "Can you link the apps you mentioned?"));
v3.AddComment(new Comment("Harper", "Subscribed!"));
videos.Add(v3);

// Display details
foreach (var video in videos)
{
    Console.WriteLine($"Title: {video.Title}");
    Console.WriteLine($"Author: {video.Author}");
    Console.WriteLine($"Length: {video.LengthSeconds} seconds");
    Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
    Console.WriteLine("Comments:");
    foreach (var c in video.GetComments())
    {
        Console.WriteLine($"- {c.CommenterName}: {c.Text}");
    }
    Console.WriteLine(new string('-', 50));
}