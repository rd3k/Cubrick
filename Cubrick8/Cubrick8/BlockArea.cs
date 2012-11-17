using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cubrick8
{
	enum BlockAreaTileType
	{
		Empty,
		Solid,
		Key,
		Door,
		Start,
	}

	class BlockArea
	{
		private const int AreaSize = 8;
		private const int TileSize = 32;

		private GraphicsDevice device;
		private BlockAreaTileType[,] tiles;
		private RenderTarget2D texture;

		public BlockArea(GraphicsDevice device)
		{
			this.device = device;
			this.tiles = new BlockAreaTileType[8, 8];
			this.texture = new RenderTarget2D(device, AreaSize * TileSize, AreaSize * TileSize);
		}

		public void RenderToDevice()
		{
			// device.SetRenderTarget(texture);

			// device.Clear(Color.Red);

			// device.SetRenderTarget(null);
		}

		private void RenderTile(int x, int y)
		{

		}

		public BlockAreaTileType[,] Tiles
		{
			get { return tiles; }
		}

		public Texture2D Texture
		{
			get { return texture; }
		}
	}
}
