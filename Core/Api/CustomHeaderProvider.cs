using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public interface IRequestContext
    {
        string CorrelationId { get; }
    }






    public class RequestContextAdapter : IRequestContext
    {
        private readonly IHttpContextAccessor _accessor;
        public RequestContextAdapter(IHttpContextAccessor accessor)
        {
            this._accessor = accessor;
        }

        public string CorrelationId
        {
            get
            {
                return this._accessor.HttpContext.Request.Headers.ToString();
            }
        }
    }
}
