using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopCase.OlivaTaxi.Common.Extensions
{
    public static class StringExtensions
    {
        public static string FromUtf8Bytes(this byte[] source)
        {
            return Encoding.UTF8.GetString(source);
        }

        public static byte[] ToUtf8Bytes(this string source)
        {
            return Encoding.UTF8.GetBytes(source);
        }

        public static int? ParseNullableInt(this string source)
        {
            return string.IsNullOrWhiteSpace(source) ? (int?)null : int.Parse(source);
        }

        public static string Join<T>(this IEnumerable<T> source, string separator = ",")
        {
            return string.Join(separator, source);
        }

        public static string Join<T>(this IEnumerable<T> source, Func<T, string> converter, string separator = ",")
        {
            return string.Join(separator, source.Select(converter));
        }

        public static string Join<T>(this IEnumerable<T> source, string separator, Func<T, string> converter)
        {
            return string.Join(separator, source.Select(converter));
        }

        public static string ToLoggingString(this object source)
        {
            if (source == null)
            {
                return "null";
            }

            return source.ToString();
        }

        public static T ToEnum<T>(this string value)
        {
            try
            {
                return (T) Enum.Parse(typeof(T), value, true);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Can't parse value {value} into {typeof(T).Name}", ex);
            }
        }
    }
}