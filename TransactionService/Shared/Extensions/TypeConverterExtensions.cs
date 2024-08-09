namespace Shared.Extensions
{
    public static class TypeConverterExtensions
    {
        public static int ToInt(this object value)
        {
            int result;
            if (int.TryParse(value.ToString(), out result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException("O objeto não pode ser convertido para um inteiro válido.");
            }
        }

        public static long ToLong(this object value)
        {
            long result;
            if (long.TryParse(value.ToString(), out result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException("O objeto não pode ser convertido para um inteiro válido.");
            }
        }

        public static double ToDouble(this object value)
        {
            double result;
            if (double.TryParse(value.ToString(), out result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException("O objeto não pode ser convertido para um Double válido.");
            }
        }

        public static decimal ToDecimal(this object value)
        {
            decimal result;
            if (decimal.TryParse(value.ToString(), out result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException("O objeto não pode ser convertido para um Decimal válido.");
            }
        }

        public static DateTime ToDateTime(this object value)
        {
            DateTime result;
            if (DateTime.TryParse(value.ToString(), out result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException("O objeto não pode ser convertido para um DateTime válido.");
            }
        }

        public static bool ToBoolean(this object value)
        {
            bool result;
            if (bool.TryParse(value.ToString(), out result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException("O objeto não pode ser convertido para um valor booleano.");
            }
        }

        public static Guid ToGuid(this object value)
        {
            Guid result;
            if (Guid.TryParse(value.ToString(), out result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException("O objeto não pode ser convertido para um Guid válido.");
            }
        }

        public static TEnum ToEnum<TEnum>(this string value) where TEnum : struct, Enum
        {
            if (Enum.TryParse<TEnum>(value, true, out TEnum result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException($"O objeto não pode ser convertido para um valor {typeof(TEnum).Name} válido.");
            }
        }

        public static string ToEnumName<TEnum>(this TEnum enumValue) where TEnum : struct, Enum
        {
            return enumValue.ToString();
        }
    }
}
