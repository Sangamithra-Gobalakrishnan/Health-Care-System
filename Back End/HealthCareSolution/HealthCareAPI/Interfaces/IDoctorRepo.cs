namespace HealthCareAPI.Interfaces
{
    public interface IDoctorRepo<T>
    {
        public Task<T?> Add(T doctor);
        public Task<ICollection<T>?> GetAll();
    }
}
