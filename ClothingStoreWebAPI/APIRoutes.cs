namespace ClothingStoreWebAPI
{
    public class APIRoutes
    {
        public const string BaseRoute = "api/v{version:apiVersion}/[controller]";

        public class UserProfiles
        {
            public const string IdRoute = "{id}" ;
        }

        public class Business {
            public const string GetById = "{id}";
        }

    }
}
