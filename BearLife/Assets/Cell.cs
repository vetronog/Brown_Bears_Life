using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CellType
{
    green,
    yellow,
    skip,
    finish
}

public class Cell : MonoBehaviour
{
    [SerializeField] private CellType _type;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateCell()
    {
        switch(_type)
        {
            case CellType.green:
                QuestionController.instance.ShowQuestion(_type);
                break;
            case CellType.yellow:
                QuestionController.instance.ShowQuestion(_type);
                break;
            case CellType.skip:
                GameController.instance.SkipTurn();
                GameController.instance.ChangeActivePlayer();
                break;
            case CellType.finish:
                break;
        }
    }
}
