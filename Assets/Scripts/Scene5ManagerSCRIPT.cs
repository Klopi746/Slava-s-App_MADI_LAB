using System;
using TMPro;
using UnityEngine;

public class Scene5ManagerSCRIPT : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComp;

    private void Start()
    {
        textComp.text = $"Вывод: Для рекультивации городских почв принимаем осадок:{Environment.NewLine}объемом – {PlayerPrefs.GetFloat("minV")} м3," +
        $"{Environment.NewLine}массой – {PlayerPrefs.GetFloat("minM")} т{Environment.NewLine}и высотой – {PlayerPrefs.GetFloat("minH")} см.";
    }
}
