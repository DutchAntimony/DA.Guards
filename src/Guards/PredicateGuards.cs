using System.Runtime.CompilerServices;

namespace DA.Guards;

/// <summary>
/// Verify that a given predicate on an object is true.
/// </summary>
public static class PredicateGuards
{
    /// <summary>
    /// Ensure that a predicate on a given object is true.
    /// </summary>
    /// <param name="value">The value to ensure.</param>
    /// <param name="predicate">The function that must be true.</param>
    /// <param name="message">The message in the exception if the value is invalid.</param>
    /// <param name="parameter">Automatically filled; the name of the provided value.</param>
    /// <param name="method">Automatically filled; the name of the method calling this value.</param>
    /// <returns>Fluently the provided value, if value is valid.</returns>
    /// <exception cref="ArgumentException">Thrown if ensure does not succeed.</exception>
    public static T EnsureTrue<T>(
        this T value,
        Predicate<T> predicate,
        string? message = null,
        [CallerArgumentExpression(nameof(value))] string parameter = "",
        [CallerMemberName] string method = "") =>
        predicate(value)
            ? value
            : throw new ArgumentException(
            message ?? $"Ongeldige waarde voor {parameter} in methode {method}. {typeof(T).Name} voldoet niet aan de gestelde voorwaarde.",
            parameter); 
    
    /// <summary>
    /// Ensure that a predicate on a given object is true.
    /// </summary>
    /// <param name="value">The value to ensure.</param>
    /// <param name="predicate">The function that must be true.</param>
    /// <param name="message">The message in the exception if the value is invalid.</param>
    /// <param name="parameter">Automatically filled; the name of the provided value.</param>
    /// <param name="method">Automatically filled; the name of the method calling this value.</param>
    /// <returns>Fluently the provided value, if value is valid.</returns>
    /// <exception cref="ArgumentException">Thrown if ensure does not succeed.</exception>
    public static async Task<T> EnsureTrueAsync<T>(
        this T value,
        Func<T, Task<bool>> predicate,
        string? message = null,
        [CallerArgumentExpression(nameof(value))] string parameter = "",
        [CallerMemberName] string method = "") =>
        await predicate(value)
            ? value
            : throw new ArgumentNullException(
                message ?? $"Ongeldige waarde '{value}' voor {parameter} in methode {method}. {typeof(T).Name} voldoet niet aan de gestelde voorwaarde.",
                parameter); 
}