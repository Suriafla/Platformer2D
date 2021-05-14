using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlatformTests
    {

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator MovePlatform()
        {

            GameObject platform = new GameObject();
            platform.AddComponent<PlatformMovements>();
            //enemy.AddComponent<Rigidbody2D>();
            PlatformMovements platformMovements = platform.GetComponent<PlatformMovements>();
            float initialHorizontalPosition = platform.transform.position.x;
            ///platformMovements.MoveHorizontal(3);

            yield return new WaitForSeconds(1f);
            Assert.AreNotEqual(initialHorizontalPosition, platform.transform.position.x);

            // Object.Destroy(mace);
        }
    }
}
