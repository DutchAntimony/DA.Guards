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