namespace GuardTests;

public class NumberGuardTests : BaseTest
{
    [Fact]
    public void EnsurePositiveTests()
    {
        10.EnsurePositive().ShouldBe(10);
        ShouldThrowWithMessageContaining<ArgumentOutOfRangeException>(() => 0.EnsurePositive(),
            "Ongeldige waarde 0 voor", nameof(EnsurePositiveTests), "Waarde moet strikt positief zijn.");
    }
    
    [Fact]
    public void EnsureNotNegativeTests()
    {
        0.EnsureNotNegative().ShouldBe(0);
        ShouldThrowWithMessageContaining<ArgumentOutOfRangeException>(() => (-0.3).EnsureNotNegative(),
            "Ongeldige waarde -0,3 voor", nameof(EnsureNotNegativeTests), "Waarde mag niet negatief zijn.");
    }

    [Fact]
    public void EnsureGreaterThanTests()
    {
        1.EnsureGreaterThan(-1, "Custom message").ShouldBe(1);
        ShouldThrowWithMessageContaining<ArgumentOutOfRangeException>(() => 1.EnsureGreaterThan(2, "Custom Message"),
            "Custom", "Message");
    }
    
    [Fact]
    public void EnsureSmallerThanTests()
    {
        (0.50m).EnsureSmallerThan(1, "Custom message").ShouldBe(0.5m);
        ShouldThrowWithMessageContaining<ArgumentOutOfRangeException>(() => 2.EnsureSmallerThan(1, "Custom Message"),
            "Custom", "Message");
    }

    [Fact]
    public void EnsureInRangeTests()
    {
        Math.PI.EnsureInRange(3, 5, "Custom message").ShouldBe(Math.PI);
        ShouldThrowWithMessageContaining<ArgumentOutOfRangeException>(() => Math.E.EnsureInRange(-1, 0, "Custom message"),
                "Custom", "Message");
    }
 
}

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