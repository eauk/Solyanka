using System;

namespace Solyanka.Domain.Events
{
    public class SendEmailEventArgs : EventArgs
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string ConfirmString { get; set; }

        public SendEmailEventArgs(string email, string name, string confirmString)
        {
            Email = email;
            Name = name;
            ConfirmString = confirmString;
        }
    }
}