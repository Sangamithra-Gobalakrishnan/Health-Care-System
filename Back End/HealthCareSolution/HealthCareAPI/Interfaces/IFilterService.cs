namespace HealthCareAPI.Interfaces
{
    public interface IFilterService<D,P>
    {
        public Task<ICollection<D>?> GetAllDoctors();
        public Task<ICollection<P>?> GetAllPatients();
    }
}
