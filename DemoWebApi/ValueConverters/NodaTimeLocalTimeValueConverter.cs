using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;

namespace DemoWebApi.ValueConverters
{
    internal class NodaTimeLocalTimeValueConverter : ValueConverter<LocalTime, TimeSpan>
    {
        private static readonly Expression<Func<LocalTime, TimeSpan>> ConvertToDb = date => new TimeSpan(0,
                                                                                                         date.Hour,
                                                                                                         date.Minute,
                                                                                                         date.Second,
                                                                                                         date.Millisecond);

        private static readonly Expression<Func<TimeSpan, LocalTime>> ConvertFromDb = time => new LocalTime(time.Hours,
                                                                                                            time.Minutes,
                                                                                                            time.Seconds,
                                                                                                            time.Milliseconds);

        public NodaTimeLocalTimeValueConverter(ConverterMappingHints mappingHints = null) 
            : base(ConvertToDb, ConvertFromDb, mappingHints) { }

        public static ValueConverterInfo DefaultInfo { get; }
            = new ValueConverterInfo(
                typeof(LocalTime), 
                typeof(TimeSpan), 
                i => new NodaTimeLocalTimeValueConverter(i.MappingHints));
    }
}
