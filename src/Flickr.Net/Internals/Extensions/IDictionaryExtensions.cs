namespace Flickr.Net.Internals.Extensions;

/// <summary>
/// </summary>
public static class DictionaryExtensions
{
    /// <summary>
    /// Appends the if.
    /// </summary>
    /// <param name="pairs">The pairs.</param>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    /// <param name="predicate">The predicate.</param>
    /// <param name="func">The func.</param>
    /// <param name="defaultValue">The default value.</param>
    internal static void AppendIf<TKey, TTargetValue, TSourceValue>(
        this IDictionary<TKey, TTargetValue> pairs,
        TKey key,
        TSourceValue value,
        Predicate<TSourceValue> predicate,
        Func<TSourceValue, TTargetValue> func,
        TTargetValue defaultValue)
    {
        if (predicate(value))
        {
            pairs.Add(key, func(value));
        }
        else
        {
            pairs.Add(key, defaultValue);
        }
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TTargetValue"></typeparam>
    /// <typeparam name="TSourceValue"></typeparam>
    /// <param name="pairs"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="predicate"></param>
    /// <param name="func"></param>
    internal static void AppendIf<TKey, TTargetValue, TSourceValue>(this IDictionary<TKey, TTargetValue> pairs, TKey key, TSourceValue value, Predicate<TSourceValue> predicate, Func<TSourceValue, TTargetValue> func)
    {
        if (predicate(value))
        {
            pairs.Add(key, func(value));
        }
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TSourceValue"></typeparam>
    /// <param name="pairs"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="predicate"></param>
    internal static void AppendIf<TKey, TSourceValue>(this IDictionary<TKey, TSourceValue> pairs, TKey key, TSourceValue value, Predicate<TSourceValue> predicate)
    {
        pairs.AppendIf(key, value, predicate, x => x);
    }
}
