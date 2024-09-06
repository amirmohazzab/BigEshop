using Kavenegar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Interfaces
{
    public interface ISmsSenderService
    {
        public SendResult SendSms(string mobile, string message);
    }
}
