namespace WyzwanieApp
{
    public class NamedObject
    {
        public NamedObject(string name)
        {
            this.Name = name;
        }
        public virtual string Name { get; set; }
    }
}