using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		// TODO make server side auth and client side integration
		await Task.Delay(1000);
		return "token";
	}

    /// <summary>
    /// Tries to register a user given a username and a password
    /// </summary>
    /// <param name="username">The username for the user</param>
    /// <param name="password">The password for the user</param>
    /// <returns>A tuple with the auth token and if the operation was succesful</returns>
    public async Task<(string authToken, RegisterStatus status)> Register(string username, string password)
	{
        // TODO make server side auth and client side integration
        await Task.Delay(1000);
        return new ("testToken", RegisterStatus.Success);
    }
}
