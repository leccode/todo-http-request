using System.Text.Json.Serialization;

namespace TodosApiCall.Models.DTOs
{
    /// <summary>
    /// A class that represents the Data Transfer Object
    /// of the information that the API provides.
    /// </summary>
    public class Todo
    {
        /// <summary>
        /// Todo's user id of type <b>int</b>.
        /// </summary>
        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        /// <summary>
        /// Todo's id of type <b>int</b>.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Todo's title of type <b>string</b>.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Todo's statement of completion of type <b>bool</b>.
        /// </summary>
        [JsonPropertyName("completed")]
        public bool Completed { get; set; }
    }
}
