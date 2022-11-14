using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SimpleUIImagesManager : MonoBehaviour
{
    public Image firstImage;
    
    public Image sceondImage;
    
    public Image thirdImage;
    
    public Image fourthImage;
    

    public RectTransform[] checkUI;

    Queue<Image> AllImages = new Queue<Image>();

    Image PeekImage;

    public SimpleTipsController tips;

    Vector2 fourthCheckUIAnchorMax;
    Vector2 fourthCheckUIAnchorMin;

    Vector2 startLocalPosition;

    void Awake()
    {
        
    }

    private void Start()
    {
        StartCoroutine(StartCheckUIFadeIn());

        AllImages.Enqueue(firstImage);
        tips.RandomValue(firstImage);
        
        AllImages.Enqueue(sceondImage);
        tips.RandomValue(sceondImage) ;

        AllImages.Enqueue(thirdImage);
        tips.RandomValue(thirdImage);

        AllImages.Enqueue(fourthImage);
        tips.RandomValue(fourthImage);

        fourthCheckUIAnchorMax = checkUI[checkUI.Length - 1].anchorMax;
        fourthCheckUIAnchorMin = checkUI[checkUI.Length - 1].anchorMin;

    }

    public void JoinQueue()
    {
        AllImages.Enqueue(PeekImage);

        tips.RandomValue(PeekImage);
    }

    public void ExitQueue()
    {
        PeekImage = AllImages.Peek();

        AllImages.Dequeue();
    }

    public IEnumerator StartCheckUIFadeIn()
    {
        for (int i = 0; i < checkUI.Length; i++)
        {
            yield return new WaitForSeconds(0.4f);
            checkUI[i].gameObject.GetComponent<Image>().enabled = false;
            checkUI[i].DOAnchorPos(new Vector2(-6, 6), 1f, false).SetEase(Ease.OutElastic);
            checkUI[0].gameObject.GetComponent<Image>().enabled = true;
        }
    }

    public void CheckUIFadeOutAndIn()
    {
        int i = 0;
        if (AllImages.Peek() == firstImage)
        {
            i = 0;
        }
        else if (AllImages.Peek() == sceondImage)
        {
            i = 1;
        }
        else if (AllImages.Peek() == thirdImage)
        {
            i = 2;
        }
        else
        {
            i = 3;
        }

        checkUI[i].GetComponent<Image>().enabled = false;

        int count1 = 0;
        for (int j = i; j < checkUI.Length - 1; j++)
        {
            count1++;
            checkUI[j + 1].DOAnchorMax(fourthCheckUIAnchorMax + new Vector2(0, (checkUI.Length - count1) * fourthCheckUIAnchorMax.y), 0.2f, false);
            checkUI[j + 1].DOAnchorMin(fourthCheckUIAnchorMin + new Vector2(0, (checkUI.Length - count1) * fourthCheckUIAnchorMax.y), 0.2f, false);
            checkUI[i + 1].GetComponent<Image>().enabled = true;
        }
        if (count1 == 0)
        {
            checkUI[0].GetComponent<Image>().enabled = true;
        }
        for (int j = 0; j < i; j++)
        {
            count1++;
            checkUI[j].DOAnchorMax(fourthCheckUIAnchorMax + new Vector2(0, (checkUI.Length - count1) * fourthCheckUIAnchorMax.y), 0.2f, false);
            checkUI[j].DOAnchorMin(fourthCheckUIAnchorMin + new Vector2(0, (checkUI.Length - count1) * fourthCheckUIAnchorMax.y), 0.2f, false);
        }

        StartCoroutine(ddd());
        IEnumerator ddd()
        {
            checkUI[i].anchorMin = fourthCheckUIAnchorMin;
            checkUI[i].anchorMax = fourthCheckUIAnchorMax;
            checkUI[i].localPosition = new Vector3(-1200, -600, 0);
            yield return new WaitForSeconds(0.4f);
            checkUI[i].DOAnchorPos(new Vector2(-6, 6), 1, false);
        }
    }
}
