namespace GuardTests;

public class DateOnlyGuardTests : BaseTest
{
    private readonly DateOnly _value = new DateOnly(2022, 1, 1);
    private readonly DateOnly _dateOnlyGreater = new DateOnly(2024, 1, 1);
    private readonly DateOnly _dateOnlySmaller = new DateOnly(2020, 1, 1);
    
    private readonly DateTime _dateTimeGreater = new DateTime(2024, 1, 1);
    private readonly DateTime _dateTimeSmaller = new DateTime(2020, 1, 1);
    
    [Fact]
    public void EnsureAfterTests()
    {
        _value.EnsureAfter(_dateOnlySmaller).ShouldBe(_value);
        ShouldThrowWithMessageContaining<ArgumentOutOfRangeException>(() => _value.EnsureAfter(_dateOnlyGreater),
            $"Ongeldige waarde {_value:d}", nameof(EnsureAfterTests), $"na {_dateOnlyGreater:d}");
        
        _value.EnsureAfter(_dateTimeSmaller).ShouldBe(_value);
        ShouldThrowWithMessageContaining<ArgumentOutOfRangeException>(() => _value.EnsureAfter(_dateTimeGreater),
            $"Ongeldige waarde {_value:d}", nameof(EnsureAfterTests), $"na {_dateTimeGreater:d}");
    }

    [Fact]
    public void EnsureBeforeTests()
    {
        _value.EnsureBefore(_dateOnlyGreater).ShouldBe(_value);
        ShouldThrowWithMessageContaining<ArgumentOutOfRangeException>(() => _value.EnsureBefore(_dateOnlySmaller),
            $"Ongeldige waarde {_value:d}", nameof(EnsureBeforeTests), $"voor {_dateOnlySmaller:d}");
        
        _value.EnsureBefore(_dateTimeGreater).ShouldBe(_value);
        ShouldThrowWithMessageContaining<ArgumentOutOfRangeException>(() => _value.EnsureBefore(_dateTimeSmaller),
            $"Ongeldige waarde {_value:d}", nameof(EnsureBeforeTests), $"voor {_dateTimeSmaller:d}");
    }
    
    [Fact]
    public void EnsureInRangeTests()
    {
        _value.EnsureInRange(_dateOnlySmaller, _dateOnlyGreater).ShouldBe(_value);
        _value.EnsureInRange(_dateTimeSmaller, _dateOnlyGreater).ShouldBe(_value);
        _value.EnsureInRange(_dateOnlySmaller, _dateTimeGreater).ShouldBe(_value);
        _value.EnsureInRange(_dateTimeSmaller, _dateTimeGreater).ShouldBe(_value);

        ShouldThrowWithMessageContaining<ArgumentOutOfRangeException>(() => _value.EnsureInRange(_dateOnlySmaller, _dateOnlySmaller),
            $"Ongeldige waarde {_value:d}", nameof(EnsureInRangeTests), $"voor {_dateOnlySmaller:d}");
        ShouldThrowWithMessageContaining<ArgumentOutOfRangeException>(() => _value.EnsureInRange(_dateOnlySmaller, _dateTimeSmaller),
            $"Ongeldige waarde {_value:d}", nameof(EnsureInRangeTests), $"voor {_dateOnlySmaller:d}");
        ShouldThrowWithMessageContaining<ArgumentOutOfRangeException>(() => _value.EnsureInRange(_dateTimeSmaller, _dateOnlySmaller),
            $"Ongeldige waarde {_value:d}", nameof(EnsureInRangeTests), $"voor {_dateOnlySmaller:d}");
        ShouldThrowWithMessageContaining<ArgumentOutOfRangeException>(() => _value.EnsureInRange(_dateTimeSmaller, _dateTimeSmaller),
            $"Ongeldige waarde {_value:d}", nameof(EnsureInRangeTests), $"voor {_dateOnlySmaller:d}");
    }
}