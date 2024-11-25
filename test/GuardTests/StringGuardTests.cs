namespace GuardTests;

public class StringGuardTests : BaseTest
{
    private readonly string? _nullString = null;
    
    [Fact]
    public void EnsureNotNullTests()
    {
        "abc".EnsureNotNull().ShouldBe("abc");
        ShouldThrowWithMessageContaining<ArgumentException>(() => _nullString.EnsureNotNull(),
            "Ongeldige waarde 'null'", nameof(EnsureNotNullTests), "String mag niet null zijn.");
    }
    
    [Fact]
    public void EnsureNotEmptyTests()
    {
        "abc".EnsureNotEmpty().ShouldBe("abc");
        ShouldThrowWithMessageContaining<ArgumentException>(() => _nullString.EnsureNotEmpty(),
            "Ongeldige waarde 'null'", nameof(EnsureNotEmptyTests), "String mag niet leeg zijn.");
        ShouldThrowWithMessageContaining<ArgumentException>(() => "\t".EnsureNotEmpty(),
            "Ongeldige waarde '\t'", nameof(EnsureNotEmptyTests), "String mag niet leeg zijn.");
    }
    
    [Fact]
    public void EnsureMinimumStringLengthTests()
    {
        "abc".EnsureMinimumStringLength(3).ShouldBe("abc");
        ShouldThrowWithMessageContaining<ArgumentException>(() => _nullString.EnsureMinimumStringLength(3),
            "Ongeldige waarde 'null'", nameof(EnsureMinimumStringLengthTests), "Lengte is 0", "minimaal 3");
        ShouldThrowWithMessageContaining<ArgumentException>(() => "ab".EnsureMinimumStringLength(3),
            "Ongeldige waarde 'ab'", nameof(EnsureMinimumStringLengthTests), "Lengte is 2", "minimaal 3");
    }
    
    [Fact]
    public void EnsureExactStringLengthTests()
    {
        "abc".EnsureExactStringLength(3).ShouldBe("abc");
        ShouldThrowWithMessageContaining<ArgumentException>(() => _nullString.EnsureExactStringLength(3),
            "Ongeldige waarde 'null'", nameof(EnsureExactStringLengthTests), "Lengte is 0", "exact 3");
        ShouldThrowWithMessageContaining<ArgumentException>(() => "ab".EnsureExactStringLength(3),
            "Ongeldige waarde 'ab'", nameof(EnsureExactStringLengthTests), "Lengte is 2", "exact 3");
    }
    
    [Fact]
    public void EnsureMaximumStringLengthTests()
    {
        "abc".EnsureMaximumStringLength(3).ShouldBe("abc");
        ShouldThrowWithMessageContaining<ArgumentException>(() => _nullString.EnsureMaximumStringLength(3),
            "Ongeldige waarde 'null'", nameof(EnsureMaximumStringLengthTests), "Lengte is 0", "maximaal 3");
        ShouldThrowWithMessageContaining<ArgumentException>(() => "abcd".EnsureMaximumStringLength(3),
            "Ongeldige waarde 'abcd'", nameof(EnsureMaximumStringLengthTests), "Lengte is 4", "maximaal 3");
    }
}