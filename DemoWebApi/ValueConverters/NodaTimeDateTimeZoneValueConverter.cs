using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;

namespace DemoWebApi.ValueConverters
{
    internal class NodaTimeDateTimeZoneValueConverter : ValueConverter<DateTimeZone, string>
    {
        private static readonly Expression<Func<DateTimeZone, string>> ConvertToDb = zone => zone.Id;
        private static readonly Expression<Func<string, DateTimeZone>> ConvertFromDb = id => DateTimeZoneProviders.Tzdb.GetZoneOrNull(id);

        public NodaTimeDateTimeZoneValueConverter(ConverterMappingHints mappingHints = null) 
            : base(ConvertToDb, ConvertFromDb, mappingHints) { }

        public static ValueConverterInfo DefaultInfo { get; }
            = new ValueConverterInfo(
                typeof(DateTimeZone), 
                typeof(string), 
                i => new NodaTimeDateTimeZoneValueConverter(i.MappingHints));
    }
}
