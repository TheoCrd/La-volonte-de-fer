using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRBuilder.Core;
using VRBuilder.Core.Behaviors;
using VRBuilder.Editor;
using VRBuilder.Editor.UI.StepInspector.Menu;

public class LerpColorMenuItem : MenuItem<IBehavior>
{
    public override string DisplayedName { get; } = "Material/Lerp Color";

    public override IBehavior GetNewItem()
    {
        return new LerpColorBehavior();
    }
}
