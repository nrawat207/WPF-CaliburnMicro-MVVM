using Flurl;
using Flurl.Http;
using System.Configuration;

namespace WPF_CaliburnMicro_MVVM.Services
{
    public abstract class ApiServiceBase
    {
        public readonly string baseUrl;

        protected ApiServiceBase()
        {
            baseUrl = ConfigurationManager.AppSettings["WebApiUrl"];
        }

        protected IFlurlRequest Url(object values = null, params string[] segments)
        {
            return baseUrl
                .SetQueryParams(values)
                .AppendPathSegments(segments)
                .WithHeader("Accept", "application/json");
        }
        protected IFlurlRequest Url(params string[] segments)
        {
            return Url(null, segments);
        }

    }
}
