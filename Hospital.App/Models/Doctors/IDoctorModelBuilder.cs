using Hospital.Core.Models.Common;

namespace Hospital.App.Models.Doctors
{
    public interface IDoctorModelBuilder
    {
        Task<PageModel<DoctorListItemModel>> GetAsync(DoctorGetListParamsModel paramsModel);
        DoctorItemModel Get(Guid id);
    }
}
