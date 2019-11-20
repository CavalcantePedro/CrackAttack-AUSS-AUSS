using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectrumDrawner : MonoBehaviour
{
    //Analyzing sound
    private const int SAMPLE_SIZE = 1024;
    public float rmsValue;
    public float dbValue;
    
    [SerializeField]private AudioSource source;
    private float[] samples;
    private float[] spectrum;
    private float sampleRate;


    //Drawning Line
    private Transform[] visualList;
    private float[] visualScale;
    
    public int amnVisual;
    
    public float visualModifier; //50f
    public float smoothSpeed; // 10f

    public float maxVisualScale; // 25f

    public float  keepPercentage;

    public GameObject tile;

    //Resizing

    public float resizeScale;
    public bool invertSides;


    // Start is called before the first frame update
    void Start()
    {
        samples =  new float[SAMPLE_SIZE];
        spectrum =  new float [SAMPLE_SIZE];
        sampleRate = AudioSettings.outputSampleRate;     
        SpawnLine();     
        AdjustSize();      
    }


    // Update is called once per frame
    void Update()
    {
        AnalyzeSound();
        UpdateVisual();
    }
    
    private void UpdateVisual()
    {
        int visualIndex = 0;
        int spectrumIndex = 0; 
        int averageSize = (int)((SAMPLE_SIZE*keepPercentage) / amnVisual);
        
        while(visualIndex < amnVisual)
        {
            int j = 0;
            float sum = 0 ;
            while(j < averageSize)
            {
                sum+= spectrum[spectrumIndex];
                spectrumIndex++;
                j++;
            }

            float scaleY = sum/averageSize * visualModifier;
            visualScale[visualIndex] -= Time.deltaTime * smoothSpeed;
            if(visualScale[visualIndex] < scaleY)
            {
                visualScale[visualIndex] = scaleY;
            }

            if(visualScale[visualIndex] > maxVisualScale)
            {
                visualScale[visualIndex] = maxVisualScale;
            }

                visualList[visualIndex].localScale = Vector3.one + Vector3.up * visualScale[visualIndex];
                visualIndex++;   
        }
    }

    private void AdjustSize()
    {
        if(invertSides)
        {
            transform.localScale = new Vector2(-resizeScale , resizeScale);
        }

        else
        {
            transform.localScale = new Vector2(resizeScale , resizeScale);
        }
    }
    private void SpawnLine()
    {
        visualScale = new float[amnVisual];
        visualList = new Transform[amnVisual];

        for (int i = 0; i < amnVisual; i++)
        {
            GameObject go = Instantiate(tile,transform.position,Quaternion.identity,transform);
            visualList[i] =  go.transform;
            visualList[i].position = Vector2.right * i;
        }
    }
    private void AnalyzeSound()
    {
        source.GetOutputData(samples,0);

        //Getting RMS
        int i = 0;
        float sum = 0;
        for (; i < SAMPLE_SIZE; i++)
        {
            sum = samples[i] * samples[i];
        }
        rmsValue = Mathf.Sqrt(sum / SAMPLE_SIZE);

        //Getting Db value
        dbValue = 20 * Mathf.Log10(rmsValue / 0.1f);

        //Getting Spectrum
        source.GetSpectrumData(spectrum, 0 , FFTWindow.BlackmanHarris);
    }
}
