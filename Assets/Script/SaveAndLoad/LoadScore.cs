using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadScore : MonoBehaviour
{
    int[] top;
    [SerializeField]
    Text topTxt;
    void Start()
    {
        topTxt.text = "";
        top = Save.LoadScore();
        for (int i = 0; i < top.Length; i++)
        {
            topTxt.text += (i+1)+"- " + top[i]+"\n";
        }
    }
    void Update()
    {
        
    }
}
