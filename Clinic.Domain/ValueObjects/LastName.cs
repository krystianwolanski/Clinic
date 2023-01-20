using Clinic.Domain.Exceptions;

namespace Clinic.Domain.ValueObjects
{
    public record LastName
    {
        public LastName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyValueException(nameof(LastName));
            }

            Value = value;
        }

        public string Value { get; }

        public static implicit operator LastName(string value) => new(value);
        public static implicit operator string(LastName lastName) => lastName.Value;

        public override string ToString()
        {
            return Value;
        }
    }
}
