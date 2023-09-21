namespace Credit_Calc_for_test.Models
{
    #region Модель данных для расчёта кредита по месяцам
    public class CalculatorMonthsRow
    {
        //Сумма кредита 
        public double loan_summ { get; set; } = 0;

        //Процент кредита 
        public double loan_rate { get; set; } = 0;

        //Процент кредита (месяц) 
        public double loan_rate_month { get; set; } = 0;

        //Срок кредита 
        public double loan_term { get; set; } = 0;

        //Номер платежа 
        public int payment_number { get; set; } = 0;

        //Дата платежа
        public string payment_date { get; set; } = null;

        //Платёж по телу (месяц)
        public double payment_body { get; set;} = 0;

        //Платёж по процентам (месяц)
        public double payment_percent { get; set;} = 0;

        //Остаток долга (для расчёта процентов)
        public double loan_percent_balance { get; set; } = 0;

        //Остаток долга
        public double loan_balance { get; set; } = 0;

        //Аннуитетный коэффициент
        public double annuity_coefficient { get; set; } = 0;

        //Сумма платежа (в месяц)
        public double monthly_payment { get; set; } = 0;

        //Сумма платежей (общая)
        public double total_payments { get; set; } = 0;

        //Сумма процентов (общая)
        public double total_percents { get; set; } = 0;
    }
    #endregion
}
