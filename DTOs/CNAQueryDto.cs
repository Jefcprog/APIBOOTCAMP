namespace Entity.DTOs
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Result
    {
        public List<string> categories { get; set; }
        public string created_at { get; set; }
        public string icon_url { get; set; }
        public string id { get; set; }
        public string updated_at { get; set; }
        public string url { get; set; }
        public string value { get; set; }
    }

    public class CNAQueryDto
    {
        public int total { get; set; }
        public List<Result> result { get; set; }
    }


}
