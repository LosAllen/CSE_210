using System;
using System.Collections.Generic;

class Video
{
    public string Title { get; }
    public string Author { get; }
    public int Length { get; }
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    public void AddComment(string commentText, string commenterName)
    {
        Comment comment = new Comment(commentText, commenterName);
        comments.Add(comment);
    }

    public int GetCommentsCount()
    {
        return comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentsCount()}");
        
        if (GetCommentsCount() > 0)
        {
            Console.WriteLine("Comments:");
            foreach (var comment in comments)
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
            }
        }

        Console.WriteLine();
    }
}

class Comment
{
    public string CommenterName { get; }
    public string CommentText { get; }

    public Comment(string commentText, string commenterName)
    {
        CommentText = commentText;
        CommenterName = commenterName;
    }
}

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        // Collecting user input for Video 1
        Console.WriteLine("Enter information for Video 1:");
        Console.Write("Title: ");
        string title1 = Console.ReadLine();
        Console.Write("Author: ");
        string author1 = Console.ReadLine();
        Console.Write("Length (seconds): ");
        int length1 = int.Parse(Console.ReadLine());

        Video video1 = new Video(title1, author1, length1);

        Console.WriteLine("Enter comments for Video 1:");
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Comment {i + 1}: ");
            string commentText = Console.ReadLine();
            Console.Write("Commenter Name: ");
            string commenterName = Console.ReadLine();
            video1.AddComment(commentText, commenterName);
        }

        videos.Add(video1);

        // Collecting user input for Video 2
        Console.WriteLine("Enter information for Video 2:");
        Console.Write("Title: ");
        string title2 = Console.ReadLine();
        Console.Write("Author: ");
        string author2 = Console.ReadLine();
        Console.Write("Length (seconds): ");

        Video video2 = new Video(title2, author2, length2);

        Console.WriteLine("Enter comments for Video 2:");
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Comment {i + 1}: ");
            string commentText = Console.ReadLine();
            Console.Write("Commenter Name: ");
            string commenterName = Console.ReadLine();
            video2.AddComment(commentText, commenterName);
        }

        videos.Add(video2);

        // Collecting user input for Video 3
        Console.WriteLine("Enter information for Video 3:");
        Console.Write("Title: ");
        string title3 = Console.ReadLine();
        Console.Write("Author: ");
        string author3 = Console.ReadLine();
        Console.Write("Length (seconds): ");
        int length3 = int.Parse(Console.ReadLine());

        Video video3 = new Video(title3, author3, length3);

        Console.WriteLine("Enter comments for Video 3:");
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Comment {i + 1}: ");
            string commentText = Console.ReadLine();
            Console.Write("Commenter Name: ");
            string commenterName = Console.ReadLine();
            video3.AddComment(commentText, commenterName);
        }

        videos.Add(video3);

        // Displaying video information
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
