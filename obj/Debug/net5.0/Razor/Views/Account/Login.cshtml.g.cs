#pragma checksum "D:\Johan\Documents\BitcubeProject\Trainingfacility_Bitcube\Views\Account\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c09790d8adc27d2c4803618a221b67ef668c9f49"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Login), @"mvc.1.0.view", @"/Views/Account/Login.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/Login.cshtml", typeof(AspNetCore.Views_Account_Login))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\Johan\Documents\BitcubeProject\Trainingfacility_Bitcube\Views\_ViewImports.cshtml"
using Trainingfacility_Bitcube;

#line default
#line hidden
#line 2 "D:\Johan\Documents\BitcubeProject\Trainingfacility_Bitcube\Views\_ViewImports.cshtml"
using Trainingfacility_Bitcube.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c09790d8adc27d2c4803618a221b67ef668c9f49", @"/Views/Account/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea6a9055b95041ddb8140f3545cb5e9ad5a5d366", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Trainingfacility_Bitcube.Models.Account>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(48, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Johan\Documents\BitcubeProject\Trainingfacility_Bitcube\Views\Account\Login.cshtml"
  
    ViewBag.Title = "Login";

#line default
#line hidden
            BeginContext(87, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "D:\Johan\Documents\BitcubeProject\Trainingfacility_Bitcube\Views\Account\Login.cshtml"
 using (Html.BeginForm("Login", "Account", FormMethod.Post))
{

#line default
#line hidden
            BeginContext(154, 61, true);
            WriteLiteral("    <fieldset>\r\n        <legend>Login page</legend>\r\n        ");
            EndContext();
            BeginContext(216, 23, false);
#line 11 "D:\Johan\Documents\BitcubeProject\Trainingfacility_Bitcube\Views\Account\Login.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(239, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(250, 28, false);
#line 12 "D:\Johan\Documents\BitcubeProject\Trainingfacility_Bitcube\Views\Account\Login.cshtml"
   Write(Html.ValidationSummary(true));

#line default
#line hidden
            EndContext();
            BeginContext(278, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 13 "D:\Johan\Documents\BitcubeProject\Trainingfacility_Bitcube\Views\Account\Login.cshtml"
         if (@ViewBag.Message != null)
        {

#line default
#line hidden
            BeginContext(331, 35, true);
            WriteLiteral("            <div>\r\n                ");
            EndContext();
            BeginContext(367, 15, false);
#line 16 "D:\Johan\Documents\BitcubeProject\Trainingfacility_Bitcube\Views\Account\Login.cshtml"
           Write(ViewBag.Message);

#line default
#line hidden
            EndContext();
            BeginContext(382, 22, true);
            WriteLiteral("\r\n            </div>\r\n");
            EndContext();
#line 18 "D:\Johan\Documents\BitcubeProject\Trainingfacility_Bitcube\Views\Account\Login.cshtml"
        }

#line default
#line hidden
            BeginContext(415, 55, true);
            WriteLiteral("        <table>\r\n            <tr>\r\n                <td>");
            EndContext();
            BeginContext(471, 38, false);
#line 21 "D:\Johan\Documents\BitcubeProject\Trainingfacility_Bitcube\Views\Account\Login.cshtml"
               Write(Html.LabelFor(model => model.Username));

#line default
#line hidden
            EndContext();
            BeginContext(509, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(537, 40, false);
#line 22 "D:\Johan\Documents\BitcubeProject\Trainingfacility_Bitcube\Views\Account\Login.cshtml"
               Write(Html.TextBoxFor(model => model.Username));

#line default
#line hidden
            EndContext();
            BeginContext(577, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(605, 50, false);
#line 23 "D:\Johan\Documents\BitcubeProject\Trainingfacility_Bitcube\Views\Account\Login.cshtml"
               Write(Html.ValidationMessageFor(model => model.Username));

#line default
#line hidden
            EndContext();
            BeginContext(655, 64, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>");
            EndContext();
            BeginContext(720, 38, false);
#line 26 "D:\Johan\Documents\BitcubeProject\Trainingfacility_Bitcube\Views\Account\Login.cshtml"
               Write(Html.LabelFor(model => model.Password));

#line default
#line hidden
            EndContext();
            BeginContext(758, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(786, 41, false);
#line 27 "D:\Johan\Documents\BitcubeProject\Trainingfacility_Bitcube\Views\Account\Login.cshtml"
               Write(Html.PasswordFor(model => model.Password));

#line default
#line hidden
            EndContext();
            BeginContext(827, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(855, 50, false);
#line 28 "D:\Johan\Documents\BitcubeProject\Trainingfacility_Bitcube\Views\Account\Login.cshtml"
               Write(Html.ValidationMessageFor(model => model.Password));

#line default
#line hidden
            EndContext();
            BeginContext(905, 162, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td><input type=\"submit\" value=\"Login\"></td>\r\n            </tr>\r\n        </table>\r\n\r\n    </fieldset>\r\n");
            EndContext();
#line 36 "D:\Johan\Documents\BitcubeProject\Trainingfacility_Bitcube\Views\Account\Login.cshtml"
}

#line default
#line hidden
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Trainingfacility_Bitcube.Models.Account> Html { get; private set; }
    }
}
#pragma warning restore 1591
