namespace Task.Service
{
    using System.Web.Http;
    using System.Web.Http.Cors;
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            enableCors(config);
            config.MapHttpAttributeRoutes();
        }

        private static void enableCors(HttpConfiguration config) => config.EnableCors(new
                EnableCorsAttribute(
                           origins: "*",
                           headers: "*",
                           methods: "*"));
    }
}
