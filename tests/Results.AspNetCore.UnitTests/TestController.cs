namespace Results.AspNetCore.UnitTests
{
    using System.Threading.Tasks;
    using MadEyeMatt.Results;
    using MadEyeMatt.Results.AspNetCore;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
	[Route("test")]
	[AllowAnonymous]
	public class TestController : ControllerBase
	{
        private readonly IActionResultTransformer transformer;

        public TestController(IActionResultTransformer transformer)
        {
            this.transformer = transformer;
        }

		[HttpGet("ok")]
		public IActionResult OkDefault()
		{
			Result result = Result.Ok();
			return result.ToActionResult(this.transformer);
		}

		[HttpGet("ok/value")]
		public IActionResult OkValue()
		{
			Result<int> result = Result.Ok(42);
			return result.ToActionResult(this.transformer);
		}

		[HttpGet("ok/async")]
		public Task<IActionResult> OkAsync()
		{
			Task<Result> CreateResult()
			{
				return Task.FromResult(Result.Ok());
			}

			Task<Result> result = CreateResult();
			return result.ToActionResult(this.transformer);
		}

		[HttpGet("ok/value/async")]
		public Task<IActionResult> OkValueAsync()
		{
			Task<Result<int>> CreateResult()
			{
				return Task.FromResult(Result.Ok(42));
			}

			Task<Result<int>> result = CreateResult();
			return result.ToActionResult(this.transformer);
		}

		[HttpGet("fail")]
		public IActionResult Fail()
		{
			Result result = Result.Fail("An error occurred.");
			return result.ToActionResult(this.transformer);
		}

		[HttpGet("fail/value")]
		public IActionResult FailValue()
		{
			Result<int> result = Result.Fail<int>("An error occurred.");
			return result.ToActionResult(this.transformer);
		}

		[HttpGet("fail/async")]
		public Task<IActionResult> FailAsync()
		{
			Task<Result> CreateResult()
			{
				return Task.FromResult(Result.Fail("An error occurred."));
			}

			Task<Result> result = CreateResult();
			return result.ToActionResult(this.transformer);
		}

		[HttpGet("fail/value/async")]
		public Task<IActionResult> FailValueAsync()
		{
			Task<Result<int>> CreateResult()
			{
				return Task.FromResult(Result.Fail<int>("An error occurred."));
			}

			Task<Result<int>> result = CreateResult();
			return result.ToActionResult(this.transformer);
		}
	}
}