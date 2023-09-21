using Credit_Calc_for_test.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Credit_Calc_for_test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Расчёт платежей по месяцам
        public IActionResult ResultMonths(double Loan_summ, string Loan_rate, double Loan_term)
        {

            double Loan_rate_transformed = Double.Parse(Loan_rate.Replace('.', ','));

            List<CalculatorMonthsRow> tableData = new List<CalculatorMonthsRow>()
            {

            };

            double annuity_coefficient = (Loan_rate_transformed / 1200 * Math.Pow(1 + Loan_rate_transformed / 1200, Loan_term)) / ((Math.Pow(1 + Loan_rate_transformed / 1200, Loan_term) - 1));

            double monthly_payment = annuity_coefficient * Loan_summ;

            double loan_balance = monthly_payment * Loan_term;

            double loan_rate_month = Loan_rate_transformed / 1200;

            double loan_percent_balance = Loan_summ;

            double payment_percent = 0;

            double payment_body = 0;            

            int payment_number = 0;

            double total_payments = 0;

            double total_percents = 0;

            DateTime Payment_date = DateTime.Now;

            

            for (int i = 1; i <= Loan_term; i++)
            {
                loan_balance = loan_balance - monthly_payment;

                payment_number++;

                

                if (i == 0)
                {
                    loan_percent_balance = Loan_summ;

                    payment_percent = loan_percent_balance * loan_rate_month;

                    monthly_payment = monthly_payment - payment_percent;
                }

                else
                {
                    loan_percent_balance = loan_percent_balance - payment_body;

                    payment_percent = loan_percent_balance * loan_rate_month;

                    payment_body = monthly_payment - payment_percent;

                    Payment_date = Payment_date.AddMonths(1);

                    
                }

                string Date_for_display = Payment_date.ToString("d");

                total_payments = monthly_payment * Loan_term;

                total_percents = total_payments - Loan_summ;

                tableData.Add(new CalculatorMonthsRow
                {
                    annuity_coefficient = Math.Round(annuity_coefficient, 6),

                    monthly_payment = Math.Round(monthly_payment, 2),

                    loan_summ = Math.Round(Loan_summ, 2),

                    loan_rate = Math.Round(Loan_rate_transformed, 2),

                    loan_rate_month = Math.Round(loan_rate_month, 2),

                    loan_term = Math.Round(Loan_term, 2),

                    loan_balance = Math.Abs(Math.Round(loan_balance, 2)),

                    loan_percent_balance = Math.Abs(Math.Round(loan_percent_balance, 2)),

                    payment_percent = Math.Round(payment_percent, 2),

                    payment_body = Math.Round(payment_body, 2),

                    payment_number = payment_number,

                    payment_date = Date_for_display,

                    total_payments = Math.Round(total_payments, 2),

                    total_percents = Math.Round(total_percents, 2)

                });


            }

            return View(tableData);

        }

        //Расчёт платежей по дням
        public IActionResult ResultDays(double Loan_summ, string Loan_rate, double Loan_term, double Payment_step)
        {

            double Loan_rate_transformed = Double.Parse(Loan_rate.Replace('.', ','));

            List<CalculatorDaysRow> tableData = new List<CalculatorDaysRow>()
            {

            };

            double payment_numbers;

            if (Loan_term / Payment_step == Math.Truncate(Loan_term / Payment_step))
            {
                payment_numbers = Loan_term / Payment_step;
            }
            else
            {
                payment_numbers = Loan_term / Payment_step + 1;
            }


            

            double annuity_coefficient = (Loan_rate_transformed * Payment_step / 100 * Math.Pow(1 + Loan_rate_transformed * Payment_step / 100, payment_numbers)) / ((Math.Pow(1 + Loan_rate_transformed * Payment_step / 100, payment_numbers) - 1));

            double day_payment = annuity_coefficient * Loan_summ;

            double loan_balance = day_payment * Loan_term;

            double loan_rate_days = Loan_rate_transformed * Payment_step / 100;

            double loan_percent_balance = Loan_summ;

            double payment_percent = 0;

            double payment_body = 0;

            int payment_number = 0;

            double total_payments = 0;

            double total_percents = 0;

            DateTime Payment_date = DateTime.Now;



            for (double i = 1; i <= Loan_term; i += Payment_step)
            {
                loan_balance = loan_balance - day_payment;

                payment_number++;



                if (i == 0)
                {
                    loan_percent_balance = Loan_summ;

                    payment_percent = loan_percent_balance * loan_rate_days;

                    day_payment = day_payment - payment_percent;
                }

                else
                {
                    loan_percent_balance = loan_percent_balance - payment_body;

                    payment_percent = loan_percent_balance * loan_rate_days;

                    payment_body = day_payment - payment_percent;

                    Payment_date = Payment_date.AddDays(Payment_step);


                }

                string Date_for_display = Payment_date.ToString("d");

                total_payments = day_payment * payment_numbers;

                total_percents = total_payments - Loan_summ;

                tableData.Add(new CalculatorDaysRow
                {
                    annuity_coefficient = Math.Round(annuity_coefficient, 6),

                    day_payment = Math.Round(day_payment, 2),

                    loan_summ = Math.Round(Loan_summ, 2),

                    loan_rate = Math.Round(Loan_rate_transformed, 5),

                    loan_rate_days = Math.Round(loan_rate_days, 2),

                    loan_term = Loan_term,

                    loan_balance = Math.Abs(Math.Round(loan_balance, 2)),

                    loan_percent_balance = Math.Abs(Math.Round(loan_percent_balance, 2)),

                    payment_percent = Math.Round(payment_percent, 2),

                    payment_body = Math.Round(payment_body, 2),

                    payment_number = payment_number,

                    payment_numbers = payment_numbers,

                    payment_date = Date_for_display,

                    total_payments = Math.Round(total_payments, 2),

                    total_percents = Math.Round(total_percents, 2)

                });


            }

            return View(tableData);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}