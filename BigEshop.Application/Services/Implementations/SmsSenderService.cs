using BigEshop.Application.Services.Interfaces;
using BigEshop.Application.Statics;
using Kavenegar;
using Kavenegar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Implementations
{
    public class SmsSenderService : ISmsSenderService
    {
        private readonly KavenegarApi kavenegarApi;

        public SmsSenderService()
        {
            string apiKey = KavenegarStatics.ApiKey;
            kavenegarApi = new KavenegarApi(apiKey);
        }


        public SendResult SendSms(string mobile, string message)
        {
            string sender = KavenegarStatics.Sender;
            return kavenegarApi.Send(sender, mobile, message); 
        }
    }
}
