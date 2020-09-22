using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Scenes Index")]
public class ScenesIndex : ScriptableObject
{
    [SerializeField] private List<int> gameplayScenesExecutionOrder;


}


