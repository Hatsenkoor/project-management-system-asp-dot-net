#pragma checksum "C:\Pesticide Design\PCVMS.Presentation\Views\AssignRole\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1d3a59897e93cc531f29e478d0c12be1f75d728d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AssignRole_Index), @"mvc.1.0.view", @"/Views/AssignRole/Index.cshtml")]
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
#line 1 "C:\Pesticide Design\PCVMS.Presentation\Views\_ViewImports.cshtml"
using PCVM.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Pesticide Design\PCVMS.Presentation\Views\_ViewImports.cshtml"
using PCVMS.Model.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Pesticide Design\PCVMS.Presentation\Views\_ViewImports.cshtml"
using PCVM.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Pesticide Design\PCVMS.Presentation\Views\_ViewImports.cshtml"
using PCVMS.Model.BusinessModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d3a59897e93cc531f29e478d0c12be1f75d728d", @"/Views/AssignRole/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dcea06301feab613317ca7b5af393de8144b817c", @"/Views/_ViewImports.cshtml")]
    public class Views_AssignRole_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PCVMS.Model.Web.AssignRoleModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("ui form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/AssignRole/AssingUserGroup"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Pesticide Design\PCVMS.Presentation\Views\AssignRole\Index.cshtml"
  
    ViewData["Title"] = "Index";
     Layout = "~/Views/Shared/_Layout.cshtml";
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1d3a59897e93cc531f29e478d0c12be1f75d728d4819", async() => {
                WriteLiteral("\r\n        <div class=\"col-md-6\">\r\n            ");
#nullable restore
#line 10 "C:\Pesticide Design\PCVMS.Presentation\Views\AssignRole\Index.cshtml"
       Write(Html.LabelFor(model => model.RoleId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n\r\n\r\n            ");
#nullable restore
#line 14 "C:\Pesticide Design\PCVMS.Presentation\Views\AssignRole\Index.cshtml"
       Write(Html.DropDownListFor(model => model.RoleId, Model.RoleList, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"col-md-6\">\r\n            ");
#nullable restore
#line 18 "C:\Pesticide Design\PCVMS.Presentation\Views\AssignRole\Index.cshtml"
       Write(Html.LabelFor(model => model.UserId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n\r\n            ");
#nullable restore
#line 21 "C:\Pesticide Design\PCVMS.Presentation\Views\AssignRole\Index.cshtml"
       Write(Html.DropDownListFor(model => model.UserId, Model.UserList, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"col-md-6\">\r\n            ");
#nullable restore
#line 25 "C:\Pesticide Design\PCVMS.Presentation\Views\AssignRole\Index.cshtml"
       Write(Html.LabelFor(model => model.RoleGroupId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n\r\n            ");
#nullable restore
#line 28 "C:\Pesticide Design\PCVMS.Presentation\Views\AssignRole\Index.cshtml"
       Write(Html.DropDownListFor(model => model.RoleGroupId, Model.RoleGroupList, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-3\">\r\n            <label for=\"FromDate\">From date:</label>\r\n\r\n            ");
#nullable restore
#line 33 "C:\Pesticide Design\PCVMS.Presentation\Views\AssignRole\Index.cshtml"
       Write(Html.TextBoxFor(model => model.FromDate, new { @class = "form-control", id = "FromDate" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-3\">\r\n            <label for=\"EndDate\">End date:</label>\r\n            ");
#nullable restore
#line 37 "C:\Pesticide Design\PCVMS.Presentation\Views\AssignRole\Index.cshtml"
       Write(Html.TextBoxFor(model => model.EndDate, new { @class = "form-control", id = "EndDate" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n        </div>\r\n        <div class=\"divider row\">\r\n        </div>\r\n        <div class=\"col-md-6\">\r\n            <button name=\"button\" value=\"Save\" class=\"btn btn-success btn-lg\">Save</button>\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n    <div class=\"divider row\"></div>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1d3a59897e93cc531f29e478d0c12be1f75d728d9351", async() => {
                WriteLiteral("\r\n            <div class=\"col-md-6\">\r\n                ");
#nullable restore
#line 50 "C:\Pesticide Design\PCVMS.Presentation\Views\AssignRole\Index.cshtml"
           Write(Html.LabelFor(model => model.RoleId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n\r\n\r\n                ");
#nullable restore
#line 54 "C:\Pesticide Design\PCVMS.Presentation\Views\AssignRole\Index.cshtml"
           Write(Html.DropDownListFor(model => model.RoleId, Model.RoleList, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"col-md-6\">\r\n                ");
#nullable restore
#line 58 "C:\Pesticide Design\PCVMS.Presentation\Views\AssignRole\Index.cshtml"
           Write(Html.LabelFor(model => model.UserGroupId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n\r\n                ");
#nullable restore
#line 61 "C:\Pesticide Design\PCVMS.Presentation\Views\AssignRole\Index.cshtml"
           Write(Html.DropDownListFor(model => model.UserGroupId, Model.UserGroupList, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            </div>

            
            <div class=""divider row"">
            </div>
            <div class=""col-md-6"">
                <button name=""button"" value=""Save"" class=""btn btn-success btn-lg"">Save</button>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        <script>\r\n            $(document).ready(function () {\r\n                $(\"#FromDate\").attr(\"data-toggle\", \"datepicker\");\r\n                $(\"#EndDate\").attr(\"data-toggle\", \"datepicker\");\r\n            });\r\n\r\n        </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PCVMS.Model.Web.AssignRoleModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
