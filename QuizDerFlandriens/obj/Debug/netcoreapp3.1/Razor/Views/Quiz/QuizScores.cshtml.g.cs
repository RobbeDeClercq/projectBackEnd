#pragma checksum "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\QuizScores.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ea7850325f045a70c411b6cf56085d2cc1417ac4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Quiz_QuizScores), @"mvc.1.0.view", @"/Views/Quiz/QuizScores.cshtml")]
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
#line 1 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\_ViewImports.cshtml"
using QuizDerFlandriens;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\_ViewImports.cshtml"
using QuizDerFlandriens.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea7850325f045a70c411b6cf56085d2cc1417ac4", @"/Views/Quiz/QuizScores.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d3485bb1a40b5e5af66eadc91240b2d264e49fd", @"/Views/_ViewImports.cshtml")]
    public class Views_Quiz_QuizScores : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<QuizDerFlandriens.Models.Result>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Quizzes", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\QuizScores.cshtml"
  
    ViewData["Title"] = "QuizScores";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Scores of ");
#nullable restore
#line 7 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\QuizScores.cshtml"
         Write(ViewData["QuizName"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ea7850325f045a70c411b6cf56085d2cc1417ac44341", async() => {
                WriteLiteral("Back to homepage");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<br />&nbsp;<br />\r\n<table class=\"table table-hover\">\r\n    <tbody>\r\n");
#nullable restore
#line 12 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\QuizScores.cshtml"
   
    int counter = 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\QuizScores.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <th scope=\"row\">\r\n                ");
#nullable restore
#line 18 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\QuizScores.cshtml"
           Write(counter);

#line default
#line hidden
#nullable disable
            WriteLiteral(". \r\n            </th>\r\n            <td>\r\n                ");
#nullable restore
#line 21 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\QuizScores.cshtml"
           Write(Html.DisplayFor(modelItem => item.Score));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 24 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\QuizScores.cshtml"
           Write(Html.DisplayFor(modelItem => item.Person.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 27 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\QuizScores.cshtml"
    counter++;
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<QuizDerFlandriens.Models.Result>> Html { get; private set; }
    }
}
#pragma warning restore 1591