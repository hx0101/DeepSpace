using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalTipsController : MonoBehaviour
{
    public Text timeText;

    string[] words;

    public Queue<string> moveKeyTextLeft = new Queue<string>();

    public Queue<string> moveKeyTextRight = new Queue<string>();

    Timer timer;

    void Awake()
    {
        words = new string[2] { "红色", "绿色" };

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

    public void RandomValue(Image moveKeyLeft, Image moveKeyRight)
    {
        string left = words[Mathf.RoundToInt(Random.value)];
        string right = words[Mathf.RoundToInt(Random.value)];

        moveKeyTextLeft.Enqueue(left);

        moveKeyTextRight.Enqueue(right);

        switch (left)
        {
            case "红色":
                moveKeyLeft.color = new Color(255, 255, 255);
                break;
            case "绿色":
                moveKeyLeft.color = new Color(0, 0, 0);
                break;
        }

        switch (right)
        {
            case "红色":
                moveKeyRight.color = new Color(255, 255, 255);
                break;
            case "绿色":
                moveKeyRight.color = new Color(0, 0, 0);
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
