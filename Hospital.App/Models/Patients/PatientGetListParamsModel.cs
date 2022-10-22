using System.ComponentModel.DataAnnotations;

namespace Hospital.App.Models.Patients
{
    public class PatientGetListParamsModel
    {
        public string? FieldName { get; set; }
        public bool? IsAscending { get; set; }
        public int ItemsCount { get; set; } = 5;
        [RegularExpression(@"^[0-9]*[1-9]+$|^[1-9]+[0-9]*$", ErrorMessage = "Число должно быть больше 0")]
        public int Page { get; set; } = 1;
    }
}
