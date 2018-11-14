using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scores : MonoBehaviour
{
    private static Scores instance;

    private int score = 0;

    public Font hsFont;

    public void Awake()
    {
        if (instance == null)
        {
            hsFont = Font.CreateDynamicFontFromOSFont("Arial", 24);
            DontDestroyOnLoad(hsFont);
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public static int GetScore()
    {
        return instance.score;
    }

    public static int SetScore(int s)
    {
        return instance.score = s;
    }

    public static int AddScore(int a)
    {
        return instance.score += a;
    }

    public void OnGUI()
    {
        Scene curScene = SceneManager.GetActiveScene();
        if (curScene.name == "Maze")
        {
            GUIStyle tStyle = GUI.skin.GetStyle("label");
            tStyle.alignment = TextAnchor.MiddleCenter;
            tStyle.font = instance.hsFont;
            tStyle.richText = true;
            GUIContent tContent = new GUIContent("<color=yellow><b>Scores:   </b>" + instance.score + "</color>");
            Vector2 tSize = tStyle.CalcScreenSize(tStyle.CalcSize(tContent));
            GUI.Label(new Rect(62, 38, tSize.x, tSize.y), tContent, tStyle);
        }
    }

}
