using System.Linq;
using AutoMapper;
using QueueManagement.Core.DataModels;
using QueueManagement.Core.ViewModels;
using QueueManagement.Service.PatientSection;
using System.Web.Mvc;

namespace QueueManagement.Mvc.Controllers
{
    public class PatientsController : Controller
    {
        private readonly PatientManager _patientManager;

        public PatientsController()
        {
            _patientManager = new PatientManager();
        }

        // GET: Patients
        public ActionResult Index()
        {
            var patientList = _patientManager.GetAll().Select(Mapper.Map<Patient, PatientViewModel>);
            return View(patientList);
        }

        public ActionResult Create()
        {
            ViewBag.Action = "Save";
            return View();
        }

        [HttpPost]
        public ActionResult Create(PatientViewModel patientVm)
        {
            ViewBag.Message = "";
            ViewBag.Css = "";

            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                var isPhoneNoExist = _patientManager.IsPhoneNoExist(patientVm.PhoneNo);
                if (isPhoneNoExist)
                {
                    ViewBag.Css = "text-info";
                    ViewBag.Message = "This Phone No Already In Database";
                }
                else
                {
                    var patient = Mapper.Map<PatientViewModel, Patient>(patientVm);
                    if (patientVm.Id == 0)
                    {
                        int success = _patientManager.Save(patient);
                        if (success > 0)
                        {
                            ModelState.Clear();
                            ViewBag.Css = "text-success";
                            ViewBag.Message = "Save Success !!!";
                            return View();
                        }
                        ViewBag.Css = "text-danger";
                        ViewBag.Message = "Save Fail !!!";
                        return View(patientVm);
                    }
                    else
                    {
                        int success = _patientManager.Update(patientVm.Id, patient);
                        if (success > 0)
                        {
                            ModelState.Clear();
                            ViewBag.Css = "text-success";
                            ViewBag.Message = "Update Success !!!";
                            return View();
                        }
                        ViewBag.Css = "text-danger";
                        ViewBag.Message = "Update Fail !!!";
                        return View(patientVm);
                    }

                }
            }
            return View(patientVm);
        }

        public ActionResult Edit(int id)
        {
            var patient = _patientManager.GetById(id);
            if (patient != null)
            {
                ViewBag.Action = "Update";

                var patientVm = Mapper.Map<Patient, PatientViewModel>(patient);
                return View("Create", patientVm);
            }
            return HttpNotFound();
        }
    }
}