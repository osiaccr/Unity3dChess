using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ComponentCopier {

	// This is needed to create a ghost copy of the pice, without having to deal with the create_New_Marker (..) bugging out
	// Credit where credit is due: https://answers.unity.com/questions/458207/copy-a-component-at-runtime.html

	public static Component CopyComponent(Component original, GameObject destination) {
		System.Type type = original.GetType();
		Component copy = destination.AddComponent(type);
		// Copied fields can be restricted with BindingFlags
		System.Reflection.FieldInfo[] fields = type.GetFields(); 
		foreach (System.Reflection.FieldInfo field in fields)
		{
			field.SetValue(copy, field.GetValue(original));
		}
		return copy;

	}
	// End

}
