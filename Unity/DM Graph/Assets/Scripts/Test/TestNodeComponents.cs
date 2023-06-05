using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using dm_graph.nodes;
using dm_graph.nodes.components;

public class TestNodeComponents
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
        Assert.NotNull(locationNode.GetComponent<LocationComponent>());

        ActorNode actorNode = new ActorNode("Test Actor Node");
        Assert.NotNull(actorNode.GetComponent<AlignmentComponent>());
        Assert.NotNull(actorNode.GetComponent<LocationComponent>());

        var actorNodeAlignment = actorNode.GetComponent<AlignmentComponent>();
        Assert.AreEqual(actorNodeAlignment.GetAlignment(), Alignment.TRUE_NEUTRAL);
        actorNodeAlignment.SetAlignment(Alignment.CHAOTIC_EVIL);
        Assert.AreEqual(actorNodeAlignment.GetAlignment(), Alignment.CHAOTIC_EVIL);
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