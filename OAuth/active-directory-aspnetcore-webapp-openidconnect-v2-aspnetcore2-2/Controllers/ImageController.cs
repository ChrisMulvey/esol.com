using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WebApp_OpenIDConnect_DotNet.Models;
using Extensions;

namespace WebApp_OpenIDConnect_DotNet.Controllers
{
    [Authorize]
    public class ImageController : Controller
    {
        //readonly ITokenAcquisition tokenAcquisition;

        //public ImageController(ITokenAcquisition tokenAcquisition)
        //{
        //    this.tokenAcquisition = tokenAcquisition;
        //}

        public IActionResult ImgIndex()
        {
            return View();
        }

        public IActionResult ImgAbout()
        {
            ViewData["Message"] = @"Your image capture\manage\store page.";

            return View();
        }

        public IActionResult ImdContact()
        {
            ViewData["Message"] = "Your image information page.";

            return View();
        }

        public IActionResult ImgPrivacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult ImgError()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        static string[] scopeRequiredByAPI = new string[] { "access_as_user" };
        
        //[AuthorizeForScopes(Scopes = new[] { "user.read" })]
        public async Task<IActionResult> Action()
        {
            HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByAPI);
            string[] scopes = new[] { "user.read" };
            try
            {
                //string accessToken = await tokenAcquisition.GetAccessTokenOnBehalfOfUserAsync(scopes);
                //// call the downstream API with the bearer token in the Authorize header
                //// Use the access token to call a protected web API.
                //HttpClient client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                //string json = await client.GetStringAsync(url);
            }
            catch (MsalUiRequiredException ex)
            {
                //tokenAcquisition.ReplyForbiddenWithWwwAuthenticateHeader(scopes, ex);
            }

            return null;
        }
    }
}
