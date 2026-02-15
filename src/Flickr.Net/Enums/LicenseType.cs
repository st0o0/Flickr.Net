using System.Runtime.Serialization;

namespace Flickr.Net.Enums;

/// <summary>
/// A enumeration containing the list of current license types.
/// </summary>
public enum LicenseType
{
    /// <summary>
    /// All Rights Reserved.
    /// </summary>
    [EnumMember(Value = "0")]
    AllRightsReserved = 0,

    /// <summary>
    /// Creative Commons: Attribution Non-Commercial, Share-alike License.
    /// </summary>
    [EnumMember(Value = "1")]
    AttributionNoncommercialShareAlikeCC = 1,

    /// <summary>
    /// Creative Commons: Attribution Non-Commercial License.
    /// </summary>
    [EnumMember(Value = "2")]
    AttributionNoncommercialCC = 2,

    /// <summary>
    /// Creative Commons: Attribution Non-Commercial, No Derivatives License.
    /// </summary>
    [EnumMember(Value = "3")]
    AttributionNoncommercialNoDerivativesCC = 3,

    /// <summary>
    /// Creative Commons: Attribution License.
    /// </summary>
    [EnumMember(Value = "4")]
    AttributionCC = 4,

    /// <summary>
    /// Creative Commons: Attribution Share-alike License.
    /// </summary>
    [EnumMember(Value = "5")]
    AttributionShareAlikeCC = 5,

    /// <summary>
    /// Creative Commons: Attribution No Derivatives License.
    /// </summary>
    [EnumMember(Value = "6")]
    AttributionNoDerivativesCC = 6,

    /// <summary>
    /// No Known Copyright Resitrctions (Flickr Commons).
    /// </summary>
    [EnumMember(Value = "7")]
    NoKnownCopyrightRestrictions = 7,

    /// <summary>
    /// United States Government Work
    /// </summary>
    [EnumMember(Value = "8")]
    UnitedStatesGovernmentWork = 8,

    /// <summary>
    /// Public Domain Dedication, CC0
    /// </summary>
    [EnumMember(Value = "9")]
    PublicDomainDedicationCC0 = 9,

    /// <summary>
    /// Public Domain Mark
    /// </summary>
    [EnumMember(Value = "10")]
    PublicDomainMark = 10
}