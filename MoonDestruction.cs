using Unity.Mathematics;
using UnityEngine;

public class MoonDestruction : MonoBehaviour
{
    
    public bool detonate = false;
    public GameObject moonDestruction;
    public GameObject[] moonParticles;
    public MeshRenderer moonMeshRenderer;

    private void Update(){

    }

    public void Detonate(){
        
        Instantiate(moonDestruction, transform);

        for(int i = 0; i < moonParticles.Length; i++){

            GameObject obj = Instantiate(moonParticles[i], transform.position, quaternion.identity);
            obj.transform.localScale = new Vector3(transform.lossyScale.x * obj.transform.localScale.x, transform.lossyScale.y * obj.transform.localScale.y, transform.lossyScale.z * obj.transform.localScale.z);

        }
 
        detonate = false;

        moonMeshRenderer.enabled = false;
    }
}
