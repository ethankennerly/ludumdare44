using FineGameDesign.UI;
using UnityEngine;
using UnityEngine.UI;

public class MapController : BaseController
{
    [SerializeField]
    private ScrollRect m_ScrollRect;

    protected override void Start()
    {
        base.Start();

        ScrollRectSnapper.SnapToChild(m_ScrollRect, Prefs.UnlockedLevel);
    }
}
