using System.ComponentModel;

/// <summary>
/// </summary>
public static class PhotoSearchExtrasExtensions
{
    /// <summary>
    /// Utility method to convert the <see cref="PhotoSearchExtras"/> enum to a string.
    /// </summary>
    /// <example>
    /// <code>
    ///PhotoSearchExtras extras = PhotoSearchExtras.DateTaken &amp; PhotoSearchExtras.IconServer;
    ///string val = Utils.ExtrasToString(extras);
    ///Console.WriteLine(val);
    /// </code>
    /// outputs: "date_taken,icon_server";
    /// </example>
    /// <param name="extras"></param>
    /// <returns></returns>
    public static string ToFlickrString(this PhotoSearchExtras extras)
    {
        List<string> extraList = new();
        Type e = typeof(PhotoSearchExtras);
        foreach (PhotoSearchExtras extra in GetFlags(extras))
        {
            System.Reflection.FieldInfo info = e.GetField(extra.ToString("G"));
            DescriptionAttribute[] o = (DescriptionAttribute[])info.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (o.Length == 0)
            {
                continue;
            }

            DescriptionAttribute att = o[0];
            extraList.Add(att.Description);
        }

        return string.Join(",", extraList.ToArray());
    }

    private static IEnumerable<Enum> GetFlags(Enum input)
    {
        long i = Convert.ToInt64(input);
        foreach (Enum value in GetValues(input))
        {
            if ((i & Convert.ToInt64(value)) != 0)
            {
                yield return value;
            }
        }
    }

    private static IEnumerable<Enum> GetValues(Enum enumeration)
    {
        List<Enum> enumerations = new();
        foreach (System.Reflection.FieldInfo fieldInfo in enumeration.GetType().GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public))
        {
            enumerations.Add((Enum)fieldInfo.GetValue(enumeration));
        }
        return enumerations;
    }
}