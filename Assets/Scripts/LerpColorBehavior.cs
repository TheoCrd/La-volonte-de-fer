using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using VRBuilder.Core;
using VRBuilder.Core.Attributes;
using VRBuilder.Core.Behaviors;
using VRBuilder.Core.SceneObjects;

[DataContract(IsReference = true)]

public class LerpColorData : IBehaviorData
{
    [DataMember]
    public Color startColor;
    [DataMember]
    public Color endColor;
    [DataMember]
    public float duration;
    [DataMember][DisplayName("Target Renderer")]
    public SceneObjectReference target;

    Metadata IData.Metadata { get; set; }
    string INamedData.Name { get; set; }
}

public class LerpColorActivatingProcess : StageProcess<LerpColorData>
{
    public Renderer targetRenderer;
    public float timer;

    public LerpColorActivatingProcess(LerpColorData Data) : base(Data)
    {

    }

    public override void End()
    {
        targetRenderer.material.color = Data.endColor;
    }

    public override void FastForward()
    {
        throw new System.NotImplementedException();
    }

    public override void Start()
    {
        timer = 0;
        targetRenderer = Data.target.Value.GameObject.GetComponent<Renderer>();
        targetRenderer.material.color = Data.startColor;
    }

    public override IEnumerator Update()
    {
        while (timer < Data.duration)
        {
            float progress = timer / Data.duration;
            targetRenderer.material.color = Color.Lerp(Data.startColor, Data.endColor, progress);
            timer += Time.deltaTime;

            yield return null;
        }

    }
}

[DataContract(IsReference = true)]

public class LerpColorBehavior : Behavior<LerpColorData>
{
    public LerpColorBehavior()
    {
        
        Data.duration = 1;
        Data.startColor = Color.white;
        Data.startColor = Color.black;
        Data.target = new SceneObjectReference("");
    }

    public override IStageProcess GetActivatingProcess()
    {
        return new LerpColorActivatingProcess(Data);
    }
}
