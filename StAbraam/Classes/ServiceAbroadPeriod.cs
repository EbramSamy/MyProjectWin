using StAbraam.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StAbraam.Classes
{
    public class ServiceAbroadPeriod
    {
        public ServiceAbroadPeriod(Period per)
        {
            this.Period = per;
            this.Difference = new DateDifference(per.From, per.To);
        }
        private Period _period;
        public Period Period
        {
            get { return this._period; }
            set { _period = value; }
        }

        private DateDifference _difference;
        public DateDifference Difference
        {
            get { return this._difference; }
            set { _difference = value; }
        }
    }
}
