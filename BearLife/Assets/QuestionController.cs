using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private GameObject _panel;
    public static QuestionController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;        
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
}
