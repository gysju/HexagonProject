using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class Hexa : MonoBehaviour
{
    public const float OUTER_RADIUS = 1.0f;
    public const float INNER_RADIUS = 0.866025404f;

    public static Vector3 Corner_UP = new Vector3( 0.0f, 0.0f, OUTER_RADIUS);
    public static Vector3 Corner_UP_LEFT = new Vector3( -INNER_RADIUS, 0.0f, 0.5f * OUTER_RADIUS);
    public static Vector3 Corner_UP_RIGHT = new Vector3( INNER_RADIUS, 0.0f, 0.5f * OUTER_RADIUS);

    public static Vector3 Corner_DOWN = new Vector3(0.0f, 0.0f, -OUTER_RADIUS);
    public static Vector3 Corner_DOWN_LEFT = new Vector3(-INNER_RADIUS, 0.0f, -0.5f * OUTER_RADIUS);
    public static Vector3 Corner_DOWN_RIGHT = new Vector3(INNER_RADIUS, 0.0f, -0.5f * OUTER_RADIUS);

    [SerializeField] Shader _s;
    Mesh _m;
    MeshFilter _mf;
    MeshRenderer _mr;

    List<Vector3> _vertices = new List<Vector3>();
    List<int> _triangles = new List<int>();

    private void Awake()
    {
        _mr = GetComponent<MeshRenderer>();
        if (_mr == null)
            _mr = gameObject.AddComponent<MeshRenderer>();

        _mf = GetComponent<MeshFilter>();
        if (_mf == null)
            _mf = gameObject.AddComponent<MeshFilter>();

        if (_s == null)
            Debug.LogError("No shader !");
    }

    void Start ()
    {
        generateMesh();	
	}

    void generateMesh()
    {        
        _m = new Mesh();

        generateTriangle( transform.position, transform.position + Corner_UP_RIGHT, transform.position + Corner_DOWN_RIGHT);
        generateTriangle( transform.position, transform.position + Corner_DOWN_RIGHT, transform.position + Corner_DOWN);
        generateTriangle( transform.position, transform.position + Corner_DOWN, transform.position + Corner_DOWN_LEFT);
        generateTriangle(transform.position, transform.position + Corner_DOWN_LEFT, transform.position + Corner_UP_LEFT);
        generateTriangle(transform.position, transform.position + Corner_UP_LEFT, transform.position + Corner_UP);
        generateTriangle(transform.position, transform.position + Corner_UP, transform.position + Corner_UP_RIGHT);

        _m.vertices = _vertices.ToArray();
        _m.triangles = _triangles.ToArray();

        _mf.mesh = _m;
        if (_mr.material == null && _s != null)
            _mr.material = new Material(_s);
    }

    void generateTriangle( Vector3 v1, Vector3 v2, Vector3 v3)
    {
        int verticesCount = _vertices.Count;

        _vertices.Add( v1 );
        _vertices.Add( v2 );
        _vertices.Add( v3 );

        _triangles.Add(verticesCount);
        _triangles.Add(verticesCount + 1);
        _triangles.Add(verticesCount + 2);
    }
}
