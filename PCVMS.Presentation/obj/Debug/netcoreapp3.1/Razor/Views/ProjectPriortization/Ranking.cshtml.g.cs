#pragma checksum "E:\C#\123\pms_saif\PCVMS.Presentation\Views\ProjectPriortization\Ranking.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0e44634981951c0498c8e2767980566bca307b80"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProjectPriortization_Ranking), @"mvc.1.0.view", @"/Views/ProjectPriortization/Ranking.cshtml")]
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
#line 1 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\ProjectPriortization\Ranking.cshtml"
using PCVMS.Presentation.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e44634981951c0498c8e2767980566bca307b80", @"/Views/ProjectPriortization/Ranking.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dcea06301feab613317ca7b5af393de8144b817c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_ProjectPriortization_Ranking : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Fertilizer_Model>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/pms/ranking.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 3 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\ProjectPriortization\Ranking.cshtml"
  
    ViewData["Title"] = "Project Ranking";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var Localizer = await obj.GetAllResource();


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<div class=\"main-card mb-3 card\" id=\"Fertilizer_Certificate_Details\">\r\n    <div class=\"card-header-custom  bg-moi-green\">\r\n        <i class=\"header-icon pe-7s-pen icon-gradient bg-royal\"> </i>\r\n        ");
#nullable restore
#line 15 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\ProjectPriortization\Ranking.cshtml"
   Write(Localizer["project_ranking_detail"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"form-row bg-moi-gold\" id=\"projectype\" style=\"margin-top: 1%;\">\r\n        <div class=\"col-md-3\">\r\n            <div class=\"position-relative form-group\"><label for=\"Username\"");
            BeginWriteAttribute("class", " class=\"", 682, "\"", 690, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 20 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\ProjectPriortization\Ranking.cshtml"
                                                                                Write(Localizer["priority"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label></div>\r\n        </div>\r\n        <div class=\"col-md-3\">\r\n            <div class=\"position-relative form-group\"><label for=\"Username\"");
            BeginWriteAttribute("class", " class=\"", 853, "\"", 861, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 23 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\ProjectPriortization\Ranking.cshtml"
                                                                                Write(Localizer["scale"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label></div>\r\n        </div>\r\n        <div class=\"col-md-3\">\r\n            <div class=\"position-relative form-group\"><label for=\"Username\"");
            BeginWriteAttribute("class", " class=\"", 1021, "\"", 1029, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 26 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\ProjectPriortization\Ranking.cshtml"
                                                                                Write(Localizer["rank"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label></div>\r\n        </div>\r\n        <div class=\"col-md-3\">\r\n            <div class=\"position-relative form-group\"><label for=\"Username\"");
            BeginWriteAttribute("class", " class=\"", 1188, "\"", 1196, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 29 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\ProjectPriortization\Ranking.cshtml"
                                                                                Write(Localizer["save"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label></div>\r\n        </div>\r\n    </div>\r\n    <div class=\"form-row\" id=\"projectype\" style=\"margin-top: 1%;\">\r\n      \r\n        <div class=\"col-md-3\">\r\n            <div class=\"position-relative form-group\"><label for=\"Username\"");
            BeginWriteAttribute("class", " class=\"", 1443, "\"", 1451, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 35 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\ProjectPriortization\Ranking.cshtml"
                                                                                Write(Localizer["project_type"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label></div>
        </div>
        <div class=""col-md-3"">

            <div class=""position-relative form-group"">

                <div class=""input-group"">
                    <select id=""project_type_selection"" name=""project_type_selection"" class=""form-control""></select>
                    <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-note btn-icon-wrapper""> </i></span></div>
                </div>

            </div>
        </div>
        <div class=""col-md-3"">

            <div class=""position-relative form-group"">

                <div class=""input-group"">
                    <select id=""project_type_rank_selection"" name=""project_type_rank_selection"" class=""form-control""></select>
                    <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-note btn-icon-wrapper""> </i></span></div>
                </div>

            </div>
        </div>
        <div class=""col-md-3"">
            <div class=""d-block text");
            WriteLiteral("-right card-footer\">\r\n                <button id=\"btnprojecttype\" name=\"btnprojecttype\" class=\"btn-icon btn-shadow btn-dashed btn btn-alternate block-page-btn-example-3\">\r\n                    <i class=\"pe-7s-search btn-icon-wrapper\"> </i>");
#nullable restore
#line 62 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\ProjectPriortization\Ranking.cshtml"
                                                             Write(Localizer["save"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"form-row\">\r\n       \r\n        <div class=\"col-md-3\">\r\n            <div class=\"position-relative form-group\"><label for=\"Username\"");
            BeginWriteAttribute("class", " class=\"", 2980, "\"", 2988, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 70 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\ProjectPriortization\Ranking.cshtml"
                                                                                Write(Localizer["project_type_category"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label></div>
        </div>
        <div class=""col-md-3"">

            <div class=""position-relative form-group"">

                <div class=""input-group"">
                    <select id=""project_type_category_selection"" name=""project_type_category_selection"" class=""form-control""></select>
                    <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-note btn-icon-wrapper""> </i></span></div>
                </div>

            </div>
        </div>
        <div class=""col-md-3"">

            <div class=""position-relative form-group"">

                <div class=""input-group"">
                    <select id=""project_type_category_rank_selection"" name=""project_type_category_rank_selection"" class=""form-control""></select>
                    <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-note btn-icon-wrapper""> </i></span></div>
                </div>

            </div>
        </div>
        <div class=""col-md-3"">
");
            WriteLiteral(@"            <div class=""d-block text-right card-footer"">
                <button id=""btnSaveFertilizerCertificate"" name=""btnSaveFertilizerCertificate"" class=""btn-icon btn-shadow btn-dashed btn btn-alternate block-page-btn-example-3"">
                    <i class=""pe-7s-search btn-icon-wrapper""> </i>");
#nullable restore
#line 97 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\ProjectPriortization\Ranking.cshtml"
                                                             Write(Localizer["save"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-row\">\r\n       \r\n        <div class=\"col-md-3\">\r\n            <div class=\"position-relative form-group\"><label for=\"Username\"");
            BeginWriteAttribute("class", " class=\"", 4592, "\"", 4600, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 106 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\ProjectPriortization\Ranking.cshtml"
                                                                                Write(Localizer["population_affected"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label></div>
        </div>
        <div class=""col-md-3"">

            <div class=""position-relative form-group"">

                <div class=""input-group"">
                    <select id=""population_selection"" name=""population_selection"" class=""form-control""></select>
                    <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-note btn-icon-wrapper""> </i></span></div>
                </div>

            </div>
        </div>
        <div class=""col-md-3"">

            <div class=""position-relative form-group"">

                <div class=""input-group"">
                    <select id=""population_rank_selection"" name=""population_rank_selection"" class=""form-control""></select>
                    <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-note btn-icon-wrapper""> </i></span></div>
                </div>

            </div>
        </div>
        <div class=""col-md-3"">
            <div class=""d-block text-right c");
            WriteLiteral(@"ard-footer"">
                <button id=""btnSaveFertilizerCertificate"" name=""btnSaveFertilizerCertificate"" class=""btn-icon btn-shadow btn-dashed btn btn-alternate block-page-btn-example-3"">
                    <i class=""pe-7s-search btn-icon-wrapper""> </i>");
#nullable restore
#line 133 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\ProjectPriortization\Ranking.cshtml"
                                                             Write(Localizer["save"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"form-row\">\r\n        \r\n        <div class=\"col-md-3\">\r\n            <div class=\"position-relative form-group\"><label for=\"Username\"");
            BeginWriteAttribute("class", " class=\"", 6157, "\"", 6165, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 141 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\ProjectPriortization\Ranking.cshtml"
                                                                                Write(Localizer["project_budget"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label></div>
        </div>
        <div class=""col-md-3"">

            <div class=""position-relative form-group"">

                <div class=""input-group"">
                    <select id=""budget_selection"" name=""budget_selection"" class=""form-control""></select>
                    <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-note btn-icon-wrapper""> </i></span></div>
                </div>

            </div>
        </div>
        <div class=""col-md-3"">

            <div class=""position-relative form-group"">

                <div class=""input-group"">
                    <select id=""budget_rank_selection"" name=""budget_rank_selection"" class=""form-control""></select>
                    <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-note btn-icon-wrapper""> </i></span></div>
                </div>

            </div>
        </div>
        <div class=""col-md-3"">
            <div class=""d-block text-right card-footer"">
  ");
            WriteLiteral("              <button id=\"btnSaveFertilizerCertificate\" name=\"btnSaveFertilizerCertificate\" class=\"btn-icon btn-shadow btn-dashed btn btn-alternate block-page-btn-example-3\">\r\n                    <i class=\"pe-7s-search btn-icon-wrapper\"> </i>");
#nullable restore
#line 168 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\ProjectPriortization\Ranking.cshtml"
                                                             Write(Localizer["save"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"form-row\">\r\n        \r\n        <div class=\"col-md-3\">\r\n            <div class=\"position-relative form-group\"><label for=\"Username\"");
            BeginWriteAttribute("class", " class=\"", 7701, "\"", 7709, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 176 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\ProjectPriortization\Ranking.cshtml"
                                                                                Write(Localizer["project_mandate"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label></div>
        </div>
        <div class=""col-md-3"">

            <div class=""position-relative form-group"">

                <div class=""input-group"">
                    <select id=""mandate_selection"" name=""mandate_selection"" class=""form-control""></select>
                    <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-note btn-icon-wrapper""> </i></span></div>
                </div>

            </div>
        </div>
        <div class=""col-md-3"">

            <div class=""position-relative form-group"">

                <div class=""input-group"">
                    <select id=""mandate_rank_selection"" name=""mandate_rank_selection"" class=""form-control""></select>
                    <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-note btn-icon-wrapper""> </i></span></div>
                </div>

            </div>
        </div>
        <div class=""col-md-3"">
            <div class=""d-block text-right card-footer"">");
            WriteLiteral("\r\n                <button id=\"btnSaveFertilizerCertificate\" name=\"btnSaveFertilizerCertificate\" class=\"btn-icon btn-shadow btn-dashed btn btn-alternate block-page-btn-example-3\">\r\n                    <i class=\"pe-7s-search btn-icon-wrapper\"> </i>");
#nullable restore
#line 203 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\ProjectPriortization\Ranking.cshtml"
                                                             Write(Localizer["save"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"form-row\">\r\n       \r\n        <div class=\"col-md-3\">\r\n            <div class=\"position-relative form-group\"><label for=\"Username\"");
            BeginWriteAttribute("class", " class=\"", 9249, "\"", 9257, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 211 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\ProjectPriortization\Ranking.cshtml"
                                                                                Write(Localizer["importance_of_doing"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label></div>
        </div>
        <div class=""col-md-3"">

            <div class=""position-relative form-group"">

                <div class=""input-group"">
                    <select id=""benefit_selection"" name=""benefit_selection"" class=""form-control""></select>
                    <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-note btn-icon-wrapper""> </i></span></div>
                </div>

            </div>
        </div>
        <div class=""col-md-3"">

            <div class=""position-relative form-group"">

                <div class=""input-group"">
                    <select id=""benefit_rank_selection"" name=""benefit_rank_selection"" class=""form-control""></select>
                    <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-note btn-icon-wrapper""> </i></span></div>
                </div>

            </div>
        </div>
        <div class=""col-md-3"">
            <div class=""d-block text-right card-footer"">");
            WriteLiteral("\r\n                <button id=\"btnSaveFertilizerCertificate\" name=\"btnSaveFertilizerCertificate\" class=\"btn-icon btn-shadow btn-dashed btn btn-alternate block-page-btn-example-3\">\r\n                    <i class=\"pe-7s-search btn-icon-wrapper\"> </i>");
#nullable restore
#line 238 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\ProjectPriortization\Ranking.cshtml"
                                                             Write(Localizer["save"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"form-row\">\r\n       \r\n        <div class=\"col-md-3\">\r\n            <div class=\"position-relative form-group\"><label for=\"Username\"");
            BeginWriteAttribute("class", " class=\"", 10801, "\"", 10809, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 246 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\ProjectPriortization\Ranking.cshtml"
                                                                                Write(Localizer["risk_of_not_doing"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label></div>
        </div>
        <div class=""col-md-3"">

            <div class=""position-relative form-group"">

                <div class=""input-group"">
                    <select id=""risk_selection"" name=""risk_selection"" class=""form-control""></select>
                    <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-note btn-icon-wrapper""> </i></span></div>
                </div>

            </div>
        </div>
        <div class=""col-md-3"">

            <div class=""position-relative form-group"">

                <div class=""input-group"">
                    <select id=""risk_rank_selection"" name=""risk_rank_selection"" class=""form-control""></select>
                    <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-note btn-icon-wrapper""> </i></span></div>
                </div>

            </div>
        </div>
        <div class=""col-md-3"">
            <div class=""d-block text-right card-footer"">
          ");
            WriteLiteral("      <button id=\"btnSaveFertilizerCertificate\" name=\"btnSaveFertilizerCertificate\" class=\"btn-icon btn-shadow btn-dashed btn btn-alternate block-page-btn-example-3\">\r\n                    <i class=\"pe-7s-search btn-icon-wrapper\"> </i>");
#nullable restore
#line 273 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\ProjectPriortization\Ranking.cshtml"
                                                             Write(Localizer["save"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"form-row\">\r\n       \r\n        <div class=\"col-md-3\">\r\n            <div class=\"position-relative form-group\"><label for=\"Username\"");
            BeginWriteAttribute("class", " class=\"", 12339, "\"", 12347, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 281 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\ProjectPriortization\Ranking.cshtml"
                                                                                Write(Localizer["project_funding"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label></div>
        </div>
        <div class=""col-md-3"">

            <div class=""position-relative form-group"">

                <div class=""input-group"">
                    <select id=""funding_selection"" name=""funding_selection"" class=""form-control""></select>
                    <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-note btn-icon-wrapper""> </i></span></div>
                </div>

            </div>
        </div>
        <div class=""col-md-3"">

            <div class=""position-relative form-group"">

                <div class=""input-group"">
                    <select id=""funding_rank_selection"" name=""funding_rank_selection"" class=""form-control"">
                      </select>
                    <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-note btn-icon-wrapper""> </i></span></div>
                </div>

            </div>
        </div>
        <div class=""col-md-3"">
            <div class=""d-block ");
            WriteLiteral(@"text-right card-footer"">
                <button id=""btnSaveFertilizerCertificate"" name=""btnSaveFertilizerCertificate"" class=""btn-icon btn-shadow btn-dashed btn btn-alternate block-page-btn-example-3"">
                    <i class=""pe-7s-search btn-icon-wrapper""> </i>");
#nullable restore
#line 309 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\ProjectPriortization\Ranking.cshtml"
                                                             Write(Localizer["save"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n   \r\n\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0e44634981951c0498c8e2767980566bca307b8026181", async() => {
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
            WriteLiteral("\r\n\r\n");
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