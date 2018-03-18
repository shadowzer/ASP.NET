using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CrossPlatformWebApp.Controllers {
	[Route("api/[controller]")]
	public class ValuesController : Controller {
		private readonly ILogger _logger;

		public ValuesController() {
			_logger = new LoggerFactory()
				.AddConsole()
				.CreateLogger<ValuesController>();
		}

		// GET api/values
		[HttpGet]
		public IEnumerable<string> Get() {
			_logger.LogInformation($"{DateTime.Now}:\t[GET] {this.GetType()}");
			return new string[] {"value1", "value2"};
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public string Get(int id) {
			_logger.LogInformation($"{DateTime.Now}:\t[GET] {this.GetType()} id={id}");
			return $"value with id[{id}]";
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody] string value) {
			_logger.LogInformation($"{DateTime.Now}:\t[POST] {this.GetType()} value={value}");
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value) {
			_logger.LogInformation($"{DateTime.Now}:\t[PUT] {this.GetType()} id={id}&value={value}");
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id) {
			_logger.LogInformation($"{DateTime.Now}:\t[DELETE] {this.GetType()} id={id}");
		}
	}
}