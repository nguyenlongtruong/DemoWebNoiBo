using Microsoft.AspNetCore.Mvc;
using WebsiteNoiBoCongTy.Data;

namespace WebsiteNoiBoCongTy.Models
{
    public class Birthdaybar:ViewComponent
    {
        private readonly WebsiteNoiBoCongTyContext _context;

        public Birthdaybar(WebsiteNoiBoCongTyContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            DateTime dateTime = DateTime.Now;
            Account? account = _context.Account.FirstOrDefault(acc => acc.Birthday.Day.Equals(dateTime.Day) && acc.Birthday.Month.Equals(dateTime.Month));
            return View(account);
        }
    }
}
