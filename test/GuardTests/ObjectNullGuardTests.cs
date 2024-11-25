namespace GuardTests;

public class ObjectNullGuardTests : BaseTest
{
    private record TestObject();
    private record struct TestStruct();
    
    [Fact]
    public void EnsureNotNullTests()
    {
        TestObject? nullObject = null;
        var validObject  = new TestObject();
        
        validObject.EnsureNotNull().ShouldBe(validObject);
        ShouldThrowWithMessageContaining<ArgumentNullException>(() => nullObject.EnsureNotNull(),
            "Ongeldige waarde", nameof(EnsureNotNullTests), nameof(TestObject));
    }

    [Fact]
    public void EnsureNotNullStructTests()
    {
        TestStruct? nullStruct = null;
        TestStruct? validStruct = new TestStruct();
        
        validStruct.EnsureNotNull().ShouldBe(validStruct.Value);
        ShouldThrowWithMessageContaining<ArgumentNullException>(() => nullStruct.EnsureNotNull(),
            "Ongeldige waarde", nameof(EnsureNotNullStructTests), nameof(TestStruct));
    }

    [Fact]
    public void EnsureNotDefaultTests()
    {
        const int valid = 3;
        const int invalid = 0;
        
        valid.EnsureNotDefault().ShouldBe(valid);
        ShouldThrowWithMessageContaining<ArgumentException>(() => invalid.EnsureNotDefault(),
            "Ongeldige waarde", nameof(EnsureNotDefaultTests), nameof(Int32), "default waarde", "'0'");
    }
}