using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace CalendarManagmentDataService
{
    public class EmailService
    {
     
        private const string SmtpHost = "sandbox.smtp.mailtrap.io";
        private const int SmtpPort = 2525;
        private const string SmtpUsername = "27f1e6b2a3305f";
        private const string SmtpPassword = "420aa348a70c4d";

        private const string FromName = "Calendar Management System";
        private const string FromEmail = "calendar@test.com";


        private const string NotificationRecipient = "notify@test.com";

        public void SendEmail(string itemName, string itemType, string date, string day, string time)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(FromName, FromEmail));
            message.To.Add(new MailboxAddress("Recipient", NotificationRecipient));

            message.Subject = $"Calendar {itemType} Created: {itemName}";

            message.Body = new TextPart("plain")
            {
                Text = $"A new {itemType.ToLower()} was created:\n\n" +
                       $"Name: {itemName}\n" +
                       $"Date: {date}\n" +
                       $"Day: {day}\n" +
                       $"Time: {time}\n\n" +
                       "This is an automated notification from the Calendar Management System."
            };

            using (var client = new SmtpClient())
            {
                client.Connect(SmtpHost, SmtpPort, SecureSocketOptions.StartTls);
                client.Authenticate(SmtpUsername, SmtpPassword);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}