# Mobearth.io - Addictive Mob Control Game

🎮 An advanced casual mobile game where you control massive crowds with intuitive tap and swipe controls. Addictive gameplay with monetization through ads.

## ⚡ Quick Start

1. **Clone the repo:**
   ```bash
   git clone https://github.com/rishuchy7654/Mobearth.io.git
   cd Mobearth.io
   ```

2. **Open in Unity:**
   - Open Unity Hub → Open Project → Select Mobearth.io folder
   - Unity 2022 LTS or higher required

3. **Play:**
   - Open `Scenes/MainMenu.unity`
   - Press Play button in Unity
   - Tap to move mob, collect power-ups, complete levels!

## 🎮 Game Features

### Core Gameplay
- 🎯 **Dual Control System**: Toggle between TAP and SWIPE controls in settings
- 👥 **Mob Control Mechanics**: Lead and command large crowds
- 📈 **Level Progression**: 10 levels with increasing difficulty
- ⭐ **Score System**: Track scores and beat high scores
- ⚡ **Power-ups**: Speed boost, health, damage, mob multiplier, shield

### Advanced Features
- 🧑 **5 Unique Characters**: Commander, Warrior, Scout, Tank, Wizard
- 🏆 **5 Different Environments**: City, Forest, Ice Palace, Desert, Volcano
- 🔫 **5 Weapon Types**: Gun, Net, Shield, Freeze, Lightning
- 👾 **Enemy Types**: Soldiers, Civilians, Zombies, Robots
- 💪 **Boss Battles**: Epic boss fights every 10 levels
- 🎨 **Character Customization**: Unlock and customize characters

### Monetization
- 📺 **Ads Between Levels**: Generate revenue after each level
- 🎁 **Reward Video Ads**: Watch ads to unlock rewards
- 💰 **In-App Purchases**: Buy premium characters and weapons

## 📁 Project Structure

```
Assets/
├── Scripts/
│   ├── Core/
│   │   ├── GameManager.cs          (Game state, level progression, scoring)
│   │   ├── InputManager.cs         (TAP/SWIPE input handling)
│   │   └── SceneLoader.cs          (Scene management)
│   ├── Game/
│   │   ├── MobController.cs        (Mob movement and control)
│   │   ├── Character.cs            (Character system)
│   │   ├── PowerUp.cs              (Power-up mechanics)
│   │   ├── Weapon.cs               (Weapon system)
│   │   ├── Enemy.cs                (Enemy behavior)
│   │   └── LevelManager.cs         (Level-specific logic)
│   ├── UI/
│   │   ├── UIManager.cs            (UI updates)
│   │   ├── SettingsPanel.cs        (Settings menu)
│   │   ├── GameOverScreen.cs       (Game over UI)
│   │   └── MainMenuUI.cs           (Main menu)
│   ├── Ads/
│   │   └── AdsManager.cs           (AdMob integration)
│   └── Utils/
│       ├── AudioManager.cs         (Audio management)
│       └── Constants.cs            (Game constants)
├── Prefabs/
│   ├── Characters/
│   ├── Mobs/
│   ├── Weapons/
│   ├── PowerUps/
│   └── UI/
├── Scenes/
│   ├── MainMenu.unity
│   ├── Level_1.unity
│   ├── Level_2.unity
│   ├── Level_3.unity
│   ├── Level_4.unity
│   ├── Level_5.unity
│   ├── Level_6.unity
│   ├── Level_7.unity
│   ├── Level_8.unity
│   ├── Level_9.unity
│   └── Level_10.unity
├── Art/
│   ├── Characters/
│   ├── Environments/
│   ├── Weapons/
│   └── UI/
├── Audio/
│   ├── Music/
│   └── SFX/
└── Resources/
    └── GameConfig.asset
```

## 🎯 How to Play

### Controls
- **TAP Mode**: Click screen to move mob to that location
- **SWIPE Mode**: Swipe to set direction for mob movement
- Toggle between modes in settings

### Objective
- Lead your mob to the goal
- Defeat enemies
- Collect power-ups
- Complete level to progress
- Earn high score

## 🛠️ Setup Instructions

### Prerequisites
- Unity 2022 LTS or higher
- Android SDK (for building APK)
- Git

### Installation

1. **Clone Repository**
   ```bash
   git clone https://github.com/rishuchy7654/Mobearth.io.git
   cd Mobearth.io
   ```

2. **Open in Unity**
   - Unity Hub → Open Project → Select folder
   - Wait for project to load

3. **Install Dependencies** (Optional)
   - Window > TextMesh Pro > Import TMP Essential Resources
   - Package Manager: Search for "Google Mobile Ads" and install

4. **Configure AdMob** (For Ads)
   - Create account at https://admob.google.com
   - Get Ad Unit IDs
   - Update in `Assets/Scripts/Ads/AdsManager.cs`

5. **Play!**
   - Open `Scenes/MainMenu.unity`
   - Press Play ▶️

## 🏗️ Building for Android

### Step 1: Setup Signing
```
Edit > Project Settings > Player > Android > Publishing Settings
- Create new Keystore
- Set passwords
```

### Step 2: Build Settings
```
File > Build Settings
- Select Android platform
- Player Settings:
  - Company: Mobearth
  - Product: Mobearth.io
  - Package: com.mobearth.io
  - Target API: 34+
  - Min API: 24
```

### Step 3: Build APK
```
File > Build Settings > Android > Build APK
OR
File > Build Settings > Android > Build App Bundle (for Play Store)
```

## 📊 Game Progression

| Level | Difficulty | Objective | Reward |
|-------|-----------|-----------|--------|
| 1-5 | Easy | Reach goal, defeat 5 enemies | Basic weapons |
| 6-10 | Medium | Dodge obstacles, defeat 10 enemies | New character |
| 11-20 | Hard | Boss battles, complex paths | Premium weapon |
| 21+ | Expert | Multiple bosses, time limits | Exclusive character |

## 💰 Monetization Strategy

- **Interstitial Ads**: After every 2-3 levels
- **Rewarded Ads**: For extra lives, power-up multipliers, level skips
- **In-App Purchases**: Premium characters, weapon bundles

## 🤝 Contributing

Contributions are welcome! Fork the repo and create a pull request.

## 📝 License

Proprietary - All rights reserved © 2025 Mobearth

## 📧 Support

For issues or questions:
- GitHub Issues: https://github.com/rishuchy7654/Mobearth.io/issues
- Email: rishuchy7654@gmail.com

## 🚀 Roadmap

- [x] Core mob control mechanics
- [x] Character system
- [x] Weapon system
- [x] Power-up system
- [x] Level progression (10 levels)
- [x] Score system
- [x] Input management (tap/swipe)
- [ ] AdMob integration (configure your IDs)
- [ ] Boss levels
- [ ] Multiplayer features
- [ ] Seasonal events

## 📞 Quick Links

- [Setup Guide](Documentation/SETUP.md)
- [Game Design Document](Documentation/GAME_DESIGN.md)
- [Build Instructions](Documentation/BUILD_GUIDE.md)
- [Troubleshooting](Documentation/TROUBLESHOOTING.md)

---

**Status**: Ready to Play & Deploy 🚀

**Latest Version**: 1.0.0

**Last Updated**: April 2026
