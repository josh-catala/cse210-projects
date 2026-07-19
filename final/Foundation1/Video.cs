// Video.cs
// Represents a YouTube video.
// Responsible for tracking the title, author, and length (in seconds) of
// the video, as well as storing the list of comments left on it.

using System;
using System.Collections.Generic;

public class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public string GetTitle()
    {
        return _title;
    }

    public void SetTitle(string title)
    {
        _title = title;
    }

    public string GetAuthor()
    {
        return _author;
    }

    public void SetAuthor(string author)
    {
        _author = author;
    }

    public int GetLength()
    {
        return _length;
    }

    public void SetLength(int length)
    {
        _length = length;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Returns the number of comments on this video, as required.
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }
}
