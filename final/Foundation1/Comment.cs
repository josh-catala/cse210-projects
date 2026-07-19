// Comment.cs
// Represents a single comment left on a video.
// Responsible for tracking the name of the commenter and the comment text.

using System;

public class Comment
{
    private string _name;
    private string _text;

    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public string GetText()
    {
        return _text;
    }

    public void SetText(string text)
    {
        _text = text;
    }

    // Overriding ToString the traditional way (method body, not expression-bodied)
    public override string ToString()
    {
        string result = _name + ": \"" + _text + "\"";
        return result;
    }
}
