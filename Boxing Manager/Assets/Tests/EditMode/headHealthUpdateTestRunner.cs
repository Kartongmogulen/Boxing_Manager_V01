using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class headHealthUpdateTestRunner
{
    // A Test behaves as an ordinary method
    [Test]
    public void reduceByOne()
    {
        int headH�althAfter = headHealthUpdate.updateHeadHealth(20, 1);

        Assert.AreEqual(19, headH�althAfter);
    }

    // A Test behaves as an ordinary method
    [Test]
    public void reduceByFive()
    {
        int headH�althAfter = headHealthUpdate.updateHeadHealth(20, 5);

        Assert.AreEqual(15, headH�althAfter);
    }

    // A Test behaves as an ordinary method
    [Test]
    public void ifNegativeSetToZero()
    {
        int headH�althAfter = headHealthUpdate.updateHeadHealth(1, 5);

        Assert.AreEqual(0, headH�althAfter);

    }

}
