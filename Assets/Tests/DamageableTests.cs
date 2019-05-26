using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class DamageableTests
    {

        GameObject goOrigin = new GameObject();
        GameObject goTarget = new GameObject();
        BaseDamageable damageable;

        public void Damageable_Setup()
        {
            if(!damageable)
            {
                damageable = goTarget.AddComponent<BaseDamageable>();
            }
            damageable.Reset();

            damageable.Awake();
        }
        
        [Test]
        public void Damageable_TestInit()
        {
            Damageable_Setup();

            // Use the Assert class to test conditions
            //Damageable is initialized
            Assert.AreEqual(0, damageable.MaxHealth);
            Assert.AreEqual(BaseDamageableState.ALIVE, damageable.DamageableState);
            Assert.AreEqual(0, damageable.CurrentHealth);
        }

        [Test]
        public void Damageable_SetParams_Ok()
        {
            Damageable_Setup();

            //Set max health but don't heal
            damageable.SetMaxHealth(100);
            Assert.AreEqual(0, damageable.CurrentHealth);
            Assert.AreEqual(100, damageable.MaxHealth);

            //Set current health
            damageable.SetCurrentHealth(100);
            Assert.AreEqual(100, damageable.CurrentHealth);
        }

        [Test]
        public void Damageable_DoHeal()
        {
            Damageable_Setup();

            damageable.SetMaxHealth(100);
            damageable.SetCurrentHealth(1);

            //Do heal
            BaseDamagePacket healPacket = new BaseDamagePacket();
            healPacket.DamageValue = 76;
            healPacket.Origin = goOrigin;
            damageable.Heal(healPacket);

            Assert.AreEqual(77, damageable.CurrentHealth);
            Assert.AreEqual(100, damageable.MaxHealth);
        }

        [Test]
        public void Damageable_DoHeal_Overflow()
        {
            Damageable_Setup();

            damageable.SetMaxHealth(100);
            damageable.SetCurrentHealth(1);

            //Do heal
            BaseDamagePacket healPacket = new BaseDamagePacket();
            healPacket.DamageValue = 9999;
            healPacket.Origin = goOrigin;
            damageable.Heal(healPacket);

            Assert.AreEqual(100, damageable.CurrentHealth);
            Assert.AreEqual(100, damageable.MaxHealth);
        }

        [Test]
        public void DamageableTakeDamge_Simple_Ok()
        {
            Damageable_Setup();

            //Change health ammount
            damageable.SetCurrentHealth(100);
            damageable.SetMaxHealth(100);

            //Do some damage
            BaseDamagePacket packet = new BaseDamagePacket();
            packet.DamageValue = -15;
            packet.Origin = goOrigin;

            damageable.TakeDamage(packet);
            Assert.AreEqual(85, damageable.CurrentHealth);
        }

        [Test]
        public void DamageableTakeDamge_Simple_Overflow()
        {
            Damageable_Setup();

            //Change health ammount
            damageable.SetCurrentHealth(100);
            damageable.SetMaxHealth(100);

            //Do some damage
            BaseDamagePacket packet = new BaseDamagePacket();
            packet.DamageValue = -9999;
            packet.Origin = goOrigin;

            damageable.TakeDamage(packet);
            Assert.AreEqual(0, damageable.CurrentHealth);
            Assert.AreEqual(BaseDamageableState.DEAD, damageable.DamageableState);
        }
    }
}
