using Backend.DTOs;

namespace Backend.Services
{
    public interface ICommonService<T,TI,TU>
    {
        public List<string> Errors { get; }
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<T> Add(TI beerInsertDto);
        Task<T> Update(int id, TU beerUpdateDto);
        Task<bool> Delete(int id);
        bool IsValid(TI dto);
        bool IsValid(TU dto);
    }
}
