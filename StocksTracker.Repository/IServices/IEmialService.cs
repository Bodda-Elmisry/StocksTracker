using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksTracker.Repository.IServices
{
    public interface IEmialService
    {
        void SetSenderInfo(string SenderEmail, string SenderPassword);
        string SendMail(string RecipientEmail, string Body, bool IsBodyHtml);
        string CreateBodyFromListToHTMl<T>(IEnumerable<T> list);
    }
}
