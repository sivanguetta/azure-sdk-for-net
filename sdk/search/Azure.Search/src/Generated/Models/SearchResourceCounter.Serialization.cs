// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Search.Models
{
    public partial class SearchResourceCounter : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Usage != null)
            {
                writer.WritePropertyName("usage");
                writer.WriteNumberValue(Usage.Value);
            }
            if (Quota != null)
            {
                writer.WritePropertyName("quota");
                writer.WriteNumberValue(Quota.Value);
            }
            writer.WriteEndObject();
        }
        internal static SearchResourceCounter DeserializeSearchResourceCounter(JsonElement element)
        {
            SearchResourceCounter result = new SearchResourceCounter();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("usage"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Usage = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("quota"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Quota = property.Value.GetInt64();
                    continue;
                }
            }
            return result;
        }
    }
}
