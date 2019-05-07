using UnityEngine;

namespace BearLife.Question
{
    [CreateAssetMenu(fileName = "YesNoQuestion_", menuName = "Scriptable object/Yes No question")]
    public class YesNoQuestion : QuestionData
    {
        [SerializeField] private bool _isTrue;
        public bool IsTrue
        {
            get
            {
                return _isTrue;
            }
        }
    }
}

