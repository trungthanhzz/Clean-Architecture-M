using System.Text.Json;
using System.Text.Json.Serialization;

namespace MISA.WebFresher.API
{
    /// <summary>
    /// Lớp thêm giá trị múi giờ vào thời gian
    /// </summary>
    /// Created by: dtthanh (28/9/2023)
    public class LocalTimeZoneConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString() ?? DateTime.Now.ToString());
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            if (value.Kind == DateTimeKind.Unspecified)
            {
                writer.WriteStringValue(DateTime.SpecifyKind(value, DateTimeKind.Local));
            }
            else
            {
                writer.WriteStringValue(value);
            }
        }
    }
}
