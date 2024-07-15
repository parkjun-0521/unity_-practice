using UnityEngine;

public class GameManager : MonoSingleton3<GameManager>
{
    public int score;
    public string playerName;

    public void IncreaseScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }

    public override void Init()
    {
        base.Init();
        Debug.Log("GameManager initialized");
        score = 0;
    }

    // 여기에 GameManager의 초기화 및 관리 로직 추가
}
