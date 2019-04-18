using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionDB", menuName = "Scriptable object/QuestionDB")]
public class QuestionDB : ScriptableObject
{
    [SerializeField] private List<YesNoQuestion> _yesNoQuestions;
    [SerializeField] private List<ChoiceQuestion> _choiceQuestions;

    public List<QuestionData> GetYesNoQuestions()
    {
        List<QuestionData> newList = new List<QuestionData>(_yesNoQuestions);
        return newList;
    }

    public List<QuestionData> GetChoiceQuestions()
    {
        List<QuestionData> newList = new List<QuestionData>(_choiceQuestions);
        return newList;
    }
}
