using Clinic.Domain.Exceptions;

namespace Clinic.Domain.ValueObjects
{
    public record Pesel
    {
        public string Value { get; }

        public Pesel(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new EmptyPeselException();

            if (!IsValidPesel(value))
                throw new InvalidPeselException();

            Value = value;
        }

        public static implicit operator Pesel(string value) => new(value);
        public static implicit operator string(Pesel pesel) => pesel.Value;

        private static bool IsValidPesel(string pesel)
        {
            if (pesel.Length != 11) return false;
            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += weights[i] * (int)char.GetNumericValue(pesel[i]);
            }
            int controlNumber = 10 - sum % 10;
            int lastDigit = (int)char.GetNumericValue(pesel[10]);
            return lastDigit == controlNumber;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
