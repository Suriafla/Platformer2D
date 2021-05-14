using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TeleportTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void CheckPointTeleport()
        {
            // Use the Assert class to test conditions
            GameObject gameObject = new GameObject();
            Teleport teleport = gameObject.AddComponent<Teleport>();
            Vector3 point = teleport.PointTeleport;

            Assert.AreEqual(point, new Vector3(158, 29, 0));
        }

    }
}
