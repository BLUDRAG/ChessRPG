using UnityEngine;
using System.Collections;

namespace Gamify
{
	/// <summary>
	/// This is a general utility class containing
	/// static methods for conveniently retrieving
	/// commonly used information or performing
	/// common calculations.
	/// </summary>
	public class Utilities {
	
		public static Color GetBlockColor(Enums.BlockColour color)
		{
			Color parsedColor = Color.black;
			
			switch(color)
			{
			case Enums.BlockColour.White:
				parsedColor = Color.white;
				break;
            case Enums.BlockColour.Red:
                parsedColor = Color.red;
                break;
			}
			
			return parsedColor;
		}
		
		public static Color GetPieceColor(Enums.PieceColour color)
		{
			Color parsedColor = Color.black;
			
			switch(color)
			{
			case Enums.PieceColour.White:
				parsedColor = Color.white;
				break;
            case Enums.PieceColour.Red:
                parsedColor = Color.red;
                break;
			}
			
			return parsedColor;
		}
	}
}
