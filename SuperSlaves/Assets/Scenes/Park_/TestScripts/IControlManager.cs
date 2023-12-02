using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControlManager
{
    void SetComboTimer();

    void ResetCombo();

    IEnumerator ResetComboTimer();
}
