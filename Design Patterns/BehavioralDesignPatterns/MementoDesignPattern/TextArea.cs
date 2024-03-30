namespace MementoDesignPattern;

public class TextArea
{
    private string text;

    public void SetText(string newText)
    {
        this.text = newText;
    }

    public string GetText()
    {
        return this.text;
    }

    public Memento TakeSnapshot()
    {
        return new Memento(this.text);
    }

    public void Restore(Memento? memento)
    {
        this.text = memento != null 
            ? memento.GetSavedText()
            : string.Empty;
    }

    public class Memento
    {
        private readonly string _text;

        public Memento(string text)
        {
            this._text = text;
        }

        public string GetSavedText()
        {
            return this._text;
        }
    }
}