namespace GameKits
{
	using UnityEngine;
	using System.Collections;

	public enum VariableType
	{
		Bool,
		Int,
		Float,
		String,
		Rect,
		Color,
		Vector2,
		Vector3,
		GameObject,
		UnityObject,
		SystemObject
	}
	
	[ System.Serializable ]
	public sealed class BaseVariable
	{
		[ SerializeField ]
		private Unique
			id;
		[ SerializeField ]
		private string
			name = string.Empty;
		[ SerializeField ]
		private VariableType
			type = VariableType.String;
		[ SerializeField ]
		private bool
			boolVar;
		[ SerializeField ]
		private Color
			colorVar;
		[ SerializeField ]
		private float
			floatVar;
		[ SerializeField ]
		public GameObject
			gameObjectVar;
		[ SerializeField ]
		private int
			intVar;
		[ SerializeField ]
		private string
			stringVar = string.Empty;
		[ SerializeField ]
		private Rect
			rectVar;
		[ SerializeField ]
		public object
			objectVar;
		[ SerializeField ]
		public Object
			ObjectVar;
		[ SerializeField ]
		private Vector2
			v2Var;
		[ SerializeField ]
		private Vector3
			v3Var;
		
		public BaseVariable ()
		{
			id = Unique.Create ();
		}
		
		public string Name {
			get{ return this.name; }
			set{ this.name = value; }
		}
		
		public Unique Id {
			get{ return this.id; }
			set{ this.id = value; }
		}
		
		public VariableType Type {
			get{ return this.type; }
			set{ this.type = value; }
		}
		
		public void SetValue (object val)
		{
			if (val != null) {
				if (val.GetType () == typeof(bool)) {
					this.type = VariableType.Bool;
					this.boolVar = (bool)val;
					return;
				}
				if (val.GetType () == typeof(int)) {
					this.type = VariableType.Int;
					this.intVar = (int)val;
					return;
				}
				if (val.GetType () == typeof(float)) {
					this.type = VariableType.Float;
					this.floatVar = (float)val;
					return;
				}
				if (val.GetType () == typeof(string)) {
					this.type = VariableType.String;
					this.stringVar = (string)val;
					return;
				}
				if (val.GetType () == typeof(Rect)) {
					this.type = VariableType.Rect;
					this.rectVar = (Rect)val;
					return;
				}
				if (val.GetType () == typeof(Color)) {
					this.type = VariableType.Color;
					this.colorVar = (Color)val;
					return;
				}
				if (val.GetType () == typeof(Vector2)) {
					this.type = VariableType.Vector2;
					this.v2Var = (Vector2)val;
					return;
				}
				if (val.GetType () == typeof(Vector3)) {
					this.type = VariableType.Vector3;
					this.v3Var = (Vector3)val;
					return;
				}
				if (val.GetType () == typeof(GameObject)) {
					this.type = VariableType.GameObject;
					this.gameObjectVar = (GameObject)val;
					return;
				}
				if (typeof(Object).IsAssignableFrom (val.GetType ())) {
					this.type = VariableType.UnityObject;
					this.ObjectVar = (Object)val;
					return;
				}
			}
			
			this.type = VariableType.SystemObject;
			this.objectVar = val;
		}
		
		public object GetValue ()
		{
			switch (this.type) {
			case VariableType.Bool:
				return this.boolVar;
			case VariableType.Int:
				return this.intVar;
			case VariableType.Float:
				return this.floatVar;
			case VariableType.String:
				return this.stringVar;
			case VariableType.Rect:
				return this.rectVar;
			case VariableType.Color:
				return this.colorVar;
			case VariableType.Vector2:
				return this.v2Var;
			case VariableType.Vector3:
				return this.v3Var;
			case VariableType.GameObject:
				return this.gameObjectVar;
			case VariableType.UnityObject:
				return this.ObjectVar;
			case VariableType.SystemObject:
				return this.objectVar;
			}
			return null;
		}
		
		public BaseVariable Copy ()
		{
			BaseVariable var = new BaseVariable ();
			var.name = this.name;
			var.type = this.type;
			
			switch (this.type) {
			case VariableType.Bool:
				var.boolVar = this.boolVar;
				return var;
			case VariableType.Int:
				var.intVar = this.intVar;
				return var;
			case VariableType.Float:
				var.floatVar = this.floatVar;
				return var;
			case VariableType.String:
				var.stringVar = this.stringVar;
				return var;
			case VariableType.Rect:
				var.rectVar = this.rectVar;
				return var;
			case VariableType.Color:
				var.colorVar = this.colorVar;
				return var;
			case VariableType.Vector2:
				var.v2Var = this.v2Var;
				return var;
			case VariableType.Vector3:
				var.v3Var = this.v3Var;
				return var;
			case VariableType.GameObject:
				var.gameObjectVar = this.gameObjectVar;
				return var;
			case VariableType.UnityObject:
				var.ObjectVar = this.ObjectVar;
				return var;
			case VariableType.SystemObject:
				var.objectVar = this.objectVar;
				return var;
			}
			return var;
		}
		
		public override string ToString ()
		{
			switch (this.type) {
			case VariableType.Bool:
				return this.boolVar.ToString ();
			case VariableType.Int:
				return this.intVar.ToString ();
			case VariableType.Float:
				return this.floatVar.ToString ();
			case VariableType.String:
				return this.stringVar.ToString ();
			case VariableType.Rect:
				return this.rectVar.ToString ();
			case VariableType.Color:
				return this.colorVar.ToString ();
			case VariableType.Vector2:
				return this.v2Var.ToString ();
			case VariableType.Vector3:
				return this.v3Var.ToString ();
			case VariableType.GameObject:
				return this.gameObjectVar == null ? string.Empty : this.gameObjectVar.ToString ();
			case VariableType.UnityObject:
				return this.ObjectVar == null ? string.Empty : this.ObjectVar.ToString ();
			case VariableType.SystemObject:
				return this.objectVar == null ? string.Empty : this.objectVar.ToString ();
			}
			return "";
		}
		
	}
}

