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
			var message = await MailUtils.SendMail("thongnqgcc200003@fpt.edu.vn", "thongnguyennqt@gmail.com", "Forgot Password!", "Hello", "thongnqgcc200003@fpt.edu.vn", "Tkcuatui1107.");
			return Content(message);
		}
	}
}
