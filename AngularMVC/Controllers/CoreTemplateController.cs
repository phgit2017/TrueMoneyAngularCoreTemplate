using Business.TrueMoney.Core.Dto;
using Business.TrueMoney.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularMVC.Controllers
{
    public class CoreTemplateController : Controller
    {
        private readonly IServerGuideServices _serverGuideServices;

        public CoreTemplateController(IServerGuideServices serverGuideServices)
        {
            this._serverGuideServices = serverGuideServices;
        }

        public ActionResult WalletMovement()
        {
            return View();
        }

        public ActionResult StartupGuide()
        {
            return View();
        }

        public ActionResult ServerGuides()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetServerGuides()
        {
            var result = this._serverGuideServices.GetAll().ToList();
            var response = new
            {
                result = result,
                isSuccess = true
            };
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetServerTypes()
        {
            var result = this._serverGuideServices.GetAllServerTypes().ToList();
            var response = new
            {
                result = result
            };
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CreateServerGuides(ServerGuideDetailRequest request)
        {
            bool isSuccess = false;

            request.CreatedBy = 0;
            request.CreatedTime = System.DateTime.Now;
            var result = _serverGuideServices.SaveDetails(request);

            if (result > 0)
            {
                isSuccess = true;
                request.ServerId = result;
            }

            var response = new
            {
                isSuccess = isSuccess,
                dto = request
            };

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateServerGuides(ServerGuideDetailRequest request)
        {
            bool isSuccess = false;
            var result = _serverGuideServices.UpdateDetails(request);

            isSuccess = result;

            var response = new
            {
                isSuccess = isSuccess,
                dto = request
            };

            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}