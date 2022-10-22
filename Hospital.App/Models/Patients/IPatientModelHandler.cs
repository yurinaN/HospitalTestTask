namespace Hospital.App.Models.Patients
{
    public interface IPatientModelHandler
    {
        void Create(PatientForm form);
        void Edit(Guid id, PatientForm form);
        void Delete(Guid id);
    }
}
