#pragma checksum "E:\C#\123\pms_saif\PCVMS.Presentation\Views\Resource\Index1.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9b13de742da1c9bb511b199cbd65c0aa3e81bcbe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Resource_Index1), @"mvc.1.0.view", @"/Views/Resource/Index1.cshtml")]
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
#line 1 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\_ViewImports.cshtml"
using PCVM.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\_ViewImports.cshtml"
using PCVMS.Model.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\_ViewImports.cshtml"
using PCVM.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\_ViewImports.cshtml"
using PCVMS.Model.BusinessModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b13de742da1c9bb511b199cbd65c0aa3e81bcbe", @"/Views/Resource/Index1.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dcea06301feab613317ca7b5af393de8144b817c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Resource_Index1 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PCVMS.Model.BusinessModel.PCVMS_Resource>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/AppJs/Resource.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\Resource\Index1.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Index</h2>\r\n\r\n<div class=\"form-row\">\r\n    <div class=\"col-md-12\">\r\n        <div class=\"position-relative form-group\">\r\n            <label for=\"txtName\"> ");
#nullable restore
#line 13 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\Resource\Index1.cshtml"
                             Write(Model.Resource["Name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n            <input id=\"txtName\"");
            BeginWriteAttribute("placeholder", " placeholder=", 362, "", 398, 1);
#nullable restore
#line 14 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\Resource\Index1.cshtml"
WriteAttributeValue("", 375, Model.Resource["Name"], 375, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"text\" class=\"form-control\">\r\n        </div>\r\n    </div>\r\n</div>\r\n<div class=\"form-row\">\r\n    <div class=\"col-md-12\">\r\n        <div class=\"position-relative form-group\">\r\n            <label for=\"exampleAddress\"> ");
#nullable restore
#line 21 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\Resource\Index1.cshtml"
                                    Write(Model.Resource["Name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n            <input name=\"txtValue\" id=\"txtKey\"");
            BeginWriteAttribute("placeholder", " placeholder=", 695, "", 731, 1);
#nullable restore
#line 22 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\Resource\Index1.cshtml"
WriteAttributeValue("", 708, Model.Resource["Name"], 708, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" type=""text"" class=""form-control"">
        </div>
    </div>
</div>
<div class=""form-row"">
    <div class=""col-md-12"">
        <div class=""position-relative form-group"">

            <button type=""submit"" id=""Save"" class=""mb-2 mr-2 btn-icon btn-shadow btn-dashed btn btn-outline-success""><i class=""pe-7s-diskette btn-icon-wrapper""> </i>");
#nullable restore
#line 30 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\Resource\Index1.cshtml"
                                                                                                                                                                Write(Model.Resource["Name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</button>
        </div>
    </div>
</div>

<div class=""card-body"">
    <table style=""width: 100%;"" id=""tbl-Resource"" name=""tbl-Resource"" class=""table table-hover table-striped table-bordered"">
        <thead>
            <tr>
                <th class=""bg-deep-blue"" style=""text-align:center""><i class=""pe-7s-album btn-icon-wrapper""> </i> ");
#nullable restore
#line 39 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\Resource\Index1.cshtml"
                                                                                                            Write(Model.Resource["Name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th class=\"bg-deep-blue\" style=\"text-align:center\"><i class=\"pe-7s-magic-wand btn-icon-wrapper\"> </i> ");
#nullable restore
#line 40 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\Resource\Index1.cshtml"
                                                                                                                 Write(Model.Resource["Name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th class=\"bg-deep-blue\" style=\"text-align:center;\"><i class=\"pe-7s-magic-wand btn-icon-wrapper\"> </i> ");
#nullable restore
#line 41 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\Resource\Index1.cshtml"
                                                                                                                  Write(Model.Resource["Name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th class=\"bg-deep-blue\" style=\"text-align:center; width:12%\"><i class=\"pe-7s-magic-wand btn-icon-wrapper\"> </i> ");
#nullable restore
#line 42 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\Resource\Index1.cshtml"
                                                                                                                            Write(Model.Resource["Name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n        </tbody>\r\n    </table>\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b13de742da1c9bb511b199cbd65c0aa3e81bcbe8785", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PCVMS.Model.BusinessModel.PCVMS_Resource> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
