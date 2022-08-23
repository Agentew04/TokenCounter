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
		await Task.Delay(100);
		return;
	}
}
