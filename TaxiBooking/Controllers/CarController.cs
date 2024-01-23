using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using TaxiBooking.Mapper;
using TaxiBooking.Models.DTO.CarDto;
using TaxiBooking.Models.Entities;
using TaxiBooking.Repositories;
using TaxiBooking.Repositories.Helper;

namespace TaxiBooking.Controllers
{
    [TokenAuthorize]
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;
        public CarController()
        {
            _carRepository = new CarRepository();
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost] 
        public ActionResult Add(CreateCarDto input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(input);
                }
                bool isSaved = true;
                if (input.Attachment != null)
                {
                    isSaved=saveFile(input.Attachment);
                    if (!isSaved)
                        return View(input);
                }
                var car = AutoMap.Mapper.Map<Car>(input);
                car.Attachment = input.Attachment != null ? Path.Combine("\\Content\\files", Path.GetFileName(input.Attachment.FileName)) : null;

                var state = _carRepository.Add(car);
                return Json(state);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, "Add api");
                return Json(ex.Message);
            }
        }
        [HttpPost] 
        public ActionResult Update(UpdateCarDto input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(input);
                }
                var car = _carRepository.GetById(input.Id);

                if (car != null)
                {
                    if(input.Attachment != null)
                    {
                        var isSaved = saveFile(input.Attachment);
                        if (!isSaved)
                        {
                            return Json(false);
                        }
                    }
                    var attachment = input.Attachment != null ? Path.Combine("\\Content\\files", Path.GetFileName(input.Attachment.FileName)) : car.Attachment;
                    car = AutoMap.Mapper.Map<Car>(input);
                    car.Attachment = attachment;
                    _carRepository.Update(car);
                }                
                return Json(true);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, "Update api");
                return Json(false);
            }
        }

        [HttpPost]
        [Route("Delete/{id}")] 
        public ActionResult Delete(Guid id)
        {
            try
            {
                var car = _carRepository.GetById(id);
                return Json(_carRepository.Delete(car));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, "Delete api");
                return Json(ex.Message);
            }
        }
        [HttpGet] 
        public ActionResult GetById(Guid id)
        {
            try
            {                
                UrlHelper urlHelper = new UrlHelper(ControllerContext.RequestContext);
                string baseUrl = urlHelper.RequestContext.HttpContext.Request.Url.GetLeftPart(UriPartial.Authority);
                var car = _carRepository.GetById(id);
                if(car == null) { return Json("car not found."); }
                var carDto = AutoMap.Mapper.Map<CarDto>(car);
                carDto.Attachment = car.Attachment != null ? Path.Combine(baseUrl, car.Attachment) : car.Attachment;
                return Json(carDto, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, "GetById api");
                return Json(ex.Message);
            }
        }
        [HttpGet]
      
        public ActionResult GetList()
        {
            try
            {               
                return Json(GetListDto(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, "GetList api");
                return Json(ex.Message);
            }
        }
        private bool saveFile(HttpPostedFileBase file)
        {
            try
            {
                string path = Path.Combine(Server.MapPath("~/Content/files"),
                Path.GetFileName(file.FileName));
                file.SaveAs(path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private List<CarDto> GetListDto()
        {
            var cars = _carRepository.ListCar();
            UrlHelper urlHelper = new UrlHelper(ControllerContext.RequestContext);
            string baseUrl = urlHelper.RequestContext.HttpContext.Request.Url.GetLeftPart(UriPartial.Authority);
            var carListDto = AutoMap.Mapper.Map<List<Car>, List<CarDto>>(cars);
            for (int i = 0; i < cars.Count; i++)
            {
                carListDto[i].Attachment = cars[i].Attachment != null ? Path.Combine(baseUrl, cars[i].Attachment) : cars[i].Attachment;
            }
            return carListDto;
        }
      
    }
}