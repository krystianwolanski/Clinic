using Clinic.Domain.Exceptions;

namespace Clinic.Domain.ValueObjects
{
    public record Login
    {
        public Login(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyValueException(nameof(Login));
            }

            Value = value;
        }

        public string Value { get; }

        public static implicit operator Login(string value) => new(value);
        public static implicit operator string(Login login) => login.Value;

        public override string ToString()
        {
            return Value;
        }
    }
}
