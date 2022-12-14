using FluentConversation.Engine.PatternSystem;
using FluentConversation.Engine.PatternSystem.Elements;
using FluentConversation.Engine.Tokenization;

namespace FluentConversation.Engine.Rules;

public class BotRule<T>
{
    public List<Func<T, BotInput, bool>> Conditions { get; set; } = new();

    public List<Action<T, PatternMatchingResult>> PostActions = new();

    public Pattern? Pattern { get; set; }

    public Func<T, string> RenderOutput { get; set; }

    public List<RuleTest> Tests { get; set; } = new();

    public bool Keep { get; set; }

    public bool Repeat { get; set; }

    public string? Name { get; set; }

    public bool IsPreConditionTrue(T context, BotInput input)
    {
        var isMatch = true;
        foreach (var condition in Conditions)
        {
            if (!condition(context, input))
            {
                isMatch = false;
                break;
            }
        }

        return isMatch;
    }
}

public class RuleTest
{
    public string Input { get; set; } = string.Empty;

    public string ExpectedResponse { get; set; } = string.Empty;
}