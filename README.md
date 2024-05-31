[![Build Status](https://dev.azure.com/fluxera/Foundation/_apis/build/status%2FGitHub%2Ffluxera.Fluxera.Results?branchName=main)](https://dev.azure.com/fluxera/Foundation/_build/latest?definitionId=96&branchName=main)

# Results

A result object implementation. Return result objects from operations
to indicate success or failure instead of throwing exceptions.

## Features

- Default result implementations with and without a result value.
    - ```Result```
    - ```Result<int>```
- Supports multiple error messages.
- Supports optional multiple success messages.
- Supports custom error and success implementations.
- Provides [FluentAssertions](https://fluentassertions.com/) extensions for simpler unit testing.
- Provides extensions to transform results to ```IActionResult``` instances for ASP.NET controllers.
- Provides extensions to transform results to ```IResult``` instances to be used with Minimal APIs.

## Usage

### Create Results

To create result instances use the static helper methods found in the ```Result``` class.

```C#
// Create a successful result without a value.
Result result = Result.Ok();

// Create a successful result with a value.
Result<int> result = Result.Ok(42);

// Create a failed result without a value.
Result result = Result.Fail("An error occurred.");
Result result = Result.Fail(new Error("An error occurred));

// Create a failed result for a result that can have a value.
Result<int> result = Result.Fail<int>("An error occurred.");
Result<int> result = Result.Fail<int>(new Error("An error occurred));
```

The result type ```Result``` is typically used by operations that have no return value.

```C#
public Result PerformOperation() 
{
    if(this.State == State.Failed) 
    {
        return Result.Fail("The operation failed.");
    }

    return Result.Ok();
}
```

The result type ```Result<T>``` is typically used by operations that have a return value.

```C#
public Result<int> PerformOperation() 
{
    if(this.State == State.Failed) 
    {
        return Result.Fail<int>("The operation failed.");
    }

    return Result.Ok(42);
}
```

### Process Results

To process the result of an operation you can check if the operation was 
successful or failed by accessing the ```IsSuccessful``` or ```IsFailed```
properties.

```C#
// Handle the return value of a result without a value.
Result result = PerformOperation();

// Print all error messages, if the result is failed.
if(result.IsFailed) 
{
    foreach(IError error in result.Errors) 
    {
        Console.WriteLine(error.Message);
    }
}

// Print all success messages, if the result is successful.
if(result.IsSuccessful) 
{
    foreach(ISuccess success in result.Successes) 
    {
        Console.WriteLine(success.Message);
    }
}

// Handle the return value of a result with a value.
Result<int> result = PerformOperation();

// Get the value if the result is successful or will throw if the result is failed.
int value = result.Value;

// Get the value oif the result is successful or will return the default of the value.
int value = result.GetValueOrDefault();
```

## References

[Michael Altmann](https://github.com/altmann)

[FluentResults](https://github.com/altmann/FluentResults)