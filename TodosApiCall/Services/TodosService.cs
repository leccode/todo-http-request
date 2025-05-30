using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text.Json;
using TodosApiCall.Models;
using TodosApiCall.Services.IServices;

namespace TodosApiCall.Services
{
    public class TodosService : ITodosService
    {
        /// <summary>
        /// Declaration of an instance of type <b><see cref="HttpClient"/></b>.
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Constructor that contains the configuration of
        /// the instance of type <b><see cref="HttpClient"/></b>.
        /// </summary>
        public TodosService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(StaticHelper.BaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Generic asynchronous operation to get
        /// the response by an API end point.
        /// </summary>
        /// <typeparam name="T">Generic class for objects</typeparam>
        /// <returns>An object of type <b><see cref="ApiResponse{T}"/></b>.</returns>
        public async Task<ApiResponse<T>> GetAllAsync<T>() where T : class
        {
            ApiResponse<T> apiResponse = new ApiResponse<T>();

            try
            {
                var response = await _httpClient.GetAsync(StaticHelper.TodosEndPoint);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    T data;
                    if (content != null)
                    {
                        data = JsonSerializer.Deserialize<T>(content);
                    }
                    else
                    {
                        data = null;
                    }

                    apiResponse.IsSuccess = response.IsSuccessStatusCode;
                    apiResponse.StatusCode = response.StatusCode;
                    apiResponse.Data = data;
                    apiResponse.ErrorMessage = null;

                    AdditionalInfo(response, LogMethodName());
                    await SaveAsJsonAsync<T>(apiResponse, StaticHelper.JsonFileNameAll);

                    return apiResponse;
                }
                else
                {
                    apiResponse.IsSuccess = response.IsSuccessStatusCode;
                    apiResponse.StatusCode = response.StatusCode;
                    apiResponse.Data = null;
                    apiResponse.ErrorMessage = "Your request is not valid! Please, try again.";

                    AdditionalInfo(response, LogMethodName());
                    await SaveAsJsonAsync<T>(apiResponse, StaticHelper.JsonFileNameAll);

                    return apiResponse;
                }
            }
            catch (HttpRequestException ex)
            {
                return new ApiResponse<T>
                {
                    IsSuccess = false,
                    StatusCode = (System.Net.HttpStatusCode)ex.StatusCode,
                    Data = null,
                    ErrorMessage = ex.Message
                };
            }
        }

        /// <summary>
        /// Generic asynchronous operation using an <b>Id</b> to get
        /// the response by an API end point.
        /// </summary>
        /// <typeparam name="T">Generic class for objects</typeparam>
        /// <param name="id">The pathway parameter which is the actual <b>Id</b> to look for.</param>
        /// <returns>An object of type <b><see cref="ApiResponse{T}"/></b>.</returns>
        public async Task<ApiResponse<T>> GetAsync<T>(int id) where T : class
        {
            ApiResponse<T> apiResponse = new ApiResponse<T>();

            try
            {
                var response = await _httpClient.GetAsync(String.Concat(StaticHelper.TodosEndPoint, $"/{id}"));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    T data;
                    if (content != null)
                    {
                        data = JsonSerializer.Deserialize<T>(content);
                    }
                    else
                    {
                        data = null;
                    }

                    apiResponse.IsSuccess = response.IsSuccessStatusCode;
                    apiResponse.StatusCode = response.StatusCode;
                    apiResponse.Data = data;
                    apiResponse.ErrorMessage = null;

                    AdditionalInfo(response, LogMethodName());
                    await SaveAsJsonAsync<T>(apiResponse, StaticHelper.JsonFileNameById);

                    return apiResponse;
                }
                else
                {
                    apiResponse.IsSuccess = response.IsSuccessStatusCode;
                    apiResponse.StatusCode = response.StatusCode;
                    apiResponse.Data = null;
                    apiResponse.ErrorMessage = "Your request is not valid! Please, try again.";

                    AdditionalInfo(response, LogMethodName());
                    await SaveAsJsonAsync<T>(apiResponse, StaticHelper.JsonFileNameById);

                    return apiResponse;
                }
            }
            catch (HttpRequestException ex)
            {
                return new ApiResponse<T>
                {
                    IsSuccess = false,
                    StatusCode = (System.Net.HttpStatusCode)ex.StatusCode,
                    Data = null,
                    ErrorMessage = ex.Message
                };
            }
        }

        #region H E L P E R S

        /// <summary>
        /// This helper method captures the name of the current method.
        /// </summary>
        /// <param name="methodName">The current method name</param>
        /// <returns>The method name as <b>string</b>.</returns>
        private static string LogMethodName([CallerMemberName] string methodName = null) => methodName;

        /// <summary>
        /// This helper method displays additional information of the response.
        /// </summary>
        /// <param name="response">A response object of type <b><see cref="HttpResponseMessage"/></b> that contains the information from the API.</param>
        private static void AdditionalInfo(HttpResponseMessage response, string methodName)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{methodName} Method");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine($"Datetime: {response.Headers.Date}");
            Console.WriteLine($"Original URL: {response.RequestMessage.RequestUri.OriginalString}");
            Console.WriteLine($"Method: {response.RequestMessage.Method}");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// This helper method saves the response as <b>.json</b> file.
        /// </summary>
        /// <typeparam name="T">Generic class for objects</typeparam>
        /// <param name="response"></param>
        /// <returns>A <b><see cref="Task"/></b> representing the asynchronous operation.</returns>
        private static async Task SaveAsJsonAsync<T>(ApiResponse<T> response, string fileName) where T : class
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string filePath = StaticHelper.JsonFilePath;

                var directory = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                string json = JsonSerializer.Serialize(response, options);
                await File.WriteAllTextAsync(String.Concat(filePath, fileName), json);

                Console.WriteLine("Trying to save the response as .json file . . .");
                Console.WriteLine("See the relative file for further info.\n");

                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("JSON saved successfully!\n");
                    Console.ResetColor();
                }
                catch (IOException) { }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Failed to save JSON: {ex.Message}\n");
            }
        }

        #endregion
    }
}
