using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public DialogNode dialog;

    public void TriggerDialog()
    {
        DialogManager.Instance.StartDialog(dialog);
    }
}
