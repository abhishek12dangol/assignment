using System;
using Xunit;
namespace Assignment1.Test;

public class Testing
{
    [Fact]
    public void RequestValidator_NoMethod_ShouldReturnMissingMethod()
    {
        // Arrange
        var requestValidator = new RequestValidator();
        var request = new Request
        {
            Path = "/api/xxx",
            Date = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()
        };
        // Act
        var result = requestValidator.ValidateRequest(request);
        // Assert
        Assert.Contains("missing method", result.Status);
    }

    [Fact]
    public void RequestValidator_InvalidMethod_ShouldReturnIllegalMethod()
    {
        // Arrange
        var requestValidator = new RequestValidator();
        var request = new Request
        {
            Method = "fetch",
            Path = "/api/categories/1",
            Date = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()
        };
        // Act
        var result = requestValidator.ValidateRequest(request);
        // Assert
        Assert.Contains("illegal method", result.Status);
    }

    [Fact]
    public void RequestValidator_NoPath_ShouldReturnMissingPath()
    {
        // Arrange
        var requestValidator = new RequestValidator();
        var request = new Request
        {
            Method = "read",
            Path = "",
            Date = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()
        };
        // Act
        var result = requestValidator.ValidateRequest(request);
        // Assert
        Assert.Contains("missing path", result.Status);
    }

    [Fact]
    public void RequestValidator_NoDate_ShouldReturnMissingDate()
    {
        // Arrange
        var requestValidator = new RequestValidator();
        var request = new Request
        {
            Method = "read",
            Path = "/api/xxx",
        };
        // Act
        var result = requestValidator.ValidateRequest(request);
        // Assert
        Assert.Contains("missing date", result.Status);
    }

    [Fact]
    public void RequestValidator_InvalidDate_ShouldReturnIllegalDate()
    {
        // Arrange
        var requestValidator = new RequestValidator();
        var request = new Request
        {
            Method = "read",
            Path = "/api/xxx",
            Date = DateTime.Now.ToString()
        };
        // Act
        var result = requestValidator.ValidateRequest(request);
        // Assert
        Assert.Contains("illegal date", result.Status);
    }

    [Theory]
    [InlineData("create")]
    [InlineData("update")]
    [InlineData("echo")]
    public void RequestValidator_NoBody_ShouldReturnMissingBody(string method)
    {
        // Arrange
        var requestValidator = new RequestValidator();
        var request = new Request
        {
            Method = method,
            Path = "/api/xxx",
            Date = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()
        };
        // Act
        var result = requestValidator.ValidateRequest(request);
        // Assert
        Assert.Contains("missing body", result.Status);
    }

    [Theory]
    [InlineData("create", "{\"id\":1,\"name\":\"xxx\"}")]
    [InlineData("update", "{\"id\":1,\"name\":\"xxx\"}")]
    public void RequestValidator_JasonBody_ShouldReturnOk(string method, string body)
    {
        // Arrange
        var requestValidator = new RequestValidator();
        var request = new Request
        {
            Method = method,
            Path = "/api/xxx",
            Date = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),
            Body = body
        };
        // Act
        var result = requestValidator.ValidateRequest(request);
        // Assert
        Assert.Equal("1 Ok", result.Status);
    }

    [Theory]
    [InlineData("create", "xxx")]
    [InlineData("update", "xxx")]
    public void RequestValidator_NoJasonBody_ShouldReturnIllegalBody(string method, string body)
    {
        // Arrange
        var requestValidator = new RequestValidator();
        var request = new Request
        {
            Method = method,
            Path = "/api/xxx",
            Date = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),
            Body = body
        };
        // Act
        var result = requestValidator.ValidateRequest(request);
        // Assert
        Assert.Contains("illegal body", result.Status);
    }


    [Fact]
    public void RequestValidator_ValidGetRequest_ShouldReturnTrue()
    {
        // Arrange
        var requestValidator = new RequestValidator();
        var request = new Request
        {
            Method = "read",
            Path = "/api/categories/1",
            Date = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()
        };
        // Act
        var result = requestValidator.ValidateRequest(request);
        // Assert
        Assert.Equal("1 Ok", result.Status);
    }
}

