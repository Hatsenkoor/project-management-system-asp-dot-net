#pragma checksum "C:\Pesticide Design\PCVMS.Presentation\Views\Alert\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "83de73876fa85023ca3cbbbe73f85ab279225afe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Alert_Index), @"mvc.1.0.view", @"/Views/Alert/Index.cshtml")]
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
#line 2 "C:\Pesticide Design\PCVMS.Presentation\Views\Alert\Index.cshtml"
using PCVMS.Presentation.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83de73876fa85023ca3cbbbe73f85ab279225afe", @"/Views/Alert/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dcea06301feab613317ca7b5af393de8144b817c", @"/Views/_ViewImports.cshtml")]
    public class Views_Alert_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Pesticide Design\PCVMS.Presentation\Views\Alert\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var Localizer = await obj.GetAllResource();

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"main-card mb-3 card\">\r\n    <div class=\"card-header-custom  bg-moi-green\">\r\n        <i class=\"header-icon pe-7s-pen icon-gradient bg-white\"> </i>\r\n        ");
#nullable restore
#line 13 "C:\Pesticide Design\PCVMS.Presentation\Views\Alert\Index.cshtml"
   Write(Localizer["communication_configuration_search"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"card-body\">\r\n        <div class=\"form-row\">\r\n            <div class=\"col-md-4\">\r\n                <div class=\"position-relative form-group\">\r\n                    <label for=\"RoyalDecree\">\r\n                        ");
#nullable restore
#line 21 "C:\Pesticide Design\PCVMS.Presentation\Views\Alert\Index.cshtml"
                   Write(Localizer["category"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                    </label>
                    <div class=""input-group"">
                        <select id=""ealist"" class=""form-control"">                          
                        </select>
                        <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-bookmarks btn-icon-wrapper""> </i></span></div>
                    </div>
                </div>
                </div>
                <div class=""col-md-4"">
                    <div class=""position-relative form-group"">
                        <label for=""ProjectName"">");
#nullable restore
#line 33 "C:\Pesticide Design\PCVMS.Presentation\Views\Alert\Index.cshtml"
                                            Write(Localizer["status"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                        <div class=\"widget-content-left\">\r\n                            <div class=\"input-group\">\r\n                                <select id=\"ealist\" class=\"form-control\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "83de73876fa85023ca3cbbbe73f85ab279225afe5906", async() => {
#nullable restore
#line 37 "C:\Pesticide Design\PCVMS.Presentation\Views\Alert\Index.cshtml"
                                                Write(Localizer["select_value"]);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "83de73876fa85023ca3cbbbe73f85ab279225afe7398", async() => {
                WriteLiteral("Active");
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
            WriteLiteral("\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "83de73876fa85023ca3cbbbe73f85ab279225afe8392", async() => {
                WriteLiteral("de-active");
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
#line 55 "C:\Pesticide Design\PCVMS.Presentation\Views\Alert\Index.cshtml"
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

            <table style=""width: 100%;"" id=""example2"" name=""tbl-resource-history"" class=""table table-hover table-striped table-bordered"">
                <thead>
                    <tr>
                        <th class=""bg-moi-gold"" style=""text-align:center""><i class=""pe-7s-magic-wand btn-icon-wrapper""> </i> ");
#nullable restore
#line 68 "C:\Pesticide Design\PCVMS.Presentation\Views\Alert\Index.cshtml"
                                                                                                                        Write(Localizer["s_no"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        <th class=\"bg-moi-gold\" style=\"text-align:center;\"><i class=\"pe-7s-magic-wand btn-icon-wrapper\"> </i> ");
#nullable restore
#line 69 "C:\Pesticide Design\PCVMS.Presentation\Views\Alert\Index.cshtml"
                                                                                                                         Write(Localizer["name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        <th class=\"bg-moi-gold\" style=\"text-align:center;\"><i class=\"pe-7s-magic-wand btn-icon-wrapper\"> </i> ");
#nullable restore
#line 70 "C:\Pesticide Design\PCVMS.Presentation\Views\Alert\Index.cshtml"
                                                                                                                         Write(Localizer["status"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        <th class=\"bg-moi-gold\" style=\"text-align:center;\"><i class=\"pe-7s-magic-wand btn-icon-wrapper\"> </i> ");
#nullable restore
#line 71 "C:\Pesticide Design\PCVMS.Presentation\Views\Alert\Index.cshtml"
                                                                                                                         Write(Localizer["action"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>

                        <td class=""text-center"">1</td>
                        <td class=""text-center"">Decision Attested</td>
                        <td class=""text-center"">Active</td>
                        <td class=""text-center"" id='tdAction' name='tdAction'><div class='position-relative'><i class=""metismenu-icon lnr-pencil"" style=""cursor: pointer;margin-left: 10px;"" title=""edit""></i><i class=""metismenu-icon lnr-trash"" style=""cursor: pointer;margin-left: 10px;"" title=""delete""></i></div></td>
                    </tr>
                    <tr>

                        <td class=""text-center"">2</td>
                        <td class=""text-center"">Payment Received</td>
                        <td class=""text-center"">Active</td>
                        <td class=""text-center"" id='tdAction' name='tdAction'><div class='position-relative'><i class=""metismenu-icon lnr-pencil"" style=""cursor: p");
            WriteLiteral(@"ointer;margin-left: 10px;"" title=""edit""></i><i class=""metismenu-icon lnr-trash"" style=""cursor: pointer;margin-left: 10px;"" title=""delete""></i></div></td>
                    </tr>
                </tbody>
            </table>
    </div>
</div>

<div class=""main-card mb-3 card"">
    <div class=""card-header-custom  bg-moi-green"">
        <i class=""header-icon pe-7s-pen icon-gradient bg-royal""> </i>

        ");
#nullable restore
#line 98 "C:\Pesticide Design\PCVMS.Presentation\Views\Alert\Index.cshtml"
   Write(Localizer["communication_configuration"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"card-body\">\r\n        <div class=\"form-row\">\r\n            <div class=\"col-md-6\">\r\n                <div class=\"position-relative form-group\">\r\n                    <label for=\"RoyalDecree\">\r\n                        ");
#nullable restore
#line 105 "C:\Pesticide Design\PCVMS.Presentation\Views\Alert\Index.cshtml"
                   Write(Localizer["category"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                    </label>
                    <div class=""input-group"">
                        <select id=""ealist"" class=""form-control"">                         
                        </select>
                        <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-bookmarks btn-icon-wrapper""> </i></span></div>
                    </div>
                </div>
            </div>
            <div class=""col-md-3"">
                <div class=""position-relative form-group"">
                    <label for=""ProjectStartDate"">");
#nullable restore
#line 117 "C:\Pesticide Design\PCVMS.Presentation\Views\Alert\Index.cshtml"
                                             Write(Localizer["start_date"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </label>

                    <div class=""input-group"">
                        <input name=""disputeStartDate"" id=""disputeStartDate"" type=""text"" class=""form-control"">
                        <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-date btn-icon-wrapper""> </i></span></div>
                    </div>
                </div>
            </div>
            <div class=""col-md-3"">
                <div class=""position-relative form-group"">
                    <label for=""ProjectStartDate"">");
#nullable restore
#line 127 "C:\Pesticide Design\PCVMS.Presentation\Views\Alert\Index.cshtml"
                                             Write(Localizer["end_date"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </label>

                    <div class=""input-group"">
                        <input name=""disputeEndDate"" id=""disputeEndDate"" type=""text"" class=""form-control"">
                        <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-date btn-icon-wrapper""> </i></span></div>
                    </div>
                </div>
            </div>
        </div>

        <div class=""form-row"">
            <div class=""col-md-2"">
                <div class=""position-relative form-group"">
                    <label for=""exampleAddress"">");
#nullable restore
#line 140 "C:\Pesticide Design\PCVMS.Presentation\Views\Alert\Index.cshtml"
                                           Write(Localizer["sms"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>


                    <div class=""input-group"">
                        <div class=""custom-checkbox custom-control"">
                            <input type=""checkbox"" id=""chk-sms"" class=""custom-control-input"">
                            <label class=""custom-control-label"" for=""chk-sms"">&nbsp;</label>
                        </div>
                        <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-alarm btn-icon-wrapper""> </i></span></div>
                    </div>
                </div>
            </div>
            <div class=""col-md-2"">
                <div class=""position-relative form-group"">
                    <label for=""exampleAddress"">");
#nullable restore
#line 154 "C:\Pesticide Design\PCVMS.Presentation\Views\Alert\Index.cshtml"
                                           Write(Localizer["email"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>


                    <div class=""input-group"">
                        <div class=""custom-checkbox custom-control"">
                            <input type=""checkbox"" id=""chk-email"" class=""custom-control-input"">
                            <label class=""custom-control-label"" for=""chk-email"">&nbsp;</label>
                        </div>
                        <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-mail-open btn-icon-wrapper""> </i></span></div>
                    </div>
                </div>
            </div>
            <div class=""col-md-2"">
                <div class=""position-relative form-group"">
                    <label for=""exampleAddress"">");
#nullable restore
#line 168 "C:\Pesticide Design\PCVMS.Presentation\Views\Alert\Index.cshtml"
                                           Write(Localizer["media"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>


                    <div class=""input-group"">
                        <div class=""custom-checkbox custom-control"">
                            <input type=""checkbox"" id=""chk-media"" class=""custom-control-input"">
                            <label class=""custom-control-label"" for=""chk-media"">&nbsp;</label>
                        </div>
                        <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-photo btn-icon-wrapper""> </i></span></div>
                    </div>
                </div>
            </div>
            <div class=""col-md-2"">
                <div class=""position-relative form-group"">
                    <label for=""exampleAddress"">");
#nullable restore
#line 182 "C:\Pesticide Design\PCVMS.Presentation\Views\Alert\Index.cshtml"
                                           Write(Localizer["news"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>


                    <div class=""input-group"">
                        <div class=""custom-checkbox custom-control"">
                            <input type=""checkbox"" id=""chk-news"" class=""custom-control-input"">
                            <label class=""custom-control-label"" for=""chk-news"">&nbsp;</label>
                        </div>
                        <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-news-paper btn-icon-wrapper""> </i></span></div>
                    </div>
                </div>
            </div>
            <div class=""col-md-2"">
                <div class=""position-relative form-group"">
                    <label for=""exampleAddress"">");
#nullable restore
#line 196 "C:\Pesticide Design\PCVMS.Presentation\Views\Alert\Index.cshtml"
                                           Write(Localizer["call"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>


                    <div class=""input-group"">
                        <div class=""custom-checkbox custom-control"">
                            <input type=""checkbox"" id=""chk-call"" class=""custom-control-input"">
                            <label class=""custom-control-label"" for=""chk-call"">&nbsp;</label>
                        </div>
                        <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-phone btn-icon-wrapper""> </i></span></div>
                    </div>
                </div>
            </div>
            <div class=""col-md-2"">
                <div class=""position-relative form-group"">
                    <label for=""exampleAddress"">");
#nullable restore
#line 210 "C:\Pesticide Design\PCVMS.Presentation\Views\Alert\Index.cshtml"
                                           Write(Localizer["letter"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>


                    <div class=""input-group"">
                        <div class=""custom-checkbox custom-control"">
                            <input type=""checkbox"" id=""chk-letter"" class=""custom-control-input"">
                            <label class=""custom-control-label"" for=""chk-letter"">&nbsp;</label>
                        </div>
                        <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-notebook btn-icon-wrapper""> </i></span></div>
                    </div>
                </div>
            </div>
        </div>

        <div class=""form-row"">
            <div class=""col-md-10"">
                <div class=""position-relative form-group"">
                    <label for=""exampleAddress"">");
#nullable restore
#line 227 "C:\Pesticide Design\PCVMS.Presentation\Views\Alert\Index.cshtml"
                                           Write(Localizer["remark"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>
                    <div class=""input-group"">
                        <input name=""txtremark"" id=""txtremark"" placeholder=""ready only..."" type=""text"" class=""form-control"">
                        <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-notebook btn-icon-wrapper""> </i></span></div>
                    </div>
                </div>
            </div>
            <div class=""col-md-2"">
                <div class=""position-relative form-group"">
                    <label for=""exampleAddress"">");
#nullable restore
#line 236 "C:\Pesticide Design\PCVMS.Presentation\Views\Alert\Index.cshtml"
                                           Write(Localizer["current_status"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>
                    <div class=""input-group"">
                        <input name=""txtremark"" id=""txtremark"" placeholder=""draft..."" type=""text"" class=""form-control"">
                        <div class=""input-group-append""><span class=""input-group-text""><i class=""pe-7s-notebook btn-icon-wrapper""> </i></span></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""d-block text-right card-footer"">

        <button id=""btnClear"" name=""btnClear"" class=""btn-icon btn-shadow btn-dashed btn btn-moi-gold""><i class=""pe-7s-trash btn-icon-wrapper""> </i>");
#nullable restore
#line 247 "C:\Pesticide Design\PCVMS.Presentation\Views\Alert\Index.cshtml"
                                                                                                                                              Write(Localizer["clear"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n        <button id=\"SearchTransaction\" name=\"SearchTransaction\" class=\"btn-icon btn-shadow btn-dashed btn btn-alternate block-page-btn-example-3\">\r\n            <i class=\"pe-7s-search btn-icon-wrapper\"> </i>");
#nullable restore
#line 249 "C:\Pesticide Design\PCVMS.Presentation\Views\Alert\Index.cshtml"
                                                     Write(Localizer["save"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </button>\r\n    </div>\r\n</div>\r\n\r\n\r\n<!-- Disable tap highlight on IE -->\r\n<meta name=\"msapplication-tap-highlight\" content=\"no\">\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591