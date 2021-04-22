using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class Util
{
	public static float AngleTowardsMouse(Vector3 pos)
	{
		var mousePos = Input.mousePosition;
		mousePos.z = 5.23f;

		var objectPos = Camera.main.WorldToScreenPoint(pos);
		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;

		return Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
	}
}
