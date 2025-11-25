using Sampel.RestAPI.SharedKernel.Translators;
using System.Text.RegularExpressions;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.Domain.ValueObjects;

namespace Sampel.RestAPI.Core.Domain.RestApiDemos.ValueObjects
{
    public class NationalId : BaseValueObject<NationalId>
    {
        public string Value { get; private set; }

        public static NationalId FromString(string value)
        {
            return new NationalId(value);
        }

        public NationalId(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidEntityStateException(TranslatorKeys.VALIDATION_ERROR_NOT_EMPTY, nameof(NationalId));
            }

            value = ConvertPersianDigitsToEnglish(value);

            if (!IsValidIranianNationalCode(value))
                throw new InvalidEntityStateException(TranslatorKeys.VALIDATION_ERROR_INVALID_FORMAT, nameof(NationalId));

            Value = value;
        }

        private static string ConvertPersianDigitsToEnglish(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            var persianDigits = new[] { '۰', '۱', '۲', '۳', '۴', '۵', '۶', '۷', '۸', '۹' };
            for (int i = 0; i < persianDigits.Length; i++)
            {
                input = input.Replace(persianDigits[i], (char)('0' + i));
            }

            return input;
        }

        private bool IsValidIranianNationalCode(string nationalCode)
        {
            if (string.IsNullOrWhiteSpace(nationalCode)) return false;

            if (!Regex.IsMatch(nationalCode, @"^\d{10}$")) return false;

            var repeatedCodes = new[]
            {
            "0000000000", "1111111111", "2222222222", "3333333333",
            "4444444444", "5555555555", "6666666666", "7777777777",
            "8888888888", "9999999999", "1234567890"
        };
            if (repeatedCodes.Contains(nationalCode)) return false;

            var check = int.Parse(nationalCode[9].ToString());
            var sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(nationalCode[i].ToString()) * (10 - i);
            }

            var remainder = sum % 11;

            return (remainder < 2 && check == remainder) || (remainder >= 2 && check == (11 - remainder));
        }

        private NationalId()
        {
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static explicit operator string(NationalId nationalId)
        {
            return nationalId.Value;
        }

        public static implicit operator NationalId(string value)
        {
            return new NationalId(value);
        }
    }
}
