using Microsoft.AspNetCore.Components;

namespace Feediary.Components.Pages
{
    public partial class Calendar : ComponentBase
    {
        // Mock data for demonstration
        public int TodaysFeedingCount { get; set; } = 6;
        public int WeeklyFeedingCount { get; set; } = 42;
        public decimal AverageFeedingsPerDay { get; set; } = 6.0m;

        private DateTime currentMonth = DateTime.Now;
        private DateTime today = DateTime.Now.Date;

        private List<CalendarDay> GetCalendarDays()
        {
            var days = new List<CalendarDay>();
            var firstDayOfMonth = new DateTime(currentMonth.Year, currentMonth.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            
            // Add days from previous month to fill the first week
            var daysFromPrevMonth = (int)firstDayOfMonth.DayOfWeek;
            var prevMonth = firstDayOfMonth.AddMonths(-1);
            var daysInPrevMonth = DateTime.DaysInMonth(prevMonth.Year, prevMonth.Month);
            
            for (int i = daysFromPrevMonth - 1; i >= 0; i--)
            {
                var date = new DateTime(prevMonth.Year, prevMonth.Month, daysInPrevMonth - i);
                days.Add(new CalendarDay 
                { 
                    Date = date, 
                    IsCurrentMonth = false, 
                    FeedingCount = GetMockFeedingCount(date) 
                });
            }
            
            // Add days of current month
            for (int day = 1; day <= lastDayOfMonth.Day; day++)
            {
                var date = new DateTime(currentMonth.Year, currentMonth.Month, day);
                days.Add(new CalendarDay 
                { 
                    Date = date, 
                    IsCurrentMonth = true, 
                    FeedingCount = GetMockFeedingCount(date) 
                });
            }
            
            // Add days from next month to fill the last week
            var totalDays = days.Count;
            var daysNeeded = 42 - totalDays; // 6 weeks * 7 days
            var nextMonth = firstDayOfMonth.AddMonths(1);
            
            for (int day = 1; day <= daysNeeded; day++)
            {
                var date = new DateTime(nextMonth.Year, nextMonth.Month, day);
                days.Add(new CalendarDay 
                { 
                    Date = date, 
                    IsCurrentMonth = false, 
                    FeedingCount = GetMockFeedingCount(date) 
                });
            }
            
            return days;
        }

        private int GetMockFeedingCount(DateTime date)
        {
            // Mock data - generate feeding counts based on date
            if (date > DateTime.Now.Date) return 0; // Future dates
            if (date == DateTime.Now.Date) return TodaysFeedingCount;
            
            var random = new Random(date.GetHashCode());
            return random.Next(3, 8); // Random feedings between 3-7
        }

        private void PreviousMonth()
        {
            currentMonth = currentMonth.AddMonths(-1);
        }

        private void NextMonth()
        {
            currentMonth = currentMonth.AddMonths(1);
        }

        private string GetMonthYearDisplay()
        {
            return currentMonth.ToString("MMMM yyyy");
        }

        private string GetCurrentDateFormatted()
        {
            return DateTime.Now.ToString("dddd, MMMM dd");
        }

        private string GetLastFeedingTime()
        {
            // Mock data - in real app this would come from a database
            var lastFeeding = DateTime.Now.AddHours(-2.5);
            return lastFeeding.ToString("h:mm tt");
        }

        private string GetNextFeedingTime()
        {
            // Mock data - in real app this would be calculated based on feeding patterns
            var nextFeeding = DateTime.Now.AddHours(0.5);
            return nextFeeding.ToString("h:mm tt");
        }
    }

    public class CalendarDay
    {
        public DateTime Date { get; set; }
        public bool IsCurrentMonth { get; set; }
        public int FeedingCount { get; set; }
    }
}