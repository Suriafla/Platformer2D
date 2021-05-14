using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class LowerBound    {
        // A Test behaves as an ordinary method
        [Test]
        public void CheckPointTeleport()
        {
            // Use the Assert class to test conditions
            GameObject gameObject = new GameObject();
            HeroController lowerBound = gameObject.AddComponent<HeroController>();
            float point = lowerBound.BottomOfMap;
            Assert.AreEqual(point, 5f);
        }

    }
}
