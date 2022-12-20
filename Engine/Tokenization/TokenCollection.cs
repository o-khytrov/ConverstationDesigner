using System.Collections;

namespace Engine.Tokenization;

public class TokenCollection : IEnumerator<string>
{
    private readonly string[] _tokens;

    private int _current;

    public TokenCollection(string[] tokens)
    {
        _tokens = tokens;
        _current = -1;
    }

    public bool MoveNext()
    {
        if (_current < _tokens.Length - 1)
        {
            _current++;
            return true;
        }

        return false;
    }

    public void Reset()
    {
        _current = -1;
    }

    public string Current => _tokens[_current];

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }
}