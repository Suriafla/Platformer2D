using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class HeroTests
    {
        private HeroController heroController;
        [SetUp]
        public void Setup()
        {
            var heroClone = Object.Instantiate(Resources.Load("Prefabs/Wizard/Ellie")) as GameObject;
            heroClone.GetComponent<HeartsHUD>().enabled = false;
            heroController = heroClone.GetComponent<HeroController>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.Destroy(heroController.gameObject);
        }
        
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator Jump()
        {        
            Vector3 initialPos = heroController.transform.position;
            heroController.Jump();
            yield return new WaitForSeconds(0.3f);
            Assert.Greater(initialPos.y, heroController.transform.position.y);
        }
    }
}
