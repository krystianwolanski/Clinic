using Clinic.Domain.Exceptions;

namespace Clinic.Domain.ValueObjects
{
    public record FirstName
    {
        public FirstName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyValueException(nameof(FirstName));
            }

            Value = value;
        }

        public string Value { get; }

        public static implicit operator FirstName(string value) => new(value);
        public static implicit operator string(FirstName firstName) => firstName.Value;

        public override string ToString()
        {
            return Value;
        }
    }
}
