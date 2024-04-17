namespace Results.AspNetCore.UnitTests
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using FluentAssertions;
    using MadEyeMatt.Results;
    using MadEyeMatt.Results.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.TestHost;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using NUnit.Framework;

    [TestFixture("Controller")]
    [TestFixture("MinimalApi")]
	public class IntegrationTests
	{
        private readonly string mode;

        private TestServer testServer;
		private HttpClient testClient;

        public IntegrationTests(string mode)
        {
            this.mode = mode;
        }

		[SetUp]
		public void Setup()
		{
			IWebHostBuilder hostBuilder = new WebHostBuilder()
				.ConfigureLogging(logging =>
				{
					logging.AddConsole();
				})
				.ConfigureServices(services =>
                {
                    services.AddProblemDetailsActionResultTransformer();
                    services.AddProblemDetailsHttpResultTransformer();

					services.AddLogging();
					services.AddCors();
					services
						.AddControllers()
						.AddControllersAsServices();
				})
				.Configure(app =>
				{
					app.UseCors(builder => builder.AllowAnyOrigin());
					app.UseRouting();
					app.UseEndpoints(builder =>
					{
						builder.MapControllers();

                        builder.MapGet("api/test/ok", (IHttpResultTransformer transformer) =>
						{
							Result result = Result.Ok();
							return result.ToHttpResult(transformer);
						});

                        //EndpointRouteBuilderExtensions.MapGet(builder, (string)"api/test/ok/custom", (Delegate)((IHttpResultTransformer transformer) =>
                        //{
                        //    CustomResultWithoutValue result = Result.Ok<CustomResultWithoutValue>();
                        //    return result.ToHttpResult(transformer);
                        //}));

                        builder.MapGet("api/test/ok/value", (IHttpResultTransformer transformer) =>
						{
							Result<int> result = Result.Ok(42);
							return result.ToHttpResult(transformer);
						});

                        //EndpointRouteBuilderExtensions.MapGet(builder, (string)"api/test/ok/value/custom", (Delegate)((IHttpResultTransformer transformer) =>
                        //{
                        //    CustomResultWithValue result = Result<int>.Ok<CustomResultWithValue>(42);
                        //    return result.ToHttpResult(transformer);
                        //}));

                        builder.MapGet("api/test/ok/async", (IHttpResultTransformer transformer) =>
						{
							Task<Result> CreateResult()
							{
								return Task.FromResult(Result.Ok());
							}

							Task<Result> result = CreateResult();
							return result.ToHttpResult(transformer);
						});

						//EndpointRouteBuilderExtensions.MapGet(builder, (string)"api/test/ok/async/custom", (Delegate)((IHttpResultTransformer transformer) =>
						//{
						//    Task<CustomResultWithoutValue> CreateResult()
						//    {
						//        return Task.FromResult(Result.Ok<CustomResultWithoutValue>());
						//    }

						//    Task<CustomResultWithoutValue> result = CreateResult();
						//    return result.ToHttpResult(transformer);
						//}));

						builder.MapGet("api/test/ok/value/async", (IHttpResultTransformer transformer) =>
						{
							Task<Result<int>> CreateResult()
							{
								return Task.FromResult(Result.Ok(42));
							}

							Task<Result<int>> result = CreateResult();
							return result.ToHttpResult(transformer);
						});

						//EndpointRouteBuilderExtensions.MapGet(builder, (string)"api/test/ok/value/async/custom", (Delegate)((IHttpResultTransformer transformer) =>
						//{
						//    Task<CustomResultWithValue> CreateResult()
						//    {
						//        return Task.FromResult(Result<int>.Ok<CustomResultWithValue>(42));
						//    }

						//    Task<CustomResultWithValue> result = CreateResult();
						//    return result.ToHttpResult<CustomResultWithValue, int>(transformer);
						//}));

						builder.MapGet("api/test/fail", (IHttpResultTransformer transformer) =>
						{
							Result result = Result.Fail("An error occurred.");
							return result.ToHttpResult(transformer);
						});

                        //EndpointRouteBuilderExtensions.MapGet(builder, (string)"api/test/fail/custom", (Delegate)((IHttpResultTransformer transformer) =>
                        //{
                        //    CustomResultWithoutValue result = Result.Fail<CustomResultWithoutValue>("An error occurred.");
                        //    return result.ToHttpResult(transformer);
                        //}));

                        builder.MapGet("api/test/fail/value", (IHttpResultTransformer transformer) =>
						{
							Result<int> result = Result.Fail<int>("An error occurred.");
							return result.ToHttpResult(transformer);
						});

                        //EndpointRouteBuilderExtensions.MapGet(builder, (string)"api/test/fail/value/custom", (Delegate)((IHttpResultTransformer transformer) =>
                        //{
                        //    CustomResultWithValue result = Result<int>.Fail<CustomResultWithValue>("An error occurred.");
                        //    return result.ToHttpResult(transformer);
                        //}));

                        builder.MapGet("api/test/fail/async", (IHttpResultTransformer transformer) =>
						{
							Task<Result> CreateResult()
							{
								return Task.FromResult(Result.Fail("An error occurred."));
							}

							Task<Result> result = CreateResult();
							return result.ToHttpResult(transformer);
						});

						//EndpointRouteBuilderExtensions.MapGet(builder, (string)"api/test/fail/async/custom", (Delegate)((IHttpResultTransformer transformer) =>
						//{
						//    Task<CustomResultWithoutValue> CreateResult()
						//    {
						//        return Task.FromResult(Result.Fail<CustomResultWithoutValue>("An error occurred."));
						//    }

						//    Task<CustomResultWithoutValue> result = CreateResult();
						//    return result.ToHttpResult(transformer);
						//}));

						builder.MapGet("api/test/fail/value/async", (IHttpResultTransformer transformer) =>
						{
							Task<Result<int>> CreateResult()
							{
								return Task.FromResult(Result.Fail<int>("An error occurred."));
							}

							Task<Result<int>> result = CreateResult();
							return result.ToHttpResult(transformer);
						});

						//EndpointRouteBuilderExtensions.MapGet(builder, (string)"api/test/fail/value/async/custom", (Delegate)((IHttpResultTransformer transformer) =>
						//{
						//    Task<CustomResultWithValue> CreateResult()
						//    {
						//        return Task.FromResult(Result<int>.Fail<CustomResultWithValue>("An error occurred."));
						//    }

						//    Task<CustomResultWithValue> result = CreateResult();
						//    return result.ToHttpResult<CustomResultWithValue, int>(transformer);
						//}));
					});
				});

			this.testServer = new TestServer(hostBuilder);
			this.testClient = this.testServer.CreateClient();
		}

		[TearDown]
		public void TearDown()
		{
			this.testClient?.Dispose();
			this.testServer?.Dispose();
		}

		[Test]
		public async Task ShouldReturnStatusCode200_ForOkResultWithoutValue()
        {
            string route = this.mode == "Controller" ? "test/ok" : "api/test/ok";
			HttpResponseMessage response = await this.testClient.GetAsync(route);
			response.StatusCode.Should().Be(HttpStatusCode.OK);
		}

		//[Test]
		//public async Task ShouldReturnStatusCode200_ForOkCustomResultWithoutValue()
		//{
  //          string route = this.mode == "Controller" ? "test/ok/custom" : "api/test/ok/custom";
  //          HttpResponseMessage response = await this.testClient.GetAsync(route);
		//	response.StatusCode.Should().Be(HttpStatusCode.OK);
		//}

		[Test]
		public async Task ShouldReturnStatusCode200_ForOkResultWithValue()
		{
            string route = this.mode == "Controller" ? "test/ok/value" : "api/test/ok/value";
            HttpResponseMessage response = await this.testClient.GetAsync(route);
			response.StatusCode.Should().Be(HttpStatusCode.OK);

			int value = await response.Content.ReadFromJsonAsync<int>();
			value.Should().Be(42);
		}

		//[Test]
		//public async Task ShouldReturnStatusCode200_ForOkCustomResultWithValue()
		//{
  //          string route = this.mode == "Controller" ? "test/ok/value/custom" : "api/test/ok/value/custom";
  //          HttpResponseMessage response = await this.testClient.GetAsync(route);
		//	response.StatusCode.Should().Be(HttpStatusCode.OK);

		//	int value = await response.Content.ReadFromJsonAsync<int>();
		//	value.Should().Be(42);
		//}

		[Test]
		public async Task ShouldReturnStatusCode200_ForOkResultWithoutValueAsync()
		{
            string route = this.mode == "Controller" ? "test/ok/async" : "api/test/ok/async";
            HttpResponseMessage response = await this.testClient.GetAsync(route);
			response.StatusCode.Should().Be(HttpStatusCode.OK);
		}

		//[Test]
		//public async Task ShouldReturnStatusCode200_ForOkCustomResultWithoutValueAsync()
		//{
  //          string route = this.mode == "Controller" ? "test/ok/async/custom" : "api/test/ok/async/custom";
  //          HttpResponseMessage response = await this.testClient.GetAsync(route);
		//	response.StatusCode.Should().Be(HttpStatusCode.OK);
		//}

		[Test]
		public async Task ShouldReturnStatusCode200_ForOkResultWithValueAsync()
		{
            string route = this.mode == "Controller" ? "test/ok/value/async" : "api/test/ok/value/async";
            HttpResponseMessage response = await this.testClient.GetAsync(route);
			response.StatusCode.Should().Be(HttpStatusCode.OK);

			int value = await response.Content.ReadFromJsonAsync<int>();
			value.Should().Be(42);
		}

		[Test]
		public async Task ShouldReturnStatusCode400_ForFailedResultWithoutValue()
		{
            string route = this.mode == "Controller" ? "test/fail" : "api/test/fail";
			HttpResponseMessage response = await this.testClient.GetAsync(route);
			response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            ValidationProblemDetails problemDetails = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
			problemDetails.Should().NotBeNull();
            problemDetails.Errors.Should().HaveCount(1);
			problemDetails.Should().HaveError("An error occurred.");
		}

		//[Test]
		//public async Task ShouldReturnStatusCode400_ForFailedCustomResultWithoutValue()
		//{
  //          string route = this.mode == "Controller" ? "test/fail/custom" : "api/test/fail/custom";
  //          HttpResponseMessage response = await this.testClient.GetAsync(route);
		//	response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

  //          ValidationProblemDetails problemDetails = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
		//	problemDetails.Should().NotBeNull();
  //          problemDetails.Errors.Should().HaveCount(1);
		//	problemDetails.Should().HaveError("An error occurred.");
		//}

		[Test]
		public async Task ShouldReturnStatusCode400_ForFailedResultWithValue()
		{
            string route = this.mode == "Controller" ? "test/fail/value" : "api/test/fail/value";
            HttpResponseMessage response = await this.testClient.GetAsync(route);
			response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            ValidationProblemDetails problemDetails = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
			problemDetails.Should().NotBeNull();
            problemDetails.Errors.Should().HaveCount(1);
			problemDetails.Should().HaveError("An error occurred.");
		}

		//[Test]
		//public async Task ShouldReturnStatusCode400_ForFailedCustomResultWithValue()
		//{
  //          string route = this.mode == "Controller" ? "test/fail/value/custom" : "api/test/fail/value/custom";
  //          HttpResponseMessage response = await this.testClient.GetAsync(route);
		//	response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

  //          ValidationProblemDetails problemDetails = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
		//	problemDetails.Should().NotBeNull();
  //          problemDetails.Errors.Should().HaveCount(1);
		//	problemDetails.Should().HaveError("An error occurred.");
		//}

		[Test]
		public async Task ShouldReturnStatusCode400_ForFailedResultWithoutValueAsync()
		{
            string route = this.mode == "Controller" ? "test/fail/async" : "api/test/fail/async";
            HttpResponseMessage response = await this.testClient.GetAsync(route);
			response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            ValidationProblemDetails problemDetails = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
			problemDetails.Should().NotBeNull();
			problemDetails.Should().HaveError("An error occurred.");
		}

		//[Test]
		//public async Task ShouldReturnStatusCode400_ForFailedCustomResultWithoutValueAsync()
		//{
  //          string route = this.mode == "Controller" ? "test/fail/async/custom" : "api/test/fail/async/custom";
  //          HttpResponseMessage response = await this.testClient.GetAsync(route);
  //          response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

		//	ValidationProblemDetails problemDetails = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
		//	problemDetails.Should().NotBeNull();
  //          problemDetails.Errors.Should().HaveCount(1);
		//	problemDetails.Should().HaveError("An error occurred.");
		//}

		[Test]
		public async Task ShouldReturnStatusCode400_ForFailedResultWithValueAsync()
		{
            string route = this.mode == "Controller" ? "test/fail/value/async" : "api/test/fail/value/async";
            HttpResponseMessage response = await this.testClient.GetAsync(route);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

			ValidationProblemDetails problemDetails = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
			problemDetails.Should().NotBeNull();
            problemDetails.Errors.Should().HaveCount(1);
			problemDetails.Should().HaveError("An error occurred.");
		}

		//[Test]
		//public async Task ShouldReturnStatusCode400_ForFailedCustomResultWithValueAsync()
		//{
  //          string route = this.mode == "Controller" ? "test/fail/value/async/custom" : "api/test/fail/value/async/custom";
  //          HttpResponseMessage response = await this.testClient.GetAsync(route);
		//	response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

  //          ValidationProblemDetails problemDetails = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
		//	problemDetails.Should().NotBeNull();
  //          problemDetails.Errors.Should().HaveCount(1);
		//	problemDetails.Should().HaveError("An error occurred.");
		//}
	}
}