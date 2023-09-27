using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialText : MonoBehaviour
{
    TextMeshProUGUI textMesh;
    [SerializeField]
    Color colorRed = new Color();
    [SerializeField]
    Color colorBlue = new Color();
    [SerializeField]
    Transform positionRed = null;
    [SerializeField]
    Transform positionBlue = null;

    void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    public void ChangeColor()
    {
        print("LLega");
        if (textMesh.color == colorBlue) textMesh.color = colorRed;
        else if (textMesh.color == colorRed) textMesh.color = colorBlue;

        if(positionRed != null && positionBlue != null)
        {
            if (textMesh.color == colorBlue) transform.position = positionBlue.position;
            if (textMesh.color == colorRed) transform.position = positionRed.position;
        }
    } 

}
