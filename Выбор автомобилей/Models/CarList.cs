using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Выбор_автомобилей.Models
{
    public class CarList
    {

        public CarList() : this("", "", "", "", "")
        {
        }

        public CarList(string auto, string cost, string rate, string reability, string comfort)
        {
            string Auto = auto;
            string Cost = cost;
            string Rate = rate;
            string Reability = reability;
            string Comfort = comfort;
        }

        private string auto;
        private string cost;
        private string rate;
        private string reability;
        private string comfort;

        public string Auto
        {
            get { return auto; }
            set { auto = value; }
        }

        public string Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public string Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public string Reability
        {
            get { return reability; }
            set { reability = value; }
        }

        public string Comfort
        {
            get { return Comfort; }
            set { comfort = value; }
        }

        public static CarList parseCarList(string auto, string cost, string rate, string reability, string comfort)
        {
            CarList res = new CarList(auto, cost, rate, reability, comfort);

            return res;
        }
    }
}
