#pragma checksum "C:\Users\newforce\workspace\Csharp-exercises\book-3\student-exercises-mvc\StudentExerciseMVC\Views\Students\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bec8a75f9c4b3da31425860e3093e904d4f53f47"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Students_Details), @"mvc.1.0.view", @"/Views/Students/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Students/Details.cshtml", typeof(AspNetCore.Views_Students_Details))]
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
#line 1 "C:\Users\newforce\workspace\Csharp-exercises\book-3\student-exercises-mvc\StudentExerciseMVC\Views\_ViewImports.cshtml"
using StudentExerciseMVC;

#line default
#line hidden
#line 2 "C:\Users\newforce\workspace\Csharp-exercises\book-3\student-exercises-mvc\StudentExerciseMVC\Views\_ViewImports.cshtml"
using StudentExerciseMVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bec8a75f9c4b3da31425860e3093e904d4f53f47", @"/Views/Students/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f7cb341ef5830db43ad43ef39eac00c0405cf7d", @"/Views/_ViewImports.cshtml")]
    public class Views_Students_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StudentExerciseMVC.Models.Student>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(42, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\newforce\workspace\Csharp-exercises\book-3\student-exercises-mvc\StudentExerciseMVC\Views\Students\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(87, 6, true);
            WriteLiteral("\r\n<h1>");
            EndContext();
            BeginContext(94, 17, false);
#line 7 "C:\Users\newforce\workspace\Csharp-exercises\book-3\student-exercises-mvc\StudentExerciseMVC\Views\Students\Details.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(111, 115, true);
            WriteLiteral("</h1>\r\n\r\n<div>\r\n    <h4>Student</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(227, 38, false);
#line 14 "C:\Users\newforce\workspace\Csharp-exercises\book-3\student-exercises-mvc\StudentExerciseMVC\Views\Students\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(265, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(327, 34, false);
#line 17 "C:\Users\newforce\workspace\Csharp-exercises\book-3\student-exercises-mvc\StudentExerciseMVC\Views\Students\Details.cshtml"
       Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(361, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(422, 45, false);
#line 20 "C:\Users\newforce\workspace\Csharp-exercises\book-3\student-exercises-mvc\StudentExerciseMVC\Views\Students\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(467, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(529, 41, false);
#line 23 "C:\Users\newforce\workspace\Csharp-exercises\book-3\student-exercises-mvc\StudentExerciseMVC\Views\Students\Details.cshtml"
       Write(Html.DisplayFor(model => model.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(570, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(631, 44, false);
#line 26 "C:\Users\newforce\workspace\Csharp-exercises\book-3\student-exercises-mvc\StudentExerciseMVC\Views\Students\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(675, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(737, 40, false);
#line 29 "C:\Users\newforce\workspace\Csharp-exercises\book-3\student-exercises-mvc\StudentExerciseMVC\Views\Students\Details.cshtml"
       Write(Html.DisplayFor(model => model.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(777, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(838, 47, false);
#line 32 "C:\Users\newforce\workspace\Csharp-exercises\book-3\student-exercises-mvc\StudentExerciseMVC\Views\Students\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SlackHandle));

#line default
#line hidden
            EndContext();
            BeginContext(885, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(947, 43, false);
#line 35 "C:\Users\newforce\workspace\Csharp-exercises\book-3\student-exercises-mvc\StudentExerciseMVC\Views\Students\Details.cshtml"
       Write(Html.DisplayFor(model => model.SlackHandle));

#line default
#line hidden
            EndContext();
            BeginContext(990, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1051, 44, false);
#line 38 "C:\Users\newforce\workspace\Csharp-exercises\book-3\student-exercises-mvc\StudentExerciseMVC\Views\Students\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CohortId));

#line default
#line hidden
            EndContext();
            BeginContext(1095, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1157, 40, false);
#line 41 "C:\Users\newforce\workspace\Csharp-exercises\book-3\student-exercises-mvc\StudentExerciseMVC\Views\Students\Details.cshtml"
       Write(Html.DisplayFor(model => model.CohortId));

#line default
#line hidden
            EndContext();
            BeginContext(1197, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1258, 49, false);
#line 44 "C:\Users\newforce\workspace\Csharp-exercises\book-3\student-exercises-mvc\StudentExerciseMVC\Views\Students\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CurrentCohort));

#line default
#line hidden
            EndContext();
            BeginContext(1307, 38, true);
            WriteLiteral("\r\n\r\n            <dd class=\"col-sm-2\"> ");
            EndContext();
            BeginContext(1346, 50, false);
#line 46 "C:\Users\newforce\workspace\Csharp-exercises\book-3\student-exercises-mvc\StudentExerciseMVC\Views\Students\Details.cshtml"
                             Write(Html.DisplayFor(model => model.CurrentCohort.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1396, 92, true);
            WriteLiteral("</dd>\r\n       \r\n        </dt>\r\n       \r\n    </dl>\r\n\r\n    <h4>Exercises:</h4>\r\n    <hr />\r\n\r\n");
            EndContext();
#line 55 "C:\Users\newforce\workspace\Csharp-exercises\book-3\student-exercises-mvc\StudentExerciseMVC\Views\Students\Details.cshtml"
     foreach (var exercise in Model.exercises)
    {

#line default
#line hidden
            BeginContext(1543, 59, true);
            WriteLiteral("        <dl class=\"row\">\r\n            <dt class=\"col-sm-2\">");
            EndContext();
            BeginContext(1603, 45, false);
#line 58 "C:\Users\newforce\workspace\Csharp-exercises\book-3\student-exercises-mvc\StudentExerciseMVC\Views\Students\Details.cshtml"
                            Write(Html.DisplayNameFor(ModelItem => exercise.Id));

#line default
#line hidden
            EndContext();
            BeginContext(1648, 43, true);
            WriteLiteral(" </dt>\r\n            <dd class=\"col-sm-10\"> ");
            EndContext();
            BeginContext(1692, 41, false);
#line 59 "C:\Users\newforce\workspace\Csharp-exercises\book-3\student-exercises-mvc\StudentExerciseMVC\Views\Students\Details.cshtml"
                              Write(Html.DisplayFor(ModelItem => exercise.Id));

#line default
#line hidden
            EndContext();
            BeginContext(1733, 44, true);
            WriteLiteral("</dd>\r\n\r\n\r\n            <dt class=\"col-sm-2\">");
            EndContext();
            BeginContext(1778, 47, false);
#line 62 "C:\Users\newforce\workspace\Csharp-exercises\book-3\student-exercises-mvc\StudentExerciseMVC\Views\Students\Details.cshtml"
                            Write(Html.DisplayNameFor(ModelItem => exercise.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1825, 41, true);
            WriteLiteral("</dt>\r\n            <dd class=\"col-sm-10\">");
            EndContext();
            BeginContext(1867, 43, false);
#line 63 "C:\Users\newforce\workspace\Csharp-exercises\book-3\student-exercises-mvc\StudentExerciseMVC\Views\Students\Details.cshtml"
                             Write(Html.DisplayFor(ModelItem => exercise.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1910, 44, true);
            WriteLiteral("</dd>\r\n\r\n\r\n            <dt class=\"col-sm-2\">");
            EndContext();
            BeginContext(1955, 54, false);
#line 66 "C:\Users\newforce\workspace\Csharp-exercises\book-3\student-exercises-mvc\StudentExerciseMVC\Views\Students\Details.cshtml"
                            Write(Html.DisplayNameFor(ModelItem => exercise.ProgramLang));

#line default
#line hidden
            EndContext();
            BeginContext(2009, 41, true);
            WriteLiteral("</dt>\r\n            <dd class=\"col-sm-10\">");
            EndContext();
            BeginContext(2051, 50, false);
#line 67 "C:\Users\newforce\workspace\Csharp-exercises\book-3\student-exercises-mvc\StudentExerciseMVC\Views\Students\Details.cshtml"
                             Write(Html.DisplayFor(ModelItem => exercise.ProgramLang));

#line default
#line hidden
            EndContext();
            BeginContext(2101, 22, true);
            WriteLiteral("</dd>\r\n        </dl>\r\n");
            EndContext();
#line 69 "C:\Users\newforce\workspace\Csharp-exercises\book-3\student-exercises-mvc\StudentExerciseMVC\Views\Students\Details.cshtml"

    }

#line default
#line hidden
            BeginContext(2132, 23, true);
            WriteLiteral("\r\n\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(2156, 54, false);
#line 75 "C:\Users\newforce\workspace\Csharp-exercises\book-3\student-exercises-mvc\StudentExerciseMVC\Views\Students\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(2210, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(2218, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bec8a75f9c4b3da31425860e3093e904d4f53f4714007", async() => {
                BeginContext(2240, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2256, 10, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StudentExerciseMVC.Models.Student> Html { get; private set; }
    }
}
#pragma warning restore 1591
