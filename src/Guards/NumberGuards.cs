using System.Numerics;
using System.Runtime.CompilerServices;

namespace DA.Guards;

/// <summary>
/// Verify that the value of a number is within certain bounds.
/// </summary>
public static class NumberGuards
{
    /// <summary>
    /// Ensure that a given number has a strictly positive value.
    /// </summary>
    /// <typeparam name="TNumber">The type of the provided number.</typeparam>
    /// <param name="value">The value to ensure.</param>
    /// <param name="message">The message in the exception if the value is invalid.</param>
    /// <param name="parameter">Automatically filled; the name of the provided value.</param>
    /// <param name="method">Automatically filled; the name of the method calling this value.</param>
    /// <returns>Fluently the provided value, if value is valid.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if ensure does not succeed.</exception>
    public static TNumber EnsurePositive<TNumber>(this TNumber value, string? message = null,
        [CallerArgumentExpression(nameof(value))] string parameter = "", [CallerMemberName] string method = "")
        where TNumber : INumber<TNumber> =>
        value > TNumber.Zero
            ? value
            : throw new ArgumentOutOfRangeException(parameter, value,
                message ??
                $"Ongeldige waarde {value} voor {parameter} in methode {method}. Waarde moet strikt positief zijn.");
    
    /// <summary>
    /// Ensure that a given number has a non-negative (0 or greater) value.
    /// </summary>
    /// <typeparam name="TNumber">The type of the provided number.</typeparam>
    /// <param name="value">The value to ensure.</param>
    /// <param name="message">The message in the exception if the value is invalid.</param>
    /// <param name="parameter">Automatically filled; the name of the provided value.</param>
    /// <param name="method">Automatically filled; the name of the method calling this value.</param>
    /// <returns>Fluently the provided value, if value is valid.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if ensure does not succeed.</exception>
    public static TNumber EnsureNotNegative<TNumber>(this TNumber value, string? message = null,
        [CallerArgumentExpression(nameof(value))] string parameter = "", [CallerMemberName] string method = "")
        where TNumber : INumber<TNumber> =>
        value >= TNumber.Zero
            ? value
            : throw new ArgumentOutOfRangeException(parameter, value,
                message ??
                $"Ongeldige waarde {value} voor {parameter} in methode {method}. Waarde mag niet negatief zijn.");
    
    /// <summary>
    /// Ensure that a given number is greater or equal to the threshold.
    /// </summary>
    /// <typeparam name="TNumber">The type of the provided number.</typeparam>
    /// <param name="value">The value to ensure.</param>
    /// <param name="minValue">The minimum value for the result.</param>
    /// <param name="message">The message in the exception if the value is invalid.</param>
    /// <param name="parameter">Automatically filled; the name of the provided value.</param>
    /// <param name="method">Automatically filled; the name of the method calling this value.</param>
    /// <returns>Fluently the provided value, if value is valid.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if ensure does not succeed.</exception>
    public static TNumber EnsureGreaterThan<TNumber>(this TNumber value, TNumber minValue, string? message = null,
        [CallerArgumentExpression(nameof(value))] string parameter = "", [CallerMemberName] string method = "")
        where TNumber : INumber<TNumber> =>
        value >= minValue
            ? value
            : throw new ArgumentOutOfRangeException(parameter, value,
                message ??
                $"Ongeldige waarde {value} voor {parameter} in methode {method}. Waarde moet groter of gelijk zijn aan {minValue}.");
    
    /// <summary>
    /// Ensure that a given number is smaller or equal to the threshold.
    /// </summary>
    /// <typeparam name="TNumber">The type of the provided number.</typeparam>
    /// <param name="value">The value to ensure.</param>
    /// <param name="maxValue">The maximum value for the result.</param>
    /// <param name="message">The message in the exception if the value is invalid.</param>
    /// <param name="parameter">Automatically filled; the name of the provided value.</param>
    /// <param name="method">Automatically filled; the name of the method calling this value.</param>
    /// <returns>Fluently the provided value, if value is valid.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if ensure does not succeed.</exception>
    public static TNumber EnsureSmallerThan<TNumber>(this TNumber value, TNumber maxValue, string? message = null,
        [CallerArgumentExpression(nameof(value))] string parameter = "", [CallerMemberName] string method = "")
        where TNumber : INumber<TNumber> =>
        value <= maxValue
            ? value
            : throw new ArgumentOutOfRangeException(parameter, value,
                message ??
                $"Ongeldige waarde {value} voor {parameter} in methode {method}. Waarde moet kleiner of gelijk zijn aan {maxValue}.");
    
    /// <summary>
    /// Ensure that a given number is within the provided range.
    /// </summary>
    /// <typeparam name="TNumber">The type of the provided number.</typeparam>
    /// <param name="value">The value to ensure.</param>
    /// <param name="minValue">The minimum value for the result.</param>
    /// <param name="maxValue">The maximum value for the result.</param>
    /// <param name="message">The message in the exception if the value is invalid.</param>
    /// <param name="parameter">Automatically filled; the name of the provided value.</param>
    /// <param name="method">Automatically filled; the name of the method calling this value.</param>
    /// <returns>Fluently the provided value, if value is ensured.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if ensure does not succeed.</exception>
    public static TNumber EnsureInRange<TNumber>(this TNumber value, TNumber minValue, TNumber maxValue, string? message = null,
        [CallerArgumentExpression(nameof(value))] string parameter = "", [CallerMemberName] string method = "")
        where TNumber : INumber<TNumber> =>
        value >= minValue && value <= maxValue
            ? value
            : throw new ArgumentOutOfRangeException(parameter, value,
                message ??
                $"Ongeldige waarde {value} voor {parameter} in methode {method}. Waarde moet tussen {minValue} en {maxValue} liggen.");
}