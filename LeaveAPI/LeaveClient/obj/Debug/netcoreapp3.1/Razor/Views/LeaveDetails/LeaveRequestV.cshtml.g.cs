#pragma checksum "D:\MCC\LeaveApp\LeaveAPI\LeaveClient\Views\LeaveDetails\LeaveRequestV.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "acdd7e02071ff18e00bd5cc576ba639ba7769611"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LeaveDetails_LeaveRequestV), @"mvc.1.0.view", @"/Views/LeaveDetails/LeaveRequestV.cshtml")]
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
#line 1 "D:\MCC\LeaveApp\LeaveAPI\LeaveClient\Views\_ViewImports.cshtml"
using LeaveClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MCC\LeaveApp\LeaveAPI\LeaveClient\Views\_ViewImports.cshtml"
using LeaveClient.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acdd7e02071ff18e00bd5cc576ba639ba7769611", @"/Views/LeaveDetails/LeaveRequestV.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf4c8f0a5faf6bb8a903add0fdcab35373b34831", @"/Views/_ViewImports.cshtml")]
    public class Views_LeaveDetails_LeaveRequestV : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formRequestLeave"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("saveLeaveRequest"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/LeaveRequest.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\MCC\LeaveApp\LeaveAPI\LeaveClient\Views\LeaveDetails\LeaveRequestV.cshtml"
  
    ViewData["Title"] = "RequestLeave";
    Layout = "_LayoutLeaveApp";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<h1>Request Leave</h1>

<!-- Modal -->
<div class=""wrapper"">
    <div class=""container-fluid"">

        <div class=""row"">
            <div class=""col-12"">
                <div class=""card m-b-20"">
                    <div id=""requesterInfo"" class=""card-body"" style=""padding-left: 100px; padding-right: 100px;"">
                        <br>
                        <h4>Requester Information</h4>
                        <hr>
                        <div class=""form-group row"">
                            <label class=""col-md-4 label-request"">ID :</label>                         
                            <input id=""employeeId"" type=""text"" name=""name""");
            BeginWriteAttribute("value", " value=\"", 755, "\"", 763, 0);
            EndWriteAttribute();
            WriteLiteral(@" disabled/>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-md-4 label-request"">Full Name :</label>
                            <input id=""fullName"" type=""text"" name=""name""");
            BeginWriteAttribute("value", " value=\"", 1022, "\"", 1030, 0);
            EndWriteAttribute();
            WriteLiteral(" disabled />\r\n                        </div>\r\n                        <div class=\"form-group row\">\r\n                            <label class=\"col-md-4 label-request\">Email :</label>\r\n                            <input id=\"email\" type=\"text\" name=\"name\"");
            BeginWriteAttribute("value", " value=\"", 1283, "\"", 1291, 0);
            EndWriteAttribute();
            WriteLiteral(@" disabled />
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-md-4 label-request"">Phone Number :</label>
                            <input id=""phoneNumber"" type=""text"" name=""name""");
            BeginWriteAttribute("value", " value=\"", 1557, "\"", 1565, 0);
            EndWriteAttribute();
            WriteLiteral(@" disabled />
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-md-4 label-request"">Available Leave (Last Year) :</label>
                            <input id=""lastYear"" type=""text"" name=""name""");
            BeginWriteAttribute("value", " value=\"", 1843, "\"", 1851, 0);
            EndWriteAttribute();
            WriteLiteral(@" disabled />
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-md-4 label-request"">Available Leave (Current Year) :</label>
                            <input id=""currentYear"" type=""text"" name=""name""");
            BeginWriteAttribute("value", " value=\"", 2135, "\"", 2143, 0);
            EndWriteAttribute();
            WriteLiteral(@" disabled />
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-md-4 label-request"">Total Leave :</label>
                            <input id=""totalLeaves"" type=""text"" name=""name""");
            BeginWriteAttribute("value", " value=\"", 2408, "\"", 2416, 0);
            EndWriteAttribute();
            WriteLiteral(@" disabled />
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-md-4 label-request"">Eligible Leave :</label>
                            <input id=""eligibleLeave"" type=""text"" name=""name""");
            BeginWriteAttribute("value", " value=\"", 2686, "\"", 2694, 0);
            EndWriteAttribute();
            WriteLiteral(" disabled />\r\n                        </div>\r\n                        <br>\r\n\r\n                        <div class=\"card\">\r\n                            <div class=\"card-header\">Leave Request Detail</div>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "acdd7e02071ff18e00bd5cc576ba639ba77696119521", async() => {
                WriteLiteral("\r\n\r\n                                <input id=\"employeeId1\" type=\"hidden\" name=\"name\"");
                BeginWriteAttribute("value", " value=\"", 3109, "\"", 3117, 0);
                EndWriteAttribute();
                WriteLiteral(@" disabled />
                                <div class=""card-body"">
                                    <div id=""alertReminder""></div>
                                    <div class=""form-group row"">
                                        <label for=""example-text-input"" class=""col-md-4 col-form-label"">
                                            Request Number :
                                        </label>
                                        <div class=""col-md-7 col-form-label"">
                                            <span></span>
                                            <input id=""rNumber"" type=""text"" name=""name""");
                BeginWriteAttribute("value", " value=\"", 3766, "\"", 3774, 0);
                EndWriteAttribute();
                WriteLiteral(@" disabled />
                                        </div>
                                    </div>
                                    <div class=""form-group row"">
                                        <label class=""col-md-4 col-form-label"">Manager ID:</label>
                                        <div class=""col-md-7"">
                                            <span></span>
                                            <input id=""managerId"" type=""text"" name=""name""");
                BeginWriteAttribute("value", " value=\"", 4259, "\"", 4267, 0);
                EndWriteAttribute();
                WriteLiteral(@" disabled />

                                        </div>
                                    </div>
                                    <div class=""form-group row"">
                                        <label class=""col-md-4 col-form-label"">Leave Type ID:</label>
                                        <div class=""col-md-7"">
                                            <select id=""LeaveType"" name=""LeaveType"" class=""form-control"">
                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "acdd7e02071ff18e00bd5cc576ba639ba776961112005", async() => {
                    WriteLiteral("Choose...");
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
                WriteLiteral("\r\n                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "acdd7e02071ff18e00bd5cc576ba639ba776961113394", async() => {
                    WriteLiteral("...");
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
                                        </div>
                                    </div>
                                    <div class=""form-group row"">
                                        <label class=""col-md-4 col-form-label"">Leave Date :</label>
                                        <div class=""col-md-7"">
                                            <span>
                                                <div class=""input-daterange input-group"" id=""date-range"">
                                                    <input id=""startDate"" type=""date"" class=""form-control"" name=""startDate""
                                                           placeholder=""Start Date"" />
                                                    <input type=""text"" id=""setFromDate""");
                BeginWriteAttribute("hidden", " hidden=\"", 5708, "\"", 5717, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
                                                    <input id=""endDate"" type=""date"" class=""form-control"" name=""endDate""
                                                           placeholder=""End Date"" />
                                                </div>
                                            </span>

                                        </div>
                                    </div>
                                    <div class=""form-group row"">
                                        <label class=""col-md-4 col-form-label"">Notes :</label>
                                        <div class=""col-md-7"">
                                            <textarea id=""notes"" name=""notes"" class=""form-control"" maxlength=""225"" rows=""3""
                                                      placeholder=""This notes has a limit of 225 chars.""></textarea>
                                        </div>
                                    </div>



                                </div>
  ");
                WriteLiteral("                          ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                <div class=""form-group row m-t-20"">
                                    <div class=""col-12 text-right pr-5"">

                                        <button type=""submit"" id=""submit"" class=""btn btn-primary"" onclick=""Insert()"" >Save</button>
                                    </div>
                                </div>

                            
                        </div>
                        <br>
                    </div>
                </div>
            </div> <!-- end col -->
        </div> <!-- end row -->
    </div> <!-- end container -->
</div>
<!-- end wrapper -->
");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "acdd7e02071ff18e00bd5cc576ba639ba776961118710", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
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
