using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class LevelButton : MonoBehaviour
{
    public Sprite passed;
    public Image image;

    [SerializeField]
    private TMP_Text m_LevelNumberText;
    public TMP_Text LevelNumberText
    {
        get { return m_LevelNumberText; }
    }

    public int LevelIndex { get; set; }

    public void OnButtonClick()
    {
        Prefs.CurrentLevel = LevelIndex;
        CUtils.LoadScene(2, true);
    }
}
