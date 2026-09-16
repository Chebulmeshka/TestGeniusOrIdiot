namespace TestGeniusOrIdiot
{
    enum Diagnosis
    {
        Idiot = 0,
        Cretine = 1,
        Durak = 2,
        Normal = 3,
        Talent = 4,
        Genius = 5
    }

    internal class User
    {
        readonly public string Name; //Имя
        private Diagnosis _diagnosis; //Диагноз
        public string Diagnosis
        {
            get
            {
                switch (_diagnosis)
                {
                    case TestGeniusOrIdiot.Diagnosis.Idiot: return "Идиот";
                    case TestGeniusOrIdiot.Diagnosis.Cretine: return "Кретин";
                    case TestGeniusOrIdiot.Diagnosis.Durak: return "Дурак";
                    case TestGeniusOrIdiot.Diagnosis.Normal: return "Нормальный";
                    case TestGeniusOrIdiot.Diagnosis.Talent: return "Талант";
                    case TestGeniusOrIdiot.Diagnosis.Genius: return "Гений";

                    default: return $"Неизвестный науке зверёк {_diagnosis}";
                }
            }
        }

        public User(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Присвоение диагноза пользователю
        /// </summary>
        public void SetDiagnosis(Diagnosis diagnosis)
        {
            _diagnosis = diagnosis;
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
