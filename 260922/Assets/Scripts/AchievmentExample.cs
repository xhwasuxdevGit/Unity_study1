using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AchievmentExample : MonoBehaviour
{
    private HashSet<string> _achievements = new HashSet<string>();

    private void Start()
    {
        AddAchievements();
        CheckAchivements();
        RemoveAchievements();
    }

    private void AddAchievements()
    {
        bool isFirstAdded = _achievements.Add("첫 처치");
        bool isBossAdded = _achievements.Add("보스 처치");
        bool isAddedAgain = _achievements.Add("첫 처치");
        Debug.Log($"AchievmentExample: 첫 처치 {isFirstAdded}, 보스 처치 {isBossAdded}, 첫 처치 다시 {isAddedAgain}");
        Debug.Log($"AchievmentExample: 모은 업적 {_achievements.Count}개");
    }

    private void CheckAchivements()
    {
        bool hasBoss = _achievements.Contains("보스 처치");
        bool hasLegend = _achievements.Contains("전설 무기 획득");
        Debug.Log($"AchievmentExample: 보스 처치 있음 {hasBoss}, 전설 무기 획득 있음 {hasLegend}");
    }

    private void RemoveAchievements()
    {
        bool isRemoved = _achievements.Remove("첫 처치");
        Debug.Log($"AchievmentExample: 첫 처치 지우기 {isRemoved}, 남은 업적 {_achievements.Count}개");
    }
}
