namespace CatWorx.BadgeMaker
{
  class Employee
  {
        public string FirstName;
        public string LastName;
        public int Id;
        public string PhotoUrl;
        public Employee(string firstName, string lastName) {
            FirstName = firstName;
            LastName = LastName;
        }
        public string GetFullName() {
            return FirstName + " " + LastName;
        }
  }
}