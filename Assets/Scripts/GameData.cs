using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameData
{
    public virtual void Start() {}

   public abstract void Tick();
}
