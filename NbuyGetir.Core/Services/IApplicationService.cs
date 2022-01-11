using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Services
{
    #region Sample
    public class UserCreateDto
    {
        public string Email { get; set; }
    }

    public class UserCreateResultDto
    {
        public bool IsSucceded { get; set; }
        public string Message { get; set; }
    }

    public interface IUserCreateApplicationService: IApplicationService<UserCreateDto, UserCreateResultDto>
    {

    }

    public class UserCreateService : IUserCreateApplicationService
    {
        public Task<UserCreateResultDto> HandleAsync(UserCreateDto dto)
        {
            throw new NotImplementedException();
        }
    }

    #endregion

    /// <summary>
    ///  Frontend tarafından gelen bir istediğin işlenip frontend tarafına bir sonucun döndürülmesi için yaptık. Api de Input Model ve View Model yerine artık Dto (Data Transfer Object) terimini kullanacağız. Buradaki servisi Application katmanı için yazıyoruz.
    /// </summary>
    /// <typeparam name="TRequestDto"> Input Model</typeparam>
    /// <typeparam name="TResultDto">ViewModel olarak kullanacağız </typeparam>
    public interface IApplicationService<TRequestDto,TResultDto>
    {
        Task<TResultDto> HandleAsync(TRequestDto dto);
    }
}
