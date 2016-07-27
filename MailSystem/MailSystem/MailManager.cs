using System;

namespace MailSystem
{
    public class MailManager
    {
        public static void OnMailArrived(object sender, MailArrivedEventArgs MailArrivedArgs)
        {
            Console.WriteLine($"Title: {MailArrivedArgs.Msg.Title}, Body: {MailArrivedArgs.Msg.Body}");
        }
    }
}