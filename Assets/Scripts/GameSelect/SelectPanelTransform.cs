using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class SelectPanelTransform : MonoBehaviour
{
    public RectTransform single;
    public RectTransform multiple;
    public RectTransform back;
    public RectTransform simple;
    public RectTransform normal;
    public RectTransform difficult;
    public RectTransform compete;
    public RectTransform cooperate;

    // Start is called before the first frame update
    void Start()
    {
        single.GetComponent<Button>().enabled = false;
        single.GetComponent<Image>().enabled = false;
        multiple.GetComponent<Button>().enabled = false;
        multiple.GetComponent<Image>().enabled = false;
        back.GetComponent<Button>().enabled = false;
        back.GetComponent<Image>().enabled = false;
        simple.GetComponent<Button>().enabled = false;
        simple.GetComponent<Image>().enabled = false;
        normal.GetComponent<Button>().enabled = false;
        normal.GetComponent<Image>().enabled = false;
        difficult.GetComponent<Button>().enabled = false;
        difficult.GetComponent<Image>().enabled = false;
        compete.GetComponent<Button>().enabled = false;
        compete.GetComponent<Image>().enabled = false;
        cooperate.GetComponent<Button>().enabled = false;
        compete.GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator GameModelEnter()
    {
        yield return new WaitForSeconds(0.4f);
        single.GetComponent<Button>().enabled = true;
        single.GetComponent<Image>().enabled = true;
        multiple.GetComponent<Button>().enabled = true;
        multiple.GetComponent<Image>().enabled = true;
        single.DOAnchorMin(new Vector2(0, single.anchorMin.y), 1f, false).SetEase(Ease.OutElastic);
        single.DOAnchorMax(new Vector2(-single.anchorMin.x, single.anchorMax.y), 1f, false).SetEase(Ease.OutElastic);
        yield return new WaitForSeconds(0.3f);
        multiple.DOAnchorMin(new Vector2(0, multiple.anchorMin.y), 1f, false).SetEase(Ease.OutElastic);
        multiple.DOAnchorMax(new Vector2(-multiple.anchorMin.x, multiple.anchorMax.y), 1f, false).SetEase(Ease.OutElastic);
    }

    public void GameModelEnterGet()
    {
        RectTransform[] rectTransforms = new RectTransform[2] { single, multiple };
        StartCoroutine(ButtonsEnter(rectTransforms,false));
    }
    public void GameModelExitGet()
    {
        RectTransform[] rectTransforms = new RectTransform[2] { single, multiple };
        StartCoroutine(ButtonsExit(rectTransforms,false));
    }

    public void DifficultyEnterGet()
    {
        RectTransform[] rectTransforms = new RectTransform[3] { simple, normal, difficult };
        StartCoroutine(ButtonsEnter(rectTransforms,true));
    }
    public void DifficultyExitGet()
    {
        RectTransform[] rectTransforms = new RectTransform[3] { simple, normal, difficult };
        StartCoroutine(ButtonsExit(rectTransforms,true));
    }

    public void AOrTogetherEnterGet()
    {
        RectTransform[] rectTransforms = new RectTransform[2] { compete, cooperate };
        StartCoroutine(ButtonsEnter(rectTransforms, true));
        
    }
    public void AOrTogetherExitGet()
    {
        RectTransform[] rectTransforms = new RectTransform[2] { compete, cooperate };
        StartCoroutine(ButtonsExit(rectTransforms,true));
    }

    public IEnumerator ButtonsEnter(RectTransform[] rectTransforms,bool backEnter)
    {
        yield return new WaitForSeconds(1f);
        ButtonEnterPanel(rectTransforms[0]);
        for (int i = 1; i < rectTransforms.Length; i++)
        {
            yield return new WaitForSeconds(0.3f);
            ButtonEnterPanel(rectTransforms[i]);
        }
        if (backEnter)
        {
            BackEnterPanel(back);
        }
    }

    public IEnumerator ButtonsExit(RectTransform[] rectTransforms,bool backExit)
    {
        ButtonExitPanel(rectTransforms[0]);
        for(int i = 1; i < rectTransforms.Length; i++)
        {
            yield return new WaitForSeconds(0.3f);
            ButtonExitPanel(rectTransforms[i]);
        }
        if (backExit)
        {
            BackExitPanel(back);
        }
    }

    public void ButtonEnterPanel(RectTransform rectTransform)
    {
        rectTransform.GetComponent<Button>().enabled = true;
        rectTransform.GetComponent<Image>().enabled = true;
        rectTransform.DOAnchorMin(new Vector2(0, rectTransform.anchorMin.y), 1f, false).SetEase(Ease.OutElastic);
        rectTransform.DOAnchorMax(new Vector2(-rectTransform.anchorMin.x, rectTransform.anchorMax.y), 1f, false).SetEase(Ease.OutElastic);
        
    }

    public void ButtonExitPanel(RectTransform rectTransform)
    {
        rectTransform.GetComponent<Button>().enabled = false;
        rectTransform.GetComponent<Image>().enabled = false;
        rectTransform.DOAnchorMin(new Vector2(-rectTransform.anchorMax.x, rectTransform.anchorMin.y), 1f, false).SetEase(Ease.InOutQuint);
        rectTransform.DOAnchorMax(new Vector2(0, rectTransform.anchorMax.y), 1f, false).SetEase(Ease.InOutElastic);
    }

    public void BackEnterPanel(RectTransform rectTransform)
    {
        rectTransform.GetComponent<Button>().enabled = true;
        rectTransform.GetComponent<Image>().enabled = true;
        rectTransform.DOAnchorMin(new Vector2(2 - rectTransform.anchorMax.x, rectTransform.anchorMin.y), 1f, false).SetEase(Ease.OutElastic);
        rectTransform.DOAnchorMax(new Vector2(1, rectTransform.anchorMax.y), 1f, false).SetEase(Ease.OutElastic);
    }

    public void BackExitPanel(RectTransform rectTransform)
    {
        rectTransform.GetComponent<Button>().enabled = false;
        rectTransform.GetComponent<Image>().enabled = false;
        rectTransform.DOAnchorMin(new Vector2(1, rectTransform.anchorMin.y), 1f, false).SetEase(Ease.InOutElastic);
        rectTransform.DOAnchorMax(new Vector2(2 - rectTransform.anchorMin.x, rectTransform.anchorMax.y), 1f, false).SetEase(Ease.InOutQuint);
    }
}

