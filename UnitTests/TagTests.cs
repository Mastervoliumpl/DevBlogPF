using DevBlogPF.BLL.Repositories;
using DevBlogPF.BLL.Interfaces;
using DevBlogPF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests.Tags
{
    [TestClass]
    public class TagTests
    {
        [TestMethod]
        public void TestCreateTag()
        {
            // Arrange
            TagRepo tagRepo = new TagRepo();
            string tagName = "Test Tag";

            // Act
            tagRepo.CreateTag(tagName);
            var tags = tagRepo.GetTags();

            // Assert
            Assert.AreEqual(1, tags.Count);
            Assert.AreEqual(tagName, tags[0].Name);
        }
    }
}
