#pragma checksum "D:\school_jaar_3\digital_innovation\cosmident\COSMIDENT\Views\Shared\_bottomBar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "705c889fe79603a008b41f4c922bd8d150729fa8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__bottomBar), @"mvc.1.0.view", @"/Views/Shared/_bottomBar.cshtml")]
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
#line 1 "D:\school_jaar_3\digital_innovation\cosmident\COSMIDENT\Views\_ViewImports.cshtml"
using COSMIDENT;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\school_jaar_3\digital_innovation\cosmident\COSMIDENT\Views\_ViewImports.cshtml"
using COSMIDENT.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"705c889fe79603a008b41f4c922bd8d150729fa8", @"/Views/Shared/_bottomBar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f362f22799ae69f38cefb3371faa447eeccbdbcc", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__bottomBar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagerModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("pageSelector"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onchange", new global::Microsoft.AspNetCore.Html.HtmlString("ChangePageSize(this);"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"container m-0 p-0 btn-group\" style=\"background-color:darkseagreen; border-radius:10px; height:45px; color:white;\">\r\n    <div class=\"col-4 btn-group p-1 m-1\">\r\n        <p>\r\n            Zie rij ");
#nullable restore
#line 6 "D:\school_jaar_3\digital_innovation\cosmident\COSMIDENT\Views\Shared\_bottomBar.cshtml"
               Write(Model.StartRecord);

#line default
#line hidden
#nullable disable
            WriteLiteral(" tot ");
#nullable restore
#line 6 "D:\school_jaar_3\digital_innovation\cosmident\COSMIDENT\Views\Shared\_bottomBar.cshtml"
                                      Write(Model.EndRecord);

#line default
#line hidden
#nullable disable
            WriteLiteral(" van de ");
#nullable restore
#line 6 "D:\school_jaar_3\digital_innovation\cosmident\COSMIDENT\Views\Shared\_bottomBar.cshtml"
                                                              Write(Model.TotalItems);

#line default
#line hidden
#nullable disable
            WriteLiteral(" rijen\r\n        </p>\r\n    </div>\r\n\r\n    <div class=\"col-3 btn-group justify-content-end\">\r\n        <span class=\"col-7 mt-2 p-0\">\r\n            Rijen per pagina\r\n        </span>\r\n\r\n        <span class=\"col-5 p-1\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "705c889fe79603a008b41f4c922bd8d150729fa85435", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 16 "D:\school_jaar_3\digital_innovation\cosmident\COSMIDENT\Views\Shared\_bottomBar.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = Model.GetPageSizes();

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </span>\r\n    </div>\r\n\r\n\r\n    <div class=\"col-5 btn-group justify-content-end m-2\">\r\n        <p>\r\n            Pagina ");
#nullable restore
#line 23 "D:\school_jaar_3\digital_innovation\cosmident\COSMIDENT\Views\Shared\_bottomBar.cshtml"
              Write(Model.CurrentPage);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 23 "D:\school_jaar_3\digital_innovation\cosmident\COSMIDENT\Views\Shared\_bottomBar.cshtml"
                                   Write(Model.TotalPages);

#line default
#line hidden
#nullable disable
            WriteLiteral(" &nbsp;&nbsp;\r\n        </p>\r\n    </div>\r\n</div>\r\n\r\n<script>\r\n    function ChangePageSize(obj) {\r\n        var controllerName = \'");
#nullable restore
#line 30 "D:\school_jaar_3\digital_innovation\cosmident\COSMIDENT\Views\Shared\_bottomBar.cshtml"
                         Write(this.ViewContext.RouteData.Values["controller"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n        window.location.href = \"/\" + controllerName + \"/");
#nullable restore
#line 31 "D:\school_jaar_3\digital_innovation\cosmident\COSMIDENT\Views\Shared\_bottomBar.cshtml"
                                                   Write(Model.Action);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" + \"?pageSize=\" + obj.value + \"&SearchText@Model.SearchText\" + \"&sortExpression=\" + \"");
#nullable restore
#line 31 "D:\school_jaar_3\digital_innovation\cosmident\COSMIDENT\Views\Shared\_bottomBar.cshtml"
                                                                                                                                                      Write(Model.SortExpression);

#line default
#line hidden
#nullable disable
            WriteLiteral("\";\r\n    }\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagerModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
