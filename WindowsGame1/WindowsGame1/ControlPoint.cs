using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame1
{
    class ControlPoint
    {
        public Texture2D tex;
        public Vector2 pos, fontPos;
        public Rectangle rect;
        public bool isCP = false;
        
        string x;
        public ControlPoint(Texture2D t, Vector2 p)
        {
            tex = t;
            pos = p;
            rect = new Rectangle(0, 0, 0, 0);
            
        }
        public void update()
        {
            rect = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
            fontPos = new Vector2(pos.X + 20, pos.Y + 20);
            x = "" + pos.X+ "," + pos.Y;
        }
        public void Draw(SpriteBatch sb, SpriteFont sf)
        {
            sb.Draw(tex, rect, Color.White);
            if (isCP == true)
            sb.DrawString(sf, x, fontPos, Color.White);

        }

    }
}
