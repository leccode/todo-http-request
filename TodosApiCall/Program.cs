/*
 * Author: Constantine Lekkos
 * Created Date: 28/05/2025
 * Purpose: Demonstration of HTTP calls,
 * saving of response object as .json file.
 * 
 * This program uses a structure:
 *      - Interfaces with its relative implementation class.
 *      - Models that contains the DTOs and the responses.
 *      - Helper class.
*/

using TodosApiCall.Models.DTOs;
using TodosApiCall.Services;

namespace TodosApiCall
{
    /// <summary>
    /// This is the main Program class that contains the <b>Main</b> method.
    /// All the logic that is implemented is called here to showcase the results.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method that contains the services and is the main entry point.
        /// Makes HTTP calls to retrieve todos data asynchronously.
        /// </summary>
        /// <param name="args">Default arguments.</param>
        /// <returns>A <b><see cref="Task"/></b> representing the asynchronous operation.</returns>
        static async Task Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Todos App Api Call(s):\n");
            Console.ResetColor();

            var service = new TodosService();
            var resultAll = await service.GetAllAsync<List<Todo>>();
            var resultById = await service.GetAsync<Todo>(StaticHelper.TodosId);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("oooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo");
            Console.ResetColor();
            Console.WriteLine("\nRESULTS:\n");
            Console.WriteLine("######################################################################");
            Console.WriteLine("\nService Status of Todos:\n");

            if (resultAll.IsSuccess)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Success: {resultAll.IsSuccess}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Status Code: {resultAll.StatusCode}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Data: {((resultAll.Data == null) ? "None" : resultAll.Data)}");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"Error Message: {((resultAll.ErrorMessage == null) ? "None" : resultAll.ErrorMessage)}");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine();

                Console.WriteLine("Todos Result:\n");
                foreach (var todo in resultAll.Data)
                {
                    Console.WriteLine($"User Id: {todo.UserId} | Id: {todo.Id} | Title: {todo.Title} | Completed: {todo.Completed}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"Success: {resultAll.IsSuccess}");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Status Code: {resultAll.StatusCode}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Data: {((resultAll.Data == null) ? "None" : resultAll.Data)}");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Error Message: {((resultAll.ErrorMessage == null) ? "None" : resultAll.ErrorMessage)}");
                Console.ResetColor();
            }

            Console.WriteLine();
            Console.WriteLine("######################################################################");
            Console.WriteLine("\nService Status of Single Todo:\n");

            if (resultById.IsSuccess)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Success: {resultById.IsSuccess}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Status Code: {resultById.StatusCode}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Data: {((resultById.Data == null) ? "None" : resultById.Data)}");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"Error Message: {((resultById.ErrorMessage == null) ? "None" : resultById.ErrorMessage)}");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine();

                Console.WriteLine("Todo Result:\n");

                Console.WriteLine($"User Id: {resultById.Data.UserId} | Id: {resultById.Data.Id} | Title: {resultById.Data.Title} | Completed: {resultById.Data.Completed}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"Success: {resultById.IsSuccess}");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Status Code: {resultById.StatusCode}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Data: {((resultById.Data == null) ? "None" : resultById.Data)}");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Error Message: {((resultById.ErrorMessage == null) ? "None" : resultById.ErrorMessage)}");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\noooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo");
            Console.ResetColor();
            Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
