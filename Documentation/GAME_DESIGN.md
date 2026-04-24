# Mobearth.io - Game Design Document

## 🎮 Core Concept

Mobearth.io is an **addictive casual mobile game** where players control massive crowds (mobs) through progressively challenging levels. The game combines **easy-to-learn** tap/swipe controls with **strategic gameplay** and **monetization through ads**.

**Target Audience:** Children and teenagers (3+)

---

## 📋 Gameplay Mechanics

### Control System

**TAP Mode:**
- Player taps screen to set destination
- Mob automatically moves to tapped location
- Perfect for younger players
- Intuitive point-and-click gameplay

**SWIPE Mode:**
- Player swipes to set movement direction
- Mob follows swiped direction
- More skill-based and action-oriented
- Better for experienced players

### Core Loop
1. **Start Level** → 2. **Control Mob** → 3. **Defeat Enemies** → 4. **Collect Power-ups** → 5. **Reach Goal** → 6. **Level Complete** → 7. **Watch Ad** → 8. **Next Level**

---

## 📈 Level Progression

### Level Difficulty Curve

| Levels | Name | Difficulty | Objectives | Rewards |
|--------|------|-----------|-----------|----------|
| 1-3 | Tutorial | Very Easy | Reach goal, no combat | Learn controls |
| 4-6 | Beginner | Easy | Defeat 5 enemies, reach goal | First power-ups |
| 7-9 | Intermediate | Medium | Defeat 10 enemies, obstacles | New characters unlock |
| 10 | Boss | Hard | Defeat boss enemy | Special reward |

### Current Implementation
- **10 Playable Levels** ready to use
- **Progressive difficulty** - more enemies and obstacles each level
- **Scaling rewards** - higher scores for harder levels
- **Boss battles** every 10 levels (Level 10 has boss)

---

## 👥 Characters

### Character Stats

| Character | Health | Speed | Damage | Special Ability | Unlock |
|-----------|--------|-------|--------|-----------------|--------|
| **Commander** | 100 | 5 | 10 | Standard control | Start |
| **Warrior** | 150 | 4 | 20 | Increased damage | Level 3 |
| **Scout** | 80 | 7 | 8 | Speed boost | Level 5 |
| **Tank** | 200 | 3 | 12 | Shield ability | Level 7 |
| **Wizard** | 90 | 5 | 25 | Magic attacks | Level 10 |

### Implementation
Each character is a prefab with:
- Character.cs component
- Customizable stats
- Unique abilities
- Visual appearance

---

## 🔫 Weapons System

### Weapon Types

| Weapon | Damage | Fire Rate | Range | Special | Cost |
|--------|--------|-----------|-------|---------|------|
| **Gun** | 10 | 1.5/sec | 20m | Standard | Free |
| **Net** | 5 | 1/sec | 15m | Stuns 2s | 100 coins |
| **Shield** | 0 | N/A | Self | Blocks damage 5s | 150 coins |
| **Freeze** | 0 | 1/sec | 18m | Freezes 3s | 200 coins |
| **Lightning** | 30 | 0.5/sec | AOE | Area damage | 300 coins |

### Weapon Mechanics
- Weapons.cs handles all weapon logic
- Projectile spawning and physics
- Damage calculation
- Cooldown/fire rate

---

## ⚡ Power-ups

### Power-up Types

| Type | Duration | Effect | Score |
|------|----------|--------|-------|
| **Speed Boost** | 10s | +50% movement speed | 50 pts |
| **Damage Boost** | 10s | +100% weapon damage | 75 pts |
| **Health Restore** | Instant | +50 health | 100 pts |
| **Mob Multiplier** | Permanent | +10 mobs | 150 pts |
| **Shield** | 5s | Block all damage | 200 pts |

### Spawn Rate
- ~3-5 power-ups per level
- Random locations
- Visual indicators
- Audio feedback on collection

---

## 👾 Enemy Types

### Enemy Stats

| Type | Health | Damage | Speed | Behavior | Points |
|------|--------|--------|-------|----------|--------|
| **Soldier** | 50 | 10 | 5 | Chases player | 100 pts |
| **Civilian** | 30 | 0 | 3 | Flees from player | 50 pts |
| **Zombie** | 80 | 15 | 3 | Slow but persistent | 150 pts |
| **Robot** | 100 | 20 | 6 | Strategic attacks | 200 pts |

### Enemy Behavior
- Detection range triggers chase
- Attack range for damage
- Death animation and score reward
- Respawn system (optional)

---

## 🏆 Scoring System

### Points Earned
```
Kill enemy:           100 points
Defeat boss:          500 points
Collect power-up:     50-200 points
Time bonus:           1 point per second remaining
Level completion:     500 points
Perfect level:        1000 bonus points
```

### Score Multipliers
- **Kill streak:** +1x per 5 kills (max 3x)
- **Power-up active:** +1.5x multiplier
- **Difficulty bonus:** Easy (1x), Normal (1.5x), Hard (2x)

### High Score System
- Saved locally using PlayerPrefs
- Persistent across sessions
- Displayed on main menu
- Achievement tracking

---

## 💰 Monetization Strategy

### Ad Placement

**Interstitial Ads:**
- Frequency: After every 2-3 levels
- Duration: 5-10 seconds
- Cannot skip
- Non-intrusive timing (between levels)

**Rewarded Ads:**
- Player watches to earn rewards
- Options:
  - Extra life (1 video)
  - 2x score multiplier (2 videos)
  - Level skip (3 videos)
  - Character unlock (5 videos)
  - 500 coins (1 video)

**Banner Ads:**
- Location: Bottom of screen (optional)
- Size: Standard banner (320x50)
- Always visible during gameplay

### In-App Purchases (Optional)
- Remove ads: $2.99
- Character bundle: $4.99
- Weapon bundle: $3.99
- Premium cosmetics: $0.99-$4.99

---

## 🏞️ Environments

### Level Themes

| Environment | Visual Style | Hazards | Enemies |
|-------------|-------------|---------|----------|
| **City** | Urban streets | Traffic, buildings | Soldiers |
| **Forest** | Nature setting | Trees, rocks | Zombies |
| **Ice Palace** | Icy terrain | Slippery surfaces | Robots |
| **Desert** | Sand dunes | Heat damage | Civilians |
| **Volcano** | Lava, eruptions | Lava pits | All types |

---

## 🎨 Visual & Audio Design

### Art Style
- **Casual cartoony** with **realistic enhancements**
- Colorful, appealing to all ages
- Simple shapes for optimization
- Smooth animations

### Sound Design
- **Background Music:** Energetic, looping
- **Sound Effects:**
  - Hit sounds (impact feedback)
  - Power-up chimes (collection)
  - Level complete fanfare
  - Enemy defeat sounds
- **Volume Control:** Settings panel

---

## 📊 Target Metrics

### Success Indicators
```
Daily Active Users (DAU):     10,000+
Monthly Active Users (MAU):   50,000+
Day 1 Retention:             40%+
Day 7 Retention:             15%+
Average Session Length:      10-15 minutes
Playtime per User:           30+ minutes/day
ARPU (Revenue per User):     $0.50-$1.00
Ads shown per session:       3-5 ads
```

---

## 🚀 Implementation Status

### ✅ Completed
- [x] Core gameplay mechanics
- [x] Input system (tap/swipe)
- [x] Character system
- [x] Enemy AI
- [x] Power-up system
- [x] Weapon system
- [x] Score system
- [x] Level progression
- [x] UI framework
- [x] Audio system
- [x] Ad system (template)
- [x] 10 playable levels

### 🔄 In Progress
- [ ] Graphics polish
- [ ] Level design refinement
- [ ] Performance optimization
- [ ] Additional content

### 📋 Future Features
- [ ] Multiplayer mode
- [ ] Seasonal events
- [ ] Tournament system
- [ ] Social features
- [ ] More levels (50+)
- [ ] New characters
- [ ] Story mode

---

## 🎯 Design Philosophy

1. **Easy to Learn, Hard to Master**
   - Simple controls
   - Progressive difficulty
   - Skill-based gameplay

2. **Highly Addictive**
   - Satisfying feedback
   - Progression rewards
   - Quick play sessions

3. **Family-Friendly**
   - Suitable for all ages
   - No violence or inappropriate content
   - Educational elements

4. **Monetization-Friendly**
   - Natural ad placements
   - Rewarding video ads
   - Optional purchases

---

## 📚 References

- Mob Control (Crowd Play)
- Snake Game
- Surf Riders
- Crowd City
- Holes.io

---

**Version:** 1.0
**Last Updated:** April 2026
**Status:** Ready for Production
