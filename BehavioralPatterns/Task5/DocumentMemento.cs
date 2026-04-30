public class DocumentMemento
{
    public string Text { get; }
    public DocumentMemento(string text) => Text = text;
}

public class TextDocument
{
    public string Text { get; set; } = string.Empty;
    public DocumentMemento Save() => new DocumentMemento(Text);
    public void Restore(DocumentMemento memento) => Text = memento?.Text ?? string.Empty;
}

public class TextEditor
{
    private readonly TextDocument _document = new TextDocument();
    private readonly Stack<DocumentMemento> _history = new Stack<DocumentMemento>();

    public string Text
    {
        get => _document.Text;
        set => _document.Text = value;
    }

    public void Save() => _history.Push(_document.Save());

    public void Undo()
    {
        if (_history.Count > 0)
        {
            _document.Restore(_history.Pop());
        }
    }
}