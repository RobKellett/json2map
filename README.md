# Json2map

## Intro

A library for converting JSON map data from [Tiled map editor](http://www.mapeditor.org/) into a POCO (plain 'ol C# object) that's easily usuable in C#, XNA, and MonoGame.

## Getting Started


### Using Json2map in a project with Nuget

Open *Visual Studio*'s **Package Manager Console** and run the `Install-Package Json2map` command to add a reference to Json2map from your project.

Then, initalize a map somewhere in your Initalize function:

```C#
Map currentMap = MapReader.ReadJson(File.ReadAllText("path/to/yourmap.json"));
```

Finally, update your draw method to draw your map. I use something like:

```C#
foreach (MapLayer currentLayer in currentMap.MapLayers)
{
	if (currentLayer.Visible)
	{
		for (int countY = 0; countY < currentMap.MapHeight; countY++)
		{
			for (int countX = 0; countX < currentMap.MapWidth; countX++)
			{
				int currentTileNumber = currentLayer.Tiles[(countY * currentMap.MapWidth) + countX];
				int TilesetWidth_inTiles = currentMap.Tilesets[0].TilesetWidth / currentMap.TileWidth;

				if (currentTileNumber != 0)   // 0 is a transparent tile in Tiled
				{
					spriteBatch.Draw(
						Resources.Spr_Envronment_DynamicTilesets[0].Texture, //TODO: Change this from a hardcoded [0] (Not very dynamic, I guess)
						Camera.getScreenPosition(new Vector2(
							countX * currentMap.TileWidth,
							countY * currentMap.TileHeight
						)),
						new Microsoft.Xna.Framework.Rectangle(
							(currentMap.TileWidth) * ((currentTileNumber - 1) % TilesetWidth_inTiles), // The -1 accounts for Tiled's numbering scheme starting at 1
							(currentMap.TileHeight) * (int)((currentTileNumber - 1) / TilesetWidth_inTiles),
							currentMap.TileWidth,
							currentMap.TileHeight
						),
						Color.White,
						0.0f,
						Vector2.Zero,
						1.0f,
						SpriteEffects.None,
						1.0f
					);
				}
			}
		}
	}
}
```

## Contributing

I appreciate any and all Pull Requests and issues, but at this point I'm still trying to figure out the scope of this project so I may not approve everything without some discussion.

Of course, the license is permissive enough for you to feel free to fork your own copy and do with it whatever you like.
