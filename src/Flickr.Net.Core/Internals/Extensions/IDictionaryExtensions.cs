namespace Flickr.Net.Core.Internals.Extensions;

/// <summary>
/// </summary>
public static class IDictionaryExtensions
{
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
    public static void AppendIf<TKey, TTargetValue, TSourceValue>(this IDictionary<TKey, TTargetValue> pairs, TKey key, TSourceValue value, Predicate<TSourceValue> predicate, Func<TSourceValue, TTargetValue> func)
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
    public static void AppendIf<TKey, TSourceValue>(this IDictionary<TKey, TSourceValue> pairs, TKey key, TSourceValue value, Predicate<TSourceValue> predicate)
    {
        pairs.AppendIf(key, value, predicate, x => x);
    }
}
