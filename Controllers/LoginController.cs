using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class LoginController : Controller
{
    private readonly AuthenticationService _authService;

    public LoginController(AuthenticationService authService)
    {
        _authService = authService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(string Mail, string Password)
    {
        var loginResult = await _authService.LoginAsync(Mail, Password);
        if (loginResult != null)
        {
            Response.Cookies.Append("authToken", loginResult.Token, new CookieOptions
            {
                HttpOnly = false,
                Secure = true, 
                SameSite = SameSiteMode.None,
                Expires = DateTimeOffset.UtcNow.AddHours(1) 
            });

           
            if (!string.IsNullOrEmpty(loginResult.Name))
            {
                
                Response.Cookies.Append("user_name", loginResult.Name, new CookieOptions
                {
                    HttpOnly = false, 
                    Secure = false,
                    SameSite = SameSiteMode.Lax
                });
            }

            return RedirectToAction("Index", "Dashboard");
        }

        ViewBag.Error = "Invalid login attempt.";
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> LogoutAsync()
    {
        
        Response.Cookies.Delete("authToken");
        Response.Cookies.Delete("user_name");
        foreach (var cookie in Request.Cookies.Keys)
        {
          Response.Cookies.Delete(cookie);
        }

     

        return RedirectToAction("Index", "Login");
    }

}

