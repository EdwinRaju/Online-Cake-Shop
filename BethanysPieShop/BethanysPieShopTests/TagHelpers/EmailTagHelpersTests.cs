using BethanysPieShop.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Moq;
using Ninject.Activation.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShopTests.TagHelpers
{
    public  class EmailTagHelpersTests
    {
        [Fact]
        public void Generates_Email_Link()
        {
            EmailTagHelper emailTagHelper = new EmailTagHelper()
            {
                Address = "test@bethanyspieshop.com",
                Content = "Email"
            };

            var tagHelperContext = new TagHelperContext(
                new TagHelperAttributeList(),
                new Dictionary<object, object>(), string.Empty);    
            var context = new Mock<TagHelperContext>();
            var tagHelperOutput = new TagHelperOutput("a",
                     new TagHelperAttributeList(),
                     (cache, encoder) =>
                     {
                         // Create and return a TagHelperContent object
                         var content = new DefaultTagHelperContent();
                         content.Append("Default Content"); // Add some default content
                         return Task.FromResult<TagHelperContent>(content);
                     });


            emailTagHelper.Process(tagHelperContext, tagHelperOutput);

            Assert.Equal("Email",tagHelperOutput.Content.GetContent());
            Assert.Equal("a", tagHelperOutput.TagName);
            Assert.Equal("mailto:test@bethanyspieshop.com", tagHelperOutput.Attributes[0].Value);
        }
    }
}
