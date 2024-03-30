namespace MementoDesignPattern;

public class Editor
{
    private readonly TextArea _textArea;
    private readonly Stack<TextArea.Memento> _stateHistory;

    public Editor()
    {
        this._textArea = new TextArea();
        this._stateHistory = new Stack<TextArea.Memento>();
    }

    public void Write(string text)
    {
        this._textArea.SetText(text);
        this._stateHistory
            .Push(this._textArea
                .TakeSnapshot());
    }

    public void Undo()
    {
        if (this._stateHistory.Count == 1)
        {
            this._stateHistory.Pop();
            this._textArea.SetText(string.Empty);
            return;
        }

        this._stateHistory.Pop();
        this._textArea.Restore(this._stateHistory.Peek());
    }

    public void PrintText()
    {
        Console.WriteLine(this._textArea.GetText());
    }
}