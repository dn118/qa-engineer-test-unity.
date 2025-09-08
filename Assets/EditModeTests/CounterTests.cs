using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using Obj = UnityEngine.Object;

public class CounterTests
{
    private GameObject go;
    private Button button;
    private TMP_Text tmpText;
    private Submit submit;

    [SetUp]
    public void Setup()
    {
        go = new GameObject("SubmitController_EditMode");
        button = go.AddComponent<Button>();
        tmpText = go.AddComponent<TextMeshProUGUI>();
        submit = go.AddComponent<Submit>();

        submit.button = button;
        submit.text = tmpText;

        
        typeof(Submit).GetMethod("Start", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .Invoke(submit, null);
    }

    [TearDown]
    public void TearDown()
    {
        if (go) Obj.DestroyImmediate(go);
    }

    [Test]
    public void Button_Is_Interactable()
    {
        Assert.IsTrue(button.interactable);
    }

    [Test]
    public void Counter_Increases_On_Click()
    {
        button.onClick.Invoke();
        Assert.AreEqual("1", tmpText.text);
    }

    [Test]
    public void Counter_Equals_10_After_Ten_Clicks()
    {
        for (int i = 0; i < 10; i++) button.onClick.Invoke();
        Assert.AreEqual("10", tmpText.text);
    }

    [Test]
    public void Button_Disabled_After_Ten_Clicks()
    {
        for (int i = 0; i < 10; i++) button.onClick.Invoke();
        Assert.IsFalse(button.interactable);
    }
}
