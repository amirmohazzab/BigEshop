using BigEshop.Data.Context;
using BigEshop.Domain.Enums.Ticket;
using Microsoft.EntityFrameworkCore;
using Quartz;

namespace BigEshop.Web.Jobs
{
    public class CloseTicketsJob (BigEshopContext dbContext) : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var tickets = await dbContext.Tickets
                .Where(t => t.CreateDate <= DateTime.Now.AddDays(-30) && t.Status != TicketStatus.Closed)
                .ToListAsync();

            foreach(var ticket in tickets)
            {
                ticket.Status = TicketStatus.Closed;

                dbContext.Tickets.Update(ticket);
            }
            await dbContext.SaveChangesAsync();

        }
    }
}
