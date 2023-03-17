using Arch_lab.Models.Enum;

namespace Arch_lab.Models.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; }

        public StatusCode StatusCode { get; set;  }

        public T Data { get; set; }
    }

    public interface IBaseResponse<T>
    {
        public string Description { get; }

        StatusCode StatusCode { get; }

        T Data { get; }

    }
}
