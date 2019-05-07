using UnityEngine;

namespace BearLife.Question
{
    [CreateAssetMenu(fileName = "ChoiceQuestion_", menuName = "Scriptable object/Choice question")]

    public class ChoiceQuestion : QuestionData
    {
        [SerializeField] private string[] _answers = new string[3];
        [SerializeField] private int _rightAnswerIndex;

        public string[] GetAnswers()
        {
            return _answers;
        }

        public int GetRightAnswer()
        {
            return _rightAnswerIndex;
        }
    }
}
