﻿using KndStore.Shared.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KndStore.Shared.Infra;

[HtmlTargetElement("div", Attributes = "page-model")]
public class PageLinkTagHelper : TagHelper
{
    private readonly IUrlHelperFactory _factory;
    public PageLinkTagHelper(IUrlHelperFactory factory)
    {
        _factory = factory;
    }
    [ViewContext, HtmlAttributeNotBound]
    public ViewContext? ViewContext { get; set; } = new ViewContext();
    public PagingInfo? PageModel { get; set; }
    public string? PageAction { get; set; }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (ViewContext != null && PageModel != null)
        {
            var urlHelper = _factory.GetUrlHelper(ViewContext);
            var result = new TagBuilder("div");
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                var tag = new TagBuilder("a");
                tag.Attributes["href"] = urlHelper.Action(PageAction, new { productPage = i });
                tag.InnerHtml.Append(i.ToString());
                result.InnerHtml.AppendHtml(tag);
            }
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
