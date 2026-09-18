using System;
using System.Collections.Generic;
using System.Text;

namespace TestGeniusOrIdiot
{
    internal class Question
    {
        public string Text { get; private set; }
        public string Answer { get; private set; }
        public bool IsDigitAnswer { get; private set; } = false;
        
        public Question(string text, string answer)
        {
            Text = text;
            Answer = answer;

            IsDigitAnswer = int.TryParse(answer, out _);
        }

        /// <summary>
        /// Строковое представление вопроса
        /// </summary>
        /// <returns>
        /// Выводит текст вопроса
        /// </returns>
        public override string ToString()
        {
            return Text;
        }
    }
}
