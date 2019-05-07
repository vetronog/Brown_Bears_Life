using BearLife.Game;
using BearLife.PlayerSettings;
using BearLife.Question;
using UnityEngine;

namespace BearLife.Field
{
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
        public void ActivateCell(PlayerType type)
        {
            if (_type == CellType.finish)
            {
                if (type == PlayerType.bear)
                {
                    Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, 1);
                    foreach (Collider2D c in col)
                    {
                        if (c.gameObject.tag == "Player")
                        {
                            if (c.gameObject.GetComponent<PlayerPresenter>().Type == PlayerType.moose)
                            {
                                GameController.instance.EndGame(type);
                                break;
                            }
                        }
                    }
                    GameController.instance.ChangeActivePlayer();
                }
                else
                {
                    GameController.instance.EndGame(type);
                }
            }
            else
            {
                ActivateCell();
            }
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
                default:
                    break;
            }
        }
    }
}

