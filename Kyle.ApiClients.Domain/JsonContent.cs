using System.Text;
using Kyle.Extensions;

namespace Kyle.ApiClients.Domain;

public class JsonContent : StringContent
{
    public JsonContent(object data) : this(data, Encoding.UTF8, "application/json")
    {
    }

    public JsonContent(object data, Encoding encoding, string mediaType) : base(data.ToJsonString(), encoding,
        mediaType)
    {
    }

    public JsonContent(string data, Encoding encoding) : base(data, encoding, "application/json")
    {
    }
}