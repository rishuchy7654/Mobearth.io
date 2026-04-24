using UnityEngine;

public static class GameConstants
{
    public const string PLAYER_TAG = "Player";
    public const string ENEMY_TAG = "Enemy";
    public const string POWERUP_TAG = "PowerUp";
    public const string GOAL_TAG = "Goal";

    public const int MAX_LEVELS = 10;
    public const int INITIAL_MOB_COUNT = 10;
    public const int ENEMY_DEFEAT_POINTS = 100;
    public const int LEVEL_COMPLETE_BONUS = 500;

    // Control modes
    public const int CONTROL_MODE_TAP = 0;
    public const int CONTROL_MODE_SWIPE = 1;
}
