using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square {

    public MeshNode tlPoint;
    public MeshNode trPoint;
    public MeshNode brPoint;
    public MeshNode blPoint;

    public int x;
    public int y;

    public Square (Vector3 bl, Vector3 br, Vector3 tl, Vector3 tr, int MapX, int MapY) {
      tlPoint = new MeshNode (tl);
      trPoint = new MeshNode (tr);
      brPoint = new MeshNode (br);
      blPoint = new MeshNode (bl);

      x = MapX;
      y = MapY;
    }
}
