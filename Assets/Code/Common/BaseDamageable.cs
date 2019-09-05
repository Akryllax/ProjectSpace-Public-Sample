using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An object that can be damaged and destroyed.
/// </summary>
public class BaseDamageable : MonoBehaviour
{
    private int m_health;
    private int m_maxHealth;
    private BaseDamageableState m_damageableState;

    public int CurrentHealth { get => m_health; }
    public int MaxHealth { get => m_maxHealth; }

    public BaseDamageableState DamageableState { get => m_damageableState; }

    public void Awake()
    {
        m_damageableState = BaseDamageableState.ALIVE;
        m_health = m_maxHealth;
    }

    public void TakeDamage(BaseDamagePacket damagePacket)
    {
        PreDamageProcessing(ref damagePacket);
        PostDamageProcessing(ref damagePacket);

        m_health += damagePacket.DamageValue;
        if(m_health <= 0)
        {
            m_health = 0;
            Kill();
        }
    }

    public void PreDamageProcessing(ref BaseDamagePacket damagePacket)
    {

    }

    public void PostDamageProcessing(ref BaseDamagePacket damagePacket)
    {

    }

    public void Kill()
    {
        this.m_health = 0;
        this.m_damageableState = BaseDamageableState.DEAD;
    }

    public void Heal(BaseDamagePacket damagePacket)
    {
        if(m_damageableState == BaseDamageableState.ALIVE)
        {
            PreDamageProcessing(ref damagePacket);
            PostDamageProcessing(ref damagePacket);

            m_health += damagePacket.DamageValue;

            if (m_health > m_maxHealth)
            {
                if(m_health >= m_maxHealth)
                {
                    m_health = m_maxHealth;
                }
            }
        }
    }

    public void SetMaxHealth(int MaxHealth)
    {
        m_maxHealth = MaxHealth;
    }

    public void SetCurrentHealth(int CurrentHealth)
    {
        m_health = CurrentHealth;
    }

    public void Reset()
    {
        m_damageableState = BaseDamageableState.ALIVE;
        m_health = 0;
        m_maxHealth = 0;
    }
}
