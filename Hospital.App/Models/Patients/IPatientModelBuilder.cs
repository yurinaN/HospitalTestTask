using Hospital.Core.Models.Common;

namespace Hospital.App.Models.Patients
{
    public interface IPatientModelBuilder
    {
        Task<PageModel<PatientListItemModel>> GetAsync(OrderingForm orderingForm, int itemsCount, int page);
        PatientItemModel Get(Guid id);
    }
}
