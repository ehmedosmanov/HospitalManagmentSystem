#pragma checksum "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\Appointment\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "456dcb89ffca5bec1ff3185f2ee831ea38bfa109"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Appointment_Index), @"mvc.1.0.view", @"/Views/Appointment/Index.cshtml")]
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
#line 1 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\_ViewImports.cshtml"
using HospitalFinalProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\_ViewImports.cshtml"
using HospitalFinalProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\_ViewImports.cshtml"
using HospitalFinalProject.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\_ViewImports.cshtml"
using HospitalFinalProject.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"456dcb89ffca5bec1ff3185f2ee831ea38bfa109", @"/Views/Appointment/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"570c41b2495a14dbb4521136c9257ff27b611fb7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Appointment_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Appointment>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:80px; border-radius:100%; object-fit:cover;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Xəstənin şəkli"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-thumbnail"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Update", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Activity", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\Appointment\Index.cshtml"
Write(await Component.InvokeAsync("PageTitle", new { pageTitle = "Rezervlərin siyahısı", breadcrumbs = new[] { "Rezervlər" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<!-- row -->
<div class=""row"">
    <div class=""col-12"">
        <div class=""card"">
            <div class=""card-header"">
                <h4 class=""card-title"">Rezervlərin siyahısı</h4>
            </div>
            <div class=""card-body"">
                <div class=""table-responsive"">
                    <table id=""dataTable"" class=""display"" style=""min-width: 845px"">
                        <thead>
                            <tr>
                                <th>Xəstənin şəkli</th>
                                <th>Xəstənin adı</th>
                                <th>Xəstənin mobil nömrə</th>
                                <th>Cins</th>
                                <th>Tarix</th>
                                <th>Vaxt</th>
                                <th>Həkim</th>
                                <th>Zədə/Xəstəliy</th>
                                <th>Əməliyyatlar</th>
                            </tr>
                        </thead>
                        <t");
            WriteLiteral("body class=\"black-text\">\r\n");
#nullable restore
#line 29 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\Appointment\Index.cshtml"
                             foreach (Appointment appointment in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "456dcb89ffca5bec1ff3185f2ee831ea38bfa1097743", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1450, "~/images/people/", 1450, 16, true);
#nullable restore
#line 32 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\Appointment\Index.cshtml"
AddHtmlAttributeValue("", 1466, appointment.Patient.Img, 1466, 24, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 33 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\Appointment\Index.cshtml"
                                    Write($"{appointment.Patient.FirstName} {appointment.Patient.LastName}");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 34 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\Appointment\Index.cshtml"
                                   Write(appointment.Patient.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 35 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\Appointment\Index.cshtml"
                                   Write(appointment.Patient.Gender);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n");
#nullable restore
#line 37 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\Appointment\Index.cshtml"
                                          
                                            if (appointment.DateOfAppointment != null)
                                            {
                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\Appointment\Index.cshtml"
                                           Write(appointment.DateOfAppointment.Value.ToString("d"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\Appointment\Index.cshtml"
                                                                                                  
                                            }
                                            else
                                            {
                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\Appointment\Index.cshtml"
                                            Write("N/A");

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\Appointment\Index.cshtml"
                                                        

                                            }
                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </td>\r\n                                    <td>\r\n");
#nullable restore
#line 50 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\Appointment\Index.cshtml"
                                          
                                            if (appointment.From != null && appointment.To != null)
                                            {
                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\Appointment\Index.cshtml"
                                            Write($"{appointment.From.Value.ToString("HH:mm")} - {appointment.To.Value.ToString("HH:mm")}");

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\Appointment\Index.cshtml"
                                                                                                                                           
                                            }
                                            else
                                            {
                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\Appointment\Index.cshtml"
                                            Write("N/A");

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\Appointment\Index.cshtml"
                                                        
                                              
                                            }
                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </td>\r\n                                    <td>Dr. ");
#nullable restore
#line 62 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\Appointment\Index.cshtml"
                                       Write(appointment.Doctor.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 63 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\Appointment\Index.cshtml"
                                   Write(appointment.InjuryCondition);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                                    \r\n");
            WriteLiteral("                                    <td>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "456dcb89ffca5bec1ff3185f2ee831ea38bfa10915473", async() => {
                WriteLiteral("<i class=\"fa fa-eye fa-lg\" style=\"font-size:1.4rem;\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 78 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\Appointment\Index.cshtml"
                                                                 WriteLiteral(appointment.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "456dcb89ffca5bec1ff3185f2ee831ea38bfa10917785", async() => {
                WriteLiteral("<i class=\"fa fa-pencil color-muted fa-lg ml-2\" style=\"font-size:1.4rem;\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 79 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\Appointment\Index.cshtml"
                                                                 WriteLiteral(appointment.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 80 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\Appointment\Index.cshtml"
                                         if (!appointment.IsDeactive)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "456dcb89ffca5bec1ff3185f2ee831ea38bfa10920461", async() => {
                WriteLiteral("<i class=\"fa-solid fa-xmark fa-lg color-danger ml-2\" style=\"font-size:1.4rem;\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 82 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\Appointment\Index.cshtml"
                                                                       WriteLiteral(appointment.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 83 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\Appointment\Index.cshtml"

                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "456dcb89ffca5bec1ff3185f2ee831ea38bfa10923169", async() => {
                WriteLiteral("<i class=\"fa-solid fa-check fa-lg color-danger ml-2\" style=\"font-size:1.4rem;\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 87 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\Appointment\Index.cshtml"
                                                                       WriteLiteral(appointment.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 88 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\Appointment\Index.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 91 "C:\Users\LEGION\Desktop\Projects\Backend\HospitalFinalProject\HospitalFinalProject\Views\Appointment\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </tbody>\r\n\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        $(\"#dataTable\").DataTable();\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Appointment>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591