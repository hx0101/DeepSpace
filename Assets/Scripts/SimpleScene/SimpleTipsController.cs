using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleTipsController : MonoBehaviour
{
    public Text timeText;

    string[] words;

    public Queue<string> moveKeyTextMiddle = new Queue<string>();

    Timer timer;

    void Awake()
    {
        words = new string[2] { "白色", "黑色" };

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

    public void RandomValue(Image moveKey)
    {
        string middle = words[Mathf.RoundToInt(Random.value)];

        moveKeyTextMiddle.Enqueue(middle);

        switch (middle)
        {
            case "白色":
                moveKey.color = new Color(255, 255, 255);
                break;
            case "黑色":
                moveKey.color = new Color(0, 0, 0);
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
