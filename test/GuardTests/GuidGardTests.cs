namespace GuardTests;

public class GuidGardTests : BaseTest
{
    [Fact]
    public void EnsureNotEmptyTests()
    {
        var valid1 = Guid.NewGuid();
        var valid2 = Guid.CreateVersion7();
        var invalid1 = Guid.Empty;
        var invalid2 = new Guid();
        
        valid1.EnsureNotEmpty().ShouldBe(valid1);
        valid2.EnsureNotEmpty().ShouldBe(valid2);
        ShouldThrowWithMessageContaining<ArgumentException>(() => invalid1.EnsureNotEmpty(),
            "Ongeldige waarde", nameof(EnsureNotEmptyTests), "Empty");
        ShouldThrowWithMessageContaining<ArgumentException>(() => invalid2.EnsureNotEmpty(),
            "Ongeldige waarde", nameof(EnsureNotEmptyTests), "Empty");
    }

    [Fact]
    public void EnsureVersion7Tests()
    {
        var valid = Guid.CreateVersion7();
        var invalid1 = Guid.NewGuid();
        var invalid2 = Guid.Empty;
        
        valid.EnsureVersion7().ShouldBe(valid);
        ShouldThrowWithMessageContaining<ArgumentException>(() => invalid1.EnsureVersion7(),
            "Ongeldige Guid", "version 4", nameof(EnsureVersion7Tests), "moet versie 7 zijn");
        ShouldThrowWithMessageContaining<ArgumentException>(() => invalid2.EnsureVersion7(),
            "Ongeldige Guid", "version 0", nameof(EnsureVersion7Tests), "moet versie 7 zijn");
    }
    
}