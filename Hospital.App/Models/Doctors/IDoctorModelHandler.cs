namespace Hospital.App.Models.Doctors
{
    public interface IDoctorModelHandler
    {
        void Create(DoctorForm form);
        void Edit(Guid id, DoctorForm form);
        void Delete(Guid id);
    }
}
