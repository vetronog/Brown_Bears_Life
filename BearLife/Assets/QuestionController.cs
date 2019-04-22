using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private Text _questionText;
    [SerializeField] private Text _timerText;
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
        StartCoroutine("QuestionTimer");
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
        StopCoroutine("QuestionTimer");
    }

    private void SetYesNoQuestion()
    {
        int i =Random.Range(0, _questionsYN.Count);
        YesNoQuestion q= _questionsYN[i] as YesNoQuestion;
        _questionText.text = q.GetQuestionTitle;
        _buttonText[0].text = "Да";
        _buttonText[1].text = "Нет";
        RemoveListeners();
        if (q.IsTrue)
        {
            _buttons[0].onClick.AddListener(RightAnswer);
            _buttons[1].onClick.AddListener(WrongAnswer);
        }
        else
        {
            _buttons[1].onClick.AddListener(RightAnswer);
            _buttons[0].onClick.AddListener(WrongAnswer);
        }
        _questionsYN.RemoveAt(i);
    }

    private void RemoveListeners()
    {
        _buttons[0].onClick.RemoveAllListeners();
        _buttons[1].onClick.RemoveAllListeners();
        _buttons[2].onClick.RemoveAllListeners();
    }



    private void SetChoiceQuestion()
    {
        int i = Random.Range(0, _questionsChoice.Count);
        ChoiceQuestion q = _questionsChoice[i] as ChoiceQuestion;
        string[] answers = q.GetAnswers();
        _questionText.text = q.GetQuestionTitle;
        RemoveListeners();
        for (int a = 0; a < 3; ++a)
        {
            if(a == q.GetRightAnswer())
                _buttons[a].onClick.AddListener(RightAnswer);
            else
                _buttons[a].onClick.AddListener(WrongAnswer);
        }
       
        _buttonText[0].text = answers[0];
        _buttonText[1].text = answers[1];
        _buttonText[2].text = answers[2];
      
        _questionsChoice.RemoveAt(i);
    }

    private IEnumerator QuestionTimer()
    {
        int t = 10;
        while (t > 0)
        {
            _timerText.text = t.ToString();
            t--;
            Debug.Log("RunningTimer");
            yield return new WaitForSeconds(1);
        }
        WrongAnswer();
    }


}
