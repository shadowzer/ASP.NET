using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using MEFLogger;

namespace MEF.Controllers {
	public class HomeController : ApiController {
		[Import(typeof(ILogger))]
		public ILogger Logger { get; set; }

		public HomeController() {
			var catalog = new AggregateCatalog();
			//Adds all the parts found in the same assembly as the Program class  
			catalog.Catalogs.Add(new AssemblyCatalog(typeof(ILogger).Assembly));

			var container = new CompositionContainer(catalog);
			container.ComposeParts(this);
		}

		[System.Web.Http.HttpGet]
		public HttpStatusCodeResult Index(string msg) {
			if (Logger == null) 
				return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
			
			Logger.Log(msg);
			return new HttpStatusCodeResult(HttpStatusCode.OK);
		}
	}
}