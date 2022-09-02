using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenCounter.Models;

namespace TokenCounter.Services;

public enum RegisterStatus
{
    Success,
    UserAlreadyExists,
    InvalidUsername,
    InvalidPassword
}

public class UserService
{

    HttpClient httpClient;
	public UserService()
	{
		httpClient = new();
	}

    /// <summary>
    /// Tries to login using a username and a password
    /// </summary>
    /// <param name="username">The username of the user</param>
    /// <param name="password">The raw password of the user</param>
    /// <returns>An auth token if succesful or <see cref="string.Empty"/> if not.</returns>
    public async Task<string> Login(string username, string password)
	{
        // TODO make authentication and client side integration
        await Task.Delay(1000);
		return "dummyAuthToken";
	}

    /// <summary>
    /// Tries to register a user given a username and a password
    /// </summary>
    /// <param name="username">The username for the user</param>
    /// <param name="password">The password for the user</param>
    /// <returns>A tuple with the auth token and if the operation was succesful</returns>
    public async Task<(string authToken, RegisterStatus status)> Register(string username, string password)
	{
        // TODO make authentication and client side integration
        await Task.Delay(1000);
        return new ("testToken", RegisterStatus.Success);
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
                Username = "John Doe",
                Tokens = 15
            },
            new() {
                Username = "Jane Doe",
                Tokens = 300
            }
        };
    }
}
