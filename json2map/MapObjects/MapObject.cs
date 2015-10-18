using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Json2Map.MapObjects
{
	public class MapObject
	{
		private Rectangle rectangle;
		private string name;
		private string type;
		private float rotation;

		#region Properties
		public int X
		{
			get { return rectangle.X; }
			set { rectangle.X = value; }
		}

		public int Y
		{
			get { return rectangle.Y; }
			set { rectangle.Y = value; }
		}

		public int Width
		{
			get { return rectangle.Width; }
			set { rectangle.Width = value; }
		}

		public int Height
		{
			get { return rectangle.Height; }
			set { rectangle.Height = value; }
		}

		public Rectangle Rectangle
		{
			get { return rectangle; }
			set { rectangle = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string Type
		{
			get { return type; }
			set { type = value; }
		}

		public float Rotation
		{
			get { return rotation; }
			set { rotation = value; }
		}
		#endregion

		#region Constructors
		public MapObject()
		{
		}
		#endregion
	}
}
