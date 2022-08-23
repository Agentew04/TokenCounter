using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenCounter.ViewModels;

public class LoginViewModel : BaseViewModel
{
	// used to check network for login
	IConnectivity _connectivity;
	public LoginViewModel(IConnectivity connectivity)
	{
		_connectivity = connectivity;
	}
}
