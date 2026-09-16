using System;
using System.Collections.Generic;
using System.Text;

namespace TestGeniusOrIdiot
{
    internal class Question
    {
        private string _text;
        private string _answer;
        private bool _isDigitAnswer = false;
        
        public Question(string text, string answer)
        {
            _text = text;
            _answer = answer;

            _isDigitAnswer = int.TryParse(answer, out _);
        }

        /// <summary>
        /// Проверка на правильность ответа
        /// </summary>
        /// <returns>
        /// true - если ответ правильный. false - если ответ не правильный. Регистр имеет значение.
        /// </returns>
        public bool IsAnswerRigth(string answer)
        {
            if (_isDigitAnswer && !int.TryParse(answer, out _))
                throw new ArgumentException("Этот вопрос подрузамевает числовой ответ. Пожалуйста, введите число!");

            return answer.Equals(_answer);
        }

        /// <summary>
        /// Строковое представление вопроса
        /// </summary>
        /// <returns>
        /// Выводит текст вопроса
        /// </returns>
        public override string ToString()
        {
            return _text;
        }
    }
}
