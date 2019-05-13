using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {

	public enum DrawMode {NoiseMap, ColorMap, Mesh}
	public DrawMode drawMode;

	public int mapWidth;
	public int mapHeight;
	public float noiseScale;

	public bool autoUpdate;

	public int octaves;
	public float persistance;
	public float lacunarity;

	[Range(0,1000)]
	public int seed;

	public Vector2 offSet;
	public float meshHeightMultiplier;
	public AnimationCurve meshHeightCurve;

	public TerrainType[] regions;


	public void GenerateMap(){
		float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth,  mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offSet);

		MapDisplay display = FindObjectOfType<MapDisplay>();


		Color[] colorMap = new Color[mapWidth*mapHeight];
		for(int y = 0; y < mapHeight ; y++){
			for(int x = 0; x < mapWidth; x++){
				float currentHeight = noiseMap[x,y];
				for(int i = 0 ; i < regions.Length ; i++){
					if(currentHeight <= regions[i].height){
						colorMap[y*mapWidth + x] = regions[i].color;

						break;
					}

				}
			}
		}

		if(drawMode == DrawMode.NoiseMap){
			display.DrawTexture(TexGenerator.TextureFromHeightMap(noiseMap));	
		}else if(drawMode == DrawMode.ColorMap){
			display.DrawTexture(TexGenerator.TextureFromColorMap(colorMap, mapWidth, mapHeight));
		}else if(drawMode == DrawMode.Mesh){
			display.DrawMesh(MeshGenerator.GenerateTerrainMesh(noiseMap,meshHeightMultiplier, meshHeightCurve), TexGenerator.TextureFromColorMap(colorMap, mapWidth, mapHeight));
		}
		

	}

	[System.Serializable]
	public struct TerrainType{
		public string name;
		public float height;
		public Color color;
	}
}
