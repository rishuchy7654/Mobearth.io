# Mobearth.io - Complete Setup & Installation Guide

## 📥 Quick Clone & Setup (5 minutes)

### Step 1: Clone Repository
```bash
git clone https://github.com/rishuchy7654/Mobearth.io.git
cd Mobearth.io
```

### Step 2: Open in Unity
1. **Open Unity Hub**
2. Click **"Open Project"**
3. Select the `Mobearth.io` folder
4. Wait for import (2-3 minutes)
5. Open `Assets/Scenes/MainMenu.unity`

### Step 3: Play the Game
- **Click Play ▶️** in Unity Editor
- Tap on screen to move mob
- Defeat enemies
- Reach the goal to complete level

---

## 🎮 Testing in Editor

### Play Controls
- **Left Mouse Click** = Tap to move mob
- **Drag Mouse** = Swipe to set direction (if swipe mode enabled)

### Test Gameplay
1. Open any Level scene
2. Press Play
3. Click screen to move mob
4. Collect power-ups
5. Defeat enemies
6. Reach goal marker

---

## 📱 Building for Android

### Prerequisites
- Android SDK installed
- JDK 11+ installed
- Signing keystore (create or use existing)

### Step 1: Configure Player Settings
```
Edit > Project Settings > Player > Android

1. Company Name: Mobearth
2. Product Name: Mobearth.io
3. Package Name: com.mobearth.io
4. Target API Level: 34 (Android 14)
5. Minimum API Level: 24 (Android 7.0)
6. Architecture: ARM64 (Required)
7. Graphics: OpenGL ES 3
```

### Step 2: Create Signing Keystore
```
Edit > Project Settings > Player > Android > Publishing Settings

- Click "Create new" Keystore
- Keystore password: [your-strong-password]
- Key Alias: mobearth
- Key password: [your-strong-password]
- Validity: 25 years
- Certificate info: Fill with your details
```

### Step 3: Build APK/AAB

**For Testing (APK):**
```
File > Build Settings
- Select Android
- Click "Build"
- Output: mobearth-release.apk
- Install on device via adb:
  adb install mobearth-release.apk
```

**For Play Store (AAB):**
```
File > Build Settings
- Select Android
- Check "Build App Bundle"
- Click "Build"
- Output: mobearth-release.aab
```

---

## 🎨 Customizing the Game

### Adding New Levels

1. **Create New Scene**
   ```
   File > New Scene > 3D
   Save as: Assets/Scenes/Level_11.unity
   ```

2. **Setup Level**
   - Create ground plane
   - Place goal marker (blue cube)
   - Spawn enemies
   - Add power-ups

3. **Add Level Manager**
   - Add empty GameObject "LevelManager"
   - Add LevelManager.cs component
   - Configure:
     - Enemy Count
     - Power-up Count
     - Level Bounds

4. **Update GameManager**
   - Edit `GameManager.cs`
   - Update `MAX_LEVELS` constant

### Changing Game Properties

**In GameManager.cs:**
```csharp
[SerializeField] private int initialMobCount = 10; // Change mob count
[SerializeField] private float mobSpeed = 5f;      // Change mob speed
```

**In MobController.cs:**
```csharp
[SerializeField] private float mobSpeed = 5f;              // Mob movement speed
[SerializeField] private float rotationSpeed = 5f;         // Mob turning speed
[SerializeField] private int initialMobCount = 10;         // Starting mob count
```

**In Enemy.cs:**
```csharp
[SerializeField] private float speed = 5f;                 // Enemy movement speed
[SerializeField] private float detectionRange = 10f;       // When to start chasing
[SerializeField] private float attackRange = 2f;           // When to attack
```

---

## 🔊 Adding Audio

### Setup Audio Sources

1. **Create AudioManager**
   - Add GameObject: "AudioManager"
   - Add AudioManager.cs script

2. **Add Audio Sources**
   - Drag AudioManager to make child
   - Add two AudioSource components
   - Assign clips in inspector

3. **Assign Audio Clips**
   ```
   Background Music: Assets/Audio/Music/bgm.mp3
   Collect Sound: Assets/Audio/SFX/collect.wav
   Hit Sound: Assets/Audio/SFX/hit.wav
   Level Up Sound: Assets/Audio/SFX/levelup.wav
   ```

---

## 📺 Configuring AdMob

### Step 1: Create AdMob Account
1. Go to https://admob.google.com
2. Sign in with Google account
3. Add your app
4. Create ad units:
   - Banner ad unit
   - Interstitial ad unit  
   - Rewarded ad unit

### Step 2: Get Ad Unit IDs
- Copy your Ad Unit IDs from AdMob console

### Step 3: Update AdsManager.cs
```csharp
[SerializeField] private string bannerAdUnitId = "YOUR_BANNER_ID";
[SerializeField] private string interstitialAdUnitId = "YOUR_INTERSTITIAL_ID";
[SerializeField] private string rewardedAdUnitId = "YOUR_REWARDED_ID";
```

### Step 4: Install Google Mobile Ads SDK
1. Download from: https://github.com/googleads/google-mobile-ads-sdk-unity
2. Extract and place in `Assets/GoogleMobileAds`
3. Import into project

---

## 🐛 Troubleshooting

### Game Won't Start
- Check all scenes are named correctly (Level_1, Level_2, etc.)
- Verify GameManager is in scene
- Check InputManager is created
- Look at Console for error messages

### No Controls Working
- Verify InputManager exists in scene
- Check EventSystem in scene (Canvas > EventSystem)
- Test with mouse clicks in editor

### Build Fails
- Update Target API Level
- Check Android SDK is installed
- Verify Java JDK 11+ installed
- Clear Library folder and rebuild

### Performance Issues
- Reduce enemy count in LevelManager
- Reduce mob count in GameManager
- Disable particle effects temporarily
- Check Profiler: Window > Analysis > Profiler

### Ads Not Showing
- Verify Ad Unit IDs are correct
- Check testMode is false in production
- Ensure GoogleMobileAds SDK is installed
- Check device is connected to internet

---

## 📊 Performance Optimization

### Graphics Settings
1. Edit > Project Settings > Quality
2. Set appropriate quality level
3. Disable unnecessary effects for mobile

### Build Optimization
1. File > Build Settings > Player Settings
2. Graphics: OpenGL ES 3
3. Stripping Level: Aggressive
4. Disable unused modules

---

## 🚀 Publishing Checklist

Before publishing to Play Store:

- [ ] All 10 levels completed
- [ ] All UI screens implemented
- [ ] Ads configured with real Ad Unit IDs
- [ ] Audio implemented
- [ ] APK/AAB builds successfully
- [ ] Tested on multiple Android devices
- [ ] No errors in console
- [ ] High score system working
- [ ] Level progression working
- [ ] Privacy policy created and linked

---

## 📞 Support

For issues:
1. Check Console for errors: Window > General > Console
2. Review this guide
3. Check GitHub Issues
4. Contact: rishuchy7654@gmail.com

---

**Happy developing! 🎮**
