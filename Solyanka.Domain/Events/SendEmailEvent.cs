using System;

namespace Solyanka.Domain.Events
{
    public class SendEmailEvent
    {
        public event EventHandler Send;

        public virtual void OnSend(SendEmailEventArgs args)
        {
            //EventHandler<SendEmailEventArgs> handler = Send;

            //var netEmail = new NetEmail();
            //netEmail.Send(args.Email, args.Name, args.ConfirmString);

            //if (handler != null) handler(this, args);
        }

        public virtual void OnSend()
        {
            EventHandler handler = Send;

            //var netEmail = new NetEmail();
            //netEmail.Send(args.Email, args.Name, args.ConfirmString);

            if (handler != null) handler(this, null);
        }
    }
}