using Hangfire.Dashboard;

namespace ResumeBuilderAPI.Filters
{
    public class MyAuthorizationFilter: IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {

            // Allow all authenticated users to see the Dashboard (potentially dangerous).
            return false;
        }
    }
}
