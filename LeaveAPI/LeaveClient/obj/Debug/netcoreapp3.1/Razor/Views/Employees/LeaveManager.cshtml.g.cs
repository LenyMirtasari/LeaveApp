#pragma checksum "D:\MCC\LeaveApp\LeaveAPI\LeaveClient\Views\Employees\LeaveManager.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "237446b001ea92b3ca2930c2b000f14824899db0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employees_LeaveManager), @"mvc.1.0.view", @"/Views/Employees/LeaveManager.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"237446b001ea92b3ca2930c2b000f14824899db0", @"/Views/Employees/LeaveManager.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf4c8f0a5faf6bb8a903add0fdcab35373b34831", @"/Views/_ViewImports.cshtml")]
    public class Views_Employees_LeaveManager : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("needs-validation"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("LeaveManagerForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/vendor/datatables/jquery.dataTables.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/vendor/datatables/dataTables.bootstrap4.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/js/demo/datatables-demo.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/LeaveManager.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "D:\MCC\LeaveApp\LeaveAPI\LeaveClient\Views\Employees\LeaveManager.cshtml"
  
    Layout = "_LeaveLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
    <div class=""col-12"">
        <div class=""card"">
            <div class=""card-header"">
                <h3 class=""card-title"">Leave Requester Data</h3>
             
            </div>
            <!-- /.card-header -->
            <div class=""card-body"">
                <table id=""leaveManager""  class=""table-bordered table-striped"" style=""width:100%"">
                    <thead>
                        <tr>
                            <th>No</th>
                           
                            <th>Employee ID </th>
                            <th>Full Name</th>
                            <th>Job Tittle</th>
                            <th>Email</th>
                            <th>Phone Number</th>
                            <th>Submit Date</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody");
            BeginWriteAttribute("id", " id=\"", 1100, "\"", 1105, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    </tbody>
                </table>

            </div>
        </div>
    </div>
</div>

<div class=""modal fade"" id=""ModalLeave"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalCenterTitle"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLongTitle"">Leave Details</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "237446b001ea92b3ca2930c2b000f14824899db07666", async() => {
                WriteLiteral("\r\n                    <div class=\"row form-group\">\r\n                        <div class=\"col\">\r\n");
                WriteLiteral("                             <label for=\"leaveDetailId\" >Leave Request ID</label>\r\n                            <input type=\"text\" class=\"form-control\" name=\"leaveDetailId\" id=\"leaveDetailId1\" aria-describedby=\"emailHelp\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 2367, "\"", 2381, 0);
                EndWriteAttribute();
                WriteLiteral(@" disabled>
                            <small id=""coba"" class=""form-text text-muted""> </small>
                        </div>
                        <div class=""col"">
                            <label for=""employeeId"">Employee ID</label>
                            <input type=""text"" id=""employeeId1"" name=""employeeId"" class=""form-control""");
                BeginWriteAttribute("placeholder", " placeholder=\"", 2729, "\"", 2743, 0);
                EndWriteAttribute();
                WriteLiteral(" disabled>\r\n                        </div>\r\n                        <div class=\"col\">\r\n                            <label for=\"fullName\">Name</label>\r\n                            <input type=\"text\" id=\"fullName1\" name=\"fullName\" class=\"form-control\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 2993, "\"", 3007, 0);
                EndWriteAttribute();
                WriteLiteral(@" disabled>
                        </div>
                    </div>


                    <div class=""row form-group"">


                        <div class=""col"">
                            <label for=""startDate"">Start Date</label>
                            <input type=""text"" name=""startDate"" id=""startDate1"" class=""form-control""");
                BeginWriteAttribute("placeholder", " placeholder=\"", 3352, "\"", 3366, 0);
                EndWriteAttribute();
                WriteLiteral(" disabled>\r\n                        </div>\r\n                        <div class=\"col\">\r\n                            <label for=\"endDate\">End Date</label>\r\n                            <input type=\"text\" name=\"endDate\" id=\"endDate1\" class=\"form-control\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 3617, "\"", 3631, 0);
                EndWriteAttribute();
                WriteLiteral(@" disabled>
                        </div>
                        <div class=""col"">
                            <label for=""leaveType"">Leave Type</label>
                            <input type=""text"" id=""leaveType1"" name=""leaveType"" class=""form-control""");
                BeginWriteAttribute("placeholder", " placeholder=\"", 3890, "\"", 3904, 0);
                EndWriteAttribute();
                WriteLiteral(@" disabled>
                        </div>
                    </div>
                    <div class=""row form-group"">
                        <div class=""col"">
                            <label for=""note"">Note</label>
                            <input type=""text"" id=""note1"" name=""note"" class=""form-control""");
                BeginWriteAttribute("placeholder", " placeholder=\"", 4220, "\"", 4234, 0);
                EndWriteAttribute();
                WriteLiteral(" disabled>\r\n                        </div>\r\n\r\n                    </div>\r\n\r\n\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n            <div class=\"modal-footer\">\r\n                <button type=\"button\" class=\"btn btn-secondary\" data-dismiss=\"modal\">Close</button>\r\n");
            WriteLiteral(@"                <button type=""button"" class=""btn btn-danger"" onclick=""Disapprove(document.getElementById('leaveDetailId1').value)"">Disapprove</button>
                <button type=""button"" class=""btn btn-success"" onclick=""Approve(document.getElementById('leaveDetailId1').value)"">Approve</button>
            </div>
        </div>
    </div>
</div>
");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "237446b001ea92b3ca2930c2b000f14824899db013240", async() => {
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
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "237446b001ea92b3ca2930c2b000f14824899db014344", async() => {
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
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "237446b001ea92b3ca2930c2b000f14824899db015448", async() => {
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
                WriteLiteral("\r\n\r\n\r\n");
                WriteLiteral(@"        <script type=""text/javascript"" charset=""utf-8"" src=""https://cdn.datatables.net/buttons/2.0.1/js/dataTables.buttons.min.js""></script>
        <script type=""text/javascript"" charset=""utf-8"" src=""https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js""></script>
        <script type=""text/javascript"" charset=""utf-8"" src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js""></script>
        <script type=""text/javascript"" charset=""utf-8"" src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js""></script>
        <script type=""text/javascript"" charset=""utf-8"" src=""https://cdn.datatables.net/buttons/2.0.1/js/buttons.html5.min.js""></script>
        <script type=""text/javascript"" charset=""utf-8"" src=""https://cdn.datatables.net/buttons/2.0.1/js/buttons.print.min.js""></script>
");
                WriteLiteral("        <script src=\"https://cdn.jsdelivr.net/npm/apexcharts\"></script>\r\n        <script>\r\n\r\n        </script>\r\n\r\n\r\n");
                WriteLiteral("        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "237446b001ea92b3ca2930c2b000f14824899db017664", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n    ");
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