namespace ChurrascApp.Application.Interfaces.Services;

public interface IBaseService<TResponseDto, TRegisterDto, TUpdateDto>
{
    Task<TResponseDto> GetById(string id);
    Task<IEnumerable<TResponseDto>> GetAll();
    Task<TResponseDto> Register(TRegisterDto registerDto);
    Task<TResponseDto> Update(TUpdateDto updateDto);
    Task Delete(string id);
}