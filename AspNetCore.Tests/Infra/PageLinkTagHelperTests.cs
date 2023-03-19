using AspNetCore.Infra;
using AspNetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetCore.Tests.Infra;

public class PageLinkTagHelperTests
{
    [Fact]
    public void Can_Generate_PageLink()
    {
        var urlHelper = new Mock<IUrlHelper>();
        urlHelper.SetupSequence(x => x.Action(It.IsAny<UrlActionContext>()))
            .Returns("Test/Page1")
            .Returns("Test/Page2")
            .Returns("Test/Page3");
        var urlHelperFactory = new Mock<IUrlHelperFactory>();
        urlHelperFactory.Setup(x => x.GetUrlHelper(It.IsAny<ActionContext>()))
            .Returns(urlHelper.Object);
        var helper = new PageLinkTagHelper(urlHelperFactory.Object) {
            PageModel = new PagingInfo {
                CurrentPage = 2,
                TotalCount = 28,
                ItemsPerPage = 10,
            },
            PageAction = "Test",
        };
        var ctx = new TagHelperContext(new TagHelperAttributeList(), new Dictionary<object, object>(), "");
        var context = new Mock<TagHelperContent>();
        var output = new TagHelperOutput("div", new TagHelperAttributeList(), 
            (cache, encoder) => Task.FromResult(context.Object));
        
        helper.Process(ctx, output);

        Assert.Equal(@"<a href=""Test/Page1"">1</a><a href=""Test/Page2"">2</a><a href=""Test/Page3"">3</a>", 
            output.Content.GetContent());        
    }
}