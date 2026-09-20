namespace TestGeniusOrIdiot
{

    internal class User
    {
        readonly public string Name;

        public string Diagnosis { get; set; }

        public User(string name)
        {
            Name = name;
            Diagnosis = "Неизвестен";
        }
    }
}
