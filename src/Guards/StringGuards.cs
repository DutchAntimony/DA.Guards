using System.Runtime.CompilerServices;

namespace DA.Guards;

public static class StringGuards
{
    /// <summary>
    /// Ensure that a given string is not empty.
    /// </summary>
    /// <param name="value">The value to ensure.</param>
    /// <param name="message">The message in the exception if the value is invalid.</param>
    /// <param name="parameter">Automatically filled; the name of the provided value.</param>
    /// <param name="method">Automatically filled; the name of the method calling this value.</param>
    /// <returns>Fluently the provided value, if value is valid.</returns>
    /// <exception cref="ArgumentException">Thrown if ensure does not succeed.</exception>
    public static string EnsureNotNull(
        this string? value,
        string? message = null,
        [CallerArgumentExpression(nameof(value))] string parameter = "",
        [CallerMemberName] string method = "") =>
        value ?? throw new ArgumentException(
            message ?? $"Ongeldige waarde '{value ?? "null"}' voor {parameter} in methode {method}. String mag niet null zijn.",
            parameter);
    
    /// <summary>
    /// Ensure that a given string is not empty.
    /// </summary>
    /// <param name="value">The value to ensure.</param>
    /// <param name="message">The message in the exception if the value is invalid.</param>
    /// <param name="parameter">Automatically filled; the name of the provided value.</param>
    /// <param name="method">Automatically filled; the name of the method calling this value.</param>
    /// <returns>Fluently the provided value, if value is valid.</returns>
    /// <exception cref="ArgumentException">Thrown if ensure does not succeed.</exception>
    public static string EnsureNotEmpty(
        this string? value,
        string? message = null,
        [CallerArgumentExpression(nameof(value))] string parameter = "",
        [CallerMemberName] string method = "") =>
        string.IsNullOrWhiteSpace(value)
            ? throw new ArgumentException(
                message ?? $"Ongeldige waarde '{value ?? "null"}' voor {parameter} in methode {method}. String mag niet leeg zijn.",
                parameter)
            : value;
    
    /// <summary>
    /// Ensure that the length of a given string is at least the provided threshold length.
    /// </summary>
    /// <param name="value">The value to ensure.</param>
    /// <param name="minLength">The minimum length of the provided string.</param>
    /// <param name="message">The message in the exception if the value is invalid.</param>
    /// <param name="parameter">Automatically filled; the name of the provided value.</param>
    /// <param name="method">Automatically filled; the name of the method calling this value.</param>
    /// <returns>Fluently the provided value, if value is valid.</returns>
    /// <exception cref="ArgumentException">Thrown if ensure does not succeed.</exception>
    public static string EnsureMinimumStringLength(
        this string? value,
        int minLength,
        string? message = null,
        [CallerArgumentExpression(nameof(value))] string parameter = "",
        [CallerMemberName] string method = "") =>
        value?.Length >= minLength
            ? value
            : throw new ArgumentException(
                message ?? $"Ongeldige waarde '{value ?? "null"}' voor {parameter} in methode {method}. Lengte is {value?.Length ?? 0} en moet minimaal {minLength} zijn.",
                parameter);

    /// <summary>
    /// Ensure that the length of a given string is at exactly the provided length.
    /// </summary>
    /// <param name="value">The value to ensure.</param>
    /// <param name="length">The required length of the provided string.</param>
    /// <param name="message">The message in the exception if the value is invalid.</param>
    /// <param name="parameter">Automatically filled; the name of the provided value.</param>
    /// <param name="method">Automatically filled; the name of the method calling this value.</param>
    /// <returns>Fluently the provided value, if value is valid.</returns>
    /// <exception cref="ArgumentException">Thrown if ensure does not succeed.</exception>
    public static string EnsureExactStringLength(
        this string? value,
        int length,
        string? message = null,
        [CallerArgumentExpression(nameof(value))] string parameter = "",
        [CallerMemberName] string method = "") =>
        value?.Length == length
            ? value
            : throw new ArgumentException(
                message ?? $"Ongeldige waarde '{value ?? "null"}' voor {parameter} in methode {method}. Lengte is {value?.Length ?? 0} en moet exact {length} zijn.",
                parameter);

    /// <summary>
    /// Ensure that the length of a given string is not longer then provided threshold length.
    /// </summary>
    /// <param name="value">The value to ensure.</param>
    /// <param name="maxLength">The maximum length of the provided string.</param>
    /// <param name="message">The message in the exception if the value is invalid.</param>
    /// <param name="parameter">Automatically filled; the name of the provided value.</param>
    /// <param name="method">Automatically filled; the name of the method calling this value.</param>
    /// <returns>Fluently the provided value, if value is valid.</returns>
    /// <exception cref="ArgumentException">Thrown if ensure does not succeed.</exception>
    public static string EnsureMaximumStringLength(
        this string? value,
        int maxLength,
        string? message = null,
        [CallerArgumentExpression(nameof(value))] string parameter = "",
        [CallerMemberName] string method = "") =>
        value is not null && value.Length <= maxLength
            ? value
            : throw new ArgumentException(
                message ?? $"Ongeldige waarde '{value ?? "null"}' voor {parameter} in methode {method}. Lengte is {value?.Length ?? 0} en mag maximaal {maxLength} zijn.",
                parameter);
}