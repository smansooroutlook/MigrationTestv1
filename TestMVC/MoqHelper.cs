using System;
using System.Collections.Specialized;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Routing;

namespace Mvc.Tests
{
    // Moq helper class.
    // Source: http://www.hanselman.com/blog/ASPNETMVCSessionAtMix08TDDAndMvcMockHelpers.aspx

    public static class MoqHelpers1
    {
        // creates a fake HttpContext
        public static ActionContext FakeHttpContext()
        {
            var context = new Mock<ActionContext>();
            //context = new Mock<HttpContext>();
            var request = new Mock<HttpRequest>();
            var response = new Mock<HttpResponse>();
            var session = new Mock<ISession>();
            //var server = new Mock<IHtmlHelper>();

            context.Setup(c => c.HttpContext.Request).Returns(request.Object);
            context.Setup(c => c.HttpContext.Response).Returns(response.Object);
            context.Setup(c => c.HttpContext.Session).Returns(session.Object);
            //context.Setup(c => c.Server).Returns(server.Object);

            return context.Object;
        }

        
        // creates a fake HttpContext for a given a request Url

        public static ActionContext FakeHttpContext(string url)
        {
            var context = FakeHttpContext();
            context.HttpContext.Request.Path = url;
            return context;
        }

        // creates a fake controller context. For a given controller.

        public static void SetFakeControllerContext(this Controller controller)
        {
            var httpContext = FakeHttpContext();
            var context = new ControllerContext(new ActionContext(httpContext));
            controller.ControllerContext = context;
        }

        // setup requested URL.

        public static void SetupRequestUrl(this HttpRequest request, string url)
        {
            if (url == null)
                throw new ArgumentNullException("url");

            if (!url.StartsWith("~/"))
                throw new ArgumentException("Expected a virtual url starting with '~/'");

            var mock = Mock.Get(request);

            //mock.Setup(req => req.QueryString).Returns(GetQueryStringParameters(url));
            //mock.Setup(req => req.AppRelativeCurrentExecutionFilePath).Returns(GetUrlFileName(url));
            mock.Setup(req => req.Path.Value).Returns(string.Empty);
        }

        // setup POST or GET method.

        public static void SetHttpMethodResult(this HttpRequest request, string httpMethod)
        {
            Mock.Get(request).Setup(req => req.HttpContext.Request.Method).Returns(httpMethod);
        }

        private static string GetUrlFileName(string url)
        {
            if (url.Contains("?"))
                return url.Substring(0, url.IndexOf("?"));
            else
                return url;
        }

        private static NameValueCollection GetQueryStringParameters(string url)
        {
            if (url.Contains("?"))
            {
                var parameters = new NameValueCollection();

                string[] parts = url.Split("?".ToCharArray());
                string[] keys = parts[1].Split("&".ToCharArray());

                foreach (string key in keys)
                {
                    string[] part = key.Split("=".ToCharArray());
                    parameters.Add(part[0], part[1]);
                }

                return parameters;
            }
            else
            {
                return null;
            }
        }
    }
}
