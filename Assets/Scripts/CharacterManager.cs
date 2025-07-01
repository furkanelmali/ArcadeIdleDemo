using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private Vector3 direction;
    private Camera camera;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Plane plane = new Plane(Vector3.up, transform.position);
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if(plane.Raycast(ray,out var distance))
                 direction = ray.GetPoint(distance);
            
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(direction.x,0f,direction.z),speed * Time.deltaTime);
            var offset = direction - transform.position;

            if(offset.magnitude > 1f)
                transform.LookAt(direction);
        }
    }
}
