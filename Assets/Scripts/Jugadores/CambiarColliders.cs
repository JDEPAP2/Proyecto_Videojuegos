using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarColliders : MonoBehaviour
{
    public GameObject evaO;
    public SkinnedMeshRenderer sEva, sAdan, sCrrnt;
    public Animator aCrrnt;
    public RuntimeAnimatorController aEva, aAdan;
    public Avatar vEva, vAdan;
    public Mesh eva, adan;
    public MeshCollider colliderP;

    [System.Obsolete]
    void Update()
    {
        if (evaO.active)
        {
            colliderP.sharedMesh = eva;
            sCrrnt = sEva;
            aCrrnt.runtimeAnimatorController = aEva;
            aCrrnt.avatar = vEva;
            
        }
        else
        {
            colliderP.sharedMesh = adan;
            sCrrnt = sAdan;
            aCrrnt.runtimeAnimatorController = aAdan;
            aCrrnt.avatar = vAdan;
        }
    }

}
