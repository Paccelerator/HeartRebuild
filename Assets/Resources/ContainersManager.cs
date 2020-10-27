using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "CreateContainers")]
public class ContainersManager : ScriptableObject
{
    public static ContainersManager GetContainersVars()
    {
        return Resources.Load<ContainersManager>("ContainersVars");
    }

    public Sprite[] processBar;
}
