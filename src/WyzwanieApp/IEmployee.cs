namespace WyzwanieApp
{
    public interface IEmployee
    {
        void AddPlusMinusGrade(string plusminusgrade);
        Statistics GetStatistics();
        string Name { get; set; }

        event Employee.LowerGradeDelegate LowerGrade;
    }
}