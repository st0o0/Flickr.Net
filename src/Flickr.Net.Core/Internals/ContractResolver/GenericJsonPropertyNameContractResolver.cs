using System.Reflection;
using Flickr.Net.Core.Internals.Attributes;
using Newtonsoft.Json.Serialization;

namespace Flickr.Net.Core.Internals.ContractResolver;

/// <summary>
/// </summary>
internal class GenericJsonPropertyNameContractResolver : DefaultContractResolver
{
    /// <summary>
    /// </summary>
    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        var prop = base.CreateProperty(member, memberSerialization);
        var attr = member.GetCustomAttribute<JsonPropertyGenericTypeNameAttribute>();
        if (attr != null)
        {
            var type = member.DeclaringType!;
            if (!type.IsGenericType)
                throw new InvalidOperationException($"{type} is not a generic type");
            if (type.IsGenericTypeDefinition)
                throw new InvalidOperationException($"{type} is a generic type definition, it must be a constructed generic type");
            var typeArgs = type.GetGenericArguments();
            if (attr.TypeParameterPosition >= typeArgs.Length)
                throw new ArgumentException($"Can't get type argument at position {attr.TypeParameterPosition}; {type} has only {typeArgs.Length} type arguments");
            if (typeArgs[attr.TypeParameterPosition].IsDefined(typeof(FlickrJsonPropertyNameAttribute), true))
                prop.PropertyName = typeArgs[attr.TypeParameterPosition].GetCustomAttribute<FlickrJsonPropertyNameAttribute>().Name;
            else
                prop.PropertyName = typeArgs[attr.TypeParameterPosition].Name.ToLower();
        }
        return prop;
    }
}