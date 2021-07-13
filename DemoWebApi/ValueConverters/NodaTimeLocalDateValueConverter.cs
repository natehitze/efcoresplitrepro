using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;

namespace DemoWebApi.ValueConverters
{
    internal class NodaTimeLocalDateValueConverter : ValueConverter<LocalDate, DateTime>
    {
        private static readonly Expression<Func<LocalDate, DateTime>> ConvertToDb = date => date.ToDateTimeUnspecified();
        private static readonly Expression<Func<DateTime, LocalDate>> ConvertFromDb = time => LocalDate.FromDateTime(time);

        public NodaTimeLocalDateValueConverter(ConverterMappingHints mappingHints = null) 
            : base(ConvertToDb, ConvertFromDb, mappingHints) { }

        public static ValueConverterInfo DefaultInfo { get; }
            = new ValueConverterInfo(
                typeof(LocalDate), 
                typeof(DateTime), 
                i => new NodaTimeLocalDateValueConverter(i.MappingHints));
    }
}
