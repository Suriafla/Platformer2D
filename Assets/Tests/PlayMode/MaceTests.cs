using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MaceTests
    {

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator MoveMace()
        {
            var maceClone = Object.Instantiate(Resources.Load("Prefabs/Mace/Mace")) as GameObject;
            Vector3 initialPos = maceClone.transform.position; 
            yield return new WaitForSeconds(1f);
            Assert.AreNotEqual(initialPos, maceClone.transform.position);
            Object.Destroy(maceClone);
        }
    }
}
