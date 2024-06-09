using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.MvcWebUI.Services
{
    public interface IMailService
    {
        void Send(EmailMessage emailMessage);
    }
}
