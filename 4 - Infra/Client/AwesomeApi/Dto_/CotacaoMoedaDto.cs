using Newtonsoft.Json;

namespace DesafioBackend.Client.AwesomeApi
{
    public partial class Cotacao
    {
        [JsonProperty("USDBRL")]
        public Usdbrl Usdbrl { get; set; }
    }

    public partial class Usdbrl
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("codein")]
        public string Codein { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("high")]
        public string High { get; set; }

        [JsonProperty("low")]
        public string Low { get; set; }

        [JsonProperty("varBid")]
        public string VarBid { get; set; }

        [JsonProperty("pctChange")]
        public string PctChange { get; set; }

        [JsonProperty("bid")]
        public string Bid { get; set; }

        [JsonProperty("ask")]
        public string Ask { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("create_date")]
        public DateTimeOffset CreateDate { get; set; }
    }
}
