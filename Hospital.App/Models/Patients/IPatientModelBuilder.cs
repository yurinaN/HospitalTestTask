using Hospital.Core.Models.Common;

namespace Hospital.App.Models.Patients
{
    public interface IPatientModelBuilder
    {
        Task<PageModel<PatientListItemModel>> GetAsync(PatientGetListParamsModel paramsModel);
        PatientItemModel Get(Guid id);
    }
}
