#pragma checksum "E:\C#\123\pms_saif\PCVMS.Presentation\Views\Report\Invoice.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0affedd3d1968c2a0aad1425d5075c7c91c9aa81"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_Invoice), @"mvc.1.0.view", @"/Views/Report/Invoice.cshtml")]
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
#nullable restore
#line 1 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\Report\Invoice.cshtml"
using PCVMS.Presentation.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0affedd3d1968c2a0aad1425d5075c7c91c9aa81", @"/Views/Report/Invoice.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dcea06301feab613317ca7b5af393de8144b817c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Report_Invoice : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Fertilizer_Model>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/report/invoice.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\Report\Invoice.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var Localizer = await obj.GetAllResource();


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n\r\n<div class=\"main-card mb-3 card\">\r\n\r\n    <div class=\"card-header-custom  bg-moi-green\">\r\n        <i class=\"header-icon pe-7s-pen icon-gradient bg-white\"> </i>\r\n        ");
#nullable restore
#line 18 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\Report\Invoice.cshtml"
   Write(Localizer["imported"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("  ");
#nullable restore
#line 18 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\Report\Invoice.cshtml"
                           Write(Localizer["fertilizer_soil_conditioners_registration_form"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"form-row\">\r\n\r\n        <div class=\"col-md-4\">\r\n            <div class=\"position-relative form-group\">\r\n                <label for=\"RoyalDecree\">\r\n                    ");
#nullable restore
#line 25 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\Report\Invoice.cshtml"
               Write(Localizer["local_company"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </label>\r\n                <div class=\"input-group\">\r\n                    <select id=\"ealist\" class=\"form-control\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0affedd3d1968c2a0aad1425d5075c7c91c9aa815742", async() => {
                WriteLiteral("select company");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0affedd3d1968c2a0aad1425d5075c7c91c9aa817043", async() => {
                WriteLiteral("Technical Agri Support");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0affedd3d1968c2a0aad1425d5075c7c91c9aa818041", async() => {
                WriteLiteral("AL Saffa");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0affedd3d1968c2a0aad1425d5075c7c91c9aa819025", async() => {
                WriteLiteral("Mazoon Diary");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </select>
                    <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-bookmarks btn-icon-wrapper""> </i></span></div>
                </div>
            </div>
        </div>


        <div class=""col-md-3"">
            <div class=""position-relative form-group"">
                <label for=""RoyalDecree"">
                    ");
#nullable restore
#line 43 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\Report\Invoice.cshtml"
               Write(Localizer["governorate"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </label>\r\n                <div class=\"input-group\">\r\n                    <select id=\"ealist\" class=\"form-control\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0affedd3d1968c2a0aad1425d5075c7c91c9aa8110792", async() => {
                WriteLiteral("Muscat");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0affedd3d1968c2a0aad1425d5075c7c91c9aa8111775", async() => {
                WriteLiteral("Dhofar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0affedd3d1968c2a0aad1425d5075c7c91c9aa8112758", async() => {
                WriteLiteral("Burami");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </select>
                    <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-bookmarks btn-icon-wrapper""> </i></span></div>
                </div>
            </div>
        </div>

        <div class=""col-md-3"">
            <div class=""position-relative form-group"">
                <label for=""ProjectName"">");
#nullable restore
#line 58 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\Report\Invoice.cshtml"
                                    Write(Localizer["status"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                <div class=\"widget-content-left\">\r\n                    <div class=\"input-group\">\r\n                        <select id=\"ealist\" class=\"form-control\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0affedd3d1968c2a0aad1425d5075c7c91c9aa8114559", async() => {
                WriteLiteral("select status");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0affedd3d1968c2a0aad1425d5075c7c91c9aa8115864", async() => {
                WriteLiteral("submitted");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0affedd3d1968c2a0aad1425d5075c7c91c9aa8116854", async() => {
                WriteLiteral("in process");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0affedd3d1968c2a0aad1425d5075c7c91c9aa8117845", async() => {
                WriteLiteral("completed");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </select>
                        <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-speaker btn-icon-wrapper""> </i></span></div>
                    </div>
                </div>

            </div>
        </div>
        <div class=""col-md-2"">
            <div class=""position-relative form-group"">
                <label for=""ProjectName"" style=""visibility:hidden"">cr</label>
                <div class=""widget-content-left"">
                    <div class=""input-group"">
                        <button id=""SearchTransaction"" name=""SearchTransaction"" class=""btn-icon btn-shadow btn-dashed btn btn-alternate block-page-btn-example-3"">
                            <i class=""pe-7s-search btn-icon-wrapper""> </i>");
#nullable restore
#line 79 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\Report\Invoice.cshtml"
                                                                     Write(Localizer["search"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </button>

                    </div>
                </div>

            </div>
        </div>
    </div>

    <table style=""width: 100%;"" id=""tbl-payment-invoice-list"" name=""tbl-payment-invoice-list"" class=""table table-hover table-striped table-bordered"">
        <thead>
            <tr>
                <th class=""bg-moi-gold"" style=""text-align:center;""><i class=""pe-7s-magic-wand btn-icon-wrapper""> </i> ");
#nullable restore
#line 92 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\Report\Invoice.cshtml"
                                                                                                                 Write(Localizer["id"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th class=\"bg-moi-gold\" style=\"text-align:center;\"><i class=\"pe-7s-magic-wand btn-icon-wrapper\"> </i> ");
#nullable restore
#line 93 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\Report\Invoice.cshtml"
                                                                                                                 Write(Localizer["company"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th class=\"bg-moi-gold\" style=\"text-align:center;\"><i class=\"pe-7s-magic-wand btn-icon-wrapper\"> </i> ");
#nullable restore
#line 94 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\Report\Invoice.cshtml"
                                                                                                                 Write(Localizer["status"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th class=\"bg-moi-gold\" style=\"text-align:center;\"><i class=\"pe-7s-magic-wand btn-icon-wrapper\"> </i> ");
#nullable restore
#line 95 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\Report\Invoice.cshtml"
                                                                                                                 Write(Localizer["action"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>


</div>

<div id=""no_record_screen"" style=""display:none;"">
    <div class=""swal2-icon swal2-success swal2-animate-success-icon"">
        <i class=""metismenu-icon lnr-hourglass"" style=""cursor: pointer; font-size: 2.5rem; line-height: 1.75; margin-left: 20%;"" title=""wait for approval""></i>
    </div>
    <div class=""results-title"" style=""font-size: 30px; color: purple; margin-left: 35%;"">
        <div class=""position-relative form-group"">
            <label for=""PrpertyCardId"">");
#nullable restore
#line 110 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\Report\Invoice.cshtml"
                                  Write(Localizer["no_payment_to_show"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0affedd3d1968c2a0aad1425d5075c7c91c9aa8122938", async() => {
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
        public ICacheHelper obj { get; private set; } = default!;
        #nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Fertilizer_Model> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
