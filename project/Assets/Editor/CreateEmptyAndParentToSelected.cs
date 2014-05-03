using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor ( typeof( Transform ) )]
[CanEditMultipleObjects]
public class CreateEmptyAndParentToSelected : NGUITransformInspector
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		//write label
		EditorGUILayout.BeginHorizontal();

			GUILayout.FlexibleSpace();

			if ( GUILayout.Button( new GUIContent( "Create Empty to Object", "Creates empty child object" ), GUILayout.Width( 200 ) ) )
			{
				foreach ( Object target in targets )
					Parent( target as Transform, new GameObject( "GameObject" ) );
			}

			GUILayout.FlexibleSpace();
		EditorGUILayout.EndHorizontal();

	}

	[MenuItem( "Custom/Create Empty And Parent %&n" )]
	static public void CreateAndParent()
	{
		if ( Selection.activeTransform == null )
			return;

		foreach( Transform selected in Selection.transforms )
			Parent( selected, new GameObject( "GameObject" ) );
	}

	[MenuItem( "CONTEXT/Transform/Parent Empty" )]
	static public void CreateAndParentContext( MenuCommand command )
	{
		Parent( command.context as Transform, new GameObject( "GameObject" ) );
	}

	static void Parent( Transform target, GameObject go )
	{
		Transform trans = go.transform;

		trans.parent = target;

		trans.localPosition = Vector3.zero;
		trans.localScale    = Vector3.one;

		go.layer = target.gameObject.layer;
	}
}
