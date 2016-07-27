using System.Threading;

namespace MailSystem
{
    class Program
    {
        static MailArrived _mailArrived;
        private static int TestMailCount;

        private static void Main()
        {
            _mailArrived = new MailArrived();
            TimerCallback timerDelegate = simulatedMailArrived;
            new Timer(timerDelegate, null, 500, 500);
            _mailArrived.mailArrived += MailManager.OnMailArrived;
            Thread.Sleep(10 * 1000);
        }

        private static void simulatedMailArrived(object sender)
        {
            _mailArrived.GetMail(new Message($"Sending a test mail {TestMailCount+=1}", "This is the test mail body"));
        }
    }
}
