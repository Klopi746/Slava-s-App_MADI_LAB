using TMPro;
using UnityEngine;

public class Scene5ManagerSCRIPT : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComp;

    private void Start()
    {
        textComp.text = $"Вывод: Для рекультивации городских почв принимаем осадок: объемом – {PlayerPrefs.GetFloat("minV")} м3, массой – {PlayerPrefs.GetFloat("minM")} т и высотой – {PlayerPrefs.GetFloat("minH")} см.";
    }
}
