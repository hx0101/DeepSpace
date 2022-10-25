using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIImageManager : MonoBehaviour
{
    public Image[] firstBlackImages;
    public Image[] firstWhiteImages;
    public Image[] sceondBlackImages;
    public Image[] sceondWhiteImages;
    public Image[] thirdBlackImages;
    public Image[] thirdWhiteImages;
    public Image[] fourthBlackImages;
    public Image[] fourthWhiteImages;

    public RectTransform[] checkUI;

    Queue<Image[]> AllBlackImages = new Queue<Image[]>();
    Queue<Image[]> AllWhiteImages = new Queue<Image[]>();

    Image[] PeekBlackImages;
    Image[] PeekWhiteImages;

    TipsControll tips;

    Vector2 fourthCheckUIAnchorMax;
    Vector2 fourthCheckUIAnchorMin;

    Vector2 startLocalPosition;

    void Awake()
    {
        tips = GameObject.FindWithTag("Panel").gameObject.GetComponent<TipsControll>();
    }

    private void Start()
    {
        StartCoroutine(StartCheckUIFadeIn());

        AllBlackImages.Enqueue(firstBlackImages);
        AllBlackImages.Enqueue(sceondBlackImages);
        AllBlackImages.Enqueue(thirdBlackImages);
        AllBlackImages.Enqueue(fourthBlackImages);

        AllWhiteImages.Enqueue(firstWhiteImages);
        AllWhiteImages.Enqueue(sceondWhiteImages);
        AllWhiteImages.Enqueue(thirdWhiteImages);
        AllWhiteImages.Enqueue(fourthWhiteImages);

        tips.RandomValue(firstBlackImages, firstWhiteImages);
        tips.RandomValue(sceondBlackImages, sceondWhiteImages);
        tips.RandomValue(thirdBlackImages, thirdWhiteImages);
        tips.RandomValue(fourthBlackImages, fourthWhiteImages);

        fourthCheckUIAnchorMax = checkUI[checkUI.Length - 1].anchorMax;
        fourthCheckUIAnchorMin = checkUI[checkUI.Length - 1].anchorMin;
        
    }

    public void JoinQueue()
    {
        AllBlackImages.Enqueue(PeekBlackImages);
        AllWhiteImages.Enqueue(PeekWhiteImages);

        tips.RandomValue(PeekBlackImages, PeekWhiteImages);
    }

    public void ExitQueue()
    {
        PeekBlackImages = AllBlackImages.Peek();
        PeekWhiteImages = AllWhiteImages.Peek();

        AllBlackImages.Dequeue();
        AllWhiteImages.Dequeue();
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
        if (AllBlackImages.Peek() == firstBlackImages)
        {
            i = 0;
        }
        else if (AllBlackImages.Peek() == sceondBlackImages)
        {
            i = 1;
        }
        else if (AllBlackImages.Peek() == thirdBlackImages)
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
            checkUI[j + 1].DOAnchorMax(fourthCheckUIAnchorMax + new Vector2(0,(checkUI.Length - count1) * fourthCheckUIAnchorMax.y), 0.2f, false);
            checkUI[j + 1].DOAnchorMin(fourthCheckUIAnchorMin + new Vector2(0,(checkUI.Length - count1) * fourthCheckUIAnchorMax.y), 0.2f, false);
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
        
        //for (int j = i; j < i + checkUI.Length - 1; j++)
        //{
        //    checkUI[j + 1 - checkUI.Length].DOAnchorMax(checkUI[j].anchorMax, 1, false);
        //    checkUI[j + 1 - checkUI.Length].DOAnchorMin(checkUI[j].anchorMin, 1, false);
        //}

        //for (int j = i; j < i + checkUI.Length - 1; j++)
        //{
        //    if (j + 1 < checkUI.Length)
        //    {
        //        checkUI[j + 1].DOAnchorMax(checkUI[j].anchorMax, 1, false);
        //        checkUI[j + 1].DOAnchorMin(checkUI[j].anchorMin, 1, false);
        //    }
        //    else if (j + 1 == checkUI.Length)
        //    {
        //        checkUI[j + 1 - checkUI.Length].DOAnchorMax(checkUI[j].anchorMax, 1, false);
        //        checkUI[j + 1 - checkUI.Length].DOAnchorMin(checkUI[j].anchorMin, 1, false);
        //    }
        //    else
        //    {
        //        checkUI[j + 1 - checkUI.Length].DOAnchorMax(checkUI[j - checkUI.Length].anchorMax, 1, false);
        //        checkUI[j + 1 - checkUI.Length].DOAnchorMin(checkUI[j - checkUI.Length].anchorMin, 1, false);
        //    }
        //}

        //checkUI[i].DOAnchorMax(fourthCheckUIAnchorMax, 0.5f, false);
        //checkUI[i].DOAnchorMin(fourthCheckUIAnchorMin, 0.5f, false);
        //checkUI[i].DOAnchorPos(new Vector2(-6,6), 10, false).SetEase(Ease.OutElastic);

        //    if (i == 0)
        //    {
        //        checkUI[i].DOAnchorPos(checkUI[checkUI.Length - 1].localPosition, 2, false);
        //        for (int j = checkUI.Length - 1; j > 0; j--)
        //        {
        //            if (j - 1 != 0)
        //            {
        //                checkUI[j].DOAnchorPos(checkUI[j - 1].localPosition, 1, false);
        //            }
        //            else
        //            {
        //                checkUI[j].DOAnchorPos(checkui, 1, false);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        checkUI[i].DOAnchorPos(checkUI[i - 1].localPosition, 2, false);
        //        for (int j = i - 1; j > i - checkUI.Length; j--)
        //        {
        //            if (j < 0)
        //            {
        //                checkUI[checkUI.Length + j].DOAnchorPos(checkUI[checkUI.Length + j - 1].localPosition, 1, false);
        //            }
        //            else if (j == 0)
        //            {
        //                checkUI[j].DOAnchorPos(checkUI[checkUI.Length + j - 1].localPosition, 1, false);
        //            }
        //            else
        //            {
        //                checkUI[j].DOAnchorPos(checkUI[j - 1].localPosition, 1, false);
        //            }
        //        }
        //    }
    }
}