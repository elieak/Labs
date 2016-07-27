using System;

namespace MailSystem
{
    public class Message
    {
        public string Title { get; }
        public string Body { get; }
        public Message(string title, string body)
        {
            Title = title;
            Body = body;
        }
    }

    public class MailArrivedEventArgs : EventArgs
    {
        public Message Msg { get; set; }
    }

    public sealed class MailArrived
    {
        internal event EventHandler<MailArrivedEventArgs> mailArrived;

        public void GetMail(Message EmailMessage)
        {
            OnMailArrived(EmailMessage);
        }

        private void OnMailArrived(Message msg)
        {
            mailArrived?.Invoke(this, new MailArrivedEventArgs { Msg = msg });
        }
    }
}
