using Microsoft.AspNetCore.Mvc;
using WebClient.Areas.SendMail.Models;

namespace WebClient.Areas.SendMail.Controllers
{
	[Area("SendMail")]
	public class MailController : Controller
	{
		public IActionResult Index()
		{

			return Content("Hihi");
		}
		public async Task<IActionResult> SendMail()
		{
			var message = await MailUtils.SendMail("thongnqgcc200003@abc.edu.vn", "thongnguyen@gmail.com", "Forgot Password!", "Hello", "thongnqgcc@abc.edu.vn", "Tkcu107.");
			return Content(message);
		}
	}
}
