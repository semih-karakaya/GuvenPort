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
                Secure = true, // HTTPS üzerinde çalışmalıdır
                SameSite = SameSiteMode.None,
                Expires = DateTimeOffset.UtcNow.AddHours(1) // Token'ın süresi
            });

            // Kullanıcı adını cookie'ye ekle
            if (!string.IsNullOrEmpty(loginResult.Name))
            {
                // user_name cookie'sini HttpOnly = false olarak ayarla
                Response.Cookies.Append("user_name", loginResult.Name, new CookieOptions
                {
                    HttpOnly = false, // HttpOnly true ise client-side erişilemez, false yapıldı
                    Secure = false,
                    SameSite = SameSiteMode.Lax
                });
            }

            return RedirectToAction("Index", "Dashboard");
        }

        ViewBag.Error = "Invalid login attempt.";
        return View();
    }

}

