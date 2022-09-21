using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using TokenCounter.Models;

namespace TokenCounter.Services;

public enum RegisterStatus
{
    Success,
    UserAlreadyExists,
    InvalidUsername,
    InvalidPassword,
    ServerError
}

public class UserService
{
    private readonly HttpClient httpClient;
    private readonly JsonSerializerOptions jsonSerializerOptions;
#if DEBUG
    const string apiUrl = "http://localhost:3000/api/";
#else
    const string apiUrl = "https://token-counter-server.vercel.app/api/";
#endif
    public UserService()
	{
        httpClient = new();
        jsonSerializerOptions = new() {
             PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
             WriteIndented = true
        };
    }

#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable CA1822 // Mark members as static

    /// <summary>
    /// Tries to login using a username and a password
    /// </summary>
    /// <param name="username">The username of the user</param>
    /// <param name="password">The raw password of the user</param>
    /// <returns>An auth token if succesful or <see cref="string.Empty"/> if not.</returns>
    public async Task<string> Login(string username, string password)
	{
        var json = JsonSerializer.Serialize( new { username, password }, jsonSerializerOptions);
        Uri uri = new($"{apiUrl}login");
        try{
            StringContent content = new(json, Encoding.UTF8, "application/json");
            HttpResponseMessage res = await httpClient.PostAsync(uri, content);
            if (res.IsSuccessStatusCode) {
                var responseStream = await res.Content.ReadAsStreamAsync();
                var doc = await JsonDocument.ParseAsync(responseStream);
                
                string token = doc.RootElement.EnumerateObject()
                    .Where(x => x.Name == "authToken")
                    .Select(x => x.Value.GetString())
                    .First();
                return token;
            }
        } catch (Exception) {
            return "";
        }
        return "";
	}

    /// <summary>
    /// Tries to register a user given a username and a password
    /// </summary>
    /// <param name="username">The username for the user</param>
    /// <param name="password">The password for the user</param>
    /// <returns>A tuple with the auth token and if the operation was succesful</returns>
    public async Task<(string authToken, RegisterStatus status)> Register(string username, string password)
	{
        var json = JsonSerializer.Serialize(new { username, password }, jsonSerializerOptions);
        Uri uri = new($"{apiUrl}register");
        try {
            StringContent content = new(json, Encoding.UTF8, "application/json");
            HttpResponseMessage res = await httpClient.PostAsync(uri, content);
            if (res.IsSuccessStatusCode) {
                var responseStream = await res.Content.ReadAsStreamAsync();
                var doc = await JsonDocument.ParseAsync(responseStream);

                string token = doc.RootElement.EnumerateObject()
                    .Where(x => x.Name == "authToken")
                    .Select(x => x.Value.GetString())
                    .First();
                return (token, RegisterStatus.Success);
            }
        } catch (Exception) {
            return ("", RegisterStatus.ServerError);
        }
        return ("", RegisterStatus.UserAlreadyExists); // parse errors
    }

    /// <summary>
    /// Tries to add other user to this user friends list
    /// </summary>
    /// <param name="authtoken">The auth token for the current user</param>
    /// <param name="friendName">The username of the friend</param>
    /// <returns><see langword="true"/> if the request was successful or 
    /// <see langword="false"/> if not.</returns>
    public async Task<bool> AddFriend(string authtoken, string friendName) {
        // TODO make social integration
        await Task.Delay(1000);
        return true;
    }

    /// <summary>
    /// Tries to remove other user from this user friends list
    /// </summary>
    /// <param name="authtoken">The auth token for the current user</param>
    /// <param name="friendName">The username of the friend to be removed</param>
    /// <returns><see langword="true"/> if the request was sucessful or
    /// <see langword="false"/> if not 
    /// (if user was not friends, returns <see langword="false"/> too).</returns>
    public async Task<bool> RemoveFriend(string authtoken, string friendName) {
        // TODO make social integration
        await Task.Delay(1000);
        return true;
    }

    /// <summary>
    /// Tries to get all of the friends of this particular user
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    public async Task<List<User>> GetFriends(string username) {
        // TODO make social integration
        await Task.Delay(1000);
        return new() {
            new() {
                Username = "Rodrigo",
                Tokens = 15
            },
            new() {
                Username = "João",
                Tokens = 30
            }
        };
    }
}
