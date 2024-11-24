namespace GuardTests;

public class BaseTest
{
    protected static void ShouldThrowWithMessageContaining<TException>(Action action, params string[] messages) 
        where TException : Exception
    {
        var actual = Should.Throw<TException>(action);
        foreach (var message in messages)
        {
            actual.Message.ShouldContain(message);
        }
    }
}