using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using dm_graph.nodes;
using dm_graph.nodes.components;

public class TestNodes
{
    [Test]
    public void TestBaseNode()
    {
        dm_graph.nodes.BaseNode baseNode = new dm_graph.nodes.BaseNode("Test Base Node");
        Assert.AreEqual(baseNode.GetName(), "Test Base Node");
        baseNode.SetName("Test Base Node 2");
        Assert.AreEqual(baseNode.GetName(), "Test Base Node 2");

        Assert.AreEqual(baseNode.GetNotes(), "");
        baseNode.SetNotes("These are test notes");
        Assert.AreEqual(baseNode.GetNotes(), "These are test notes");
    }

    [Test]
    public void TestGetComponents()
    {
        BaseNode baseNode = new BaseNode("Test Base Node");
        Assert.Null(baseNode.GetComponent<LocationComponent>());

        LocationNode locationNode = new LocationNode("Test Location Node");
        Assert.Null(locationNode.GetComponent<AlignmentComponent>());
        Assert.Null(locationNode.GetComponent<NodeComponentBase>());
        Assert.NotNull(locationNode.GetComponent<LocationComponent>());

        Assert.IsTrue(locationNode.HasComponent(typeof(LocationComponent)));

        ActorNode actorNode = new ActorNode("Test Actor Node");
        Assert.NotNull(actorNode.GetComponent<AlignmentComponent>());
        Assert.NotNull(actorNode.GetComponent<LocationComponent>());

        var actorNodeAlignment = actorNode.GetComponent<AlignmentComponent>();
        Assert.AreEqual(actorNodeAlignment.GetAlignment(), Alignment.TRUE_NEUTRAL);
        actorNodeAlignment.SetAlignment(Alignment.CHAOTIC_EVIL);
        Assert.AreEqual(actorNodeAlignment.GetAlignment(), Alignment.CHAOTIC_EVIL);
    }

    [Test]
    public void TestLocationComponent()
    {
        LocationNode locationNode = new LocationNode("Test Location Node");
        LocationComponent locationComponent = locationNode.GetComponent<LocationComponent>();
        Assert.NotNull(locationComponent);

        Map map1 = new ("Test Map 1");
        Map map2 = new ("Test Map 2");

        locationComponent.SetPosition(map1, new Vector2(0.0f, 0.0f));
        {
            var (isInMap, position) = locationComponent.GetPosition(map1);
            Assert.IsTrue(isInMap);
            Assert.AreEqual(position, new Vector2(0.0f, 0.0f));
        }
        {
            var (isInMap, position) = locationComponent.GetPosition(map2);
            Assert.IsFalse(isInMap);
        }
    }

    // // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // // `yield return null;` to skip a frame.
    // [UnityTest]
    // public IEnumerator NewTestScriptWithEnumeratorPasses()
    // {
    //     // Use the Assert class to test conditions.
    //     // Use yield to skip a frame.
    //     yield return null;
    // }
}
