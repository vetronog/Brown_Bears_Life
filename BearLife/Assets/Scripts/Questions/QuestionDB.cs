using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionDB", menuName = "Scriptable object/QuestionDB")]
public class QuestionDB : ScriptableObject
{
    [SerializeField] private List<QuestionData> _questions;
}
