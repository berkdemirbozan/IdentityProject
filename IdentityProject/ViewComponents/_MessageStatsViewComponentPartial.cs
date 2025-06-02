using IdentityProject.Context;
using IdentityProject.Entities;
using IdentityProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityProject.ViewComponents
{
    public class _MessageStatsViewComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly MailContext _context;

        public _MessageStatsViewComponentPartial(MailContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var inboxCount = _context.Messages.Count(x => x.ReceiverEmail == values.Email && x.IsRead == false);
            var sendboxCount = _context.Messages.Count(x => x.SenderEmail == values.Email);
            var model = new MessageStatsViewModel
            {
                InboxCount = inboxCount,
                SendboxCount = sendboxCount
            };
            return View(model);
        }
    }

}
