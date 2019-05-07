using UnityEngine;

namespace BearLife.Question
{
    public class QuestionData : ScriptableObject
    {
        [SerializeField] private string _questionTitle;

        public string GetQuestionTitle
        {
            get
            {
                return _questionTitle;
            }
        }
    }
}
