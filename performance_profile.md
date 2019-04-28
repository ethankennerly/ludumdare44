# Profile

Huawei Android phone BLA AO9.

## Editor CPU: Reload Main 160 ms, fade out 60 ms

Windows editor:

- 100 ms `EarlyUpdate.UpdatePreloading`: Load Main scene second time.
    - `Preload Single Step`
- 60 ms `WordRegion.CheckAnswer`
    - `TextPreview.FadeOut`
        - `iTween.ValueTo`
            - `iTween.Launch`
                - `CryptoConfig.LoadConfig`
                    - `SmallXmlParser.ReadContent`
- 40 ms `MainController.Start`: Load Main scene second time.
- 20 ms `WordRegion.Load`
    - 9 ms `LineWord.Build`
        - 6 ms `Object.Instantiate`
- 5 ms `Utils.Load`
    - 5 ms `Resources.Load`: Level asset?

## CPU: Scroll 30 ms, level complete 20 ms on April 20, 2019

- 30 ms Scroll level select:
    - 20 ms UGUI.Rendering.UpdateBatches
        - 8 ms Canvas.BuildBatch
    - 5 ms EventSystem.Updatea
    - 5 ms CanvasRenderer.SyncTransform + SyncWorldRect + SyncClipRect: in 1466 calls.
- 20 ms Level complete:
    - 15 ms ScreenFader.DoTask
    - Canvas.WillSendRenderCanvases: Layout: 16.4 KB garbage.

Solution:
1. [ ] Page 23 level select screens. Currently all laid out in scene.
1. [ ] Pool 720 level select buttons.
1. [ ] Put sprites in an atlas.
1. [ ] Redo level select layout in world, without canvas.
1. [ ] Pool level complete.

## CPU: Single-threaded 10 ms on April 20, 2019 at 8 am

- 10 ms Rendering

Solution:
1. [x] Build Settings: Multithreaded rendering.

