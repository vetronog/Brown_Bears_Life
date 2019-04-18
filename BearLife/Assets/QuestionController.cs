using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private Text _questionText;
    [SerializeField] private GameObject _panel;
    [SerializeField] private QuestionDB _db;
    private Text[] _buttonText;
    private List<QuestionData> _questionsYN;
    private List<QuestionData> _questionsChoice;
    public static QuestionController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        _questionsYN = _db.GetYesNoQuestions();
        _questionsChoice = _db.GetChoiceQuestions();
        _buttonText = new Text[3];
        for (int i = 0; i<3;++i)
        {
            _buttonText[i] = _buttons[i].GetComponentInChildren<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ShowQuestion(CellType type)
    {
        _panel.SetActive(true);
        if (type == CellType.green)
        {
            _buttons[2].gameObject.SetActive(false);
            SetYesNoQuestion();

        }
        else
        {
            _buttons[2].gameObject.SetActive(true);
            SetChoiceQuestion();
        }

    }

    public void RightAnswer()
    {
        HidePanel();
        GameController.instance.ChangeActivePlayer();
    }

    public void WrongAnswer()
    {
        GameController.instance.GetCurrentPlayer.WalkBack(2);
        HidePanel();
    }

    private void HidePanel()
    {
        _panel.SetActive(false);
    }

    private void SetYesNoQuestion()
    {
        int i =Random.Range(0, _questionsYN.Count);
        YesNoQuestion q= _questionsYN[i] as YesNoQuestion;
        _questionText.text = q.GetQuestionTitle;
        if (q.IsTrue)
        {
            _buttonText[0].text = "Да";
            _buttonText[1].text = "Нет";
        }
        else
        {
            _buttonText[0].text = "Нет";
            _buttonText[1].text = "Да";
        }
        _questionsYN.RemoveAt(i);
    }

    private void SetChoiceQuestion()
    {
        int i = Random.Range(0, _questionsChoice.Count);
        ChoiceQuestion q = _questionsChoice[i] as ChoiceQuestion;
        string[] answers = q.GetAnswers();
        _questionText.text = q.GetQuestionTitle;
        switch (q.GetRightAnswer())
        {
            case 0:
                _buttonText[0].text = answers[0];
                _buttonText[1].text = answers[1];
                _buttonText[2].text = answers[2];
                break;
            case 1:
                _buttonText[0].text = answers[1];
                _buttonText[1].text = answers[0];
                _buttonText[2].text = answers[2];
                break;
            case 2:
                _buttonText[0].text = answers[2];
                _buttonText[1].text = answers[1];
                _buttonText[2].text = answers[0];
                break;
            default:
                break;
        }
        _questionsChoice.RemoveAt(i);
    }


}
