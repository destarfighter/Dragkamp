
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

    public const int maxHealth = 100;

    [SyncVar(hook = "OnChangeHealth")]
    public int currentHealth = maxHealth;
    public RectTransform healthBar;
    public bool DestroyOnDeath;

    private NetworkStartPosition[] spawnPoints;

    private void Start()
    {
        if (isLocalPlayer)
        {
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        }
    }

    public void TakeDamage(int amount)
    {
        if (!isServer) return;

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            if (DestroyOnDeath) Destroy(gameObject);
            else
            {
                currentHealth = maxHealth;
                RpcRespaw();
            }
        }
    }

    [ClientRpc]
    private void RpcRespaw()
    {
        if (isLocalPlayer)
        {
            // set the spawn point to origin as a default value
            Vector3 spawnPoint = Vector3.zero;

            // if there is a spawn point array and the array is not empty, pick a spawn point at random
            if (spawnPoints != null && spawnPoints.Length > 0)
            {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }

            // set the players position to the chosen spawn point
            transform.position = spawnPoint;
            
        }
    }

    private void OnChangeHealth(int currentHealth)
    {
        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);

    }
}
