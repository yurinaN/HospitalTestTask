namespace Hospital.Core.Extentions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Не найдено") { }
    }
}
