using AghaShad_Shop.Errors;
using System.Net;

namespace AghaShad_Shop.OutPut
{
    public class ApiResponseResult<T> where T : class
    {
        public T? Result { get; set; }
        public HttpStatusCode? HttpStatusCode { get; set; }
        public Error? Error { get; set; }
    }
}
