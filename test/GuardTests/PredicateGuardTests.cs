namespace GuardTests;

public class PredicateGuardTests : BaseTest
{
    private record TestObject(string Value);
    
    [Fact]
    public void EnsureTrueTests()
    {
        var testObject = new TestObject("Test");

        testObject.EnsureTrue(t => t.Value == "Test").ShouldBe(testObject);
        ShouldThrowWithMessageContaining<ArgumentException>(() => testObject.EnsureTrue(t => t.Value == "Wrong"),
            "Ongeldige waarde", nameof(EnsureTrueTests), nameof(TestObject), "voldoet niet aan de gestelde voorwaarde.");
    }

    [Fact]
    public async Task EnsureTrueAsyncTests()
    {
        var validObject = new TestObject("Correct");
        var invalidObject = new TestObject("Wrong");
        
        (await validObject.EnsureTrueAsync(Check)).ShouldBe(validObject);
        var failure = await Should.ThrowAsync<ArgumentException>(() => invalidObject.EnsureTrueAsync(Check));
        failure.Message.ShouldContain("Ongeldige waarde");
        failure.Message.ShouldContain(nameof(EnsureTrueAsyncTests));
        failure.Message.ShouldContain(nameof(TestObject));
        failure.Message.ShouldContain("voldoet niet aan de gestelde voorwaarde.");
    }

    private static Task<bool> Check(TestObject testObject)
    {
        return Task.FromResult(testObject.Value == "Correct");
    }
}