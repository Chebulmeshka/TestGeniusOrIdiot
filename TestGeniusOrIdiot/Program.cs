namespace TestGeniusOrIdiot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Регистрация пользователя
            User user = RegistrationNewUser();

            while (true)
            {
                //Формироване уникального списка вопросов для пользователя
                List<Question> questions = GetDefaultQuestions();
                ShuffleQuestions(questions);

                //Тестирование пользователя
                int countRigthAnswers = TestUser(user, questions);

                //Диагноз пользователю
                user.Diagnosis = SetDiagnosis(countRigthAnswers);

                //Вывод диагноза пользователя в консоль
                PrintDiagnosis(user);

                //Запрос на повторное тестирование
                CustomConsole.SkipLine();
                if (!AskUserStartAgain(user)) break;
            }
        }

        /// <summary>
        /// Спрашивает имя пользователя и регестрирует его в системе
        /// </summary>
        /// <returns>
        /// Экземпляр User с заполненным полем Name
        /// </returns>
        static User RegistrationNewUser()
        {
            CustomConsole.Title("РЕГИСТРАЦИЯ");

            string name = default;

            while (true)
            {
                CustomConsole.Message("Введите своё имя: ");
                name = CustomConsole.ReadInput();

                if (IsNameCorrect(name))
                {
                    break;
                }
                else
                {
                    CustomConsole.MessageLine("Некорректное имя. Попробуйте снова.");
                }
            }
            CustomConsole.Clear();

            return new User(name);
        }

        /// <summary>
        /// Проверка на корректность введённого имени
        /// </summary>
        /// <returns>
        /// true - если пользователь ввел имя как минимум состоящее из одного символа. 
        /// false - в остальных случаях
        /// </returns>
        static bool IsNameCorrect(string name)
        {
            string nameWithoutSpaces = name.Replace(" ", "");
            return !string.IsNullOrEmpty(nameWithoutSpaces);
        }

        /// <summary>
        /// Начинает тестирование пользователя по списку выбранных вопросов
        /// </summary>
        static int TestUser(User user, List<Question> questions)
        {
            CustomConsole.Title("Информация");
            CustomConsole.MessageLine($"Тест предназначен для определения ваших умственных способностей.");
            CustomConsole.MessageLine($"Для достижения высокой точности диагноза старайтесь давать ответ как можно быстрее.");
            CustomConsole.InfoLine($"Нажмите любую клавишу, когда будете готовы начать тестирование");
            CustomConsole.ReadKey();
            CustomConsole.Clear();

            int numberQuestion = 1;
            int countRigthAnswers = 0;

            foreach (var question in questions)
            {
                CustomConsole.Title($"Вопрос № {numberQuestion}");
                CustomConsole.QuestionLine(question);

                while (true)
                {
                    string answer = GetAnswer(user);

                    try
                    {
                        if (IsAnswerRigth(question, answer)) countRigthAnswers++;
                        break;
                    }
                    catch(Exception ex)
                    {
                        CustomConsole.ErrorLine(ex.Message);
                        CustomConsole.SkipLine();
                    }
                }

                numberQuestion++;
                CustomConsole.Clear();
            }
            CustomConsole.Clear();

            return countRigthAnswers;
        }

        /// <summary>
        /// Спрашивает пользователя о повторном тестировании
        /// </summary>
        /// <returns>
        /// true - если пользователь ответит "да". false - если пользователь ответит "нет". Регистр не важен.
        /// </returns>
        static bool AskUserStartAgain(User user)
        {
            CustomConsole.MessageLine("Если вы считаете что этот тест с вами был несправедлив, " +
                "вы можете взять реванш.");

            string answer = GetAnswer(user).ToLower();
            while (answer != "да" && answer != "нет")
            {
                CustomConsole.Clear();

                CustomConsole.ErrorLine("Не понял вас. Выберете ответ из следующих вариантов:");
                CustomConsole.MessageLine("Да - начать ещё раз");
                CustomConsole.MessageLine("Нет - выйти");

                answer = GetAnswer(user).ToLower();
            }

            CustomConsole.Clear();
            return answer == "да";
        }

        /// <summary>
        /// Вывод в консоль диагноза выбранного пользователя
        /// </summary>
        static void PrintDiagnosis(User user)
        {
            CustomConsole.MessageLine("ДИАГНОЗ");
            CustomConsole.SuccessLine($"Уважаемый {user}! Вы - {user.Diagnosis}");
        }

        /// <summary>
        /// Определение диагноза по количеству ответов
        /// </summary>
        static string SetDiagnosis(int countRigthAnswers)
        {
            switch (countRigthAnswers)
            {
                case 0: return "Идиот";
                case 1: return "Кретин";
                case 2: return "Дурак";
                case 3: return "Нормальный";
                case 4: return "Талант";
                case 5: return "Гений";
                default: return "Если вы это видите, то дураком является разработчик";
            }
        }

        /// <summary>
        /// Перемешивает указанный список
        /// </summary>
        static void ShuffleQuestions(List<Question> questions)
        {
            Random rand = new Random();

            for (int i = questions.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);

                var temp = questions[i];
                questions[i] = questions[j];
                questions[j] = temp;
            }
        }

        /// <summary>
        /// Формирует список уникальных вопросов
        /// </summary>
        /// <returns>
        /// List экземпляров Questions
        /// </returns>
        static List<Question> GetDefaultQuestions()
        {
            return new List<Question>()
            {
                new Question("Сколько будет 2 плюс 2, умноженное на 2?", "6"),
                new Question("Бревно нужно распилить на 10 частей. Сколько надо сделать распилов?", "9"),
                new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", "25"),
                new Question("Укол делают каждые полчаса. Сколько нужно минут для трех уколов?", "60"),
                new Question("5 свечей горело, 2 потухли. Сколько свечей осталось?", "2"),
            };
        }

        /// <summary>
        /// Выводит в консоль имя пользователя и через пробел ждёт ответ
        /// </summary>
        /// <returns>
        /// string ответ пользователя в консоль
        /// </returns>
        static string GetAnswer(User user)
        {
            CustomConsole.Message($"{user.Name}: ");
            return CustomConsole.ReadInput() ?? "";
        }

        /// <summary>
        /// Проверка на правильность ответа
        /// </summary>
        /// <returns>
        /// true - если ответ правильный. false - если ответ не правильный. Регистр имеет значение.
        /// </returns>
        static bool IsAnswerRigth(Question question, string answer)
        {
            if (question.IsDigitAnswer && !int.TryParse(answer, out _))
                throw new ArgumentException("Этот вопрос подрузамевает числовой ответ. Пожалуйста, введите число!");

            return answer.Equals(question.Answer);
        }
    }
}
