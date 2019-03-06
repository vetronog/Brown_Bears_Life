using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType {
    bear,
    moose,
    none
}

public class Player : MonoBehaviour
{
    [SerializeField]
    private PathHandler _pathHandler;
    [SerializeField]
    private Vector3 _startScale, _endScale;
    [SerializeField]
    private PlayerType type;
    private bool isActive;
    private int _currentPos;
    private int _wayLength;
    private float _timer;
    private Queue<Transform> _path;
    private bool _isMoving;
    private Vector3 _startPos, _endPos;
    // Start is called before the first frame update
    void Start()
    {
        _currentPos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isMoving)
        {
            transform.position = Vector3.Lerp(_startPos, _endPos, _timer / 0.5f);
            _timer += Time.deltaTime;
            if (_timer <= 0.25f)
            {
                transform.localScale = Vector3.Lerp(_startScale, _endScale, _timer / 0.25f);
            }
            else
            {
                transform.localScale = Vector3.Lerp(_endScale, _startScale, (_timer-0.25f)/ 0.25f);
            }
            
            if(_timer >= 0.6f)
            {
                if(_path.Count>0)
                {
                    _startPos = transform.position;
                    _endPos = _path.Dequeue().position;
                    _timer = 0;
                }
                else
                {
                    _isMoving = false;
                    GameController.instance.ChangeActivePlayer();
                }
            }
        }
    }

    private void GetPath()
    {
        _path =_pathHandler.GetPath(_currentPos, _wayLength);
        _currentPos = _currentPos + _wayLength;
        _startPos = transform.position;
        _endPos = _path.Dequeue().position;
        _isMoving = true;
        _timer = 0;
    }

    public int Roll()
    {
        if (!_isMoving)
        {
            _wayLength = Random.Range(2, 12);
            GetPath();
        }
        return _wayLength;        
    }

    public PlayerType Type
    {
        get {
            return type;
        }
    }



}
