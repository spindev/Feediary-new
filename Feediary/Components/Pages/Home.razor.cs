using Microsoft.AspNetCore.Components;

namespace Feediary.Components.Pages
{
    public partial class Home : ComponentBase
    {
        private string GetGreeting()
        {
            var hour = DateTime.Now.Hour;
            return hour switch
            {
                >= 5 and < 12 => "Good Morning",
                >= 12 and < 17 => "Good Afternoon",
                >= 17 and < 22 => "Good Evening",
                _ => "Good Night"
            };
        }
    }
}