using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.WebUI.HtmlHelpers;
using SportsStore.WebUI.Models;

namespace SportsStore.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void CanGeneratePageLinks()
        {
            HtmlHelper htmlHelper = null;

            var pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                ItemsPerPage = 10,
                TotalItems = 28
            };

            Func<int, string> pageUrlDelegate = i => $"page/{i}";

            // ReSharper disable once ExpressionIsAlwaysNull
            var result = htmlHelper.PageLinks(pagingInfo, pageUrlDelegate);

            Assert.AreEqual(result.ToString(), @"<a href=""page/1"">1</a><a class=""selected"" href=""page/2"">2</a><a href=""page/3"">3</a>");
        }
    }
}
