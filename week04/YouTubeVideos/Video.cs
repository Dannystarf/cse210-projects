namespace Week04.YouTubeVideos;

public class Video
{
    private readonly string _title;
    private readonly string _author;
    private readonly int _lengthSeconds;
    private readonly List<Comment> _comments = new();

    public Video(string title, string author, int lengthSeconds)
    {
        if (lengthSeconds < 0) throw new ArgumentOutOfRangeException(nameof(lengthSeconds));
        _title = title ?? throw new ArgumentNullException(nameof(title));
        _author = author ?? throw new ArgumentNullException(nameof(author));
        _lengthSeconds = lengthSeconds;
    }

    public string Title => _title;
    public string Author => _author;
    public int LengthSeconds => _lengthSeconds;

    public void AddComment(Comment comment)
    {
        if (comment == null) throw new ArgumentNullException(nameof(comment));
        _comments.Add(comment);
    }

    public int GetCommentCount() => _comments.Count;

    public IReadOnlyList<Comment> GetComments() => _comments.AsReadOnly();
}