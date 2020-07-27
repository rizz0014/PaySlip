using System;
using System.Collections.Generic;
namespace CSProjectNew
{
    public class Staff
    {

        #region Fields

        private float hourlyRate;
        private int hWorked;

        #endregion

        #region Properties

        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }
        public string NameOfStaff { get; private set; }
        public int HoursWorked
        {
            get
            {
                return HoursWorked;
            }
            set
            {
                if (value > 0) {
                    hWorked = value;
                }
                else
                {
                    hWorked = 0;
                }
            }
        }

        #endregion

        #region Constructor

        public Staff(string name, float rate)
        {
            NameOfStaff = name;
            hourlyRate = rate;

        }

        #endregion

        #region Methods

        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Pay...");

            BasicPay = hWorked * hourlyRate;
            TotalPay = BasicPay;
        }

        public override string ToString()
        {
            return "\nNameOfStaff: " + NameOfStaff
                + "\nhourlyRate: " + hourlyRate
                + "\nhWorked: " + hWorked
                + "\nBacisPay: " + BasicPay

                + "\n\nTotalPay: " + TotalPay;
        }

        #endregion
    }

    public class Manager : Staff
    {

        #region Fields

        private const float managerHourlyRate = 50;

        #endregion

        #region Properties

        public int Allowance { get; private set; }

        #endregion

        #region Constructor

        public Manager(string name) : base (name, managerHourlyRate) 
        {
            // the base is to call the base staff class and pass the parameter to it, not necessary to have a body
        }
        #endregion

        #region Methods

        public override void CalculatePay()
        {
            base.CalculatePay();

            // if the manager worked more than 160 hours/month she/he will get the allowance

            Allowance = 0;

            if (HoursWorked > 160)
            {
                Allowance = 1000;
                TotalPay = BasicPay + Allowance;
            }
        }

        public override string ToString()
        {
            //return base.ToString();

            return "\nNameOfStaff: " + NameOfStaff
                + "\nhourlyRate: " + managerHourlyRate
                + "\nhWorked: " + HoursWorked
                + "\nBacisPay: " + BasicPay
                + "\nAllowance: " + Allowance

                + "\n\nTotalPay: " + TotalPay;
        }

        #endregion

    }

    public class Admin : Staff
    {
        #region Fields

        private const float overtimeRate = 15.5f; // Note: the "f" is to set the float precision
        private const float adminHourlyRate = 30;

        #endregion

        #region Properties

        public float Overtime { get; private set; }

        #endregion

        #region Constructor

        public Admin(string name) : base(name, adminHourlyRate)
        {
            // the base is to call the base staff class and pass the parameter to it, not necessary to have a body
        }

        #endregion

        #region Methods

        public override void CalculatePay()
        {
            base.CalculatePay();

            Overtime = 0;

            if (HoursWorked > 160)
            {
                Overtime = overtimeRate * (HoursWorked - 160); // formula to only get the overtime hours (after 160h worked)
                TotalPay = BasicPay + Overtime;
            }
        }

        public override string ToString()
        {
            //return base.ToString();

            return "\nNameOfStaff: " + NameOfStaff
                + "\nhourlyRate: " + adminHourlyRate
                + "\novertimeRate: " + overtimeRate
                + "\nhWorked: " + HoursWorked
                + "\nBacisPay: " + BasicPay
                + "\nOvertime: " + Overtime

                + "\n\nTotalPay: " + TotalPay;
        }

        #endregion
    }

}
