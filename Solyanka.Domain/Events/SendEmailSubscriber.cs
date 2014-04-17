using System;

namespace Solyanka.Domain.Events
{
    public class SendEmailSubscriber
    {
        public void Subscribe(string email, string name, string confirmString)
        {
            var netEmail = new NetEmail();
            netEmail.Send(email, name, confirmString);
        }
    }
}