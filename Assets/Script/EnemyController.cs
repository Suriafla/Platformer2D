using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private MeleeAttack meleeAtack;
    // Start is called before the first frame update
    void Start()
    {
        meleeAtack = GetComponent<MeleeAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        meleeAtack.Attack();
    }


}
