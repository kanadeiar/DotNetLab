using KndStore.ShopAccount.Core.WebModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KndStore.ShopAccount.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userMgr;
    private readonly SignInManager<IdentityUser> _signInMgr;
    public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr)
    {
        _userMgr = userMgr;
        _signInMgr = signInMgr;
    }

    public IActionResult Login(string returnUrl)
    {
        var model = new LoginWebModel
        {
            ReturnUrl = returnUrl,
        };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginWebModel loginModel)
    {
        if (ModelState.IsValid)
        {
            var user = await _userMgr.FindByNameAsync(loginModel.Name!);
            if (user != null)
            {
                await _signInMgr.SignOutAsync();
                var result = await _signInMgr.PasswordSignInAsync(user, loginModel.Password!, false, false);
                if (result.Succeeded)
                {
                    return Redirect(loginModel?.ReturnUrl ?? "/Admin");
                }
            }
        }
        ModelState.AddModelError("", "Неправильное имя пользователя или пароль");
        return View(loginModel);
    }

    public async Task<IActionResult> Logout(string returnUrl = "/")
    {
        await _signInMgr.SignOutAsync();
        return Redirect(returnUrl);
    }
}