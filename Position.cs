using System;

public class Position
{
	public string mapName;
	public string identificationName;
	public string parameterValue;
	public Position(string mapName, string identificationName, string parameterValue)
	{
		this.mapName = mapName;
		this.identificationName = identificationName;
		this.parameterValue = parameterValue;
	}
}
