using FineGameDesign.Anagram;
using FineGameDesign.Text;
using FineGameDesign.UI;
using UnityEngine;
using UnityEngine.UI;

/// <remarks>
/// <see cref="BaseController"/> implemented in WordLink asset store package.
/// </remarks>
public class MapController : BaseController
{
    [SerializeField]
    private ScrollRect m_ScrollRect;

    [SerializeField]
    private Transform m_LevelsParent;

    [SerializeField]
    private LetterPositioner m_LetterPositioner;

    [SerializeField]
    private CharLevelInstantiator m_Instantiator;

    [SerializeField]
    private AnagramLevelsParser m_LevelsParser;

    /// <remarks>
    /// Snaps to child.
    /// Does not call <see cref="CUtils.ShowChildInScrollView"/> because that doesn't support nested children in scaled parents.
    /// </remarks>
    protected override void Start()
    {
        base.Start();

        m_LevelsParser.ParseLevels();
        AnagramLevelsController.instance.Levels = m_LevelsParser.Levels;

        m_LetterPositioner.ParseText();

        int levelIndex = Prefs.UnlockedLevel;
        m_Instantiator.Instantiate(levelIndex, m_LevelsParent, m_LetterPositioner.PrintableCharacters, m_LetterPositioner.LocalPositions);

        Transform levelTransform = ScrollRectSnapper.GetChild(m_LevelsParent, levelIndex);
        ScrollRectSnapper.SnapTo(m_ScrollRect, levelTransform);
    }
}
