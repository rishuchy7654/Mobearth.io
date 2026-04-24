using UnityEngine;

public class AdsManager : MonoBehaviour
{
    public static AdsManager Instance { get; private set; }

    [SerializeField] private bool testMode = true;
    [SerializeField] private string bannerAdUnitId = "ca-app-pub-3940256099942544/6300978111"; // Test ID
    [SerializeField] private string interstitialAdUnitId = "ca-app-pub-3940256099942544/1033173712"; // Test ID
    [SerializeField] private string rewardedAdUnitId = "ca-app-pub-3940256099942544/5224354917"; // Test ID

    private int interstitialLoadAttempts = 0;
    private int rewardedLoadAttempts = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InitializeMobileAds();
    }

    private void InitializeMobileAds()
    {
        Debug.Log("Mobile Ads initialized (Test Mode: " + testMode + ")");
        
        // In production, use:
        // GoogleMobileAds.Api.MobileAds.Initialize(initStatus => { });
        
        // For now, just log
        Debug.Log("AdMob ready for ads (Configure your Ad Unit IDs in AdsManager)");
    }

    public void ShowInterstitialAd()
    {
        if (testMode)
        {
            Debug.Log("[AD] Interstitial Ad would show here (Test Mode)");
            return;
        }
        
        Debug.Log("[AD] Showing Interstitial Ad");
        // Production code:
        // if (interstitialAd != null && interstitialAd.CanShowAd())
        // {
        //     interstitialAd.Show();
        //     LoadInterstitialAd();
        // }
    }

    public void ShowRewardedAd()
    {
        if (testMode)
        {
            Debug.Log("[AD] Rewarded Ad would show here (Test Mode)");
            OnRewardEarned();
            return;
        }
        
        Debug.Log("[AD] Showing Rewarded Ad");
        // Production code:
        // if (rewardedAd != null && rewardedAd.CanShowAd())
        // {
        //     rewardedAd.Show((Reward reward) =>
        //     {
        //         OnRewardEarned();
        //     });
        // }
    }

    private void OnRewardEarned()
    {
        GameManager.Instance.AddScore(500);
        Debug.Log("[AD] Reward earned: 500 points");
    }

    public void SetTestMode(bool enabled)
    {
        testMode = enabled;
    }
}
