using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshNode {
		public Vector3 position;
		public int vertexIndex = -1;

		public MeshNode(Vector3 _pos) {
			position = _pos;
		}
}
