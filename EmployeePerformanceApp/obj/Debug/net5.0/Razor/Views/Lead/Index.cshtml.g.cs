#pragma checksum "C:\Users\79197\Desktop\SolbegSoft\EmployeePerformanceApp\EmployeePerformanceApp\Views\Lead\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c4384640369fa359755adc0d0dd070a86c12d693"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Lead_Index), @"mvc.1.0.view", @"/Views/Lead/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\79197\Desktop\SolbegSoft\EmployeePerformanceApp\EmployeePerformanceApp\Views\_ViewImports.cshtml"
using EmployeePerformanceApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\79197\Desktop\SolbegSoft\EmployeePerformanceApp\EmployeePerformanceApp\Views\_ViewImports.cshtml"
using EmployeePerformanceApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4384640369fa359755adc0d0dd070a86c12d693", @"/Views/Lead/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b63e252036820faa1301c80e6c794133978c1257", @"/Views/_ViewImports.cshtml")]
    public class Views_Lead_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\79197\Desktop\SolbegSoft\EmployeePerformanceApp\EmployeePerformanceApp\Views\Lead\Index.cshtml"
  
    ViewData["Title"] = "Lead Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>");
#nullable restore
#line 4 "C:\Users\79197\Desktop\SolbegSoft\EmployeePerformanceApp\EmployeePerformanceApp\Views\Lead\Index.cshtml"
Write(ViewBag.Ide);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
#nullable restore
#line 5 "C:\Users\79197\Desktop\SolbegSoft\EmployeePerformanceApp\EmployeePerformanceApp\Views\Lead\Index.cshtml"
 using (Html.BeginForm("Logout", "Account", FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"input-form\">\r\n        <input type=\"submit\" name=\"logout\" value=\"Log out\" />\r\n    </div>\r\n");
#nullable restore
#line 10 "C:\Users\79197\Desktop\SolbegSoft\EmployeePerformanceApp\EmployeePerformanceApp\Views\Lead\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
