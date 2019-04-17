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
    private List<QuestionData> _questions;
    public static QuestionController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        _questions = _db.GetQuestions();
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

        }
        else
        {
            _buttons[2].gameObject.SetActive(true);
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
        int i =Random.Range(0, _questions.Count);
        YesNoQuestion q= _questions[i] as YesNoQuestion;
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
        _questions.RemoveAt(i);
    }

    
}
