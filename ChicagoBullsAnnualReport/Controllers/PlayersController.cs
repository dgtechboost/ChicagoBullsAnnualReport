using ChicagoBullsAnnualReport.Core;
using ChicagoBullsAnnualReport.Mapper;
using System.Web.Mvc;

namespace ChicagoBullsAnnualReport.Controllers
{
    public class PlayersController : Controller
    {
        private IReportHelper _reportHelper;
        private IFileHelper _fileHelper;
        private IReportBuilder _reportBuilder;
        private IModelMapper _modelMapper;

        public PlayersController(IReportHelper reportHelper, IFileHelper fileHelper, IReportBuilder reportBuilder, IModelMapper modelMapper)
        {
            _reportHelper = reportHelper;
            _fileHelper = fileHelper;
            _reportBuilder = reportBuilder;
            _modelMapper = modelMapper;
        }

        // GET: Players
        public ActionResult Index()
        {
            var data = _fileHelper.ExtractContent();
            var processedData = _reportHelper.ContentProcessor(data);
            var mapPlayers = _reportHelper.MapCSVDataToModel(processedData);
            var mapDomainPlayerToMvcModel = _modelMapper.MapDomainModels(mapPlayers);
            _reportBuilder.BuildReport(mapPlayers);
            return View(mapDomainPlayerToMvcModel);
        }

        // GET: Players/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Players/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Players/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Players/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
