using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class HealthControllerTests
    {
        // A Test behaves as an ordinary method
        [UnityTest]
        public IEnumerator SetMaxHealthOnStart()
        {
            GameObject gameObject = new GameObject();
            HealthController healthController = gameObject.AddComponent<HealthController>();
            yield return null;
            Assert.AreEqual(healthController.MaxHealth, healthController.CurrentHealth);
            Object.Destroy(gameObject);
        }
        [UnityTest]
        public IEnumerator CurrentHealthNonNegative()
        {
            GameObject gameObject = new GameObject();
            gameObject.AddComponent<HealthController>();
            HealthController healthController = gameObject.GetComponent<HealthController>();
            yield return null;
            healthController.HealthChange(-(healthController.MaxHealth + 1));
            Assert.Zero(healthController.CurrentHealth);
        }
    }
}



