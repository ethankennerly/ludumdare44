# Profile

Huawei Android phone BLA AO9.

## CPU: Scroll 30 ms, level complete 20 ms

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

