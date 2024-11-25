# DA.Guards

Guard extensions for personal projects of DutchAntimony

## Structure of a guard clause:

Every guard clause has a similar structure:

- Extension method starting with ```Ensure```
- Returning the original value for fluent chaining and handling
- Optional parameter ```message``` that is generated if not added
- ```[CallerArgumentExpression]``` name of the provided value.
- ```[CallerMemberName]``` name of the method that called the guard clause.

```csharp
public static string EnsureNotNull(this string? value, string? message = null,
        [CallerArgumentExpression(nameof(value))] string parameter = "",
        [CallerMemberName] string method = "") { /* omitted */ }
```

## Overview of the Guards present:

- DateOnlyGuards: Guard that a ```DateOnly``` is before, after, or in range of the bounds.
- DateTimeGuards: Guard that a ```DateTime``` is before, after, or in range of the bounds.
- GuidGuards: Guard that a ```Guid``` has a set value or is of the new Version7 type.
- NumberGuards: Guard that any ```INumber``` has a value greater, smaller or in range of the bounds.
- ObjectGuards: Guard that any ```class``` or ```struct``` has a not null or not default value.
- PredicateGuards: Guard that a provided predicate ```Func<T, bool>``` is ```true``` for a provided object.
- StringGuards: Guard that a ```string``` is not null, empty and has a valid length.

## Future work

- [Committed] Enum in range validation
- [Probable] Collections : EnsureNotEmpty(), EnsureNoNullElements(), EnsureExactCount(int count), 
- [Questionable] Include async overloads for guards