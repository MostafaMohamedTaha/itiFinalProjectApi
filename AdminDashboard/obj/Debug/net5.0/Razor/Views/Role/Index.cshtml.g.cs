#pragma checksum "D:\0p\0121project\Talabat.Demo.Solution-20231107T152725Z-001\Talabat.Demo.Solution\AdminDashboard\Views\Role\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "202773eb4729cf1e42742bb516edd17a1f8aec74792770b7a8cf86b8d73397c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Role_Index), @"mvc.1.0.view", @"/Views/Role/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\0p\0121project\Talabat.Demo.Solution-20231107T152725Z-001\Talabat.Demo.Solution\AdminDashboard\Views\_ViewImports.cshtml"
using AdminDashboard;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\0p\0121project\Talabat.Demo.Solution-20231107T152725Z-001\Talabat.Demo.Solution\AdminDashboard\Views\_ViewImports.cshtml"
using AdminDashboard.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\0p\0121project\Talabat.Demo.Solution-20231107T152725Z-001\Talabat.Demo.Solution\AdminDashboard\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\0p\0121project\Talabat.Demo.Solution-20231107T152725Z-001\Talabat.Demo.Solution\AdminDashboard\Views\_ViewImports.cshtml"
using Talabat.Core.Entities.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\0p\0121project\Talabat.Demo.Solution-20231107T152725Z-001\Talabat.Demo.Solution\AdminDashboard\Views\_ViewImports.cshtml"
using Talabat.APIs.Dtos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\0p\0121project\Talabat.Demo.Solution-20231107T152725Z-001\Talabat.Demo.Solution\AdminDashboard\Views\_ViewImports.cshtml"
using Talabat.Core.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\0p\0121project\Talabat.Demo.Solution-20231107T152725Z-001\Talabat.Demo.Solution\AdminDashboard\Views\_ViewImports.cshtml"
using Talabat.Core.Repositories;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\0p\0121project\Talabat.Demo.Solution-20231107T152725Z-001\Talabat.Demo.Solution\AdminDashboard\Views\_ViewImports.cshtml"
using Talabat.Core.Entities.Order_Aggregate;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"202773eb4729cf1e42742bb516edd17a1f8aec74792770b7a8cf86b8d73397c1", @"/Views/Role/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"49a3d07ae9cd9bda5b7eea5e8c26972763715aa295a0db0ba84422c02f562ee9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Role_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IdentityRole>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "RoleForm", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ValidationScriptsPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\0p\0121project\Talabat.Demo.Solution-20231107T152725Z-001\Talabat.Demo.Solution\AdminDashboard\Views\Role\Index.cshtml"
  
    ViewData["Title"] = "Roles";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>All Roles</h1>\r\n<hr />\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "202773eb4729cf1e42742bb516edd17a1f8aec74792770b7a8cf86b8d73397c17201", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 9 "D:\0p\0121project\Talabat.Demo.Solution-20231107T152725Z-001\Talabat.Demo.Solution\AdminDashboard\Views\Role\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = new RoleFormViewModel();

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 10 "D:\0p\0121project\Talabat.Demo.Solution-20231107T152725Z-001\Talabat.Demo.Solution\AdminDashboard\Views\Role\Index.cshtml"
 if (Model.Count() > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table table-striped table-hover\">\r\n        <thead>\r\n            <tr>\r\n                <th>");
#nullable restore
#line 15 "D:\0p\0121project\Talabat.Demo.Solution-20231107T152725Z-001\Talabat.Demo.Solution\AdminDashboard\Views\Role\Index.cshtml"
               Write(Html.DisplayNameFor(D=>D.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 16 "D:\0p\0121project\Talabat.Demo.Solution-20231107T152725Z-001\Talabat.Demo.Solution\AdminDashboard\Views\Role\Index.cshtml"
               Write(Html.DisplayNameFor(D=>D.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>Actions</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 21 "D:\0p\0121project\Talabat.Demo.Solution-20231107T152725Z-001\Talabat.Demo.Solution\AdminDashboard\Views\Role\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 24 "D:\0p\0121project\Talabat.Demo.Solution-20231107T152725Z-001\Talabat.Demo.Solution\AdminDashboard\Views\Role\Index.cshtml"
                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 25 "D:\0p\0121project\Talabat.Demo.Solution-20231107T152725Z-001\Talabat.Demo.Solution\AdminDashboard\Views\Role\Index.cshtml"
                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "202773eb4729cf1e42742bb516edd17a1f8aec74792770b7a8cf86b8d73397c110914", async() => {
                WriteLiteral("<i class=\"fas fa-trash\"></i> Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 27 "D:\0p\0121project\Talabat.Demo.Solution-20231107T152725Z-001\Talabat.Demo.Solution\AdminDashboard\Views\Role\Index.cshtml"
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
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "202773eb4729cf1e42742bb516edd17a1f8aec74792770b7a8cf86b8d73397c113306", async() => {
                WriteLiteral("<i class=\"fas fa-trash\"></i> Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 28 "D:\0p\0121project\Talabat.Demo.Solution-20231107T152725Z-001\Talabat.Demo.Solution\AdminDashboard\Views\Role\Index.cshtml"
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
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 31 "D:\0p\0121project\Talabat.Demo.Solution-20231107T152725Z-001\Talabat.Demo.Solution\AdminDashboard\Views\Role\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 34 "D:\0p\0121project\Talabat.Demo.Solution-20231107T152725Z-001\Talabat.Demo.Solution\AdminDashboard\Views\Role\Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"mt-3 p-3 alert-warning\">\r\n        <h2>There is no Roles!</h2>\r\n    </div>\r\n");
#nullable restore
#line 40 "D:\0p\0121project\Talabat.Demo.Solution-20231107T152725Z-001\Talabat.Demo.Solution\AdminDashboard\Views\Role\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "202773eb4729cf1e42742bb516edd17a1f8aec74792770b7a8cf86b8d73397c116665", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IdentityRole>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
