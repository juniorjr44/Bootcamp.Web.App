namespace Bootcamp.Api.Helpers
{
    public static class RouteHelper
    {
        public static class Contact
        {
            private const string Base = "/contact";
            public const string Get = Base + "/{id}";
            public const string Main = Base;
            public const string Delete = Base + "/remove";
            public const string Update = Base + "/update";
            public const string Create = Base + "/create";
        }
    }
}
