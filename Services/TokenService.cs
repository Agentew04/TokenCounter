using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenCounter.Services;

public class TokenService
{
    HttpClient httpClient;

	public TokenService()
	{
		httpClient = new();
	}

	/// <summary>
	/// Updates the server side amount of tokens for the user associated with an authToken
	/// </summary>
	/// <param name="authToken">The user's auth token</param>
	/// <param name="amount">The new amount of tokens to be saved</param>
	public async Task UpdateTokens(string authToken, int amount)
	{
        // TODO integrate with server side db
        await Task.Delay(100);
		return;
	}

	/// <summary>
	/// Gets the server side amount of tokens a user has
	/// </summary>
	/// <param name="authToken">The auth token of the current user</param>
	/// <param name="username">The username of the person to be looked up for, 
	/// can be the same bearer of the token</param>
	/// <returns>The amount of tokens stored server side</returns>
	public async Task<int> GetTokens(string authToken, string username) {
		// TODO integrate with server side db
		await Task.Delay(100);
		var tokens = new Random().Next(100);
		return tokens;
	}
}
