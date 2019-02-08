using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlatform : IActivatable
{
    void Activate(ForkType type);

    void DeActivate(ForkType type);

}
