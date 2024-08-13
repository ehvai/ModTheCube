using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    void Start()
    {
        float[] cubePosition = RandomizePositionCube();
        transform.position = new Vector3(cubePosition[0], cubePosition[1], cubePosition[2]);
        transform.localScale = Vector3.one * 2;

        Material material = Renderer.material;
        material.color = Random.ColorHSV();
    }

    void Update()
    {
        float[] cubePosition = RandomizePositionCube();

        transform.position = new Vector3(cubePosition[0], cubePosition[1], cubePosition[2]);

        transform.Rotate(15.0f * Time.deltaTime, 0.0f, 0.0f);

        Material material = Renderer.material;
        material.color = Random.ColorHSV();

        ScaleSlowly(2f, 0.5f);
    }

    float[] RandomizePositionCube()
    {
        float[] cubePosition = new float[3];
        cubePosition[0] = Random.Range(0, 5);
        cubePosition[1] = Random.Range(0, 5);
        cubePosition[2] = Random.Range(0, 5);

        return cubePosition;
    }

    private IEnumerator ScaleSlowly(float duration, float scale)
    {
        Vector3 startScale = transform.localScale;
        Vector3 endScale = Vector3.one * scale;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float timer = elapsed / duration;
            transform.localScale = Vector3.Lerp(startScale, endScale, timer);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = endScale;

    }
}
