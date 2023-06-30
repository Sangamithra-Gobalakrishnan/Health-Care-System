using HealthCareAPI.Models.DTO;

namespace HealthCareAPI.Interfaces
{
    public interface IGenerateToken<L>
    {
        public string GenerateToken(L loginDTO);
    }
}
