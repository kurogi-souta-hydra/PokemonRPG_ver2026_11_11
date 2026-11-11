using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MainCameraAspect : MonoBehaviour
{
    private Camera cam;

    // 追加：前回の画面サイズを保存
    private int previousWidth;
    private int previousHeight;

    void Awake()
    {
        cam = GetComponent<Camera>();
        AdjustCamera();
    }

    // 追加：画面サイズの変化を監視
    void Update()
    {
        if (Screen.width != previousWidth ||
            Screen.height != previousHeight)
        {
            AdjustCamera();
        }
    }

    void AdjustCamera()
    {
        // 追加：現在の画面サイズを記録
        previousWidth = Screen.width;
        previousHeight = Screen.height;

        float targetAspect = 16f / 9f;
        float screenAspect = (float)Screen.width / Screen.height;

        if (screenAspect > targetAspect)
        {
            float width = targetAspect / screenAspect;
            cam.rect = new Rect((1f - width) / 2f, 0f, width, 1f);
        }
        else
        {
            float height = screenAspect / targetAspect;
            cam.rect = new Rect(0f, (1f - height) / 2f, 1f, height);
        }
    }
}
