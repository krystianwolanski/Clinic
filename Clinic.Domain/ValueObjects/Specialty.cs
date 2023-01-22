using Clinic.Domain.Exceptions;

namespace Clinic.Domain.ValueObjects
{
    public sealed record Specialty
    {
        public static readonly Specialty Surgery = nameof(Surgery);
        public static readonly Specialty Cardiology = nameof(Cardiology);

        public Specialty(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyValueException(nameof(Specialty));
            }

            Value = value;
        }

        public string Value { get; }

        public static implicit operator Specialty(string value) => new(value);
        public static implicit operator string(Specialty firstName) => firstName.Value;

        public override string ToString()
        {
            return Value;
        }
    }
}
