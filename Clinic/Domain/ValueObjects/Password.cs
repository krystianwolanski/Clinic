using Clinic.Domain.Exceptions;

namespace Clinic.Domain.ValueObjects
{
    public record Password
    {
        public Password(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyValueException(nameof(Password));
            }

            Value = value;
        }

        public string Value { get; }

        public static implicit operator Password(string value) => new(value);
        public static implicit operator string(Password password) => password.Value;

        public override string ToString()
        {
            return Value;
        }
    }
}
