using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : Singleton<SessionManager>
{
    Player player;

    public override void Awake()
    {
        base.Awake();

        if (player == null)
        {
            lock (_syncLock)
            {
                if (player == null)
                {
                    player = new Player();
                }
            }
        }
    }

    public int GetScore()
    {
        return player.Score;
    }

    public void AddScore(int value)
    {
        player.Score += value;
    }

    public void ResetScore()
    {
        player.Score = 0;
    }
}
