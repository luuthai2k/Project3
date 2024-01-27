using UnityEngine;
//this script gets the color from the color picker scripts and applies it to the selected cars by the players
public class ColorSelect : MonoBehaviour
{
    public int ModeSelection;
    private GameObject CarP1Body;
    private GameObject CarP2Body;
    private Renderer m_Renderer;
    private Renderer m_RendererP2;

    void Update()
    {
        ModeSelection = ModeSelect.RaceMode;
        CarP1Body = GameObject.FindWithTag("CarBodyP1");
        m_Renderer = CarP1Body.GetComponent<Renderer>();
        m_Renderer.material.color = ColorPicker.carColor;
       
    }
}