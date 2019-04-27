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

    /// <remarks>
    /// Snaps to child.
    /// Does not call <see cref="CUtils.ShowChildInScrollView"/> because that doesn't support nested children in scaled parents.
    /// </remarks>
    protected override void Start()
    {
        base.Start();

        Transform levelTransform = ScrollRectSnapper.GetChild(m_LevelsParent, Prefs.UnlockedLevel);
        ScrollRectSnapper.SnapTo(m_ScrollRect, levelTransform);
    }
}
