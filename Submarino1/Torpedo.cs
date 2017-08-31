using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submarino1
{

    class Torpedo
    {
        public int TorpedoId { get; set; }
        public Vector2 TorpedoPosition { get; set; }
        public Texture2D TorpedoImage { get; set; }
        public int TorpedoMaxPosition { get; set; }
        public bool TorpedoVisible { get; set; }

        public Torpedo(int id, Vector2 position, Texture2D image, int maxPosition, bool visible, SpriteBatch spriteBatch)
        {
            TorpedoId = id;
            TorpedoPosition = position;
            TorpedoImage = image;
            TorpedoMaxPosition = maxPosition;
            TorpedoVisible = visible;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TorpedoImage, TorpedoPosition, Color.White);
        }
    }

}
