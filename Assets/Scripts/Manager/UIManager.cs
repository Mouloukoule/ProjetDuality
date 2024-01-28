using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] PlayerStatsComponent playerStats = null;
    [SerializeField] PlayerHealthBarUI playerHealthBarUI = null;
    [SerializeField] PlayerEnergyBarUI playerEnergyBarUI = null;
    [SerializeField] PlayerStatsUI playerStatsUI = null;
    [SerializeField] PlayedTimerUI playerPlayedTimerUI = null;
    [SerializeField] DeathPopupUI deathPopupUI = null;
    [SerializeField] WaveStatusUI waveStatusUI = null;


    public PlayerHealthBarUI PlayerHealthBarUI => playerHealthBarUI;
    public PlayerEnergyBarUI PlayerEnergyBarUI => playerEnergyBarUI;
    public PlayerStatsUI PlayerStatsUI => playerStatsUI;
    public PlayedTimerUI PlayedTimerUI => playerPlayedTimerUI;
    public DeathPopupUI DeathPopupUI => deathPopupUI;
    public WaveStatusUI WaveStatusUI => waveStatusUI;





    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Init()
    {
        playerStats.OnEnergyUpdated += PlayerEnergyBarUI.UpdatePlayerEnergySlider;
        playerStats.OnEnergyUpdated += PlayerEnergyBarUI.SetPlayerEnergyText;
        playerStats.OnHpUpdated += PlayerHealthBarUI.UpdatePlayerHealthSlider;
        playerStats.OnHpUpdated += PlayerHealthBarUI.SetPlayerHealthText;
        playerStats.OnDeath += DeathPopupUI.UpdateVisibility;
        playerStats.OnMoveSpeedUpdated += UIManager.Instance.PlayerStatsUI.SetPlayerMoveSpeedText;
        playerStats.OnAttackSpeedUpdated += UIManager.Instance.PlayerStatsUI.SetPlayerAttackSpeedText;
    }
}
