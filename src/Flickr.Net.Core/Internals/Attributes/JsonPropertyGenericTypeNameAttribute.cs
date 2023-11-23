﻿namespace Flickr.Net.Core.Internals.Attributes;

[AttributeUsage(AttributeTargets.Property)]
internal class JsonPropertyGenericTypeNameAttribute(int position) : Attribute
{
    public int TypeParameterPosition { get; } = position;
}