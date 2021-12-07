#pragma checksum "C:\Users\HP\Documents\API\LeaveAPI\Client\Views\Home\RequestLeave.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "45b92aea837b475f629fa4b9395a6074f408554a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_RequestLeave), @"mvc.1.0.view", @"/Views/Home/RequestLeave.cshtml")]
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
#line 1 "C:\Users\HP\Documents\API\LeaveAPI\Client\Views\_ViewImports.cshtml"
using Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\Documents\API\LeaveAPI\Client\Views\_ViewImports.cshtml"
using Client.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"45b92aea837b475f629fa4b9395a6074f408554a", @"/Views/Home/RequestLeave.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3332004e6f18ccbec22253d7e177fe1fd5f40969", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_RequestLeave : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formValidation"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\HP\Documents\API\LeaveAPI\Client\Views\Home\RequestLeave.cshtml"
  
    ViewData["Title"] = "RequestLeave";
    Layout = "_LayoutLeaveApp";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<h1>List Data Employee</h1>

<p></p>
<button class=""btn btn-primary fa fa-save"" data-toggle=""modal"" data-target=""#modalPokemon""> Masukkan Data </button>
<p></p>

<button class=""btn btn-secondary far fa-copy"" aria-hidden=""true"" onclick=""ExportToCopy();""> Copy </button>
<button class=""btn btn-success far fa-file-excel"" aria-hidden=""true"" onclick=""ExportToExcel();""> Excel </button>
<button class=""btn btn-danger far fa-file-pdf"" aria-hidden=""true"" onclick=""ExportToPDF();""> PDF </button>
<button class=""btn btn-info"" onclick=""ExportToCSV();""><i class=""fas fa-file-csv""></i> CSV </button>
<p></p>
");
            WriteLiteral(@"
<table id=""tabelPokemon"" class=""table table-primary"">
    <thead>
        <tr>
            <th>NIK</th>
            <th>Full Name</th>
            <th>Phone Number</th>
            <th>Birth Date</th>
            <th>Salary</th>
            <th>Email</th>
            <th>Gender</th>
            <th>Action</th>
        </tr>
    </thead>
    <tbody id=""tablePoke"">
    </tbody>
</table>
");
            WriteLiteral(@"
<!-- Modal -->
<div class=""modal fade"" id=""modalPokemon"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Tambahkan Data</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"" onclick=""window.location.reload();"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "45b92aea837b475f629fa4b9395a6074f408554a5723", async() => {
                WriteLiteral(@"
                    <div class=""form-row"">
                        <div class=""col-md-4 mb-3"">
                            <label>NIK</label>
                            <input type=""text"" class=""form-control"" id=""nik"" name=""nik"" placeholder=""NIK"" required>
                        </div>
                        <div class=""col-md-4 mb-3"">
                            <label>First Name</label>
                            <input type=""text"" class=""form-control"" id=""firstName"" name=""firstName"" placeholder=""First Name"" required>
                        </div>
                        <div class=""col-md-4 mb-3"">
                            <label>Last Name</label>
                            <input type=""text"" class=""form-control"" id=""lastName"" name=""lastName"" placeholder=""Last Name"" required>
                        </div>
                    </div>
                    <div class=""form-row"">
                        <div class=""col-md-4 mb-3"">
                            <label>Phone Number</label>");
                WriteLiteral(@"
                            <input type=""text"" class=""form-control"" id=""phoneNumber"" name=""phoneNumber"" placeholder=""Phone Number"" required>
                        </div>
                        <div class=""col-md-4 mb-3"">
                            <label>Birth Date</label>
                            <input type=""date"" class=""form-control"" id=""birthDate"" name=""birthDate"" placeholder=""Birth Date"" required>
                        </div>
                        <div class=""col-md-4 mb-3"">
                            <label>Salary</label>
                            <input type=""number"" class=""form-control"" id=""salary"" name=""salary"" placeholder=""Salary"" required>
                        </div>
                    </div>
                    <div class=""form-row"">
                        <div class=""col-md-4 mb-3"">
                            <label>Email</label>
                            <input type=""text"" class=""form-control"" id=""email"" name=""email"" placeholder=""Email"" required>
          ");
                WriteLiteral("              </div>\r\n                        <div class=\"col-md-4 mb-3\">\r\n                            <label>Gender</label>\r\n                            <select class=\"form-control\" id=\"gender\">\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "45b92aea837b475f629fa4b9395a6074f408554a8430", async() => {
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
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "45b92aea837b475f629fa4b9395a6074f408554a9802", async() => {
                    WriteLiteral("Male");
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
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "45b92aea837b475f629fa4b9395a6074f408554a10846", async() => {
                    WriteLiteral("Female");
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
                        <div class=""col-md-4 mb-3"">
                            <label>Password</label>
                            <input type=""password"" class=""form-control"" id=""password"" name=""password"" placeholder=""Password"" required>
                        </div>
                    </div>
                    <div class=""form-row"">
                        <div class=""col-md-4 mb-3"">
                            <label>Degree</label>
                            <input type=""text"" class=""form-control"" id=""degree"" name=""degree"" placeholder=""Degree"" required>
                        </div>
                        <div class=""col-md-4 mb-3"">
                            <label>GPA</label>
                            <input type=""number"" class=""form-control"" id=""gpa"" name=""gpa"" placeholder=""GPA"" required>
                        </div>
                        <div class=""col-md-4 mb-3"">
");
                WriteLiteral(@"                            <label>University ID</label>
                            <input type=""number"" class=""form-control"" id=""universityId"" name=""universityId"" placeholder=""UniversityId"" required>
                        </div>
                    </div>
                    <div class=""form-group"">
");
                WriteLiteral(@"                        <label>Role ID</label>
                        <input type=""number"" class=""form-control"" id=""roleId"" name=""roleId"" placeholder=""RoleId"" required>
                    </div>
                    <div class=""modal-footer"">
                        <button type=""button"" class=""btn btn-danger"" data-dismiss=""modal"" onclick=""window.location.reload();"">Close</button>
                        <button id=""btnDaftar"" type=""submit"" class=""btn btn-info"">Daftar</button>
                        <button id=""btnUpdate"" type=""button"" class=""btn btn-warning"" style=""display:none;"" onclick=""updateData();"">Simpan Data</button>
                    </div>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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