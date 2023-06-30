namespace HealthCareAPI.Interfaces
{
    public interface IPatientRepo<T>
    {
        public Task<T?> Add(T patient);
        public Task<ICollection<T>?> GetAll();
    }
}
