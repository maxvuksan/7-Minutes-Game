using Unity.Mathematics;
using UnityEngine;

public class MoonDestruction : MonoBehaviour
{
    
    public bool detonate = false;
    public GameObject moonDestruction;
    public GameObject moonParticles;

    private void Update(){

        if(Input.GetKeyDown(KeyCode.I)){
            Detonate();
        }
    }

    public void Detonate(){
        Instantiate(moonDestruction, transform);
        Instantiate(moonParticles, transform.position, quaternion.identity);
        detonate = false;
    }
}
