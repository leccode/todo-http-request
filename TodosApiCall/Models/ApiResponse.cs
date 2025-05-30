using System.Net;

namespace TodosApiCall.Models
{
    /// <summary>
    /// A class that represents the API response model
    /// that populates the needed information every time
    /// a call occurs.
    /// </summary>
    /// <typeparam name="T">This is a generic form of the class for different usage of objects.</typeparam>
    public class ApiResponse<T> where T : class
    {
        /// <summary>
        /// API's successful condition of type <b>bool</b>.
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// API's status code of type <b><see cref="HttpStatusCode"/></b>.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// API's data object of type <b><typeparamref name="T"/></b> generic form.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// API's error message of type <b>string</b>.
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
