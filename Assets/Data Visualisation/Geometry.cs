//Introduction to Real-time Rendering and 3D Visualisation in Unity - 2021

/* These objects are based on the various objects that exist in out dataset.
   You can create as many objects as you like as long as the names and types match
   the corresponding objects in your JSON dataset and the following are true:
    - The classes do not derive from MonoBehaviour; they are plain c# classes
    - they have the System.Serializable attribute in square brackets as shown below
*/


[System.Serializable]
public class Geometry 
{
    public float[] coordinates;
}
