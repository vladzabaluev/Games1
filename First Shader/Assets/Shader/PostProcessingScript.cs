using UnityEngine;

public class PostProcessingScript : MonoBehaviour
{
    [SerializeField]
    private Material postprocessMaterial;
    // Start is called before the first frame update
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source,destination,postprocessMaterial);
    }
}
