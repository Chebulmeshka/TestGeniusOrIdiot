namespace TestGeniusOrIdiot
{

    internal class User
    {
        readonly public string Name; //Имя

        public string Diagnosis { get; set; } //Диагноз

        public User(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Строковое представление пользователя
        /// </summary>
        /// <returns>
        /// Выводит его имя
        /// </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
