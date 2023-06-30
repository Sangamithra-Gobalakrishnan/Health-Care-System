namespace HealthCareAPI.Interfaces
{
    public interface IUserRepo<T,S>
    {
        public Task<T?> Add(T user);
        public Task<T?> Update(T user);
        public Task<T?> GetIDByEmail(S email);
        public Task<T> Get(S id);
    }
}
