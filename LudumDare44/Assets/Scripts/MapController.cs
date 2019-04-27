using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : BaseController {
    public ScrollRect scrollRect;
    public Transform levelContent;

    protected override void Start()
    {
        base.Start();

        CUtils.ShowChildInScrollView(scrollRect, Prefs.UnlockedLevel, levelContent);
    }
}
