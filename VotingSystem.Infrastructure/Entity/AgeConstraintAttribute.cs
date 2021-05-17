using System;
using System.ComponentModel.DataAnnotations;

namespace VotingSystem.Infrastructure.Entity
{
    public class AgeConstraintAttribute : ValidationAttribute
    {
        private readonly int _minimumAcceptedAge;
        public AgeConstraintAttribute(int minimumAcceptedAge)
        {
            _minimumAcceptedAge = minimumAcceptedAge;
        }

        public override bool IsValid(object value)
        {
            DateTime date;
            if (DateTime.TryParse(value.ToString(), out date))
                return date.AddYears(_minimumAcceptedAge) < DateTime.Now;

            return false;
        }
    }
}
