using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scene3ManagerSCRIPT : MonoBehaviour
{
    public TMP_InputField[] inputFields;

    [SerializeField] string otvet = "";

    void Start()
    {
        foreach (TMP_InputField field in inputFields)
        {
            var se = new TMP_InputField.SubmitEvent();
            se.AddListener(delegate
            {
                SubmitText(field.name, field.text);
            });
            field.onEndEdit = se;
        }
    }

    [SerializeField] Image image;
    [SerializeField] Sprite acceptSprite;
    [SerializeField] Sprite denySprite;
    [SerializeField] Button button;
    public void SubmitText(string prefKey, string prefVal)
    {
        if (!image.enabled) image.enabled = true;
        if (prefVal == otvet)
        {
            image.sprite = acceptSprite;
            image.color = Color.green;
            button.interactable = true;
        }
        else
        {
            image.sprite = denySprite;
            image.color = Color.red;
        }
    }
}
