using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApplication5.Controllers
{
    public class StateManagmentController : Controller
    {
        #region TempData
        public IActionResult SetTempData()
        {

            TempData["msg"] = "Hello Fathi"; // create new instance form tempdata ---> dictionary<string,object>

            return Content("Tempdata Saved");
            // return response ("Tempdata Saved")
            // with tempdata obj 
            // and destroy tempdata obj 
            // saved in client side in browser  in cookies
            // and send with each request
            // once server read it or session end ( close tab of browser) --> deleted from browser cookies
        }
        public IActionResult GetTempDataV1()
        {
            // browser send tempdata with request
            // after reding it or session expired --> tempdata deleted from client side
            // send and recieve tempdata in Header of request / Response

            string? data = TempData["msg"]!.ToString();

            return Content($"Tempdata Saved : {data}");
        }

        public IActionResult GetTempDataV2()
        {

            if (TempData["msg"] is null)
            {
                return NotFound($"Tempdata Not Found");
            }

            string? data = TempData["msg"]!.ToString();
            return Content($"Tempdata Saved : {data}");

        }

        #endregion

        #region session

        public ActionResult SetSession()
        {
            // data stored in session of server 
            // rerurn response with session id only with out data 

            //options.IdleTimeout = TimeSpan.FromMinutes(1);  -- data still stored in server as long as there is request during 1 min
            // if no request during this duration server delete it 

            // client side send session id in each request
            // client side delete session id when tab is close  ---->>> Session Ended

            HttpContext.Session.SetString("msg", "Hello Fathi");
            HttpContext.Session.SetInt32("intMsg", 24);
            return Content("session Saved");
        }

        public IActionResult GetSessionV()
        {
            var msg1 = HttpContext.Session.GetString("msg");
            if (msg1 is null)
            {
                return NotFound("String Msg Not found");
            }

            var msg2 = HttpContext.Session.GetInt32("intMsg");
            if (msg2 is null)
            {
                return NotFound("Int Msg Not Found");
            }

            return Content($"Session data : {msg1} --- {msg2}");

        }
        #endregion


        #region cookies
        public ActionResult SetCookies()
        {
            // create cookies
            // tell browser to store data   in cookies at it 
            // send stored data like Toke with each request 
            // but after Expiry time --> it deleted from client side 

            CookieOptions cookieOptions = new CookieOptions()
            {
                Expires = DateTimeOffset.UtcNow.AddHours(10),
                HttpOnly=true,
                SameSite=SameSiteMode.Strict,
                IsEssential=true

            };

            Response.Cookies.Append("token", "hjgudihfkhdeoruhgytm45227sjdjdhru",cookieOptions);
            
            //1- return data at HTTP Response Header  --> Set-Cookie: token=hjgudihfkhdeoruhgytm45227sjdjdhru; expires=10
            //2- rerurn response Content("Cookies saved");
            return Content("Cookies saved");
       
        }

        public IActionResult GetCookies()
        {

            string? token = Request.Cookies["token"];

            if (token is null)
                return NotFound();

      
            return Content($"Message: {token}");

        }



        #endregion
    }
}

/*
 * 
 * الفرق المهم بين Cookie و Session
	                             Cookie	          Session
مكان التخزين                	      المتصفح	  السيرفر         
ما الذي يرسل في كل   reques	         كل البيانات	    SessionID فقط
الحجم                   	                محدود	أكبر
ا
 * */

// sessio ---> for critical data like token bec it server side data stored at server not browser
// cookies ---> data stored in browser and sent with each request 