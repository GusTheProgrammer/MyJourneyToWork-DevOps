using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Calculator
{
    /*
     * List of Transport Modes
     */
    public enum TransportModes
    {
        [Display(Name = "Petrol")] petrol,
        [Display(Name = "Diesel")] deisel,
        [Display(Name = "Hybrid")] hybrid,
        [Display(Name = "Electric")] electric,
        [Display(Name = "Motorbike")] motorbike,
        [Display(Name = "Electric Bike or Scooter")] electricbike,
        [Display(Name = "Train")] train,
        [Display(Name = "Bus")] bus,
        [Display(Name = "Tram")] tram,
        [Display(Name = "Cycling")] cycling,
        [Display(Name = "Walking")] walking
    }

    public enum DistanceMeasurement
    {
        [Display(Name = "Miles")] miles,
        [Display(Name = "Kilometers")] kms
    }

    public class Calculator
    {
        private List<double> transportModeWeighting = new List<double> { 8, 10, 6, 4, 3, 2, 3, 3, 3, 0.005, 0.005 };

        public const int distanceMin = 1;
        public const int distanceMax = 1000;

        [Range(distanceMin, distanceMax, ErrorMessage = "Invalid distance - Only Available from 1 to 1000 miles")]
        [DisplayName("Enter Your Distance to work (KMs/miles):")]
        public double distance { get; set; }

        [DisplayName("Select A Distance Measurement:")]
        public DistanceMeasurement milesOrKms { get; set; }

        public const int daysMin = 1;
        public const int daysMax = 7;

        [Range(daysMin, daysMax, ErrorMessage = "Invalid num of days - Only Available from 1 to 7 days")]
        [DisplayName("Enter the number of days you travel to work:")]
        public double numDays { get; set; }

        [DisplayName("Select A Transport mode:")]
        public TransportModes transportMode { get; set; }

        //Ensure that distance is in miles for calculation
        public double convertDistance()
        {
            if (milesOrKms.Equals(DistanceMeasurement.kms))
                return this.distance / 1.609344;
            else
                return this.distance;
        }

        // calculate sustainability number
        [DisplayName("Your Sustainability Weighting:")]
        public double sustainabilityWeighting
        {
            // Total =  (Transport method Weighting * distance to work (in miles) * (onsite num Days per week*2))
            get
            {
                double total = 0;

                if (transportMode.Equals(TransportModes.petrol))
                {
                    total = transportModeWeighting[(int)TransportModes.petrol] * convertDistance() * (this.numDays * 2);
                }
                else if (transportMode.Equals(TransportModes.deisel))
                {
                    total = transportModeWeighting[(int)TransportModes.deisel] * convertDistance() * (this.numDays * 2);
                }
                else if (transportMode.Equals(TransportModes.hybrid))
                {
                    total = transportModeWeighting[(int)TransportModes.hybrid] * convertDistance() * (this.numDays * 2);
                }
                else if (transportMode.Equals(TransportModes.electric))
                {
                    total = transportModeWeighting[(int)TransportModes.electric] * convertDistance() * (this.numDays * 2);
                }
                else if (transportMode.Equals(TransportModes.motorbike))
                {
                    total = transportModeWeighting[(int)TransportModes.motorbike] * convertDistance() * (this.numDays * 2);
                }
                else if (transportMode.Equals(TransportModes.electricbike))
                {
                    total = transportModeWeighting[(int)TransportModes.electricbike] * convertDistance() * (this.numDays * 2);
                }
                else if (transportMode.Equals(TransportModes.train))
                {
                    total = transportModeWeighting[(int)TransportModes.train] * convertDistance() * (this.numDays * 2);
                }
                else if (transportMode.Equals(TransportModes.bus))
                {
                    total = transportModeWeighting[(int)TransportModes.bus] * convertDistance() * (this.numDays * 2);
                }
                else if (transportMode.Equals(TransportModes.tram))
                {
                    total = transportModeWeighting[(int)TransportModes.tram] * convertDistance() * (this.numDays * 2);
                }
                else if (transportMode.Equals(TransportModes.cycling))
                {
                    total = transportModeWeighting[(int)TransportModes.cycling] * convertDistance() * (this.numDays * 2);
                }
                else if (transportMode.Equals(TransportModes.walking))
                {
                    total = transportModeWeighting[(int)TransportModes.walking] * convertDistance() * (this.numDays * 2);
                }
                return total;
            }
        }

        [DisplayName("Estimated Transportation Cost: €")]
        public double TransportationCost
        {
            get
            {
                // Estimated cost per km for each transportation mode
                var costPerMile = new Dictionary<TransportModes, double>
            {
                { TransportModes.petrol, 0.16 },
                { TransportModes.deisel, 0.20 },
                { TransportModes.hybrid, 0.014 },
                { TransportModes.electric, 0.12 },
                { TransportModes.motorbike, 0.18 },
                { TransportModes.electricbike, 0.08 },
            };

                double totalCost;

                
                double distanceInMiles = convertDistance();
                int fareIntervals = (int)Math.Ceiling(distanceInMiles / 15); // Calculate the amount of fare intervals (15 miles per trip)

                switch (transportMode)
                {
                    case TransportModes.bus:
                        totalCost = 1.35 * fareIntervals; 
                        break;
                    case TransportModes.tram:
                        totalCost = 2.00 * fareIntervals;
                        break;
                    case TransportModes.train:
                        totalCost = 2.50 * fareIntervals;
                        break;
                    default:
                        totalCost = costPerMile.TryGetValue(transportMode, out double costFactor) ? costFactor * distanceInMiles * numDays : 0;
                        break;
                }

                return totalCost;
            }
        }
    }
}
