#pragma checksum "C:\Users\79197\Desktop\SolbegSoft\EmployeePerformanceApp\EmployeePerformanceApp\Views\Shared\_LayoutLead.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "16028cb5304715b3e9364f5eded0709fd7f4f6e6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LayoutLead), @"mvc.1.0.view", @"/Views/Shared/_LayoutLead.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16028cb5304715b3e9364f5eded0709fd7f4f6e6", @"/Views/Shared/_LayoutLead.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b63e252036820faa1301c80e6c794133978c1257", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__LayoutLead : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "16028cb5304715b3e9364f5eded0709fd7f4f6e63376", async() => {
                WriteLiteral(@"
    <link rel=""stylesheet"" href=""https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css"" integrity=""sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU"" crossorigin=""anonymous"">
    <meta name=""viewport"" content=""width=device-width"" />
    <title>");
#nullable restore
#line 6 "C:\Users\79197\Desktop\SolbegSoft\EmployeePerformanceApp\EmployeePerformanceApp\Views\Shared\_LayoutLead.cshtml"
      Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "16028cb5304715b3e9364f5eded0709fd7f4f6e64907", async() => {
                WriteLiteral(@"
    <header>
        <nav class=""navbar navbar-expand-md navbar-dark fixed-top bg-info"">
            <div class=""container-fluid"">
                <button class=""navbar-toggler"" type=""button"" data-bs-toggle=""collapse"" data-bs-target=""#navbarCollapse"" aria-controls=""navbarCollapse"" aria-expanded=""false"" aria-label=""Переключить навигацию"">
                    <span class=""navbar-toggler-icon""></span>
                </button>
                <div class=""collapse navbar-collapse"" id=""navbarCollapse"">
                    <ul class=""navbar-nav me-auto mb-2 mb-md-0"">
                        <li class=""form-inline"">
                            <label class=""navbar-brand"" href=""#""><font style=""vertical-align: inherit;""><font style=""vertical-align: inherit;"">");
#nullable restore
#line 18 "C:\Users\79197\Desktop\SolbegSoft\EmployeePerformanceApp\EmployeePerformanceApp\Views\Shared\_LayoutLead.cshtml"
                                                                                                                                          Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</font></font></label>\r\n                        </li>\r\n                        <li class=\"nav-item\">\r\n");
#nullable restore
#line 21 "C:\Users\79197\Desktop\SolbegSoft\EmployeePerformanceApp\EmployeePerformanceApp\Views\Shared\_LayoutLead.cshtml"
                             using (Html.BeginForm("Logout", "Account", FormMethod.Get))
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <button class=\"btn btn-outline-danger\" type=\"submit\"><font style=\"vertical-align: inherit;\"><font style=\"vertical-align: inherit;\">LogOut</font></font></button>\r\n");
#nullable restore
#line 24 "C:\Users\79197\Desktop\SolbegSoft\EmployeePerformanceApp\EmployeePerformanceApp\Views\Shared\_LayoutLead.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </li>\r\n                        <li class=\"nav-item\">\r\n");
#nullable restore
#line 27 "C:\Users\79197\Desktop\SolbegSoft\EmployeePerformanceApp\EmployeePerformanceApp\Views\Shared\_LayoutLead.cshtml"
                             using (Html.BeginForm("CheckHierarchy", "Lead", FormMethod.Get))
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <button class=\"btn btn-outline-primary\" type=\"submit\"><font style=\"vertical-align: inherit;\"><font style=\"vertical-align: inherit;\">My Team</font></font></button>\r\n");
#nullable restore
#line 30 "C:\Users\79197\Desktop\SolbegSoft\EmployeePerformanceApp\EmployeePerformanceApp\Views\Shared\_LayoutLead.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </li>\r\n                        <li class=\"nav-item\">\r\n");
#nullable restore
#line 33 "C:\Users\79197\Desktop\SolbegSoft\EmployeePerformanceApp\EmployeePerformanceApp\Views\Shared\_LayoutLead.cshtml"
                             using (Html.BeginForm("AddMark", "Lead", FormMethod.Get))
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <button class=\"btn btn-outline-primary\" type=\"submit\"><font style=\"vertical-align: inherit;\"><font style=\"vertical-align: inherit;\">Marks</font></font></button>\r\n");
#nullable restore
#line 36 "C:\Users\79197\Desktop\SolbegSoft\EmployeePerformanceApp\EmployeePerformanceApp\Views\Shared\_LayoutLead.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </li>\r\n                    </ul>\r\n                </div>\r\n            </div>\r\n        </nav>\r\n    </header>\r\n    <div>\r\n        ");
#nullable restore
#line 44 "C:\Users\79197\Desktop\SolbegSoft\EmployeePerformanceApp\EmployeePerformanceApp\Views\Shared\_LayoutLead.cshtml"
   Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
