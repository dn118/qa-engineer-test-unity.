using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Submit : MonoBehaviour
{
    [Header("References")]
    public Button button;
    public TMP_Text text;

    private int counter = 0;
    private const int Limit = 10;

    private void Start()
    {
        if (button == null || text == null)
        {
            UnityEngine.Debug.LogError($"[Submit] Missing refs: button={button}, text={text}");
            return;
        }

        button.onClick.AddListener(TaskOnClick);
        UpdateUI();
    }

    private void TaskOnClick()
    {
        if (counter >= Limit) return;

        counter++;

        if (counter >= Limit)
            button.interactable = false;

        UpdateUI();
    }

    private void UpdateUI()
    {
        text.text = counter.ToString();
    }
}
