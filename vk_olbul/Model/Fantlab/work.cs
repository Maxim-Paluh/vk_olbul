using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vk_olbul.Model
{
    public class work
    {
        [JsonProperty("authors")]
        public Author[] Authors { get; set; }

        [JsonProperty("classificatory")]
        public Classificatory Classificatory { get; set; }

        [JsonProperty("work_name")]
        public string WorkName { get; set; }

        [JsonProperty("work_description")]
        public string WorkDescription { get; set; }
    }

    public partial class Author
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("is_opened")]
        public long IsOpened { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_orig")]
        public string NameOrig { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class Classificatory
    {
        [JsonProperty("genre_group")]
        public GenreGroup[] GenreGroup { get; set; }

        [JsonProperty("total_count")]
        public long TotalCount { get; set; }
    }

    public partial class GenreGroup
    {
        [JsonProperty("genre")]
        public Genre[] Genre { get; set; }

        [JsonProperty("genre_group_id")]
        public long GenreGroupId { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }

    public partial class Genre
    {
        [JsonProperty("genre_id")]
        public long GenreId { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("percent")]
        public double Percent { get; set; }

        [JsonProperty("votes")]
        public long Votes { get; set; }

        [JsonProperty("genre", NullValueHandling = NullValueHandling.Ignore)]
        public Genre[] GenreGenre { get; set; }
    }
}
