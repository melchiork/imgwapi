using System.Net;

namespace ImgwApi.Test;

internal class MockHttpMessageHandler : HttpMessageHandler
{
    private readonly HttpStatusCode _statusCode;
    private readonly string _content;

    public MockHttpMessageHandler(HttpStatusCode statusCode, string content = "")
    {
        _statusCode = statusCode;
        _content = content;
    }

    public MockHttpMessageHandler(string fileName)
    {
        _statusCode = HttpStatusCode.OK;
        _content = File.ReadAllText(fileName);
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        return Task.FromResult(new HttpResponseMessage
        {
            StatusCode = _statusCode,
            Content = new StringContent(_content)
        });
    }
}