
using UnityEngine;

public class Sunflower : Plant
{
    public float produceDuration = 5;
    private float produceTimer = 0;
    private Animator anim;
    public GameObject sunPrefab;

    public float jumpMinDistance = 0.3f;
    public float jumpMaxDistance = 1;
    private void Awake()
    {
        anim = GetComponent<Animator>(); 
    }
    protected override void EnableUpdate()
    {
        produceTimer += Time.deltaTime; 

        if (produceTimer > produceDuration) 
        {
            produceTimer = 0;
            anim.SetTrigger("IsGlowing");
        }
    }
    public void ProuduceSun()
    {
        GameObject go= GameObject.Instantiate(sunPrefab,transform.position,Quaternion.identity);

        float distance =  Random.Range(jumpMinDistance,jumpMaxDistance);
        //判断生成0和1之间的随机数是否小于1，如果是0取负数，否则取本身。
        distance= Random.Range(0, 2) < 1 ? -distance : distance;
        Vector3 position = transform.position;
        position.x += distance;

        go.GetComponent<Sun>().JumpTo(position);
    }
}
