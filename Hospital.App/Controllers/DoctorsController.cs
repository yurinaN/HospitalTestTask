using Hospital.App.Models.Doctors;
using Hospital.Core.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorModelBuilder doctorModelBuilder;
        private readonly IDoctorModelHandler doctorModelHandler;

        public DoctorsController(IDoctorModelBuilder doctorModelBuilder, 
            IDoctorModelHandler doctorModelHandler)
        {
            this.doctorModelBuilder = doctorModelBuilder;
            this.doctorModelHandler = doctorModelHandler;
        }

        /// <summary>
        /// Постраничное получение списка докторов
        /// </summary>
        /// <param name="paramsModel"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PageModel<DoctorListItemModel>> Get([FromQuery] DoctorGetListParamsModel paramsModel)
        {
            return await doctorModelBuilder.GetAsync(paramsModel);
        }

        /// <summary>
        /// Получение доктора по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public DoctorItemModel Get(Guid id)
        {
            return doctorModelBuilder.Get(id);
        }

        /// <summary>
        /// Создание доктора
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(DoctorForm form)
        {
            doctorModelHandler.Create(form);
            return Ok();
        }

        /// <summary>
        /// Редактирование доктора
        /// </summary>
        /// <param name="id"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Edit(Guid id, DoctorForm form)
        {
            doctorModelHandler.Edit(id, form);
            return Ok();
        }

        /// <summary>
        /// Удаление доктора
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            doctorModelHandler.Delete(id);
            return Ok();
        }
    }
}
