using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

public  class MyEditorScript : EditorWindow
{
    [MenuItem("Tools/MyScript")]
    public static void ExecuteEditorScript()
    {
        Debug.Log("My editor script was executed! Amazing!");
    }
}
