#pragma checksum "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "216f4fa45da1848572128667b0711bdb82d796e5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FertilizerCertificate_Approval), @"mvc.1.0.view", @"/Views/FertilizerCertificate/Approval.cshtml")]
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
#nullable restore
#line 1 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
using PCVMS.Presentation.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"216f4fa45da1848572128667b0711bdb82d796e5", @"/Views/FertilizerCertificate/Approval.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dcea06301feab613317ca7b5af393de8144b817c", @"/Views/_ViewImports.cshtml")]
    public class Views_FertilizerCertificate_Approval : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Fertilizer_Model>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/fertilizer/approval.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var Localizer = await obj.GetAllResource();


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n<div class=\"main-card mb-3 card\">\r\n\r\n    <div class=\"card-header-custom  bg-moi-green\">\r\n        <i class=\"header-icon pe-7s-pen icon-gradient bg-white\"> </i>\r\n        ");
#nullable restore
#line 17 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
   Write(Localizer["imported"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("  ");
#nullable restore
#line 17 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
                           Write(Localizer["fertilizer_soil_conditioners_registration_form"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"form-row\">\r\n\r\n        <div class=\"col-md-4\">\r\n            <div class=\"position-relative form-group\">\r\n                <label for=\"RoyalDecree\">\r\n                    ");
#nullable restore
#line 24 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
               Write(Localizer["local_company"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </label>\r\n                <div class=\"input-group\">\r\n                    <select id=\"ealist\" class=\"form-control\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "216f4fa45da1848572128667b0711bdb82d796e55867", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "216f4fa45da1848572128667b0711bdb82d796e57168", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "216f4fa45da1848572128667b0711bdb82d796e58166", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "216f4fa45da1848572128667b0711bdb82d796e59150", async() => {
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
#line 42 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
               Write(Localizer["governorate"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </label>\r\n                <div class=\"input-group\">\r\n                    <select id=\"ealist\" class=\"form-control\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "216f4fa45da1848572128667b0711bdb82d796e510934", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "216f4fa45da1848572128667b0711bdb82d796e511917", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "216f4fa45da1848572128667b0711bdb82d796e512900", async() => {
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
#line 57 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
                                    Write(Localizer["status"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                <div class=\"widget-content-left\">\r\n                    <div class=\"input-group\">\r\n                        <select id=\"ealist\" class=\"form-control\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "216f4fa45da1848572128667b0711bdb82d796e514718", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "216f4fa45da1848572128667b0711bdb82d796e516023", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "216f4fa45da1848572128667b0711bdb82d796e517013", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "216f4fa45da1848572128667b0711bdb82d796e518004", async() => {
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
#line 78 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
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

    <table style=""width: 100%;"" id=""tbl-fertilizer-certificate-list"" name=""tbl-fertilizer-certificate-list"" class=""table table-hover table-striped table-bordered"">
        <thead>
            <tr>
                <th class=""bg-moi-gold"" style=""text-align:center;""><i class=""pe-7s-magic-wand btn-icon-wrapper""> </i> ");
#nullable restore
#line 91 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
                                                                                                                 Write(Localizer["id"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th class=\"bg-moi-gold\" style=\"text-align:center;\"><i class=\"pe-7s-magic-wand btn-icon-wrapper\"> </i> ");
#nullable restore
#line 92 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
                                                                                                                 Write(Localizer["company"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th class=\"bg-moi-gold\" style=\"text-align:center;\"><i class=\"pe-7s-magic-wand btn-icon-wrapper\"> </i> ");
#nullable restore
#line 93 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
                                                                                                                 Write(Localizer["status"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th class=\"bg-moi-gold\" style=\"text-align:center;\"><i class=\"pe-7s-magic-wand btn-icon-wrapper\"> </i> ");
#nullable restore
#line 94 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
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

<div class=""main-card mb-3 card"" id=""record_screen"" style=""display:none;"">
    <div class=""card-header-custom  bg-moi-green"">
        <i class=""header-icon pe-7s-pen icon-gradient bg-white""> </i>
        ");
#nullable restore
#line 106 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
   Write(Localizer["ministry_review_process"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"no-results\">\r\n        <div class=\"main-card mb-3 card\">\r\n            <div class=\"card-header-custom  bg-moi-green\">\r\n                <i class=\"header-icon pe-7s-pen icon-gradient bg-royal\"> </i>\r\n                ");
#nullable restore
#line 112 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
           Write(Localizer["review_history"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
            <div class=""card-body"" readonly=""readonly"">
                <table style=""width: 100%;"" id=""tbl-review-history"" name=""tbl-review-history"" class=""table table-hover table-striped table-bordered"">
                    <thead>
                        <tr>
                            <th class=""bg-moi-gold"" style=""text-align:center""><i class=""pe-7s-magic-wand btn-icon-wrapper""> </i> ");
#nullable restore
#line 118 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
                                                                                                                            Write(Localizer["remark"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th class=\"bg-moi-gold\" style=\"text-align:center\"><i class=\"pe-7s-magic-wand btn-icon-wrapper\"> </i> ");
#nullable restore
#line 119 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
                                                                                                                            Write(Localizer["status"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th class=\"bg-moi-gold\" style=\"text-align:center\"><i class=\"pe-7s-magic-wand btn-icon-wrapper\"> </i> ");
#nullable restore
#line 120 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
                                                                                                                            Write(Localizer["user"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th class=\"bg-moi-gold\" style=\"text-align:center\"><i class=\"pe-7s-magic-wand btn-icon-wrapper\"> </i> ");
#nullable restore
#line 121 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
                                                                                                                            Write(Localizer["date"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th class=\"bg-moi-gold\" style=\"text-align:center\"><i class=\"pe-7s-magic-wand btn-icon-wrapper\"> </i> ");
#nullable restore
#line 122 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
                                                                                                                            Write(Localizer["action"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>

                </table>
            </div>
        </div>
        <div class=""swal2-icon swal2-success swal2-animate-success-icon"">
            <i class=""metismenu-icon lnr-hourglass"" style=""cursor: pointer;font-size:2.5rem;line-height: 1.75;"" title=""wait for approval""></i>
        </div>
        <div class=""results-title"">
            <div class=""position-relative form-group"">
                <label for=""PrpertyCardId"">");
#nullable restore
#line 136 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
                                      Write(Localizer["remark"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>

                <div class=""input-group"">
                    <input name=""PrpertyCardId"" id=""txtReviewHistory"" type=""text"" class=""form-control"">
                    <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-notebook btn-icon-wrapper""> </i></span></div>
                </div>
            </div>
        </div>
        <div class=""main-card mb-3 card"" id=""additional-document-fertilizer-registration"">
            <div class=""card-body"">
                <div class=""card-header-custom  bg-moi-green"">
                    <i class=""header-icon pe-7s-pen icon-gradient bg-white""> </i>
                    ");
#nullable restore
#line 148 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
               Write(Localizer["supporting_document"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
                <table style=""width: 100%;"" id=""tbl-support-document"" name=""tbl-resource-history"" class=""table table-hover table-striped table-bordered"">
                    <thead>
                        <tr>
                            <th class=""bg-moi-gold"" style=""text-align:center;""><i class=""pe-7s-magic-wand btn-icon-wrapper""> </i> ");
#nullable restore
#line 153 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
                                                                                                                             Write(Localizer["document_no"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th class=\"bg-moi-gold\" style=\"text-align:center;\"><i class=\"pe-7s-magic-wand btn-icon-wrapper\"> </i> ");
#nullable restore
#line 154 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
                                                                                                                             Write(Localizer["document_name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th class=\"bg-moi-gold\" style=\"text-align:center;\"><i class=\"pe-7s-magic-wand btn-icon-wrapper\"> </i> ");
#nullable restore
#line 155 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
                                                                                                                             Write(Localizer["mandatory"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th class=\"bg-moi-gold\" style=\"text-align:center;\"><i class=\"pe-7s-magic-wand btn-icon-wrapper\"> </i> ");
#nullable restore
#line 156 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
                                                                                                                             Write(Localizer["pdf"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th class=\"bg-moi-gold\" style=\"text-align:center;\"><i class=\"pe-7s-magic-wand btn-icon-wrapper\"> </i> ");
#nullable restore
#line 157 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
                                                                                                                             Write(Localizer["action"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th class=\"bg-moi-gold\" style=\"text-align:center;\"><i class=\"pe-7s-magic-wand btn-icon-wrapper\"> </i> ");
#nullable restore
#line 158 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
                                                                                                                             Write(Localizer["uploaded"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n                        <tr>\r\n                            <td>1</td>\r\n                            <td>");
#nullable restore
#line 164 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
                           Write(Localizer["support_document_for_selected_remark"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                            <td class=""text-center"" style=""color:forestgreen"">*</td>
                            <td>
                                <div class=""position-relative form-group"" style=""margin-top: 0.3rem;"">
                                    <img name=""email"" id=""FileImage1_review"" height=""18"" width=""24"">
                                    <input type=""hidden"" id=""Image1_review"" height=""18"" width=""24"">
                                    <input type=""hidden"" id=""ReviewID"" height=""18"" width=""24"">
                                    <input type=""hidden"" id=""ID"" height=""18"" width=""24"">
                                </div>
                            </td>
                            <td class=""text-center"" id='File1_review_upload' name='File1_review_upload'>
                                <div class='position-relative'> <label for=""File1_review""><i class=""metismenu-icon lnr-upload"" style=""cursor: pointer;margin-left: 10px;"" title=""upload""></i></label></div>
                  ");
            WriteLiteral(@"              <input style=""cursor:pointer; display:none;"" title=""Choose file automatically uploaded to system"" id=""File1_review"" name=""File1_review"" accept="".jpg,.jpeg"" type=""file"" size=""1"" multiple onchange=""uploadFiles(this);"" />
                            </td>
                            <td class=""text-center"" id='File1_review_success' name='File1_review_success'><i class=""metismenu-icon lnr-thumbs-up"" style=""cursor: pointer;margin-left: 10px;"" title=""success""></i></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <div class=""mt-3 mb-3""></div>
        <div class=""text-center"" id=""pnlreviewapproval"" style=""display:none;"">
            <button id=""btnApproveCertificate"" name=""btnApproveCertificate"" class=""btn-shadow btn-wide btn btn-moi-green btn-lg"">Approval</button>
            <button id=""btnRFCCertificate"" name=""btnRFCCertificate"" class=""btn-shadow btn-wide btn btn-moi-gold-dark btn-lg"" title=""this site visit g");
            WriteLiteral(@"oing to be cancelled"">RFC (Request for Clarification)</button>
            <button id=""btnRefuseCertificate"" name=""btnRefuseCertificate"" class=""btn-shadow btn-wide btn btn-danger btn-lg"">Refusal</button>
        </div>
    </div>
</div>

<div id=""no_record_screen"" style=""display:none;"">
    <div class=""swal2-icon swal2-success swal2-animate-success-icon"">
        <i class=""metismenu-icon lnr-hourglass"" style=""cursor: pointer; font-size: 2.5rem; line-height: 1.75; margin-left: 20%;"" title=""wait for approval""></i>
    </div>
    <div class=""results-title"" style=""font-size: 30px; color: purple; margin-left: 35%;"">
        <div class=""position-relative form-group"">
            <label for=""PrpertyCardId"">");
#nullable restore
#line 199 "C:\Pesticide Design\PCVMS.Presentation\Views\FertilizerCertificate\Approval.cshtml"
                                  Write(Localizer["no_certificate_to_show"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "216f4fa45da1848572128667b0711bdb82d796e534885", async() => {
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
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ICacheHelper obj { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Fertilizer_Model> Html { get; private set; }
    }
}
#pragma warning restore 1591