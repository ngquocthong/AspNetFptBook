using System.Net;
using System.Net.Mail;

namespace WebClient.Areas.SendMail.Models
{
	public class MailUtils
	{
	
			public static async Task<string> SendMail(string _from, string _to, string _subject, string _body, string _gmail, string _password)
			{
				// Tạo nội dung Email
				MailMessage message = new MailMessage(
					from: _from,
					to: _to,
					subject: _subject,
					body: _body
				);
				message.BodyEncoding = System.Text.Encoding.UTF8;
				message.SubjectEncoding = System.Text.Encoding.UTF8;
				message.IsBodyHtml = true;
				message.ReplyToList.Add(new MailAddress(_from));
				message.Sender = new MailAddress(_from);
				using var smtpClient = new SmtpClient("smtp.gmail.com");
				smtpClient.Port = 587;
				smtpClient.EnableSsl = true;
				smtpClient.Credentials = new NetworkCredential(_gmail, _password);

				try
				{
					await smtpClient.SendMailAsync(message);
					return "Sent Successfully";
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					return "Sent Fail";
				}
			}
	}


}
