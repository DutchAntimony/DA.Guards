using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace DA.Guards;

/// <summary>
/// Verify that an object is not null.
/// </summary>
public static class ObjectNullGuards
{
    /// <summary>
    /// Ensure that a given object is not null.
    /// </summary>
    /// <param name="value">The value to ensure.</param>
    /// <param name="message">The message in the exception if the value is invalid.</param>
    /// <param name="parameter">Automatically filled; the name of the provided value.</param>
    /// <param name="method">Automatically filled; the name of the method calling this value.</param>
    /// <returns>Fluently the provided value, if value is valid.</returns>
    /// <exception cref="ArgumentException">Thrown if ensure does not succeed.</exception>
    public static T EnsureNotNull<T>(
        [NoEnumeration] this T? value,
        string? message = null,
        [CallerArgumentExpression(nameof(value))] string parameter = "",
        [CallerMemberName] string method = "")
        where T : class =>
        value ?? throw new ArgumentNullException(
            message ?? $"Ongeldige waarde voor {parameter} in methode {method}. {typeof(T).Name} mag niet null zijn.",
            parameter);
    
    /// <summary>
    /// Ensure that a given struct is not null.
    /// </summary>
    /// <param name="value">The value to ensure.</param>
    /// <param name="message">The message in the exception if the value is invalid.</param>
    /// <param name="parameter">Automatically filled; the name of the provided value.</param>
    /// <param name="method">Automatically filled; the name of the method calling this value.</param>
    /// <returns>Fluently the provided value, if value is valid.</returns>
    /// <exception cref="ArgumentException">Thrown if ensure does not succeed.</exception>
    public static T EnsureNotNull<T>(
        this T? value,
        string? message = null,
        [CallerArgumentExpression(nameof(value))] string parameter = "",
        [CallerMemberName] string method = "")
        where T : struct =>
        value ?? throw new ArgumentNullException(
            message ?? $"Ongeldige waarde '{value}' voor {parameter} in methode {method}. {typeof(T).Name} mag niet de null zijn.",
            parameter);
    
    /// <summary>
    /// Ensure that a given object does not have it's default value.
    /// </summary>
    /// <param name="value">The value to ensure.</param>
    /// <param name="message">The message in the exception if the value is invalid.</param>
    /// <param name="parameter">Automatically filled; the name of the provided value.</param>
    /// <param name="method">Automatically filled; the name of the method calling this value.</param>
    /// <returns>Fluently the provided value, if value is valid.</returns>
    /// <exception cref="ArgumentException">Thrown if ensure does not succeed.</exception>
    public static T EnsureNotDefault<T>(
        this T value,
        string? message = null,
        [CallerArgumentExpression(nameof(value))] string parameter = "",
        [CallerMemberName] string method = "")
        where T : struct =>
        Equals(value, default(T))
        ? throw new ArgumentException(
            message ?? $"Ongeldige waarde voor {parameter} in methode {method}. {typeof(T).Name} mag niet de default waarde '{default(T)}' zijn.",
            parameter)
        : value;
}