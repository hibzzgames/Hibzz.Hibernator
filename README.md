# Hibzz.Hibernator
 A library used to create low performant idle applications in Unity

### Installation
**Via NPM**
This package is published to the NPM registery, so users can install and get updates directly in the Unity Package Manager when the package is installed via NPM.
- Navigate to the advanced project settings menu in the Unity Package Manager
- Create a new scoped registry with the URL `https://registry.npmjs.org`
- Add `com.hibzz.hibernator` as scope
- Now you'll be able to view and install the package under the "My Registeries" in the Package Manager.

**Via Github**
This package can be installed in the Unity Package Manager using the following git URL.
```
https://github.com/Hibzz-Games/Hibzz.Hibernator.git
```

### Usage
Initializing the Hibernator
```c#
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

Refreshing Graphics
```c#
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
