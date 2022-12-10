using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Selection : MonoBehaviour{

    public GameObject selectedBuilding;
    public AudioSource place_sound;
    private BoxCollider boundsTrigger;
    public GameObject place_particle;
    // Start is called before the first frame update.
    void Start(){
        boundsTrigger = GetComponent<BoxCollider>();
        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        int[] tris = new int[6]
               {
                    // lower left triangle
                    1, 0, 3,
                    // upper right triangle
                    0, 3, 2
               };
        mesh.triangles = tris;
    }

    // Update is called once per frame.
    void Update(){

        var cam = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(cam, out hit, 100.0f, ~(1<<LayerMask.NameToLayer("BuildingBounds"))) && !IsPointerOverUIElement())
        {

            if(hit.collider.tag == "Map16"){

                //Vector3[] Hello = this.GetComponent<Mesh>().vertices;

                //this.transform.position = new Vector3((hit.point.x + 0.52f), 2.0f, (hit.point.z + 0.52f));
                //this.transform.position = new Vector3((Mathf.RoundToInt((hit.point.x + 0.5f)/2.0f)*2.0f), 2.0f, (Mathf.RoundToInt((hit.point.z + 0.5f)/2.0f)*2.0f));

                // Hello[0] = new Vector3(10.0f, 1.0f, 1.0f);

                LandScape landscape = hit.collider.GetComponentInParent<LandScape>();

                Vector3 pos = hit.point;
                int x = (int) Mathf.Round(pos.x / 2) * 2;
                int z = (int)Mathf.Round(pos.z / 2) * 2;


                //pos = new Vector3(x, 0, z);

                Mesh mesh = this.GetComponent<MeshFilter>().mesh;
                Vector3[] verts = mesh.vertices;
                Vector3[] tile_verts = landscape.GetTileVerts(hit.point.x,hit.point.z);

                Vector3 mid = Vector3.zero;
                float maxY = 0;
                if (tile_verts.Length >= 3)
                {
                    mid = (tile_verts[0] + tile_verts[3]) / 2;
                    this.transform.position = mid;
                }

                for (int i = 0; i < verts.Length; i++)
                {
                    // tile_verts[i].y = max_y;
                    verts[i] = this.transform.InverseTransformPoint(tile_verts[i]) + transform.up*.01f;
                }
                mesh.vertices = verts;
                mesh.RecalculateBounds();

                if (!selectedBuilding)
                {
                    return;
                }

                BuildingScript bs = selectedBuilding.GetComponent<BuildingScript>();
                if (!bs)
                {
                    bs = selectedBuilding.GetComponent<RoadScript>() as BuildingScript;
                }

                if (Input.GetMouseButtonDown(0)){
                    if(GameManager.gm.Money >= bs.cost)
                    {
                        if (landscape.PlaceTile(hit.point.x, hit.point.z, selectedBuilding))
                        {
                            GameManager.gm.Money -= bs.cost;
                            place_sound.Play();
                            Instantiate(place_particle, transform.position, Quaternion.identity);
                        }
                    }
                    
                }else if (Input.GetMouseButtonDown(2))
                {
                    landscape.RotateTile(hit.point.x, hit.point.z);
                }else if (Input.GetMouseButtonDown(1))
                {
                    landscape.DeleteTile(hit.point.x, hit.point.z);
                }

                

                

            }
        }
    }


    public bool IsPointerOverUIElement()
    {
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }

    private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.layer == LayerMask.NameToLayer("UI"))
                return true;
        }
        return false;
    }


    //Gets all event system raycast results of current mouse or touch position.
    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }



}
