using AutoMapper;

namespace TaxiBooking.Mapper
{
    public static class AutoMap
    {
        public static IMapper Mapper { get; set; }

        public static void RegisterMappings()
        {
            var mapperConfiguration = new MapperConfiguration(
               config =>
               {
                   config.AddProfile<CarProfile>();
               });

            Mapper = mapperConfiguration.CreateMapper();
        }
    }
}