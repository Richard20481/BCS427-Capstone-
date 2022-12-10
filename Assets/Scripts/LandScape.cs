
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



enum landScapeSizes{

    LS_SIZE_S = 0x10,
    LS_SIZE_M = 0x20,
    LS_SIZE_L = 0x40,
};

public class LandScape : MonoBehaviour{

    // //Google more about refferances types???
    // public float height = 1.0f;
    private GameObject _map;
    public int size;
    public byte height;

    [HideInInspector]
    public Vector3[] Hello;

    public GameObject gm_16;

    public GameObject[,] tileArray = new GameObject[16,16];
    public List<GameObject> tiles = new List<GameObject>();


    private int GenTerain(){

        int seed = Random.Range(-1000,1000);
        print("Generating Terrain...");

        //Varifys the map size is withing range.
        switch(this.size){

            case ((int)landScapeSizes.LS_SIZE_S):

                //Generation Terrain with no perlin noise being applyed...
                _map = Instantiate(this.gm_16, this.transform);
                
                // _map.transform.position = new Vector3(-1.0f, 0.5f, -1.0f);
                break;

            case ((int)landScapeSizes.LS_SIZE_M):

                break;

            case ((int)landScapeSizes.LS_SIZE_L):

                break;

            default:

                Debug.LogWarning("Invalid Generation Terrain size, failed to generation!");
                return -1;
        }

        //Generation Terrain perlin noise...
        //Also the Y and Z axis are switched!!!
        Hello = this._map.GetComponent<MeshFilter>().mesh.vertices;
        float tmp = 1.0f;

        /**
         *
         */
        print(Hello.Length);
        for (int i = 0; i < Hello.Length; i++){
           
            if (Hello[i].y > -.5f){
                tmp = (Mathf.PerlinNoise(Hello[i].x/16.0f + seed, Hello[i].z/16.0f + seed) * this.height);
                Hello[i] = new Vector3(Mathf.Round(Hello[i].x), Mathf.Round(tmp), Mathf.Round(Hello[i].z));
            }
        }

        
        /**
         * Sets the mesh changes.
         */
        this._map.GetComponent<MeshFilter>().mesh.vertices = Hello;
        
        this._map.GetComponent<MeshFilter>().mesh.RecalculateBounds();
        this._map.GetComponent<MeshFilter>().mesh.RecalculateNormals();

        this._map.GetComponent<MeshCollider>().sharedMesh = this._map.GetComponent<MeshFilter>().mesh;

        /**
         * Fixing normals. (not mine credit to robertbu).
         * https://answers.unity.com/questions/798510/flat-shading.html
         */
        // Vector3[] oldVerts = this._map.GetComponent<MeshFilter>().mesh.vertices;
        // int[] triangles = this._map.GetComponent<MeshFilter>().mesh.triangles;
        // Vector3[] vertices = new Vector3[triangles.Length];


        //Vector2[] uvs = new Vector2[triangles.Length];
        //uvs = this._map.GetComponent<MeshFilter>().mesh.uv;

        // for (int i = 0; i < triangles.Length; i++) {

        //     vertices[i] = oldVerts[triangles[i]];
        //     triangles[i] = i;
        // }

        // this._map.GetComponent<MeshFilter>().mesh.vertices = vertices;
        // this._map.GetComponent<MeshFilter>().mesh.triangles = triangles;

        // this._map.GetComponent<MeshFilter>().mesh.RecalculateBounds();
        // this._map.GetComponent<MeshFilter>().mesh.RecalculateNormals();

        // /**
        //  * Fixes the uv's
        //  */
        // Vector2[] uvs = this._map.GetComponent<MeshFilter>().mesh.uv;

        // for (int i = 0; i < uvs.Length; i++){

        //     //uvs[i] = new Vector2(vertices[i].x / 32.0f, vertices[i].z/32.0f);
        //     //uvs[i] = new Vector2(vertices[i].x, vertices[i].z);
        //     uvs[i] = new Vector2(vertices[i].x, vertices[i].z);
        // }

        //this._map.GetComponent<MeshFilter>().mesh.uv = uvs;
        return 0;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        for (int i = 0; i < Hello.Length; i++)
        {
            Gizmos.DrawSphere(Hello[i], 0.1f);
        }
    }

    public float GetPositionHeight(float x, float z)
    {
        Vector2Int coords = GetTileIndex(x, z);
        Vector3[] verts = this._map.GetComponent<MeshFilter>().mesh.vertices;

        int start_ind = coords.x + coords.y * 17;
        Vector3 a =  this._map.transform.TransformPoint(verts[start_ind + 17]) ; //a
        Vector3 b = this._map.transform.TransformPoint(verts[start_ind + 18]); //b
        Vector3 c = this._map.transform.TransformPoint(verts[start_ind + 1]);  //c
        Vector3 d = this._map.transform.TransformPoint(verts[start_ind + 0]);  //d

        Vector3 e = new Vector3(x, 0, z);

        float qa = (d.z - e.z) / (d.z - a.z) * a.y + (e.z - a.z) / (d.z - a.z) * d.y;
        float qb = (c.z - e.z) / (c.z - b.z) * b.y + (e.z - b.z) / (c.z - b.z) * c.y;
        float y = (b.x - e.x) / (b.x - a.x) * qa + (e.x - a.x) / (b.x - a.x) * qb;
        return y;
    }
    public Vector3[] GetTileVerts(float x, float z)
    {
        Vector2Int coords = GetTileIndex(x, z);

        // print(coords.x.ToString() + ", " + coords.y.ToString());
        Vector3[] verts = this._map.GetComponent<MeshFilter>().mesh.vertices;

        int start_ind = coords.x + coords.y * 17;
        Vector3 a = this._map.transform.TransformPoint(verts[start_ind + 0]); //a
        Vector3 b = this._map.transform.TransformPoint(verts[start_ind + 1]); //b
        Vector3 c = this._map.transform.TransformPoint(verts[start_ind + 17]);  //c
        Vector3 d = this._map.transform.TransformPoint(verts[start_ind + 18]);  //d
        
        return new Vector3[] {a,b,c,d};
    }

    public Vector2Int GetTileIndex(float x, float z)
    {
        int x_index = (int)(Mathf.Abs(15 - x) / 2.0f);
        int z_index = (int)(Mathf.Abs(15 - z) / 2.0f);
        x_index = Mathf.Clamp(x_index, 0, 15);
        z_index = Mathf.Clamp(z_index, 0, 15);

        return new Vector2Int((int)x_index, (int)z_index);
    }

    public void SpawnCar(GameObject spawn_building)
    {

        RoadScript spawn = NearestRoad(spawn_building);
        BuildingScript building = tiles[Random.Range(0, tiles.Count)].GetComponent<BuildingScript>();
        RoadScript dest = NearestRoad(building.gameObject);
        print(tiles.Count);
        if(spawn && dest && spawn != dest)
        {
            print("SPAWNED CAR!");
            spawn.SpawnCar(spawn_building.GetComponent<BuildingScript>().income + building.income, dest.transform.position);
        }
    }

    public RoadScript NearestRoad(GameObject building)
    {
        Vector2Int coords = GetTileIndex(building.transform.position.x, building.transform.position.z);
        if (IsRoad(coords.x, coords.y + 1) || IsRoad(coords.x, coords.y - 1) || IsRoad(coords.x - 1, coords.y) || IsRoad(coords.x + 1, coords.y))
        {
            print("THERE IS A ROAD!");
            for (int i = 0; i < 100; i++)
            {
                int x = 0 + (Random.Range(-1, 2));
                int y = 0 + (Random.Range(-1, 2));
                if(Mathf.Abs(x) + Mathf.Abs(y) == 2)
                {
                    continue;
                }

                if (IsRoad(coords.x + x, coords.y + y))
                {
                    return tileArray[coords.x + x, coords.y + y].GetComponent<RoadScript>();
                }


            }
        }
        return null;
    }

    public bool PlaceTile(float x, float z, GameObject tile)
    {
        Vector2Int coords = GetTileIndex(x, z);

        if (tileArray[coords.x, coords.y])
        {
            return false;
        }
        
        if (tile.tag.Equals("Building"))
        {
            Vector3[] tileVerts = GetTileVerts(x, z);
            float maxY = Mathf.Max(tileVerts[0].y, tileVerts[1].y, tileVerts[2].y, tileVerts[3].y);
            Vector3 mid = (tileVerts[0] + tileVerts[3]) / 2;
            mid.y = maxY + .1f;
            GameObject new_object = Instantiate(tile, mid, Quaternion.identity);

            tileArray[coords.x, coords.y] = new_object;
            BuildingScript bs = new_object.GetComponent<BuildingScript>();
            for (int i = 0; i < bs.demand; i++)
            {
                tiles.Add(new_object);
                
            }
            UpdatePop();
            return true;
        }else if (tile.tag.Equals("Road"))
        {
            Vector3[] tileVerts = GetTileVerts(x, z);
            Vector3 mid = (tileVerts[0] + tileVerts[3]) / 2;
            GameObject new_object = Instantiate(tile, mid, Quaternion.identity);
            RoadScript rs = new_object.GetComponent<RoadScript>();
            rs.UpdateMesh(this.gameObject);
            place_road(coords.x, coords.y, rs);
            
            return true;
        }
        return false;
    }
    private void UpdatePop()
    {
        int pop = 0;
        List<GameObject> list_pop = tiles.Distinct<GameObject>().ToList();
        for (int i = 0; i < list_pop.Count; i++)
        {
            pop+= list_pop[i].GetComponent<BuildingScript>().population;
        }
        GameManager.gm.SetPop(pop);
    }
    private void place_road(int x, int y, RoadScript road)
    {

        tileArray[x,y] = road.gameObject;
        update_Road(x, y);
        UpdateNearRoads(x, y);

    }
    private void UpdateNearRoads(int x, int y)
    {
        
        update_Road(x + 1, y);
        update_Road(x - 1, y);
        update_Road(x, y - 1);
        update_Road(x, y + 1);
    }
    private void update_Road(int x, int y)
    {

        if (!IsRoad(x, y)) return;
        bool[] direction = new bool[] { IsRoad(x, y - 1), IsRoad(x, y + 1), IsRoad(x-1, y), IsRoad(x+1, y) };
        tileArray[x, y].GetComponent<RoadScript>().UpdateRoad(direction);


    }

    private bool IsRoad(int x, int y)
    {
        return (x < 0 || x > 15 || y < 0 || y > 15) || (!tileArray[x, y] || !tileArray[x, y].GetComponent<RoadScript>()) ? false : true;
    }
    public void RotateTile(float x, float z)
    {
        Vector2Int coords = GetTileIndex(x, z);
        GameObject selectedTile = tileArray[coords.x, coords.y];
        if (selectedTile)
        {
            selectedTile.transform.GetChild(0).Rotate(new Vector3(0,90,0), Space.World);
        }
    }

    public void DeleteTile(float x, float z)
    {
        Vector2Int coords = GetTileIndex(x, z);
        GameObject selectedTile = tileArray[coords.x, coords.y];
        if (selectedTile) {
            // tiles.Remove(selectedTile);
            tiles.RemoveAll(s => s == selectedTile);
            Destroy(selectedTile);
            tileArray[coords.x, coords.y] = null;
            UpdateNearRoads(coords.x, coords.y);
            UpdatePop();
        }
    }

    /**
     * Start is called before the first frame update.
     */
    void Start(){

        //Terminal output...
        print("Landscape Script Version 7.0");
        this.GenTerain();
    }

    /**
     * Update is called once per frame.
     */
    void Update(){

    }
}
