using UnityEngine;

public class Waypoints : MonoBehaviour
{
  public Transform GetPoint(Transform currentPoint)
  {
    if (currentPoint == null)
      return transform.GetChild(0);

    if (currentPoint.GetSiblingIndex() < transform.childCount - 1)
      return transform.GetChild(currentPoint.GetSiblingIndex() + 1);

    return null;
  }
}