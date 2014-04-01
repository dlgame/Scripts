namespace GameKits
{
	using UnityEngine;
	using System.Collections.Generic;
	
	[System.Serializable]
	public sealed class Unique
	{
		[SerializeField] 
		private string
			savedIdent = string.Empty;
		private System.Guid _ident = System.Guid.Empty;
		
		public System.Guid Value {
			get {
				if (_ident == System.Guid.Empty) {
					if (!string.IsNullOrEmpty (savedIdent)) {
						try {
							_ident = new System.Guid (savedIdent);
						} catch {
							_ident = System.Guid.Empty;
							savedIdent = _ident.ToString ("N");
						}
					}
				}
				return _ident;
			}
			
			set {
				_ident = value;
				savedIdent = _ident.ToString ("N");
			}
		}
		
		public bool IsEmpty {
			get {
				if (_ident == System.Guid.Empty) {
					if (!string.IsNullOrEmpty (savedIdent)) {
						try {
							_ident = new System.Guid (savedIdent);
						} catch {
							_ident = System.Guid.Empty;
							savedIdent = _ident.ToString ("N");
							return true;
						}
					}
					if (_ident == System.Guid.Empty)
						return true;
				}
				return false;
			}
		}
		
		public Unique ()
		{
		}
		
		public Unique (string id)
		{
			if (string.IsNullOrEmpty (id)) {
				_ident = System.Guid.Empty;
				savedIdent = _ident.ToString ("N");
			} else {
				try {
					savedIdent = id;
					_ident = new System.Guid (savedIdent);
				} catch {
					_ident = System.Guid.Empty;
					savedIdent = _ident.ToString ("N");
				}
			}
		}
		
		public static Unique Create ()
		{
			Unique id = new Unique ();
			id.GenerateId ();
			return id;
		}
		
		public static Unique Create (Unique id)
		{
			if (id == null) {
				id = new Unique ();
				id.GenerateId ();
			} else {
				if (id.IsEmpty)
					id.GenerateId ();
			}
			return id;
		}
		
		private void GenerateId ()
		{
			_ident = System.Guid.NewGuid ();
			savedIdent = _ident.ToString ("N");
		}
		
		public Unique Copy ()
		{
			Unique id = new Unique ();
			id.Value = this.Value;
			return id;
		}
		
		public static bool operator == (Unique a, Unique b)
		{
			if (System.Object.ReferenceEquals (a, b))
				return true;
			
			if (((object)a == null) || ((object)b == null))
				return false;
			
			return a.Value == b.Value;
		}
		
		public static bool operator != (Unique a, Unique b)
		{
			return !(a == b);
		}
		
		public override bool Equals (object obj)
		{
			if (obj == null)
				return false;
			
			Unique p = obj as Unique;
			if ((System.Object)p == null)
				return false;
			
			return Value == p.Value;
		}
		
		public bool Equals (Unique guid)
		{
			if ((object)guid == null)
				return false;
			
			return Value == guid.Value;
		}
		
		public override int GetHashCode ()
		{
			byte[] _bytes = Value.ToByteArray ();
			return ((int)_bytes [0]) | ((int)_bytes [1] << 8) | ((int)_bytes [2] << 16) | ((int)_bytes [3] << 24);
		}
		
		public override string ToString ()
		{
			return savedIdent;
		}
		
		public static bool ListContains (List<Unique> list, Unique id)
		{
			for (int i = 0; i < list.Count; i++) {
				if (list [i] == id)
					return true;
			}
			return false;
		}
	}
}
