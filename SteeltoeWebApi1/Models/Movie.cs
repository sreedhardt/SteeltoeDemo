using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Movie
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "ReleaseDate")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [JsonProperty(PropertyName = "Genre")]
        public string Genre { get; set; }

        [JsonProperty(PropertyName = "Price")]
        public decimal Price { get; set; }
    }
}