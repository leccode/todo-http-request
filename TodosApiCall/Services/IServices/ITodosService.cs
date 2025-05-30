using TodosApiCall.Models;

namespace TodosApiCall.Services.IServices
{
    /// <summary>
    /// Interface class that contains the signatures of every used HTTP method.
    /// Their implementation takes place in the relative class.
    /// </summary>
    public interface ITodosService
    {
        /// <summary>
        /// Generic signature of HTTP method to obtain all the Todos
        /// information by the API original string URL.
        /// </summary>
        /// <typeparam name="T">This is a generic form of the class for different usage of objects.</typeparam>
        /// <returns>An object of type <b><see cref="ApiResponse{T}"/></b>.</returns>
        Task<ApiResponse<T>> GetAllAsync<T>() where T : class;

        /// <summary>
        /// Generic signature of HTTP method to obtain by <b>Id</b> the Todo
        /// information by the API original string URL.
        /// </summary>
        /// <typeparam name="T">This is a generic form of the class for different usage of objects.</typeparam>
        /// <param name="id">The pathway parameter which is the actual <b>Id</b> to look for.</param>
        /// <returns>An object of type <b><see cref="ApiResponse{T}"/></b>.</returns>
        Task<ApiResponse<T>> GetAsync<T>(int id) where T : class;
    }
}
