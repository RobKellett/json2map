using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Json2Map.MapObjects
{
	public class MapObject
	{
		private int x;
		public int X
		{
			get { return x; }
			set { x = value; }
		}

		private int y;
		public int Y
		{
			get { return y; }
			set { y = value; }
		}

		private int width;
		public int Width
		{
			get { return width; }
			set { width = value; }
		}

		private int height;
		public int Height
		{
			get { return height; }
			set { height = value; }
		}

		private string name;
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private string type;
		public string Type
		{
			get { return type; }
			set { type = value; }
		}

		private float rotation;
		public float Rotation
		{
			get { return rotation; }
			set { rotation = value; }
		}

		
		public MapObject()
		{
		}
	}
}
