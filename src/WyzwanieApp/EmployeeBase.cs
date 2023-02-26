namespace WyzwanieApp
{
    public abstract class EmployeeBase : NamedObject, IEmployee
    {
        public EmployeeBase(string name) : base(name)
        {

        }

        public virtual event Employee.LowerGradeDelegate LowerGrade;
        public abstract void AddPlusMinusGrade(string plusminusgrade);
        public abstract Statistics GetStatistics();

    }
}