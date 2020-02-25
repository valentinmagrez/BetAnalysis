using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace UnibetService.Utils.Converters
{
    public class MicrosecondEpochConverter : DateTimeConverterBase
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var datetimeOffset = new DateTimeOffset((DateTime) value);
            writer.WriteRawValue(datetimeOffset.ToUnixTimeMilliseconds().ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) { return null; }

            var offsetDatetime = DateTimeOffset.FromUnixTimeMilliseconds((long)reader.Value);
            return offsetDatetime.DateTime;
        }
    }

}
