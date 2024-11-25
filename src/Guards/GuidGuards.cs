using System.Runtime.CompilerServices;

namespace DA.Guards;

/// <summary>
/// Verify that a certain Guid is correct.
/// </summary>
public static class GuidGuards
{
    /// <summary>
    /// Ensure that a given Guid is not empty.
    /// </summary>
    /// <param name="value">The value to ensure.</param>
    /// <param name="message">The message in the exception if the value is invalid.</param>
    /// <param name="parameter">Automatically filled; the name of the provided value.</param>
    /// <param name="method">Automatically filled; the name of the method calling this value.</param>
    /// <returns>Fluently the provided value, if value is valid.</returns>
    /// <exception cref="ArgumentException">Thrown if ensure does not succeed.</exception>
    public static Guid EnsureNotEmpty(
        this Guid value,
        string? message = null,
        [CallerArgumentExpression(nameof(value))] string parameter = "",
        [CallerMemberName] string method = "") =>
        value == Guid.Empty 
            ? throw new ArgumentException(message ?? 
                                          $"Ongeldige waarde voor Guid {parameter} in methode {method}. Guid mag niet Empty zijn.", parameter)
            : value;

    /// <summary>
    /// Ensure that a given Guid is a version 7 Guid.
    /// </summary>
    /// <param name="value">The value to ensure.</param>
    /// <param name="message">The message in the exception if the value is invalid.</param>
    /// <param name="parameter">Automatically filled; the name of the provided value.</param>
    /// <param name="method">Automatically filled; the name of the method calling this value.</param>
    /// <returns>Fluently the provided value, if value is valid.</returns>
    /// <exception cref="ArgumentException">Thrown if ensure does not succeed.</exception>
    public static Guid EnsureVersion7(
        this Guid value,
        string? message = null,
        [CallerArgumentExpression(nameof(value))]
        string parameter = "",
        [CallerMemberName] string method = "") =>
        value.Version == 7
            ? value
            : throw new ArgumentException(message ??
                                          $"Ongeldige Guid 'version {value.Version}' voor {parameter} in methode {method}. Guid moet versie 7 zijn.",
                parameter);
}