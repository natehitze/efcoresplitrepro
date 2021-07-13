using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;

namespace DemoWebApi.ValueConverters
{
    /// <summary>
    /// Provides custom value conversions (e.g. NodaTime)
    /// </summary>
    /// <remarks>
    /// Based on code from https://andrewlock.net/strongly-typed-ids-in-ef-core-using-strongly-typed-entity-ids-to-avoid-primitive-obsession-part-4
    /// which is based on existing code in EF core
    /// </remarks>
    public class MyValueConverterSelector : ValueConverterSelector
    {
        // The dictionary in the base type is private, so we need our own one here.
        private readonly ConcurrentDictionary<(Type ModelClrType, Type ProviderClrType), ValueConverterInfo> _converters
            = new ConcurrentDictionary<(Type ModelClrType, Type ProviderClrType), ValueConverterInfo>();

        public MyValueConverterSelector([NotNull] ValueConverterSelectorDependencies dependencies) : base(dependencies) { }

        public override IEnumerable<ValueConverterInfo> Select(Type modelClrType, Type providerClrType = null)
        {
            var baseConverters = base.Select(modelClrType, providerClrType);
            foreach (var converter in baseConverters)
            {
                yield return converter;
            }

            // Extract the "real" type T from Nullable<T> if required
            var underlyingModelType = UnwrapNullableType(modelClrType);
            var underlyingProviderType = UnwrapNullableType(providerClrType);

            if (underlyingModelType == typeof(Instant))
            {
                if (underlyingProviderType == null || underlyingProviderType == typeof(DateTime))
                {
                    yield return _converters.GetOrAdd((underlyingModelType, typeof(DateTime)), k => NodaTimeInstantValueConverter.DefaultInfo);
                }
            }

            if (underlyingModelType == typeof(LocalDate))
            {
                if (underlyingProviderType == null || underlyingProviderType == typeof(DateTime))
                {
                    yield return _converters.GetOrAdd((underlyingModelType, typeof(DateTime)), k => NodaTimeLocalDateValueConverter.DefaultInfo);
                }
            }

            if (underlyingModelType == typeof(LocalTime))
            {
                if (underlyingProviderType == null || underlyingProviderType == typeof(DateTime))
                {
                    yield return _converters.GetOrAdd((underlyingModelType, typeof(DateTime)), k => NodaTimeLocalTimeValueConverter.DefaultInfo);
                }
            }

            if (underlyingModelType == typeof(DateTimeZone))
            {
                if (underlyingProviderType == null || underlyingProviderType == typeof(string))
                {
                    yield return _converters.GetOrAdd((underlyingModelType, typeof(string)), k => NodaTimeDateTimeZoneValueConverter.DefaultInfo);
                }
            }
        }

        private static Type UnwrapNullableType(Type type)
        {
            if (type is null) { return null; }

            return Nullable.GetUnderlyingType(type) ?? type;
        }
    }
}
