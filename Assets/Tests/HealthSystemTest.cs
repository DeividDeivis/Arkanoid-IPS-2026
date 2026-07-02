using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HealthSystemTest
{
    private HealthSystem healthSystem;

    [SetUp]
    public void SetUp()
    {
        healthSystem = new HealthSystem(3);
    }

    [Test]
    public void SetHealthTest()
    {
        healthSystem = new HealthSystem(1);
        Assert.AreEqual(1, healthSystem.Health);
    }

    [Test]
    public void RemoveHealthTest()
    {
        healthSystem.SubstractHealth();
        Assert.AreEqual(2, healthSystem.Health);
    }

    [Test]
    public void ResetHealthTest()
    {
        healthSystem = new HealthSystem(1);
        healthSystem.SubstractHealth();
        healthSystem.ResetHealth();
        Assert.AreEqual(1, healthSystem.Health);
    }

    [Test]
    public void NegativeHealthTest()
    {
        healthSystem = new HealthSystem(1);
        healthSystem.SubstractHealth();
        Assert.AreEqual(0, healthSystem.Health);
    }
}

public class PointSystemTest
{
    private PointSystem pointSystem;

    [SetUp]
    public void SetUp()
    {
        pointSystem = new PointSystem(10);
    }

    [Test]
    public void AddPointsTest()
    {
        pointSystem.AddPoints(1);
        Assert.AreEqual(1, pointSystem.CurrentPoints);
    }

    [Test]
    public void RemovePointsTest()
    {
        pointSystem.AddPoints(-1);
        Assert.AreEqual(0, pointSystem.CurrentPoints);
    }

    [Test]
    public void ResetPointsTest()
    {
        pointSystem.AddPoints(10);
        pointSystem.ResetPoint();
        Assert.AreEqual(0, pointSystem.CurrentPoints);
    }

    [Test]
    public void NegativePointTest()
    {
        pointSystem = new PointSystem(1);
        pointSystem.AddPoints(-10);
        Assert.AreEqual(0, pointSystem.CurrentPoints);
    }
}