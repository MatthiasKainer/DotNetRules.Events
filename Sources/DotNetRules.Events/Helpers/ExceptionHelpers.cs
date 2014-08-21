namespace DotNetRules.Events.Helpers
{
    using System;

    static class Errors
    {
        public static TReturn ThrowIfNull<TReturn>(Func<TReturn> @for, Exception toThrow) where TReturn : class
        {
            var result = @for();
            if (result == null || string.IsNullOrWhiteSpace(result.ToString())) throw toThrow;
            return result;
        }
    }
}
