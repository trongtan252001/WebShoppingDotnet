using Microsoft.AspNetCore.Mvc;
using WebShoppingDotnet.common;
using WebShoppingDotnet.Service;

namespace WebShoppingDotnet.Controllers
{
    public class SignUpController : Controller
    {
        public IActionResult Verify(string code)
        {
            if(IUserService.verify(code))
            return RedirectToAction("Index","Home");
            else return RedirectToAction("Index", "SignUp");
        }
        public IActionResult Index(string userName,string email,string password)
        {
            
            string verificationCode=Guid.NewGuid().ToString();
            string userID=Guid.NewGuid().ToString();

            if (userName != null && email != null && password != null && IUserService.checkAccountInfo(userName, email)
                && IUserService.insertUser(userName, IUserService.ComputeSha512Hash(password), email, verificationCode, userID))
            {     
                string url= "https://localhost:7241/SignUp/Verify?code=" + verificationCode;     
                MailInfor info=new MailInfor("19130249@st.hcmuaf.edu.vn", email,"Xác thực",url);
                IUserService.SendMail(info);
                return RedirectToAction("Index","Login");

            }
            else
            {
                ViewBag.UserName = userName;
                ViewBag.Email = email;
                ViewBag.Password = password;

                return View();
            }


            
        }
    }
}
