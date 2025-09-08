using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using TMPro;

using Obj = UnityEngine.Object;
using UIImage = UnityEngine.UI.Image;

public class CounterPlayModeTests
{
    private GameObject root;
    private Submit submit;
    private Button button;
    private TextMeshProUGUI countText;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        root = new GameObject("UITestRoot_PlayMode");

        // Canvas
        var canvasGO = new GameObject("Canvas",
            typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
        canvasGO.transform.SetParent(root.transform, false);
        var canvas = canvasGO.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        // TMP Text
        var textGO = new GameObject("CountText", typeof(RectTransform));
        textGO.transform.SetParent(canvasGO.transform, false);
        countText = textGO.AddComponent<TextMeshProUGUI>();
        countText.text = "0";

        // Button
        var btnGO = new GameObject("SubmitButton", typeof(RectTransform));
        btnGO.transform.SetParent(canvasGO.transform, false);
        btnGO.AddComponent<UIImage>();
        button = btnGO.AddComponent<Button>();

        // Submit
        submit = btnGO.AddComponent<Submit>();
        submit.button = button;
        submit.text = countText;

        
        yield return null;
    }

    [UnityTearDown]
    public IEnumerator TearDown()
    {
        if (root != null) Obj.Destroy(root);
        yield return null; 
    }

    [UnityTest]
    public IEnumerator Button_Is_Interactable()
    {
        Assert.IsTrue(button.interactable);
        yield break;
    }

    [UnityTest]
    public IEnumerator Counter_Increases_On_Click()
    {
        button.onClick.Invoke();
        yield return null;
        Assert.AreEqual("1", countText.text);
    }

    [UnityTest]
    public IEnumerator Counter_Equals_10_After_Ten_Clicks()
    {
        for (int i = 0; i < 10; i++)
        {
            button.onClick.Invoke();
            yield return null;
        }
        Assert.AreEqual("10", countText.text);
    }

    [UnityTest]
    public IEnumerator Button_Disabled_After_Ten_Clicks()
    {
        for (int i = 0; i < 10; i++)
        {
            button.onClick.Invoke();
            yield return null;
        }
        Assert.IsFalse(button.interactable);
    }
}
