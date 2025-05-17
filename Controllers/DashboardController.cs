using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class DashboardController : Controller
{
    private readonly DashboardService _dashboardService;

    public DashboardController(DashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    public async Task<IActionResult> Index()
    {
        var model = new DashboardViewModel
        {
            TotalActiveCompanies = await _dashboardService.GetActiveCompaniesCountAsync(),
            TotalActiveOffices = await _dashboardService.GetActiveOfficesCountAsync()
        };
        return View(model);
    }
}
