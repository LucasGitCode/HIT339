#pragma checksum "D:\Uni\2021\Semester 2\HIT 339 Distributed Development\Assignment 2\MusicApp - Latest3.1\MusicApp\Views\Letters\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "11d4dd199082ae9032b5c4705c8c12f5cb40978d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Letters_Delete), @"mvc.1.0.view", @"/Views/Letters/Delete.cshtml")]
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
#line 1 "D:\Uni\2021\Semester 2\HIT 339 Distributed Development\Assignment 2\MusicApp - Latest3.1\MusicApp\Views\_ViewImports.cshtml"
using MusicApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Uni\2021\Semester 2\HIT 339 Distributed Development\Assignment 2\MusicApp - Latest3.1\MusicApp\Views\_ViewImports.cshtml"
using MusicApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11d4dd199082ae9032b5c4705c8c12f5cb40978d", @"/Views/Letters/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05658f0c308c1bbc010ef74805877d1495ce3218", @"/Views/_ViewImports.cshtml")]
    public class Views_Letters_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MusicApp.Models.Letters>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Uni\2021\Semester 2\HIT 339 Distributed Development\Assignment 2\MusicApp - Latest3.1\MusicApp\Views\Letters\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Delete</h1>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>Letters</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 15 "D:\Uni\2021\Semester 2\HIT 339 Distributed Development\Assignment 2\MusicApp - Latest3.1\MusicApp\Views\Letters\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Students));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "D:\Uni\2021\Semester 2\HIT 339 Distributed Development\Assignment 2\MusicApp - Latest3.1\MusicApp\Views\Letters\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Students.ContactEmail));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd class>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "D:\Uni\2021\Semester 2\HIT 339 Distributed Development\Assignment 2\MusicApp - Latest3.1\MusicApp\Views\Letters\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.LessonTY));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "D:\Uni\2021\Semester 2\HIT 339 Distributed Development\Assignment 2\MusicApp - Latest3.1\MusicApp\Views\Letters\Delete.cshtml"
       Write(Html.DisplayFor(model => model.LessonTY.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd class>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "D:\Uni\2021\Semester 2\HIT 339 Distributed Development\Assignment 2\MusicApp - Latest3.1\MusicApp\Views\Letters\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.LessonDT));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "D:\Uni\2021\Semester 2\HIT 339 Distributed Development\Assignment 2\MusicApp - Latest3.1\MusicApp\Views\Letters\Delete.cshtml"
       Write(Html.DisplayFor(model => model.LessonDT.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd class>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "D:\Uni\2021\Semester 2\HIT 339 Distributed Development\Assignment 2\MusicApp - Latest3.1\MusicApp\Views\Letters\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Semester));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "D:\Uni\2021\Semester 2\HIT 339 Distributed Development\Assignment 2\MusicApp - Latest3.1\MusicApp\Views\Letters\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Semester));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "D:\Uni\2021\Semester 2\HIT 339 Distributed Development\Assignment 2\MusicApp - Latest3.1\MusicApp\Views\Letters\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.BankId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "D:\Uni\2021\Semester 2\HIT 339 Distributed Development\Assignment 2\MusicApp - Latest3.1\MusicApp\Views\Letters\Delete.cshtml"
       Write(Html.DisplayFor(model => model.BankId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 45 "D:\Uni\2021\Semester 2\HIT 339 Distributed Development\Assignment 2\MusicApp - Latest3.1\MusicApp\Views\Letters\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.AccName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "D:\Uni\2021\Semester 2\HIT 339 Distributed Development\Assignment 2\MusicApp - Latest3.1\MusicApp\Views\Letters\Delete.cshtml"
       Write(Html.DisplayFor(model => model.AccName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 51 "D:\Uni\2021\Semester 2\HIT 339 Distributed Development\Assignment 2\MusicApp - Latest3.1\MusicApp\Views\Letters\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.BSBNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 54 "D:\Uni\2021\Semester 2\HIT 339 Distributed Development\Assignment 2\MusicApp - Latest3.1\MusicApp\Views\Letters\Delete.cshtml"
       Write(Html.DisplayFor(model => model.BSBNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 57 "D:\Uni\2021\Semester 2\HIT 339 Distributed Development\Assignment 2\MusicApp - Latest3.1\MusicApp\Views\Letters\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.AccNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 60 "D:\Uni\2021\Semester 2\HIT 339 Distributed Development\Assignment 2\MusicApp - Latest3.1\MusicApp\Views\Letters\Delete.cshtml"
       Write(Html.DisplayFor(model => model.AccNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 63 "D:\Uni\2021\Semester 2\HIT 339 Distributed Development\Assignment 2\MusicApp - Latest3.1\MusicApp\Views\Letters\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Cost));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 66 "D:\Uni\2021\Semester 2\HIT 339 Distributed Development\Assignment 2\MusicApp - Latest3.1\MusicApp\Views\Letters\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Cost));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 69 "D:\Uni\2021\Semester 2\HIT 339 Distributed Development\Assignment 2\MusicApp - Latest3.1\MusicApp\Views\Letters\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Paid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 72 "D:\Uni\2021\Semester 2\HIT 339 Distributed Development\Assignment 2\MusicApp - Latest3.1\MusicApp\Views\Letters\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Paid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 75 "D:\Uni\2021\Semester 2\HIT 339 Distributed Development\Assignment 2\MusicApp - Latest3.1\MusicApp\Views\Letters\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Signature));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 78 "D:\Uni\2021\Semester 2\HIT 339 Distributed Development\Assignment 2\MusicApp - Latest3.1\MusicApp\Views\Letters\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Signature));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "11d4dd199082ae9032b5c4705c8c12f5cb40978d13074", async() => {
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "11d4dd199082ae9032b5c4705c8c12f5cb40978d13341", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 83 "D:\Uni\2021\Semester 2\HIT 339 Distributed Development\Assignment 2\MusicApp - Latest3.1\MusicApp\Views\Letters\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" /> |\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "11d4dd199082ae9032b5c4705c8c12f5cb40978d15174", async() => {
                    WriteLiteral("Back to List");
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
                WriteLiteral("\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MusicApp.Models.Letters> Html { get; private set; }
    }
}
#pragma warning restore 1591
