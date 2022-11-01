using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Defines the landscapes avalible sizes.
 */
enum landScape_Sizes : int{
        
    LSSS = 0x10,
    LSSM = 0x20,
    LSSL = 0x40
}

/**
 * Start is called before the first frame update.
 */
public class LandScape2 : MonoBehaviour{

    /**
     * LandScape2 public attributes declaration.
     */
    public Mesh landScapeMesh;
    public byte size;

    /**
     * LandScape2 private attributes declaration.
     */
    private GameObject _map;

    /**
     * Start is called before the first frame update.
     */
    void Start(){

        /**
         * 
         */
        switch(this.size){
            
            //Creates the small map mesh.
            case((int)landScape_Sizes.LSSS):

                break;
            
            //If the size was not a valid size then exit the methoid.
            default:

                Debug.LogWarning("Invalid Generation Terrain size, failed to generation!");
                break;
        }
    }

    /**
     * Update is called once per frame.
     */
    void Update(){

       
    }
}
