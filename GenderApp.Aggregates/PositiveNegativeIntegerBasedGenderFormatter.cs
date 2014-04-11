using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenderApp.Aggregates
{
    public class PositiveNegativeIntegerBasedGenderFormatter : IGenderFormatter
    {
        public Gender Deserialize(string gender)
        {
            double genderResult = 0;
            if (double.TryParse(gender, out genderResult))
            {
                if (genderResult > 0)
                {
                    return Gender.Female;
                }

                return Gender.Male;
            }

            return Gender.None;
        }
    }
}
