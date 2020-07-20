using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{

    List<Vector3> vertices =  new List<Vector3>();
    List<int> triangles = new List<int>();
    List<Square> meshSquares = new List<Square>();
    public float scale = 1;
    public float zPos;

    public MapGenerator mapComponent;
    // Start is called before the first frame update

    void Start() {
      for (int x = 0; x < mapComponent.width; x ++) {
        for (int y = 0; y < mapComponent.height; y ++) {
          if (mapComponent.map[x,y] == 1) {
            ConfigureSquare(x, y);
          }
        }
      }


      Mesh mesh = new Mesh();
  		GetComponent<MeshFilter>().mesh = mesh;

  		mesh.vertices = vertices.ToArray();
  		mesh.triangles = triangles.ToArray();
  		mesh.RecalculateNormals();

    }

    void ConfigureSquare (int x, int y) {
      float width = -(float)mapComponent.width/2;
      float height = -(float)mapComponent.height/2;
      Vector2 worldPos = new Vector2(width + (float)x + 0.5f, height + (float)y + 0.5f);

      List<Vector3> currentSquarePoints = new List<Vector3>();
      Vector3 bl = new Vector3(worldPos.x - scale/2, worldPos.y - scale/2, zPos);
      Vector3 br = new Vector3(worldPos.x + scale/2, worldPos.y - scale/2, zPos);
      Vector3 tl = new Vector3(worldPos.x - scale/2, worldPos.y + scale/2, zPos);
      Vector3 tr = new Vector3(worldPos.x + scale/2, worldPos.y + scale/2, zPos);
      currentSquarePoints.Add(tl);
      currentSquarePoints.Add(tr);
      currentSquarePoints.Add(br);
      currentSquarePoints.Add(bl);

      foreach (Vector3 point in currentSquarePoints) {
        if (!vertices.Contains(point)) {
          vertices.Add(point);
        }
      }
      Square currentSquare = new Square(bl,br,tl,tr,x,y);
      meshSquares.Add(currentSquare);

      ConfigureTriangle(currentSquare.tlPoint, currentSquare.trPoint, currentSquare.brPoint, currentSquare.blPoint);

    }

    void ConfigureTriangle (params MeshNode[] points) {
      AssignVertices(points);

      CreateTriangle(points[0], points[1], points[2]);
			CreateTriangle(points[0], points[2], points[3]);

    }
    void AssignVertices(MeshNode[] points) {
  		for (int i = 0; i < points.Length; i ++) {
  			if (points[i].vertexIndex == -1) {
  				points[i].vertexIndex = vertices.Count;
  				vertices.Add(points[i].position);
  			}
  		}
  	}

    void CreateTriangle(MeshNode a, MeshNode b, MeshNode c) {
      triangles.Add(a.vertexIndex);
      triangles.Add(b.vertexIndex);
      triangles.Add(c.vertexIndex);
    }
}
