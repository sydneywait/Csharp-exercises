#pragma checksum "C:\Users\newforce\workspace\Csharp-exercises\book-4\StudentExercisesEF\Views\Cohorts\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4d35c389fbae994bc22ef711628dafbe2dc20da9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cohorts_Details), @"mvc.1.0.view", @"/Views/Cohorts/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Cohorts/Details.cshtml", typeof(AspNetCore.Views_Cohorts_Details))]
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
#line 1 "C:\Users\newforce\workspace\Csharp-exercises\book-4\StudentExercisesEF\Views\_ViewImports.cshtml"
using StudentExercisesEF;

#line default
#line hidden
#line 2 "C:\Users\newforce\workspace\Csharp-exercises\book-4\StudentExercisesEF\Views\_ViewImports.cshtml"
using StudentExercisesEF.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d35c389fbae994bc22ef711628dafbe2dc20da9", @"/Views/Cohorts/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a3fc7f13ddcef97d3362c60e72d45d5026b7860", @"/Views/_ViewImports.cshtml")]
    public class Views_Cohorts_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StudentExercisesEF.Models.Cohort>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(41, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\newforce\workspace\Csharp-exercises\book-4\StudentExercisesEF\Views\Cohorts\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(86, 127, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Cohort</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(214, 40, false);
#line 14 "C:\Users\newforce\workspace\Csharp-exercises\book-4\StudentExercisesEF\Views\Cohorts\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(254, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(316, 36, false);
#line 17 "C:\Users\newforce\workspace\Csharp-exercises\book-4\StudentExercisesEF\Views\Cohorts\Details.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(352, 81, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    <dl>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(434, 44, false);
#line 22 "C:\Users\newforce\workspace\Csharp-exercises\book-4\StudentExercisesEF\Views\Cohorts\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Students));

#line default
#line hidden
            EndContext();
            BeginContext(478, 253, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            <table class=\"table\">\r\n                <tr>\r\n                    <th>First Name</th>\r\n                    <th>Last Name</th>\r\n                    <th>Slack Handle</th>\r\n                </tr>\r\n");
            EndContext();
#line 31 "C:\Users\newforce\workspace\Csharp-exercises\book-4\StudentExercisesEF\Views\Cohorts\Details.cshtml"
                 foreach (var item in Model.Students)
                {

#line default
#line hidden
            BeginContext(805, 84, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(890, 44, false);
#line 35 "C:\Users\newforce\workspace\Csharp-exercises\book-4\StudentExercisesEF\Views\Cohorts\Details.cshtml"
                       Write(Html.DisplayFor(modelItem => item.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(934, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1026, 43, false);
#line 38 "C:\Users\newforce\workspace\Csharp-exercises\book-4\StudentExercisesEF\Views\Cohorts\Details.cshtml"
                       Write(Html.DisplayFor(modelItem => item.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(1069, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1161, 46, false);
#line 41 "C:\Users\newforce\workspace\Csharp-exercises\book-4\StudentExercisesEF\Views\Cohorts\Details.cshtml"
                       Write(Html.DisplayFor(modelItem => item.SlackHandle));

#line default
#line hidden
            EndContext();
            BeginContext(1207, 60, true);
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 44 "C:\Users\newforce\workspace\Csharp-exercises\book-4\StudentExercisesEF\Views\Cohorts\Details.cshtml"
                }

#line default
#line hidden
            BeginContext(1286, 82, true);
            WriteLiteral("            </table>\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1369, 47, false);
#line 49 "C:\Users\newforce\workspace\Csharp-exercises\book-4\StudentExercisesEF\Views\Cohorts\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Instructors));

#line default
#line hidden
            EndContext();
            BeginContext(1416, 253, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            <table class=\"table\">\r\n                <tr>\r\n                    <th>First Name</th>\r\n                    <th>Last Name</th>\r\n                    <th>Slack Handle</th>\r\n                </tr>\r\n");
            EndContext();
#line 58 "C:\Users\newforce\workspace\Csharp-exercises\book-4\StudentExercisesEF\Views\Cohorts\Details.cshtml"
                 foreach (var item in Model.Instructors)
                {

#line default
#line hidden
            BeginContext(1746, 84, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1831, 44, false);
#line 62 "C:\Users\newforce\workspace\Csharp-exercises\book-4\StudentExercisesEF\Views\Cohorts\Details.cshtml"
                       Write(Html.DisplayFor(modelItem => item.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(1875, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1967, 43, false);
#line 65 "C:\Users\newforce\workspace\Csharp-exercises\book-4\StudentExercisesEF\Views\Cohorts\Details.cshtml"
                       Write(Html.DisplayFor(modelItem => item.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(2010, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2102, 46, false);
#line 68 "C:\Users\newforce\workspace\Csharp-exercises\book-4\StudentExercisesEF\Views\Cohorts\Details.cshtml"
                       Write(Html.DisplayFor(modelItem => item.SlackHandle));

#line default
#line hidden
            EndContext();
            BeginContext(2148, 60, true);
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 71 "C:\Users\newforce\workspace\Csharp-exercises\book-4\StudentExercisesEF\Views\Cohorts\Details.cshtml"
                }

#line default
#line hidden
            BeginContext(2227, 67, true);
            WriteLiteral("            </table>\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(2294, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d35c389fbae994bc22ef711628dafbe2dc20da910907", async() => {
                BeginContext(2340, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 77 "C:\Users\newforce\workspace\Csharp-exercises\book-4\StudentExercisesEF\Views\Cohorts\Details.cshtml"
                           WriteLiteral(Model.Id);

#line default
#line hidden
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
            EndContext();
            BeginContext(2348, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(2356, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d35c389fbae994bc22ef711628dafbe2dc20da913249", async() => {
                BeginContext(2378, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2394, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StudentExercisesEF.Models.Cohort> Html { get; private set; }
    }
}
#pragma warning restore 1591
