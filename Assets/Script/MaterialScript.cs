using System.Linq;
using UnityEngine;

public class MaterialScript : MonoBehaviour
{
    [SerializeField]
    private Texture[] textures;
    private int indexSelected = 0;

    void OnMouseDown()
    {
        if (textures.Any())
        {
            if(indexSelected == textures.Length - 1)
            {
                indexSelected = 0;
            }
            else
            {
                indexSelected++;
            }

            GetComponent<Renderer>().material.mainTexture = textures[indexSelected];
        }
    }
}
