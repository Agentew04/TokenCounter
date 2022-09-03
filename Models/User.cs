using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenCounter.Models; 
public class User {

    /// <summary>
    /// The user visible username
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// The current user auth token, or if it's an outside user, is <see cref="string.Empty"></see>
    /// </summary>
    public string AuthToken { get; set; } = "";

    /// <summary>
    /// The amount of tokens this user has
    /// </summary>
    public int Tokens { get; set; }

    /// <summary>
    /// A list with all the friends this user is has
    /// </summary>
    public List<string> Friends { get; set; }
}
