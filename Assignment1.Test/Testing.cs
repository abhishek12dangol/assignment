using System;
using Xunit;
namespace Assignment1.Test;

public class Testing
{
    [Fact]
    public void UrlParser_ValidUrlWithoutId_ShouldParseCorrectly()
    {
        // Arrange
        var urlParser = new UrlParser();
        var url = "/api/categories";
        // Act
        var result = urlParser.ParseUrl(url);
        // Assert
        Assert.True(result);
        Assert.False(urlParser.HasId);
        Assert.Equal("/api/categories", urlParser.Path);
    }

    [Fact]
    public void UrlParser_ValidUrlWithId_ShouldParseCorrectly()
    {
        // Arrange
        var urlParser = new UrlParser();
        var url = "/api/categories/5";
        // Act
        var result = urlParser.ParseUrl(url);
        // Assert
        Assert.True(result);
        Assert.True(urlParser.HasId);
        Assert.Equal("5", urlParser.Id);
        Assert.Equal("/api/categories", urlParser.Path);
    }
}

