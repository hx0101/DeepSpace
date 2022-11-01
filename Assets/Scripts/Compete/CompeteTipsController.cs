using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompeteTipsController : MonoBehaviour
{
    public Text timeText;

    string[] words;

    public Queue<string> moveKeyTextBlack = new Queue<string>();

    public Queue<string> moveKeyTextWhite = new Queue<string>();

    UIImageManager uiManager;

    Timer timer;

    void Awake()
    {
        words = new string[4] { "向前", "向左", "向后", "向右" };

        timeText.text = "0:00";
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimerShart();
    }

    private void FixedUpdate()
    {
        
    }

    public void RandomValue(Image[] moveKeysBlack, Image[] moveKeysWhite)
    {
        string black = words[(int)Random.Range(0, 3)];
        string white = words[(int)Random.Range(0, 3)];

        moveKeyTextBlack.Enqueue(black);

        moveKeyTextWhite.Enqueue(white);

        switch (black)
        {
            case "向前":
                foreach (var moveKey in moveKeysBlack)
                {
                    if (moveKey.name == "W")
                    {
                        moveKey.color = new Color(1, 1, 1, 0.4f);
                    }
                    else
                    {
                        moveKey.color = new Color(1, 1, 1, 1);
                    }
                }
                break;
            case "向左":
                foreach (var moveKey in moveKeysBlack)
                {
                    if (moveKey.name == "A")
                    {
                        moveKey.color = new Color(1, 1, 1, 0.4f);
                    }
                    else
                    {
                        moveKey.color = new Color(1, 1, 1, 1);
                    }
                }
                break;
            case "向后":
                foreach (var moveKey in moveKeysBlack)
                {
                    if (moveKey.name == "S")
                    {
                        moveKey.color = new Color(1, 1, 1, 0.4f);
                    }
                    else
                    {
                        moveKey.color = new Color(1, 1, 1, 1);
                    }
                }
                break;
            case "向右":
                foreach (var moveKey in moveKeysBlack)
                {
                    if (moveKey.name == "D")
                    {
                        moveKey.color = new Color(1, 1, 1, 0.4f);
                    }
                    else
                    {
                        moveKey.color = new Color(1, 1, 1, 1);
                    }
                }
                break;

        }

        switch (white)
        {
            case "向前":
                foreach (var moveKey in moveKeysWhite)
                {
                    if (moveKey.name == "W")
                    {
                        moveKey.color = new Color(1, 1, 1, 0.4f);
                    }
                    else
                    {
                        moveKey.color = new Color(1, 1, 1, 1);
                    }
                }
                break;
            case "向左":
                foreach (var moveKey in moveKeysWhite)
                {
                    if (moveKey.name == "A")
                    {
                        moveKey.color = new Color(1, 1, 1, 0.4f);
                    }
                    else
                    {
                        moveKey.color = new Color(1, 1, 1, 1);
                    }
                }
                break;
            case "向后":
                foreach (var moveKey in moveKeysWhite)
                {
                    if (moveKey.name == "S")
                    {
                        moveKey.color = new Color(1, 1, 1, 0.4f);
                    }
                    else
                    {
                        moveKey.color = new Color(1, 1, 1, 1);
                    }
                }
                break;
            case "向右":
                foreach (var moveKey in moveKeysWhite)
                {
                    if (moveKey.name == "D")
                    {
                        moveKey.color = new Color(1, 1, 1, 0.4f);
                    }
                    else
                    {
                        moveKey.color = new Color(1, 1, 1, 1);
                    }
                }
                break;

        }
    }

    public void TimerShart()
    {
        if (timeText.text != "0:00")
        {
            timeText.text = Mathf.Floor((1000 - timer.GetTimeNow()) / 60) + ":" + ((int)(1000 - timer.GetTimeNow()) % 60);
            return;
        }
        if ((Input.GetKeyDown("w")
            || Input.GetKeyDown("a")
            || Input.GetKeyDown("s")
            || Input.GetKeyDown("d"))
            && timeText.text == "0:00")
        {
            timer = Timer.createTimer("Timer");
            timer.startTiming(1000, false, null, null, true, false, false, 0, false, true);
            timeText.text = "0:0";
        }
    }
}
