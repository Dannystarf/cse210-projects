namespace Week04.YouTubeVideos;

public class Comment
{
    private readonly string _commenterName;
    private readonly string _text;

    public Comment(string commenterName, string text)
    {
        _commenterName = commenterName ?? throw new ArgumentNullException(nameof(commenterName));
        _text = text ?? string.Empty;
    }

    public string CommenterName => _commenterName;
    public string Text => _text;
}