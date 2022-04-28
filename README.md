# Hibzz.Hibernator
 A library used to create low performant idle applications in Unity

### Usage
```c#
// Initializing the Hibernator
using Hibzz.Hibernator;

public class GameManager : MonoBehavior
{
    void start()
    {
        // How long (in seconds) should the system wait for refresh while hibernating? Here we wait for an hour!
        Hibernator.Instance.RenderFrequency = 3600.0f; 

        // Start the system
        Hibernator.Instance.Begin();
    }

    void OnDestroy()
    {
        // Stop the system
        Hibernator.Instance.Stop();
    }
}
```

```c#
// Refreshing graphics
using Hibzz.Hibernator;

public class RotateClass : MonoBehavior
{
    public float speed = 50.0f;

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            transform.Rotate(Vector3.up, speed * Time.DeltaTime);
            Hibernator.Instance.Refresh(); // Requests the graphics system to be updated
        }
    }
}
```

### Optional Features
While refreshing the hibernator, users can optionally give a time and the system will keep refreshing for the given time. This time is scalable by Time.TimeScale.

```c#
// the hibernator will continue to run with max refresh rate for the next 4.5 seconds
Hibernator.Instance.Refresh(4.5f);
```
