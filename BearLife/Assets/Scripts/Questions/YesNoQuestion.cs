using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "YesNoQuestion_", menuName = "Scriptable object/Yes No question")]
public class YesNoQuestion : QuestionData
{
    [SerializeField] private bool _isTrue;
}
