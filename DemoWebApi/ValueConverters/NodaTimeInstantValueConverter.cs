using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;

namespace DemoWebApi.ValueConverters
{
    internal class NodaTimeInstantValueConverter : ValueConverter<Instant, DateTime>
    {
        private static readonly Expression<Func<Instant, DateTime>> ConvertToDb = instant => instant.ToDateTimeUtc();
        private static readonly Expression<Func<DateTime, Instant>> ConvertFromDb = time => Instant.FromDateTimeUtc(DateTime.SpecifyKind((DateTime) time, DateTimeKind.Utc));

        public NodaTimeInstantValueConverter(ConverterMappingHints mappingHints = null) 
            : base(ConvertToDb, ConvertFromDb, mappingHints) { }

        public static ValueConverterInfo DefaultInfo { get; }
            = new ValueConverterInfo(
                typeof(Instant), 
                typeof(DateTime), 
                i => new NodaTimeInstantValueConverter(i.MappingHints));
    }
}
