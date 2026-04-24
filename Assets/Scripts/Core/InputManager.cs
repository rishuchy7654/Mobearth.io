using UnityEngine;

public enum ControlMode
{
    Tap,
    Swipe
}

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    [SerializeField] private ControlMode currentControlMode = ControlMode.Tap;
    [SerializeField] private float swipeThreshold = 50f;

    private Vector2 touchStartPos = Vector2.zero;
    private Vector2 touchEndPos = Vector2.zero;
    private bool isSwiping = false;

    public delegate void TapAction(Vector2 position);
    public delegate void SwipeAction(Vector2 direction);

    public event TapAction OnTap;
    public event SwipeAction OnSwipe;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadControlMode();
    }

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsPaused())
            return;

        HandleInput();
    }

    private void HandleInput()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        // Mouse input for testing
        if (Input.GetMouseButtonDown(0))
        {
            touchStartPos = Input.mousePosition;
            isSwiping = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            touchEndPos = Input.mousePosition;
            isSwiping = false;
            ProcessInput();
        }
#else
        // Mobile touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
                isSwiping = true;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                touchEndPos = touch.position;
                isSwiping = false;
                ProcessInput();
            }
        }
#endif
    }

    private void ProcessInput()
    {
        if (currentControlMode == ControlMode.Tap)
        {
            OnTap?.Invoke(touchStartPos);
        }
        else if (currentControlMode == ControlMode.Swipe)
        {
            Vector2 swipeDirection = touchEndPos - touchStartPos;
            if (swipeDirection.magnitude > swipeThreshold)
            {
                OnSwipe?.Invoke(swipeDirection.normalized);
            }
        }
    }

    public void SetControlMode(ControlMode mode)
    {
        currentControlMode = mode;
        SaveControlMode();
        Debug.Log($"Control mode changed to: {mode}");
    }

    public ControlMode GetControlMode() => currentControlMode;

    private void SaveControlMode()
    {
        PlayerPrefs.SetInt("ControlMode", (int)currentControlMode);
        PlayerPrefs.Save();
    }

    private void LoadControlMode()
    {
        if (PlayerPrefs.HasKey("ControlMode"))
        {
            currentControlMode = (ControlMode)PlayerPrefs.GetInt("ControlMode");
        }
    }
}
