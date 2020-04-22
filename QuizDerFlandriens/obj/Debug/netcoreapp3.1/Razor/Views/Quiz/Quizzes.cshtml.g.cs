#pragma checksum "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\Quizzes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4510688abd207ca7213b985db553601941bec34d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Quiz_Quizzes), @"mvc.1.0.view", @"/Views/Quiz/Quizzes.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4510688abd207ca7213b985db553601941bec34d", @"/Views/Quiz/Quizzes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d3485bb1a40b5e5af66eadc91240b2d264e49fd", @"/Views/_ViewImports.cshtml")]
    public class Views_Quiz_Quizzes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<QuizDerFlandriens.Models.Quiz>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PlayQuiz", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "QuizScores", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\Quizzes.cshtml"
  
    ViewData["Title"] = "Quizzes";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Quizzes</h1>\r\n\r\n<div class=\"card-deck\">\r\n");
#nullable restore
#line 10 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\Quizzes.cshtml"
     if (Model.Count() == 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"jumbotron\">\r\n            <h1 class=\"display-3\">There are no quizzes created yet. Please return later...</h1>\r\n        </div>\r\n");
#nullable restore
#line 15 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\Quizzes.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\Quizzes.cshtml"
      
        int counter = 0;
        List<bool> validQuizzes = new List<bool>();
        foreach (var item in Model)
        {
            bool isValidQuiz = true;
            if (item.Questions.Count() > 3)
            {
                List<bool> validQuestions = new List<bool>();
                foreach (Question question in item.Questions)
                {
                    bool isValidQuestion = true;
                    if (question.Answers.Count() < 2)
                    {
                        isValidQuestion = false;
                    }
                    else
                    {
                        int countTrues = 0;
                        bool onlyDiscriptions = true;
                        bool onlyPhotos = true;
                        foreach (Answer answer in question.Answers)
                        {
                            if (answer.Correct.ToString() == "True")
                            {
                                countTrues = countTrues + 1;
                            }
                            if (answer.Description == null)
                            {
                                onlyDiscriptions = false;
                            }
                            if (answer.FotoURL == null)
                            {
                                onlyPhotos = false;
                            }
                        }
                        if (!onlyDiscriptions && !onlyPhotos)
                        {
                            isValidQuestion = false;
                        }
                        if (countTrues == 0)
                        {
                            isValidQuestion = false;
                        }
                        else if (countTrues > 1)
                        {
                            isValidQuestion = false;
                        }
                    }
                    validQuestions.Add(isValidQuestion);
                }

                if (!validQuestions.Contains(true))
                {
                    isValidQuiz = false;
                }
                else
                {
                    if ((counter % 3) == 0)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 76 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\Quizzes.cshtml"
                   Write(Html.Raw("</div>"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 77 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\Quizzes.cshtml"
                   Write(Html.Raw("<div class='card-deck'>"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 77 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\Quizzes.cshtml"
                                                            
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"card border-secondary mb-3\" style=\"max-width: 20rem;\">\r\n                        <div class=\"card-header\">\r\n                            <h4>");
#nullable restore
#line 81 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\Quizzes.cshtml"
                           Write(item.Subject);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                        </div>\r\n");
#nullable restore
#line 83 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\Quizzes.cshtml"
                          
                            switch (item.Difficulty.Description)
                            {
                                case "Easy":

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div class=\"card-header text-white bg-success\">\r\n                                        Easy\r\n                                    </div>\r\n");
#nullable restore
#line 90 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\Quizzes.cshtml"
                                    break;
                                case "Medium":

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div class=\"card-header text-white bg-warning\">\r\n                                        Medium\r\n                                    </div>\r\n");
#nullable restore
#line 95 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\Quizzes.cshtml"
                                    break;
                                case "Hard":

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div class=\"card-header text-white bg-danger\">\r\n                                        Hard\r\n                                    </div>\r\n");
#nullable restore
#line 100 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\Quizzes.cshtml"
                                    break;
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"card-body\">\r\n                            <p class=\"card-text\">");
#nullable restore
#line 104 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\Quizzes.cshtml"
                                            Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4510688abd207ca7213b985db553601941bec34d11254", async() => {
                WriteLiteral("Play Quiz!");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 105 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\Quizzes.cshtml"
                                                                               WriteLiteral(item.Id);

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
            WriteLiteral("\r\n                            &nbsp;\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4510688abd207ca7213b985db553601941bec34d13608", async() => {
                WriteLiteral("Scores");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 107 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\Quizzes.cshtml"
                                                                                   WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 107 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\Quizzes.cshtml"
                                                                                                                 WriteLiteral(item.Subject);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["quizName"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-quizName", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["quizName"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            \r\n                        </div>\r\n                        <div class=\"card-footer\">\r\n");
#nullable restore
#line 111 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\Quizzes.cshtml"
                              
                                List<int> scores = new List<int>();
                                foreach (var result in item.Results)
                                {
                                    scores.Add(result.Score);
                                }
                                if (scores.Count() > 0)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <p class=\"card-text\">The current highscore is: ");
#nullable restore
#line 119 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\Quizzes.cshtml"
                                                                              Write(scores.Max());

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 120 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\Quizzes.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <p class=\"card-text\">There is no current highscore yet</p>\r\n");
#nullable restore
#line 124 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\Quizzes.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 128 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\Quizzes.cshtml"
                    counter++;
                }
            }
            else {
                isValidQuiz = false;
            }
            validQuizzes.Add(isValidQuiz);
        }
        if (!validQuizzes.Contains(true))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"jumbotron\">\r\n                <h1 class=\"display-3\">There are no valid quizzes. Please return later...</h1>\r\n            </div>\r\n");
#nullable restore
#line 141 "C:\Users\Robbe\Desktop\BackEnd\projectBackEnd\QuizDerFlandriens\Views\Quiz\Quizzes.cshtml"
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<QuizDerFlandriens.Models.Quiz>> Html { get; private set; }
    }
}
#pragma warning restore 1591
