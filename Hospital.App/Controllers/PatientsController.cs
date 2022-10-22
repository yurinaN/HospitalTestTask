using Hospital.App.Models.Patients;
using Hospital.Core.Models.Common;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Hospital.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientModelBuilder patientModelBuilder;
        private readonly IPatientModelHandler patientModelHandler;

        public PatientsController(IPatientModelBuilder patientModelBuilder, 
            IPatientModelHandler patientModelHandler)
        {
            this.patientModelBuilder = patientModelBuilder;
            this.patientModelHandler = patientModelHandler;
        }

        /// <summary>
        /// Постраничное полученик списка всех пациентов с сортировкой
        /// </summary>
        /// <param name="orderingForm"></param>
        /// <param name="itemsCount"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PageModel<PatientListItemModel>> Get([FromQuery] OrderingForm orderingForm, int itemsCount = 5, 
            [RegularExpression(@"^[0-9]*[1-9]+$|^[1-9]+[0-9]*$", ErrorMessage = "Число должно быть больше 0")] int page = 1)
        {
            return await patientModelBuilder.GetAsync(orderingForm, itemsCount, page);
        }

        /// <summary>
        /// Получение пациента по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public PatientItemModel Get(Guid id)
        {
            return patientModelBuilder.Get(id);
        }

        /// <summary>
        /// Создание нового пациента
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(PatientForm form)
        {
            patientModelHandler.Create(form);
            return Ok();
        }

        /// <summary>
        /// Редактирование пациента
        /// </summary>
        /// <param name="id"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Edit(Guid id, PatientForm form)
        {
            patientModelHandler.Edit(id, form);
            return Ok();
        }

        /// <summary>
        /// Удаление пациента
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            patientModelHandler.Delete(id);
            return Ok();
        }
    }
}
