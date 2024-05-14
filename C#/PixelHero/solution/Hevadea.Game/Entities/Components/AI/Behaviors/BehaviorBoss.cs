using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hevadea.Entities.Monsters;
using Hevadea.Framework;
using Hevadea.Worlds;
using Microsoft.Xna.Framework;

namespace Hevadea.Entities.Components.AI.Behaviors
{
    class BehaviorBoss:BehaviorEnemy
    {
        private int _SpawnedMinion = 1000;
        public BehaviorBoss()
        {
            AgroRange = 20;
            FollowRange = 30;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            float distance = Mathf.Distance(_lastTagetPosition.ToVector2(), Agent.Owner.Position);
            Agent.Owner.GameState.Camera.Thrauma = 0.5 - (distance/500);
            //~15 sec
            if (_SpawnedMinion >= 1000 && distance < 200)
            {
                SpawnMinion();
                _SpawnedMinion = 0;
            }
            else
                _SpawnedMinion++;
        }
        protected override bool CheckLineOfSight(Coordinates coords)
        {
            return true;
        }

        private void SpawnMinion()
        {
            int x = (int)Agent.Owner.X;
            int y = (int)Agent.Owner.Y;
            Level l = Agent.Owner.Level;
            for (int i = x - 10; i < x + 10; i++)
            {
                for (int j = y - 10; j < y + 10; j++)
                {
                    Coordinates coordinates = new Coordinates(i, j);
                    if (!l.GetTile(coordinates).BlockLineOfSight &&
                        !l.AnyEntityAt(coordinates))
                    {
                        Entity e = ((IBoss)Agent.Owner).Minion.Construct();
                        e.SetPosition(i, j);
                        l.AddEntity(e);
                        return;
                    }
                }
            }
        }
    }
}
