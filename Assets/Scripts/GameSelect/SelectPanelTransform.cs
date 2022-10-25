using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
        StartCoroutine(GameModelIn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GameModelIn()
    {
        yield return new WaitForSeconds(0.2f);
        single.DOAnchorMin(new Vector2(0, single.anchorMin.y), 1f, false).SetEase(Ease.OutElastic);
        single.DOAnchorMax(new Vector2(-single.anchorMin.x, single.anchorMax.y), 1f, false).SetEase(Ease.OutElastic);
        yield return new WaitForSeconds(0.3f);
        multiple.DOAnchorMin(new Vector2(0, multiple.anchorMin.y), 1f, false).SetEase(Ease.OutElastic);
        multiple.DOAnchorMax(new Vector2(-multiple.anchorMin.x, multiple.anchorMax.y), 1f, false).SetEase(Ease.OutElastic);
    }

    public IEnumerator GameModelOut()
    {
        yield return new WaitForSeconds(0.2f);
        single.DOAnchorMin(new Vector2(0, single.anchorMin.y), 1f, false).SetEase(Ease.OutElastic);
        single.DOAnchorMax(new Vector2(-single.anchorMin.x, single.anchorMax.y), 1f, false).SetEase(Ease.OutElastic);
        yield return new WaitForSeconds(0.3f);
        multiple.DOAnchorMin(new Vector2(0, multiple.anchorMin.y), 1f, false).SetEase(Ease.OutElastic);
        multiple.DOAnchorMax(new Vector2(-multiple.anchorMin.x, multiple.anchorMax.y), 1f, false).SetEase(Ease.OutElastic);
    }
    public static void ButtonEnterPanel(RectTransform rectTransform)
    {
        rectTransform.DOAnchorMin(new Vector2(0, rectTransform.anchorMin.y), 1f, false).SetEase(Ease.OutElastic);
        rectTransform.DOAnchorMax(new Vector2(-rectTransform.anchorMin.x, rectTransform.anchorMax.y), 1f, false).SetEase(Ease.OutElastic);
    }

    public void ButtonExitPanel(RectTransform rectTransform)
    {
        rectTransform.DOAnchorMin(new Vector2(-rectTransform.anchorMax.x, rectTransform.anchorMin.y), 1f, false).SetEase(Ease.InOutElastic);
        rectTransform.DOAnchorMax(new Vector2(0, rectTransform.anchorMax.y), 1f, false).SetEase(Ease.InOutElastic);
    }
}
}
