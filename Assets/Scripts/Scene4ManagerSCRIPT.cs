using System.Collections;
using System.Globalization;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scene4ManagerSCRIPT : MonoBehaviour
{
    [SerializeField] Image gruzoff;

    [SerializeField] Image podaviteliZemlya;

    private Sprite gruzoffwalk;
    [SerializeField] Sprite gruzoffSvalka;
    [SerializeField] Image[] plants;
    [SerializeField] Sprite plantsBad;
    [SerializeField] Sprite plantsGood;

    [SerializeField] Button goodButt;
    [SerializeField] Button badButt;

    [SerializeField] Image[] zemlya;

    private bool resultWasShown = false;

    int minIndex = -1;
    public void ShowResult(int index)
    {
        if (resultWasShown) return;

        resultWasShown = true;
        minIndex = index;

        Debug.Log(resultsH.Min());

        bool result = resultsH[index] <= resultsH.Min();
        StartCoroutine(ShowResultCoroutine(result));
    }
    private IEnumerator ShowResultCoroutine(bool result)
    {
        gruzoffwalk = gruzoff.sprite;

        Tween gruzoffTween = gruzoff.transform.DOMoveX(300, 3f);
        yield return gruzoffTween.WaitForCompletion();
        gruzoff.sprite = gruzoffSvalka;
        gruzoff.transform.DOMoveY(355, 0f);
        zemlya[0].DOFade(1, 1);
        yield return new WaitForSeconds(1f);

        gruzoff.sprite = gruzoffwalk;
        gruzoff.transform.DOMoveY(320, 0f);
        gruzoffTween = gruzoff.transform.DOMoveX(600, 3f);
        yield return gruzoffTween.WaitForCompletion();
        gruzoff.sprite = gruzoffSvalka;
        gruzoff.transform.DOMoveY(355, 0f);
        zemlya[1].DOFade(1, 1);
        yield return new WaitForSeconds(1f);

        gruzoff.sprite = gruzoffwalk;
        gruzoff.transform.DOMoveY(320, 0f);
        gruzoffTween = gruzoff.transform.DOMoveX(900, 3f);
        yield return gruzoffTween.WaitForCompletion();
        gruzoff.sprite = gruzoffSvalka;
        gruzoff.transform.DOMoveY(355, 0f);
        zemlya[2].DOFade(1, 1);
        yield return new WaitForSeconds(1f);

        gruzoff.sprite = gruzoffwalk;
        gruzoff.transform.DOMoveY(320, 0f);
        gruzoffTween = gruzoff.transform.DOMoveX(1200, 3f);
        yield return gruzoffTween.WaitForCompletion();

        Tween podavitelTween = podaviteliZemlya.transform.DOMoveX(300, 3f);
        yield return new WaitForSeconds(1.5f);
        zemlya[0].transform.DOScaleY(0.5f, 1);
        yield return podavitelTween.WaitForCompletion();
        yield return new WaitForSeconds(1f);

        podavitelTween = podaviteliZemlya.transform.DOMoveX(600, 2f);
        yield return new WaitForSeconds(1f);
        zemlya[1].transform.DOScaleY(0.5f, 1);
        yield return podavitelTween.WaitForCompletion();
        yield return new WaitForSeconds(1f);

        podavitelTween = podaviteliZemlya.transform.DOMoveX(900, 2f);
        yield return new WaitForSeconds(1f);
        zemlya[2].transform.DOScaleY(0.5f, 1);
        yield return podavitelTween.WaitForCompletion();
        yield return new WaitForSeconds(1f);

        podavitelTween = podaviteliZemlya.transform.DOMoveX(1200, 2f);
        yield return podavitelTween.WaitForCompletion();

        if (result == true)
        {
            PlayerPrefs.SetFloat("minV", resultsV[minIndex]);
            PlayerPrefs.SetFloat("minM", resultsM[minIndex]);
            PlayerPrefs.SetFloat("minH", resultsH[minIndex]);

            plants[0].sprite = plantsGood;
            plants[1].sprite = plantsGood;
            plants[2].sprite = plantsGood;
        }
        else
        {
            plants[0].sprite = plantsBad;
            plants[1].sprite = plantsBad;
            plants[2].sprite = plantsBad;
        }

        Tween plantsTween = null;
        foreach (var plant in plants)
        {
            plantsTween = plant.DOFade(1, 1);
        }
        if (plantsTween != null)
            yield return plantsTween.WaitForCompletion();

        if (result == true) goodButt.interactable = true;
        else badButt.interactable = true;
    }


    float Ccmcu = 3f;
    float Ccmmn = 1500f;
    float Ccmno3 = 130f;
    float Ccmva = 150f;

    float[] resultsH = new float[4];
    float[] resultsV = new float[4];
    float[] resultsM = new float[4];
    private void Awake()
    {
        float H = float.Parse(PlayerPrefs.GetString("H"), CultureInfo.InvariantCulture.NumberFormat);
        float S = float.Parse(PlayerPrefs.GetString("S"), CultureInfo.InvariantCulture.NumberFormat);
        float W = H * S * 10000;

        float Pp = float.Parse(PlayerPrefs.GetString("Pp"), CultureInfo.InvariantCulture.NumberFormat);
        float M = W * Pp;

        float Poc = float.Parse(PlayerPrefs.GetString("Poc"), CultureInfo.InvariantCulture.NumberFormat);
        float CocCu = float.Parse(PlayerPrefs.GetString("CocCu"), CultureInfo.InvariantCulture.NumberFormat);
        float CocMn = float.Parse(PlayerPrefs.GetString("CocMn"), CultureInfo.InvariantCulture.NumberFormat);
        float CocNO = float.Parse(PlayerPrefs.GetString("CocNO"), CultureInfo.InvariantCulture.NumberFormat);
        float CocVa = float.Parse(PlayerPrefs.GetString("CocVa"), CultureInfo.InvariantCulture.NumberFormat);
        float CCu = CocCu / Poc;
        float CMn = CocMn / Poc;
        float CNO = CocNO / Poc;
        float CVa = CocVa / Poc;

        float CfCu = float.Parse(PlayerPrefs.GetString("CfCu"), CultureInfo.InvariantCulture.NumberFormat);
        float CfMn = float.Parse(PlayerPrefs.GetString("CfMn"), CultureInfo.InvariantCulture.NumberFormat);
        float CfNO = float.Parse(PlayerPrefs.GetString("CfNO"), CultureInfo.InvariantCulture.NumberFormat);
        float CfVa = float.Parse(PlayerPrefs.GetString("CfVa"), CultureInfo.InvariantCulture.NumberFormat);
        float mCu = M * (Ccmcu - CfCu) / (CCu - Ccmcu);
        resultsM[0] = mCu;
        float mMn = M * (Ccmmn - CfMn) / (CMn - Ccmmn);
        resultsM[1] = mMn;
        float mNo = M * (Ccmno3 - CfNO) / (CNO - Ccmno3);
        resultsM[2] = mNo;
        float mVa = M * (Ccmva - CfVa) / (CVa - Ccmva);
        resultsM[3] = mVa;

        float Vcu = mCu / Poc;
        resultsV[0] = Vcu;
        float Vmn = mMn / Poc;
        resultsV[1] = Vmn;
        float Vno = mNo / Poc;
        resultsV[2] = Vno;
        float Vva = mVa / Poc;
        resultsV[3] = Vva;

        float hcu = Vcu / S / 100;
        resultsH[0] = hcu;
        float hmn = Vmn / S / 100;
        resultsH[1] = hmn;
        float hno = Vno / S / 100;
        resultsH[2] = hno;
        float hva = Vva / S / 100;
        resultsH[3] = hva;
    }

    [SerializeField] TextMeshProUGUI[] buttonsText;
    private void Start()
    {
        buttonsText[0].text = resultsH[0].ToString();
        buttonsText[1].text = resultsH[1].ToString();
        buttonsText[2].text = resultsH[2].ToString();
        buttonsText[3].text = resultsH[3].ToString();
    }
}
