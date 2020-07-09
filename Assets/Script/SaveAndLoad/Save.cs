using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Save : MonoBehaviour
{
    static int[] top;
    void Awake()
    {
        top = new int[5];
        for(int i = 0; i < top.Length; i++)
        {
            top[i] = 0;
        }
        top = LoadScore();
        Sort();
        
    }
    public static void SaveScore(int score)
    {
        for (int i = 0; i < top.Length; i++)
        {
            if (score > top[i])
            {
                int aux = 0;
                aux = score;
                score = top[i];
                top[i] = aux;
            }
        }
        BinaryFormatter fm = new BinaryFormatter();
        string path = Application.persistentDataPath + "/HighScore.dat";
        FileStream s = new FileStream(path, FileMode.Create);
        s.SetLength(0);
        fm.Serialize(s, top);
        s.Close();
    }
    public static int[] LoadScore()
    {
        string path = Application.persistentDataPath + "/HighScore.dat";
        if(File.Exists(path))
        {
            BinaryFormatter fm = new BinaryFormatter();
            FileStream s = new FileStream(path, FileMode.Open);
            if (s.Length!=0)
            {
                int[] data = (int[])fm.Deserialize(s);
                s.Close();
                return data;
            }
            s.Close();
        }
        int[] w = new int[top.Length];
        return w;
    }
    public static void DeleteScore()
    {
        string path = Application.persistentDataPath + "/HighScore.dat";
        if(File.Exists(path))
        {
            FileStream s = new FileStream(path,FileMode.Create);
            s.SetLength(0);
            s.Close();
        }
    }
    static void Sort()
    {
        for(int i = 0; i < top.Length-1; i++)
        {
            if(top[i]<top[i+1])
            {
                int aux = 0;
                aux = top[i + 1];
                top[i+1] = top[i];
                top[i] = aux;
            }
        }
    }

}
