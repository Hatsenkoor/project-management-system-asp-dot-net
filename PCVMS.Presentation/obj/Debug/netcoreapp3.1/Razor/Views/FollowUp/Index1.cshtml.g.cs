#pragma checksum "E:\C#\123\pms_saif\PCVMS.Presentation\Views\FollowUp\Index1.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f6a2ae6eafeee25de43cf3f846a816dd38c4a137"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FollowUp_Index1), @"mvc.1.0.view", @"/Views/FollowUp/Index1.cshtml")]
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
#line 1 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\FollowUp\Index1.cshtml"
using PCVMS.Presentation.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6a2ae6eafeee25de43cf3f846a816dd38c4a137", @"/Views/FollowUp/Index1.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dcea06301feab613317ca7b5af393de8144b817c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_FollowUp_Index1 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PCVMS.Model.Web.PCVMS_Project_Model>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/AppJs/Followup.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "E:\C#\123\pms_saif\PCVMS.Presentation\Views\FollowUp\Index1.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var Localizer = await obj.GetAllResource();


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral(@"

<div class=""tab-content"">

    <div class=""main-card mb-3 card"">
        <div class=""card-body"">
            <div id=""smartwizard"">
                <ul class=""forms-wizard"">
                    <li>
                        <a href=""#step-1"">
                            <em>1</em><span>Account Information</span>
                        </a>
                    </li>
                    <li>
                        <a href=""#step-2"">
                            <em>2</em><span>Payment Information</span>
                        </a>
                    </li>
                    <li>
                        <a href=""#step-3"">
                            <em>3</em><span>Finish Wizard</span>
                        </a>
                    </li>
                </ul>
                <div class=""form-wizard-content"">
                    <div id=""step-1"">
                        <div id=""smartwizard-draft"" class=""forms-wizard-vertical"">
                            <ul class=""forms-wizard""");
            WriteLiteral(@">
                                <li>
                                    <a href=""#step-122"">
                                        <em>1</em><span>Account Information</span>
                                    </a>
                                </li>
                                <li>
                                    <a href=""#step-222"">
                                        <em>2</em><span>Payment Information</span>
                                    </a>
                                </li>
                                <li>
                                    <a href=""#step-322"">
                                        <em>3</em><span>Finish Wizard</span>
                                    </a>
                                </li>
                            </ul>
                            <div class=""form-wizard-content"">
                                <div id=""step-122"">
                                    <div class=""card-body"">
                                ");
            WriteLiteral(@"        <div class=""position-relative form-group"">
                                            <label for=""exampleEmail5"">Input without validation</label>
                                            <input type=""text"" class=""form-control"">
                                            <div class=""invalid-feedback"">You will not be able to see this</div>
                                            <small class=""form-text text-muted"">Example help text that remains unchanged.</small>
                                        </div>
                                        <div class=""position-relative form-group"">
                                            <label for=""exampleEmail6"">Valid  input</label>
                                            <input type=""text"" class=""is-valid form-control"">
                                            <div class=""valid-feedback"">Sweet! that name is available</div>
                                            <small class=""form-text text-muted"">Example help text that rema");
            WriteLiteral(@"ins unchanged.</small>
                                        </div>
                                        <div class=""position-relative form-group"">
                                            <label for=""examplePassword"">Invalid input</label>
                                            <input type=""text"" class=""is-invalid form-control"">
                                            <div class=""invalid-feedback"">Oh noes! that name is already taken</div>
                                            <small class=""form-text text-muted"">Example help text that remains unchanged.</small>
                                        </div>
                                        <div class=""position-relative form-group"">
                                            <label for=""exampleEmail7"">Input without validation</label>
                                            <input type=""text"" class=""form-control"">
                                            <div class=""invalid-tooltip"">You will not be able to see thi");
            WriteLiteral(@"s</div>
                                            <small class=""form-text text-muted"">Example help text that remains unchanged.</small>
                                        </div>
                                        <div class=""position-relative form-group"">
                                            <label for=""exampleEmail"">Valid input</label>
                                            <input type=""text"" class=""is-valid form-control"">
                                            <div class=""valid-tooltip"">Sweet! that name is available</div>
                                            <small class=""form-text text-muted"">Example help text that remains unchanged.</small>
                                        </div>
                                        <div class=""position-relative form-group"">
                                            <label for=""examplePassword"">Invalid input</label>
                                            <input type=""text"" class=""is-invalid form-control"">
  ");
            WriteLiteral(@"                                          <div class=""invalid-tooltip"">Oh noes! that name is already taken</div>
                                            <small class=""form-text text-muted"">Example help text that remains unchanged.</small>
                                        </div>
                                    </div>
                                </div>
                                <div id=""step-222"">
                                    <div id=""accordion"" class=""accordion-wrapper mb-3"">
                                        <div class=""card"">
                                            <div id=""headingTwo"" class=""b-radius-0 card-header"">
                                                <button type=""button"" data-toggle=""collapse"" data-target=""#collapseTwo"" aria-expanded=""false"" aria-controls=""collapseTwo""
                                                        class=""text-left m-0 p-0 btn btn-link btn-block"">
                                                    <span class=""form");
            WriteLiteral(@"-heading"">Credit Card Informations<p>Enter your user informations below</p></span>
                                                </button>
                                            </div>
                                            <div data-parent=""#accordion"" id=""collapseTwo"" class=""collapse show"">
                                                <div class=""card-body"">
                                                    <div class=""position-relative form-group"">
                                                        <label for=""exampleEmail3"">Plain Text (Static)</label>
                                                        <p class=""form-control-plaintext"">Some plain text/ static value</p>
                                                    </div>
                                                    <div class=""position-relative form-group"">
                                                        <label for=""exampleEmail4"">Email</label>
                                                      ");
            WriteLiteral(@"  <input name=""email"" id=""exampleEmail4"" placeholder=""with a placeholder"" type=""email"" class=""form-control"">
                                                    </div>
                                                    <div class=""position-relative form-group"">
                                                        <label for=""examplePassword"">Password</label>
                                                        <input name=""password"" id=""examplePassword"" placeholder=""password placeholder"" type=""password"" class=""form-control"">
                                                    </div>
                                                    <div class=""position-relative form-group"">
                                                        <label for=""exampleUrl"">Url</label>
                                                        <input name=""url"" id=""exampleUrl"" placeholder=""url placeholder"" type=""url"" class=""form-control"">
                                                    </div>
                  ");
            WriteLiteral(@"                                  <div class=""position-relative form-group"">
                                                        <label for=""exampleNumber"">Number</label>
                                                        <input name=""number"" id=""exampleNumber"" placeholder=""number placeholder"" type=""number"" class=""form-control"">
                                                    </div>
                                                    <div class=""position-relative form-group"">
                                                        <label for=""exampleDatetime"">Datetime</label>
                                                        <input name=""datetime"" id=""exampleDatetime"" placeholder=""datetime placeholder"" type=""datetime"" class=""form-control"">
                                                    </div>
                                                    <div class=""position-relative form-group"">
                                                        <label for=""exampleDate"">Date</label");
            WriteLiteral(@">
                                                        <input name=""date"" id=""exampleDate"" placeholder=""date placeholder"" type=""date"" class=""form-control"">
                                                    </div>
                                                    <div class=""position-relative form-group"">
                                                        <label for=""exampleTime"">Time</label>
                                                        <input name=""time"" id=""exampleTime"" placeholder=""time placeholder"" type=""time"" class=""form-control"">
                                                    </div>
                                                    <div class=""position-relative form-group"">
                                                        <label for=""exampleColor"">Color</label>
                                                        <input name=""color"" id=""exampleColor"" placeholder=""color placeholder"" type=""color"" class=""form-control"">
                                       ");
            WriteLiteral(@"             </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id=""step-322"">
                                    <div class=""no-results"">
                                        <div class=""swal2-icon swal2-success swal2-animate-success-icon"">
                                            <div class=""swal2-success-circular-line-left"" style=""background-color: rgb(255, 255, 255);""></div>
                                            <span class=""swal2-success-line-tip""></span>
                                            <span class=""swal2-success-line-long""></span>
                                            <div class=""swal2-success-ring""></div>
                                            <div class=""swal2-success-fix"" style=""background-color: rgb(255, 255, 255);""></div>
   ");
            WriteLiteral(@"                                         <div class=""swal2-success-circular-line-right"" style=""background-color: rgb(255, 255, 255);""></div>
                                        </div>
                                        <div class=""results-subtitle mt-4"">Finished!</div>
                                        <div class=""results-title"">You arrived at the last form wizard step!</div>
                                        <div class=""mt-3 mb-3""></div>
                                        <div class=""text-center"">
                                            <button class=""btn-shadow btn-wide btn btn-success btn-lg"">Finish</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""divider""></div>
                        <div class=""clearfix"">
                            <button type=""button"" id=""reset-btn22"" ");
            WriteLiteral(@"class=""btn-shadow float-left btn btn-link"">Reset</button>
                            <button type=""button"" id=""next-btn22"" class=""btn-shadow btn-wide float-right btn-pill btn-hover-shine btn btn-success"">Next</button>
                            <button type=""button"" id=""prev-btn22"" class=""btn-shadow float-right btn-wide btn-pill mr-3 btn btn-outline-secondary"">Previous</button>
                        </div>
                    </div>
                    <div id=""step-2"">
                        <div id=""accordion"" class=""accordion-wrapper mb-3"">
                            <div class=""card"">
                                <div id=""headingOne"" class=""card-header"">
                                    <button type=""button"" data-toggle=""collapse"" data-target=""#collapseOne"" aria-expanded=""false""
                                            aria-controls=""collapseOne"" class=""text-left m-0 p-0 btn btn-link btn-block"">
                                        <span class=""form-heading"">Account Informatio");
            WriteLiteral(@"n<p>Enter your  user informations below</p></span>
                                    </button>
                                </div>
                                <div data-parent=""#accordion"" id=""collapseOne"" aria-labelledby=""headingOne"" class=""collapse show"">
                                    <div class=""card-body"">
                                        <div class=""form-row"">
                                            <div class=""col-md-6"">
                                                <div class=""position-relative form-group"">
                                                    <label for=""exampleEmail2"">Email</label>
                                                    <input name=""email"" id=""exampleEmail2"" placeholder=""with a placeholder"" type=""email"" class=""form-control"">
                                                </div>
                                            </div>
                                            <div class=""col-md-6"">
                                      ");
            WriteLiteral(@"          <div class=""position-relative form-group"">
                                                    <label for=""examplePassword"">Password</label>
                                                    <input name=""password"" id=""examplePassword"" placeholder=""password placeholder"" type=""password"" class=""form-control"">
                                                </div>
                                            </div>
                                        </div>
                                        <div class=""position-relative form-group"">
                                            <label for=""exampleAddress"">Address</label>
                                            <input name=""address"" id=""exampleAddress"" placeholder=""1234 Main St"" type=""text"" class=""form-control"">
                                        </div>
                                        <div class=""position-relative form-group"">
                                            <label for=""exampleAddress2"">Address 2</label>
");
            WriteLiteral(@"                                            <input name=""address2"" id=""exampleAddress2"" placeholder=""Apartment, studio, or floor"" type=""text"" class=""form-control"">
                                        </div>
                                        <div class=""form-row"">
                                            <div class=""col-md-6"">
                                                <div class=""position-relative form-group"">
                                                    <label for=""exampleCity"">City</label>
                                                    <input name=""city"" id=""exampleCity"" type=""text"" class=""form-control"">
                                                </div>
                                            </div>
                                            <div class=""col-md-4"">
                                                <div class=""position-relative form-group"">
                                                    <label for=""exampleState"">State</label>
            ");
            WriteLiteral(@"                                        <input name=""state"" id=""exampleState"" type=""text"" class=""form-control"">
                                                </div>
                                            </div>
                                            <div class=""col-md-2"">
                                                <div class=""position-relative form-group"">
                                                    <label for=""exampleZip"">Zip</label>
                                                    <input name=""zip"" id=""exampleZip"" type=""text"" class=""form-control"">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id=""step-3"">
                        <div class=""no-results"">
        ");
            WriteLiteral(@"                    <div class=""swal2-icon swal2-success swal2-animate-success-icon"">
                                <div class=""swal2-success-circular-line-left"" style=""background-color: rgb(255, 255, 255);""></div>
                                <span class=""swal2-success-line-tip""></span>
                                <span class=""swal2-success-line-long""></span>
                                <div class=""swal2-success-ring""></div>
                                <div class=""swal2-success-fix"" style=""background-color: rgb(255, 255, 255);""></div>
                                <div class=""swal2-success-circular-line-right"" style=""background-color: rgb(255, 255, 255);""></div>
                            </div>
                            <div class=""results-subtitle mt-4"">Finished!</div>
                            <div class=""results-title"">You arrived at the last form wizard step!</div>
                            <div class=""mt-3 mb-3""></div>
                            <div class=""text-ce");
            WriteLiteral(@"nter"">
                                <button class=""btn-shadow btn-wide btn btn-success btn-lg"">Finish</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""divider""></div>
            <div class=""clearfix"">
                <button type=""button"" id=""reset-btn"" class=""btn-shadow float-left btn btn-link"">Reset</button>
                <button type=""button"" id=""next-btn"" class=""btn-shadow btn-wide float-right btn-pill btn-hover-shine btn btn-success"">Next</button>
                <button type=""button"" id=""prev-btn"" class=""btn-shadow float-right btn-wide btn-pill mr-3 btn btn-outline-secondary"">Previous</button>
            </div>
        </div>
    </div>

</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f6a2ae6eafeee25de43cf3f846a816dd38c4a13724662", async() => {
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PCVMS.Model.Web.PCVMS_Project_Model> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
