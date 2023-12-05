using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Booking_Gruppe.Pages.Kalendere
{
    public class IndexModel : PageModel
    {
            public void OnGet(int? month)
            {
                var today = DateTime.Today;
                CurrentMonth = new DateTime(today.Year, month ?? today.Month, 1);

                var firstDayOfMonth = CurrentMonth;
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                var weeks = new List<DateTime[]>();
                var currentWeek = new List<DateTime>();


                for (var day = firstDayOfMonth; day <= lastDayOfMonth; day = day.AddDays(1))
                {
                    currentWeek.Add(day);

                    if (day.DayOfWeek == DayOfWeek.Saturday)
                    {
                        weeks.Add(currentWeek.ToArray());
                        currentWeek.Clear();
                    }
                }

                if (currentWeek.Count > 0)
                {
                    weeks.Add(currentWeek.ToArray());
                }

                Weeks = weeks;
            }

            public List<DateTime[]> Weeks { get; set; }

            [BindProperty(SupportsGet = true)]
            public DateTime CurrentMonth { get; set; }

            [BindProperty]
            public List<DateTime> TakenDates { get; set; } = new List<DateTime>();

            public IActionResult OnPostBookDate(DateTime date)
            {
                // Add the booked date to the list of taken dates
                TakenDates.Add(date);

                // Redirect back to the same page
                return RedirectToPage(new { month = CurrentMonth.Month });
            }
        }
    }