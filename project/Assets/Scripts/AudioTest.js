var freqData:float[] = new float[8192];
var listener : AudioListener;
 
var band:float[];
var g:GameObject[];
 


function Start()
{
    var n:int = freqData.length;
    var k:int = 0;
    for(var j=0;j<freqData.length;j++)
    {
        n /= 2;
        if(!n) break;
        k++;
    }
    band  = new float[k+1];
    g     = new GameObject[k+1];
    for (var i=0;i<band.length;i++)
    {
        band[i] = 0;
        g[i] = new  GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        g[i].transform.position = Vector3(i,0,0);
        g[i].transform.rotation.eulerAngles = Vector3(90,90,0);
        g[i].transform.localScale.y = 0.5f;
    }
    InvokeRepeating("check", 0, 1.0/15.0); // update at 15 fps
}

 

function check()
{
    listener.GetSpectrumData(freqData, 0, FFTWindow.Rectangular);
       
    var k:int = 0;
    var crossover:int = 2; 
    for(var i:int;i< freqData.length;i++)
    {   
        var d = freqData[i];
        var b = band[k];       
        band[k] = (d>b)? d:b;   // find the max as the peak value in that frequency band.
        if (i>crossover-3)
        {
            k++;
            crossover *= 2;   // frequency crossover point for each band.
            g[k].transform.localScale.x = 3 * band[k]*32;
            g[k].transform.localScale.z = 3 * band[k]*32;
            g[k].renderer.material.color.b = band[k]*15;
            g[k].renderer.material.color.r = 0;
            g[k].renderer.material.color.g = 0;
            band[k] = 0;
        }   
    }
}

private var sqrt = Mathf().Sqrt;