using ECommerceApp.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace ECommerceApp.Tests
{
    public class GlobalExceptionFilterTests
    {
        [Fact] // This tells Visual Studio: "Hey, this is a test!"
        public void OnException_SetsStatusCodeTo500()
        {
            // 1. SETUP: Prepare the fake actor and the Paramedic

            // We use 'Moq' to create a fake Logger (so we don't actually print to a real console)
            var mockLogger = new Mock<ILogger<GlobalExceptionFilter>>();
            var filter = new GlobalExceptionFilter(mockLogger.Object);

            // We create a fake web request and a fake error
            var httpContext = new DefaultHttpContext();
            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>())
            {
                Exception = new System.Exception("Fake crash for testing!")
            };

            // 2. ACT: Make the Paramedic do their job!
            filter.OnException(exceptionContext);

            // 3. CHECK (Assert): Did the Paramedic do it correctly?

            // We look at the result the Paramedic gave us
            var result = exceptionContext.Result as ContentResult;

            // We Check: Did we get a result? (It shouldn't be empty)
            Assert.NotNull(result);

            // We Check: Is the status code exactly 500?
            Assert.Equal(500, result.StatusCode);

            // We Check: Did the Paramedic tell the system the error was handled?
            Assert.True(exceptionContext.ExceptionHandled);
        }
    }
}