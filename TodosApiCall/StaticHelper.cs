namespace TodosApiCall
{
    /// <summary>
    /// A static helper that contains constants strings
    /// that represent the base URLs and the end points.
    /// </summary>
    public class StaticHelper
    {
        /// <summary>
        /// Base URL pathway.
        /// </summary>
        public static string BaseUrl = "https://jsonplaceholder.typicode.com";

        /// <summary>
        /// End point pathway for todos list.
        /// </summary>
        public static string TodosEndPoint = "/todos";

        /// <summary>
        /// Todo's id to be used in the pathway.
        /// </summary>
        public static int TodosId = 50;

        /// <summary>
        /// File pathway for .json
        /// </summary>
        public static string JsonFilePath = @"C:\tmp\";

        /// <summary>
        /// File name for .json
        /// </summary>
        public static string JsonFileNameAll = "response-all.json";

        /// <summary>
        /// File name for .json
        /// </summary>
        public static string JsonFileNameById = "response-by-id.json";
    }
}
