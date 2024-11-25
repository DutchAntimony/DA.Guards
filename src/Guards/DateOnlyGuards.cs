using System.Runtime.CompilerServices;

namespace DA.Guards;

/// <summary>
/// Verify that a DateOnly is within certain bounds.
/// </summary>
public static class DateOnlyGuards
{
    /// <summary>
    /// Ensure that a given DateOnly is after a specified date.
    /// </summary>
    /// <param name="value">The value to ensure.</param>
    /// <param name="comparison">The Date to compare with.</param>
    /// <param name="message">The message in the exception if the value is invalid.</param>
    /// <param name="parameter">Automatically filled; the name of the provided value.</param>
    /// <param name="method">Automatically filled; the name of the method calling this value.</param>
    /// <returns>Fluently the provided value, if value is valid.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if ensure does not succeed.</exception>
    public static DateOnly EnsureAfter(this DateOnly value, DateOnly comparison, string? message = null,
        [CallerArgumentExpression(nameof(value))] string parameter = "", [CallerMemberName] string method = "") =>
        value >= comparison
            ? value
            : throw new ArgumentOutOfRangeException(parameter, value,
                message ??
                $"Ongeldige waarde {value:d} voor {parameter} in methode {method}. Datum moet na {comparison:d} zijn.");
    
    /// <summary>
    /// Ensure that a given DateOnly is after a specified date time.
    /// </summary>
    /// <param name="value">The value to ensure.</param>
    /// <param name="comparison">The Date to compare with.</param>
    /// <param name="message">The message in the exception if the value is invalid.</param>
    /// <param name="parameter">Automatically filled; the name of the provided value.</param>
    /// <param name="method">Automatically filled; the name of the method calling this value.</param>
    /// <returns>Fluently the provided value, if value is valid.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if ensure does not succeed.</exception>
    public static DateOnly EnsureAfter(this DateOnly value, DateTime comparison, string? message = null,
        [CallerArgumentExpression(nameof(value))] string parameter = "", [CallerMemberName] string method = "") =>
        EnsureAfter(value, DateOnly.FromDateTime(comparison), message, parameter, method);
    
    /// <summary>
    /// Ensure that a given DateOnly is before a specified date.
    /// </summary>
    /// <param name="value">The value to ensure.</param>
    /// <param name="comparison">The Date to compare with.</param>
    /// <param name="message">The message in the exception if the value is invalid.</param>
    /// <param name="parameter">Automatically filled; the name of the provided value.</param>
    /// <param name="method">Automatically filled; the name of the method calling this value.</param>
    /// <returns>Fluently the provided value, if value is valid.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if ensure does not succeed.</exception>
    public static DateOnly EnsureBefore(this DateOnly value, DateOnly comparison, string? message = null,
        [CallerArgumentExpression(nameof(value))] string parameter = "", [CallerMemberName] string method = "") =>
        value <= comparison
            ? value
            : throw new ArgumentOutOfRangeException(parameter, value,
                message ??
                $"Ongeldige waarde {value} voor {parameter} in methode {method}. Datum moet voor {comparison:d} zijn.");
    
    /// <summary>
    /// Ensure that a given DateOnly is before a specified date time.
    /// </summary>
    /// <param name="value">The value to ensure.</param>
    /// <param name="comparison">The Date to compare with.</param>
    /// <param name="message">The message in the exception if the value is invalid.</param>
    /// <param name="parameter">Automatically filled; the name of the provided value.</param>
    /// <param name="method">Automatically filled; the name of the method calling this value.</param>
    /// <returns>Fluently the provided value, if value is valid.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if ensure does not succeed.</exception>
    public static DateOnly EnsureBefore(this DateOnly value, DateTime comparison, string? message = null,
        [CallerArgumentExpression(nameof(value))] string parameter = "", [CallerMemberName] string method = "") =>
        EnsureBefore(value, DateOnly.FromDateTime(comparison), message, parameter, method);

    /// <summary>
    /// Ensure that a given DateOnly in between two specified dates.
    /// </summary>
    /// <param name="value">The value to ensure.</param>
    /// <param name="after">The date the value should be after.</param>
    /// <param name="before">The date the value should be before.</param>
    /// <param name="message">The message in the exception if the value is invalid.</param>
    /// <param name="parameter">Automatically filled; the name of the provided value.</param>
    /// <param name="method">Automatically filled; the name of the method calling this value.</param>
    /// <returns>Fluently the provided value, if value is valid.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if ensure does not succeed.</exception>
    public static DateOnly EnsureInRange(this DateOnly value, DateOnly after, DateOnly before, string? message = null,
        [CallerArgumentExpression(nameof(value))]
        string parameter = "", [CallerMemberName] string method = "") =>
        value.EnsureBefore(before, message, parameter, method).EnsureAfter(after, message, parameter, method);
    
    /// <summary>
    /// Ensure that a given DateOnly in between two specified date times.
    /// </summary>
    /// <param name="value">The value to ensure.</param>
    /// <param name="after">The date the value should be after.</param>
    /// <param name="before">The date the value should be before.</param>
    /// <param name="message">The message in the exception if the value is invalid.</param>
    /// <param name="parameter">Automatically filled; the name of the provided value.</param>
    /// <param name="method">Automatically filled; the name of the method calling this value.</param>
    /// <returns>Fluently the provided value, if value is valid.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if ensure does not succeed.</exception>
    public static DateOnly EnsureInRange(this DateOnly value, DateOnly after, DateTime before, string? message = null,
        [CallerArgumentExpression(nameof(value))]
        string parameter = "", [CallerMemberName] string method = "") =>
        value.EnsureBefore(before, message, parameter, method).EnsureAfter(after, message, parameter, method);
    
    /// <summary>
    /// Ensure that a given DateOnly in between two specified date times.
    /// </summary>
    /// <param name="value">The value to ensure.</param>
    /// <param name="after">The date the value should be after.</param>
    /// <param name="before">The date the value should be before.</param>
    /// <param name="message">The message in the exception if the value is invalid.</param>
    /// <param name="parameter">Automatically filled; the name of the provided value.</param>
    /// <param name="method">Automatically filled; the name of the method calling this value.</param>
    /// <returns>Fluently the provided value, if value is valid.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if ensure does not succeed.</exception>
    public static DateOnly EnsureInRange(this DateOnly value, DateTime after, DateOnly before, string? message = null,
        [CallerArgumentExpression(nameof(value))]
        string parameter = "", [CallerMemberName] string method = "") =>
        value.EnsureBefore(before, message, parameter, method).EnsureAfter(after, message, parameter, method);
    
    /// <summary>
    /// Ensure that a given DateOnly in between two specified date times.
    /// </summary>
    /// <param name="value">The value to ensure.</param>
    /// <param name="after">The date the value should be after.</param>
    /// <param name="before">The date the value should be before.</param>
    /// <param name="message">The message in the exception if the value is invalid.</param>
    /// <param name="parameter">Automatically filled; the name of the provided value.</param>
    /// <param name="method">Automatically filled; the name of the method calling this value.</param>
    /// <returns>Fluently the provided value, if value is valid.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if ensure does not succeed.</exception>
    public static DateOnly EnsureInRange(this DateOnly value, DateTime after, DateTime before, string? message = null,
        [CallerArgumentExpression(nameof(value))]
        string parameter = "", [CallerMemberName] string method = "") =>
        value.EnsureBefore(before, message, parameter, method).EnsureAfter(after, message, parameter, method);
}