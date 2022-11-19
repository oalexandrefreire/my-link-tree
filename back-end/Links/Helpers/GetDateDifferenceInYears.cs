namespace Web.Helpers
{
    public static class GetDateDifferenceInYears
    {
        public static int Convert(DateTime startDate)
        {
            int finalResult = 0;

            const int DaysInYear = 365;

            DateTime endDate = DateTime.Now;

            TimeSpan timeSpan = endDate - startDate;

            if (timeSpan.TotalDays > 365)
            {
                finalResult = (int)Math.Round((timeSpan.TotalDays / DaysInYear), MidpointRounding.ToEven);
            }

            return finalResult;
        }
    }
}
