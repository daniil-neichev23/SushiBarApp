#pragma checksum "C:\Users\User\source\repos\SushiBarApp\SushiBarApp\Views\Product\ProductInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eb406a47f17f71bfd42b564d6281e0c2f7c9f17e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_ProductInfo), @"mvc.1.0.view", @"/Views/Product/ProductInfo.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Product/ProductInfo.cshtml", typeof(AspNetCore.Views_Product_ProductInfo))]
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
#line 1 "C:\Users\User\source\repos\SushiBarApp\SushiBarApp\Views\_ViewImports.cshtml"
using SushiBarApp;

#line default
#line hidden
#line 2 "C:\Users\User\source\repos\SushiBarApp\SushiBarApp\Views\_ViewImports.cshtml"
using SushiBarApp.Data.Models;

#line default
#line hidden
#line 3 "C:\Users\User\source\repos\SushiBarApp\SushiBarApp\Views\_ViewImports.cshtml"
using SushiBarApp.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb406a47f17f71bfd42b564d6281e0c2f7c9f17e", @"/Views/Product/ProductInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00592aa87633d3c157cb56a07213debae4c1e2e9", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_ProductInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SushiBarApp.Data.Models.Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddReview", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\User\source\repos\SushiBarApp\SushiBarApp\Views\Product\ProductInfo.cshtml"
  
    ViewData["Title"] = "Fishing Line";
    Layout = "_Layout";

#line default
#line hidden
            BeginContext(113, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(141, 56, true);
            WriteLiteral("\r\n\r\n<table>\r\n    <tr>\r\n        <td>\r\n            <p><img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 197, "\"", 265, 1);
#line 13 "C:\Users\User\source\repos\SushiBarApp\SushiBarApp\Views\Product\ProductInfo.cshtml"
WriteAttributeValue("", 203, Url.Action("GetImage", "Product", new {ProductId = Model.Id}), 203, 62, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(266, 77, true);
            WriteLiteral(" width=\"400\" height=\"450\"></p>\r\n        </td>\r\n        <td>\r\n            <h3>");
            EndContext();
            BeginContext(344, 10, false);
#line 16 "C:\Users\User\source\repos\SushiBarApp\SushiBarApp\Views\Product\ProductInfo.cshtml"
           Write(Model.Name);

#line default
#line hidden
            EndContext();
            BeginContext(354, 35, true);
            WriteLiteral("</h3>\r\n            <p>Description: ");
            EndContext();
            BeginContext(390, 17, false);
#line 17 "C:\Users\User\source\repos\SushiBarApp\SushiBarApp\Views\Product\ProductInfo.cshtml"
                       Write(Model.Description);

#line default
#line hidden
            EndContext();
            BeginContext(407, 18, true);
            WriteLiteral("</p>\r\n            ");
            EndContext();
            BeginContext(425, 680, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eb406a47f17f71bfd42b564d6281e0c2f7c9f17e5776", async() => {
                BeginContext(493, 44, true);
                WriteLiteral("\r\n                <div class=\"form-group\">\r\n");
                EndContext();
                BeginContext(724, 205, true);
                WriteLiteral("                    <input type=\"text\" class=\"form-control\" placeholder=\"Введите комментарий\" name=\"text\" />\r\n\r\n                    <button class=\"btn btn-secondary\" type=\"submit\">Add a review</button>\r\n\r\n");
                EndContext();
                BeginContext(1048, 50, true);
                WriteLiteral("                </div>\r\n            \r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 18 "C:\Users\User\source\repos\SushiBarApp\SushiBarApp\Views\Product\ProductInfo.cshtml"
                                                         WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1105, 16, true);
            WriteLiteral("\r\n\r\n            ");
            EndContext();
            BeginContext(1122, 74, false);
#line 31 "C:\Users\User\source\repos\SushiBarApp\SushiBarApp\Views\Product\ProductInfo.cshtml"
       Write(Html.ActionLink("Reviews", "ViewReviews", "Product", new {id = Model.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1196, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(1417, 36, true);
            WriteLiteral("        </td>\r\n    </tr>\r\n\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SushiBarApp.Data.Models.Product> Html { get; private set; }
    }
}
#pragma warning restore 1591