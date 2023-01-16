#pragma checksum "C:\Pesticide Design\PCVMS.Presentation\Views\PesticideCertificate\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a93df8c72bb71fe6bbc0d467df415be9ec7388f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PesticideCertificate_Dashboard), @"mvc.1.0.view", @"/Views/PesticideCertificate/Dashboard.cshtml")]
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
#line 1 "C:\Pesticide Design\PCVMS.Presentation\Views\PesticideCertificate\Dashboard.cshtml"
using PCVMS.Presentation.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a93df8c72bb71fe6bbc0d467df415be9ec7388f9", @"/Views/PesticideCertificate/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dcea06301feab613317ca7b5af393de8144b817c", @"/Views/_ViewImports.cshtml")]
    public class Views_PesticideCertificate_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PCVMS.Model.Web.DashboardModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/morris/morris.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/morris/morris.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/pesticide/dashboard.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Pesticide Design\PCVMS.Presentation\Views\PesticideCertificate\Dashboard.cshtml"
  
    ViewData["Title"] = "Dashboard";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var Localizer = await obj.GetAllResource();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a93df8c72bb71fe6bbc0d467df415be9ec7388f95575", async() => {
                WriteLiteral("\r\n");
                WriteLiteral("    <link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/prettify/r224/prettify.min.css\">\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a93df8c72bb71fe6bbc0d467df415be9ec7388f95984", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
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
            WriteLiteral(@"

<div class=""tab-content"">
    <div class=""tab-pane tabs-animation fade show active"" id=""tab-content-0"" role=""tabpanel"">
        <div class=""row"">
            <div class=""col-lg-12 col-md-12"">
                <div class=""main-card mb-3 card"">
                    <div class=""card-header  bg-happy-green"">
                        <i class=""header-icon pe-7s-pen icon-gradient bg-royal""> </i>
                        <h1>Dashboard</h1>
                    </div>
                </div>

            </div>

        </div>
        <div class=""row"">
            <div class=""col-md-6 col-lg-3"">
                <div class=""widget-chart widget-chart2 text-left mb-3 card-btm-border card-shadow-primary border-primary card"">
                    <div class=""widget-chat-wrapper-outer"">
                        <div class=""widget-chart-content"">
                            <div class=""widget-title opacity-5 text-uppercase"">Total Certificate</div>
                            <div class=""widget-numbers mt-2 f");
            WriteLiteral(@"size-2 mb-0 w-100"">
                                <div class=""widget-chart-flex align-items-center"">
                                    <div>
                                        <span class=""opacity-10 text-danger pr-2"">
                                            <i class=""fa fa-angle-up""></i>
                                        </span>
                                        <label id=""lbl_total_certificate""></label>
                                        <div class=""card-header-title"" style=""font-size: small;"">currently active</div>
                                    </div>
                                    <div class=""widget-title ml-auto font-size-lg font-weight-normal text-muted"">
                                        <div class=""circle-progress circle-progress-gradient-alt-sm d-inline-block"">
                                            <small></small>
                                        </div>
                                    </div>
                                ");
            WriteLiteral(@"</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-md-6 col-lg-3"">
                <div class=""widget-chart widget-chart2 text-left mb-3 card-btm-border card-shadow-danger border-danger card"">
                    <div class=""widget-chat-wrapper-outer"">
                        <div class=""widget-chart-content"">
                            <div class=""widget-title opacity-5 text-uppercase"">Total Certificate</div>
                            <div class=""widget-numbers mt-2 fsize-2 mb-0 w-100"">
                                <div class=""widget-chart-flex align-items-center"">
                                    <div>
                                        <span class=""opacity-10 text-success pr-2"">
                                            <i class=""fa fa-angle-down""></i>
                                        </span>
                                        <label id=""lbl_tot");
            WriteLiteral(@"al_certificate_approval_pending""></label>
                                        <div class=""card-header-title"" style=""font-size: small;"">pending for approval</div>
                                    </div>
                                    <div class=""widget-title ml-auto font-size-lg font-weight-normal text-muted"">
                                        <div class=""circle-progress circle-progress-success-sm d-inline-block"">
                                            <small></small>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-md-6 col-lg-3"">
                <div class=""widget-chart widget-chart2 text-left mb-3 card-btm-border card-shadow-warning border-warning card"">
                    <div class=""widget-chat-wrapper-outer"">
                ");
            WriteLiteral(@"        <div class=""widget-chart-content"">
                            <div class=""widget-title opacity-5 text-uppercase"">Total Certificate</div>
                            <div class=""widget-numbers mt-2 fsize-4 mb-0 w-100"">
                                <div class=""widget-chart-flex align-items-center"">
                                    <div>
                                        <span class=""opacity-10 text-success pr-2"">
                                            <i class=""fa fa-angle-down""></i>
                                        </span>
                                        <label id=""lbl_total_cancelled_certificate""></label>
                                        <div class=""card-header-title"" style=""font-size: small;"">Cancelled</div>
                                    </div>
                                    <div class=""widget-title ml-auto font-size-lg font-weight-normal text-muted"">
                                        <div class=""circle-progress circle-progress-warn");
            WriteLiteral(@"ing-sm d-inline-block"">
                                            <small></small>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-md-6 col-lg-3"">
                <div class=""widget-chart widget-chart2 text-left mb-3 card-btm-border card-shadow-success border-success card"">
                    <div class=""widget-chat-wrapper-outer"">
                        <div class=""widget-chart-content"">
                            <div class=""widget-title opacity-5 text-uppercase"">Total Certificate</div>
                            <div class=""widget-numbers mt-2 fsize-4 mb-0 w-100"">
                                <div class=""widget-chart-flex align-items-center"">
                                    <div>
                                        <span class=""opaci");
            WriteLiteral(@"ty-10 text-warning pr-2"">
                                            <i class=""fa fa-angle-down""></i>
                                        </span>
                                        <label id=""lbl_total_cancel_certificate""></label>
                                        <div class=""card-header-title"" style=""font-size: small;"">pending for cancellation</div>
                                    </div>
                                    <div class=""widget-title ml-auto font-size-lg font-weight-normal text-muted"">
                                        <div class=""circle-progress circle-progress-success-sm d-inline-block"">
                                            <small></small>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class=""row"">
");
            WriteLiteral(@"            <div class=""col-md-6"">
                <div class=""main-card mb-3 card"">
                    <div class=""card-header-tab card-header-tab-animation card-header"">
                        <div class=""card-header-title"">
                            <i class=""header-icon lnr-apartment icon-gradient bg-love-kiss""> </i>
                            ");
#nullable restore
#line 141 "C:\Pesticide Design\PCVMS.Presentation\Views\PesticideCertificate\Dashboard.cshtml"
                       Write(Localizer["review_pending"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>
                    <table style=""width: 100%;"" id=""tbl-fertilizer-certificate-review-list"" name=""tbl-fertilizer-certificate-review-list"" class=""table table-hover table-striped table-bordered"">
                        <thead>
                            <tr>
                                <th class=""bg-moi-gold"" style=""text-align:center;""><i class=""pe-7s-magic-wand btn-icon-wrapper""> </i> ");
#nullable restore
#line 147 "C:\Pesticide Design\PCVMS.Presentation\Views\PesticideCertificate\Dashboard.cshtml"
                                                                                                                                 Write(Localizer["company"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                <th class=\"bg-moi-gold\" style=\"text-align:center;\"><i class=\"pe-7s-magic-wand btn-icon-wrapper\"> </i> ");
#nullable restore
#line 148 "C:\Pesticide Design\PCVMS.Presentation\Views\PesticideCertificate\Dashboard.cshtml"
                                                                                                                                 Write(Localizer["status"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                <th class=\"bg-moi-gold\" style=\"text-align:center;\"><i class=\"pe-7s-magic-wand btn-icon-wrapper\"> </i> ");
#nullable restore
#line 149 "C:\Pesticide Design\PCVMS.Presentation\Views\PesticideCertificate\Dashboard.cshtml"
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
            </div>
            <div class=""col-md-6"">
                <div class=""main-card mb-3 card"">
                    <div class=""card-header-tab card-header-tab-animation card-header"">
                        <div class=""card-header-title"">
                            <i class=""header-icon lnr-apartment icon-gradient bg-love-kiss""> </i>
                            ");
#nullable restore
#line 161 "C:\Pesticide Design\PCVMS.Presentation\Views\PesticideCertificate\Dashboard.cshtml"
                       Write(Localizer["approval_pending"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>
                    <table style=""width: 100%;"" id=""tbl-fertilizer-certificate-approval-list"" name=""tbl-fertilizer-certificate-approval-list"" class=""table table-hover table-striped table-bordered"">
                        <thead>
                            <tr>
                                <th class=""bg-moi-gold"" style=""text-align:center;""><i class=""pe-7s-magic-wand btn-icon-wrapper""> </i> ");
#nullable restore
#line 167 "C:\Pesticide Design\PCVMS.Presentation\Views\PesticideCertificate\Dashboard.cshtml"
                                                                                                                                 Write(Localizer["company"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                <th class=\"bg-moi-gold\" style=\"text-align:center;\"><i class=\"pe-7s-magic-wand btn-icon-wrapper\"> </i> ");
#nullable restore
#line 168 "C:\Pesticide Design\PCVMS.Presentation\Views\PesticideCertificate\Dashboard.cshtml"
                                                                                                                                 Write(Localizer["status"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                <th class=\"bg-moi-gold\" style=\"text-align:center;\"><i class=\"pe-7s-magic-wand btn-icon-wrapper\"> </i> ");
#nullable restore
#line 169 "C:\Pesticide Design\PCVMS.Presentation\Views\PesticideCertificate\Dashboard.cshtml"
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
            </div>
        </div>

        <div class=""row"">
            <div class=""col-lg-12"">

                <div class=""card"">
                    <div class=""card-header card-success"">
                        <div class=""d-flex justify-content-between"">
                            <i class=""fa fa-bar-chart nav-icon""></i>
                            <span class=""text-bold text-lg"" id=""txtlease"">Certificate<span class=""peie-legend-dashboard"">(in Number)</span> </span>
                        </div>
                    </div>
                    <div class=""d-flex justify-content-between"">
                        <div id=""barchartlocal"" style=""width:84%;""></div>
                    </div>
                    <div id='barchartlocal_legend' class='text-center'></div>
                </div>

                <!-- /.card --");
            WriteLiteral(">\r\n            </div>\r\n        </div>\r\n        <!-- /.row -->\r\n\r\n    </div>\r\n\r\n</div>\r\n\r\n<script src=\"https://cdnjs.cloudflare.com/ajax/libs/raphael/2.1.2/raphael-min.js\"></script>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a93df8c72bb71fe6bbc0d467df415be9ec7388f921796", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<script src=\"https://cdnjs.cloudflare.com/ajax/libs/prettify/r224/prettify.min.js\"></script>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a93df8c72bb71fe6bbc0d467df415be9ec7388f922934", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PCVMS.Model.Web.DashboardModel> Html { get; private set; }
    }
}
#pragma warning restore 1591