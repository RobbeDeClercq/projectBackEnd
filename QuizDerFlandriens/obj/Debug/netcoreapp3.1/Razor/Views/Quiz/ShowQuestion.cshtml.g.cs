#pragma checksum "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\ShowQuestion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d68f0e8a667e4c5713d18debcd8422379d087e44"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Quiz_ShowQuestion), @"mvc.1.0.view", @"/Views/Quiz/ShowQuestion.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d68f0e8a667e4c5713d18debcd8422379d087e44", @"/Views/Quiz/ShowQuestion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d3485bb1a40b5e5af66eadc91240b2d264e49fd", @"/Views/_ViewImports.cshtml")]
    public class Views_Quiz_ShowQuestion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QuizDerFlandriens.Models.Question>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("stretched-link text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("\r\n                                            text-decoration: none;\r\n                                            "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CheckAnswer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\ShowQuestion.cshtml"
  
    ViewData["Title"] = "ShowQuestion";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 7 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\ShowQuestion.cshtml"
Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<h5 class=\"text-primary\">Current Score: ");
#nullable restore
#line 8 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\ShowQuestion.cshtml"
                                   Write(ViewData["Score"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 8 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\ShowQuestion.cshtml"
                                                      Write(ViewData["PotentialScore"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n<hr />\r\n\r\n<div class=\"card-deck\">\r\n");
#nullable restore
#line 12 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\ShowQuestion.cshtml"
     foreach (Answer answer in Model.Answers)
    {
        if (answer.Description != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div");
            BeginWriteAttribute("class", " class=\"", 373, "\"", 427, 5);
            WriteAttributeValue("", 381, "card", 381, 4, true);
            WriteAttributeValue(" ", 385, "btn", 386, 4, true);
            WriteAttributeValue(" ", 389, "btn-primary", 390, 12, true);
            WriteAttributeValue(" ", 401, "mb-", 402, 4, true);
#nullable restore
#line 16 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\ShowQuestion.cshtml"
WriteAttributeValue("", 405, Model.Answers.Count(), 405, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <h5>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d68f0e8a667e4c5713d18debcd8422379d087e446946", async() => {
#nullable restore
#line 25 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\ShowQuestion.cshtml"
                                                       Write(answer.Description);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-isCorrect", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 22 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\ShowQuestion.cshtml"
                                WriteLiteral(answer.Correct);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["isCorrect"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-isCorrect", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["isCorrect"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 23 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\ShowQuestion.cshtml"
                             WriteLiteral(Model.QuizId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["QuizId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-QuizId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["QuizId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 24 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\ShowQuestion.cshtml"
                                      WriteLiteral(ViewData["PotentialScore"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["currentQuestion"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-currentQuestion", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["currentQuestion"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 25 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\ShowQuestion.cshtml"
                            WriteLiteral(ViewData["Score"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["score"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-score", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["score"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</h5>\r\n            </div>\r\n");
#nullable restore
#line 27 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\ShowQuestion.cshtml"
        }
        else if(answer.FotoURL != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div");
            BeginWriteAttribute("class", " class=\"", 1095, "\"", 1157, 5);
            WriteAttributeValue("", 1103, "card", 1103, 4, true);
            WriteAttributeValue(" ", 1107, "text-white", 1108, 11, true);
            WriteAttributeValue(" ", 1118, "border-light", 1119, 13, true);
            WriteAttributeValue(" ", 1131, "mb-", 1132, 4, true);
#nullable restore
#line 30 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\ShowQuestion.cshtml"
WriteAttributeValue("", 1135, Model.Answers.Count(), 1135, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"card-body text-center\">\r\n");
#nullable restore
#line 32 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\ShowQuestion.cshtml"
                      
                        var photoPath = "~/images/" + answer.FotoURL;

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d68f0e8a667e4c5713d18debcd8422379d087e4413107", async() => {
                WriteLiteral("\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d68f0e8a667e4c5713d18debcd8422379d087e4413391", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 43 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\ShowQuestion.cshtml"
                                               WriteLiteral(photoPath);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 43 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\ShowQuestion.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-isCorrect", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 39 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\ShowQuestion.cshtml"
                                WriteLiteral(answer.Correct);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["isCorrect"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-isCorrect", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["isCorrect"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 40 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\ShowQuestion.cshtml"
                             WriteLiteral(Model.QuizId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["QuizId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-QuizId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["QuizId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 41 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\ShowQuestion.cshtml"
                                      WriteLiteral(ViewData["PotentialScore"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["currentQuestion"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-currentQuestion", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["currentQuestion"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 42 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\ShowQuestion.cshtml"
                            WriteLiteral(ViewData["Score"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["score"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-score", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["score"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            WriteLiteral("                </div>\r\n            </div>\r\n");
#nullable restore
#line 48 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\ShowQuestion.cshtml"
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n    \r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QuizDerFlandriens.Models.Question> Html { get; private set; }
    }
}
#pragma warning restore 1591
