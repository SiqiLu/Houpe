// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : JsonOptions.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-12
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Houpe.Foundation;

/// <summary>
///     JsonOptions
/// </summary>
public static class JsonOptions
{
    /// <summary>
    ///     DataJsonSerializerOptions
    /// </summary>
    public static readonly JsonSerializerOptions DataJsonOptions = new JsonSerializerOptions
    {
        // Indicates whether an extra comma at the end of a list of JSON values in an object or array is allowed (and ignored) within the JSON payload being deserialized.
        AllowTrailingCommas = true,

        // Determines when properties with default values are ignored during serialization or deserialization. The default value is Never.
        DefaultIgnoreCondition = JsonIgnoreCondition.Never,

        // The policy used to convert a IDictionary key's name to another format, such as camel-casing.
        DictionaryKeyPolicy = null,

        // The encoder to use when escaping strings, or null to use the default encoder.
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,

        // Indicates whether read-only fields are ignored during serialization. A field is read-only if it is marked with the readonly keyword. The default value is false.
        IgnoreReadOnlyFields = false,

        // Indicates whether read-only properties are ignored during serialization. The default value is false.
        IgnoreReadOnlyProperties = false,

        // Indicates whether fields are handled during serialization and deserialization. The default value is false.
        IncludeFields = false,

        // The maximum depth allowed when serializing or deserializing JSON, with the default value of 0 indicating a maximum depth of 64.
        MaxDepth = 0,

        // Specifies how number types should be handled when serializing or deserializing.
        NumberHandling = JsonNumberHandling.Strict,

        // Indicates whether a property's name uses a case-insensitive comparison during deserialization. The default value is false.
        PropertyNameCaseInsensitive = false,

        // Specifies the policy used to convert a property's name on an object to another format, such as camel-casing, or null to leave property names unchanged.
        PropertyNamingPolicy = null,

        // Defines how comments are handled during deserialization.
        ReadCommentHandling = JsonCommentHandling.Skip,

        // Specifies how object references are handled when reading and writing JSON.
        ReferenceHandler = ReferenceHandler.IgnoreCycles,

        // Specifies how deserializing a type declared as an Object is handled during deserialization.
        UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement,

        // Indicates whether JSON should use pretty printing. By default, JSON is serialized without any extra white space.
        WriteIndented = false
    };

    /// <summary>
    ///     LogJsonSerializerOptions
    /// </summary>
    public static readonly JsonSerializerOptions LogJsonOptions = new JsonSerializerOptions
    {
        // Indicates whether an extra comma at the end of a list of JSON values in an object or array is allowed (and ignored) within the JSON payload being deserialized.
        AllowTrailingCommas = true,

        // Determines when properties with default values are ignored during serialization or deserialization. The default value is Never.
        DefaultIgnoreCondition = JsonIgnoreCondition.Never,

        // The policy used to convert a IDictionary key's name to another format, such as camel-casing.
        DictionaryKeyPolicy = null,

        // The encoder to use when escaping strings, or null to use the default encoder.
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,

        // Indicates whether read-only fields are ignored during serialization. A field is read-only if it is marked with the readonly keyword. The default value is false.
        IgnoreReadOnlyFields = false,

        // Indicates whether read-only properties are ignored during serialization. The default value is false.
        IgnoreReadOnlyProperties = false,

        // Indicates whether fields are handled during serialization and deserialization. The default value is false.
        IncludeFields = false,

        // The maximum depth allowed when serializing or deserializing JSON, with the default value of 0 indicating a maximum depth of 64.
        MaxDepth = 0,

        // Specifies how number types should be handled when serializing or deserializing.
        NumberHandling = JsonNumberHandling.Strict,

        // Indicates whether a property's name uses a case-insensitive comparison during deserialization. The default value is false.
        PropertyNameCaseInsensitive = false,

        // Specifies the policy used to convert a property's name on an object to another format, such as camel-casing, or null to leave property names unchanged.
        PropertyNamingPolicy = null,

        // Defines how comments are handled during deserialization.
        ReadCommentHandling = JsonCommentHandling.Skip,

        // Specifies how object references are handled when reading and writing JSON.
        ReferenceHandler = ReferenceHandler.IgnoreCycles,

        // Specifies how deserializing a type declared as an Object is handled during deserialization.
        UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement,

        // Indicates whether JSON should use pretty printing. By default, JSON is serialized without any extra white space.
        WriteIndented = false
    };

    /// <summary>
    ///     WebApiJsonSerializerOptions
    /// </summary>
    public static readonly JsonSerializerOptions WebApiJsonOptions = new JsonSerializerOptions
    {
        // Indicates whether an extra comma at the end of a list of JSON values in an object or array is allowed (and ignored) within the JSON payload being deserialized.
        AllowTrailingCommas = true,

        // Determines when properties with default values are ignored during serialization or deserialization. The default value is Never.
        DefaultIgnoreCondition = JsonIgnoreCondition.Never,

        // The policy used to convert a IDictionary key's name to another format, such as camel-casing.
        DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,

        // The encoder to use when escaping strings, or null to use the default encoder.
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,

        // Indicates whether read-only fields are ignored during serialization. A field is read-only if it is marked with the readonly keyword. The default value is false.
        IgnoreReadOnlyFields = false,

        // Indicates whether read-only properties are ignored during serialization. The default value is false.
        IgnoreReadOnlyProperties = false,

        // Indicates whether fields are handled during serialization and deserialization. The default value is false.
        IncludeFields = false,

        // The maximum depth allowed when serializing or deserializing JSON, with the default value of 0 indicating a maximum depth of 64.
        MaxDepth = 10,

        // Specifies how number types should be handled when serializing or deserializing.
        NumberHandling = JsonNumberHandling.AllowReadingFromString,

        // Indicates whether a property's name uses a case-insensitive comparison during deserialization. The default value is false.
        PropertyNameCaseInsensitive = true,

        // Specifies the policy used to convert a property's name on an object to another format, such as camel-casing, or null to leave property names unchanged.
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,

        // Defines how comments are handled during deserialization.
        ReadCommentHandling = JsonCommentHandling.Skip,

        // Specifies how object references are handled when reading and writing JSON.
        ReferenceHandler = ReferenceHandler.IgnoreCycles,

        // Specifies how deserializing a type declared as an Object is handled during deserialization.
        UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement,

        // Indicates whether JSON should use pretty printing. By default, JSON is serialized without any extra white space.
        WriteIndented = false
    };
}
