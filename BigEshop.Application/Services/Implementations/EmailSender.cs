using BigEshop.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Implementations
{
	public class EmailSender : IEmailSender
	{
		public Task<bool> Send(string to, string subject, string body)
		{
			throw new NotImplementedException();
		}
	}
}
