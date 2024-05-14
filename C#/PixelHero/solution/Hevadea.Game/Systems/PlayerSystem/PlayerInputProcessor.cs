using Hevadea.Entities;
using Hevadea.Entities.Components;
using Hevadea.Framework;
using Hevadea.Scenes.Menus;
using Hevadea.Systems.InventorySystem;
using Hevadea.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace Hevadea.Systems.PlayerSystem
{
    public enum PlayerInput
    {
        MoveLeft,
        MoveRight,
        MoveUp,
        MoveDown,
        Action,
        Attack,
        Pickup,
        DropItem,
        AddWaypoint,
        ZoomIn,
        ZoomOut,
    }

    public class PlayerInputProcessor : EntityUpdateSystem
    {
        public const float PLAYER_MOVE_SPEED = 1f;

        public PlayerInputProcessor()
        {
            Filter.AnyOf(typeof(ComponentPlayerBody), typeof(ComponentRideable));
        }

        public override void Update(Entity entity, GameTime gameTime)
        {
            var i = Rise.Input;
            if (entity.HasComponent<ComponentRideable>() && !(entity.GetComponent<ComponentRideable>().Rider?.HasComponent<ComponentPlayerBody>() ?? false))
            {
                return;
            }

            if (i.KeyDown(Keys.A) != i.KeyDown(Keys.D))
            {
                if (i.KeyDown(Keys.A)) HandleInput(entity, PlayerInput.MoveLeft);
                if (i.KeyDown(Keys.D)) HandleInput(entity, PlayerInput.MoveRight);
            }

            if (i.KeyDown(Keys.W) != i.KeyDown(Keys.S))
            {
                if (i.KeyDown(Keys.W)) HandleInput(entity, PlayerInput.MoveUp);
                if (i.KeyDown(Keys.S)) HandleInput(entity, PlayerInput.MoveDown);
            }

            switch (i.MousePostionDelta())
            {
                case Framework.Input.Direction.North:
                    entity.Facing = Direction.North;
                    break;
                case Framework.Input.Direction.East:
                    entity.Facing = Direction.East;
                    break;
                case Framework.Input.Direction.South:
                    entity.Facing = Direction.South;
                    break;
                case Framework.Input.Direction.West:
                    entity.Facing = Direction.West;
                    break;
                default:
                    break;
            }

            // Action que l'on peut faire sur un bateau
            if (entity.HasComponent<ComponentRideable>())
            {
                Entity rider = entity.GetComponent<ComponentRideable>().Rider;
                rider.GetComponent<ComponentRider>().RidingFor++;
                rider.Position = entity.Position;
                rider.Facing = entity.Facing;
                if (i.KeyTyped(Keys.L)) HandleInput(rider, PlayerInput.Pickup);
                if (i.KeyTyped(Keys.Q)) HandleInput(rider, PlayerInput.DropItem);
                if (i.MouseRightButtonClick()) HandleInput(rider, PlayerInput.Action);
                if (i.KeyTyped(Keys.X)) HandleInput(rider, PlayerInput.AddWaypoint);
                if (i.KeyDown(Keys.LeftControl))
                {
                    if (i.ScrollWheelDelta() == true)
                    {
                        HandleInput(entity, PlayerInput.ZoomIn);
                    }
                    else if (i.ScrollWheelDelta() == false)
                    {
                        HandleInput(entity, PlayerInput.ZoomOut);
                    }
                }
                return;
            }

            if (i.KeyDown(Keys.LeftControl))
            {
                if (i.ScrollWheelDelta() == true)
                {
                    HandleInput(entity, PlayerInput.ZoomIn);
                }
                else if (i.ScrollWheelDelta() == false)
                {
                    HandleInput(entity, PlayerInput.ZoomOut);
                }
            }
            if (i.MouseLeftButtonClick()) HandleInput(entity, PlayerInput.Attack);
            if (i.KeyTyped(Keys.Q)) HandleInput(entity, PlayerInput.DropItem);
            if (i.MouseRightButtonClick()) HandleInput(entity, PlayerInput.Action);
            if (i.KeyTyped(Keys.X)) HandleInput(entity, PlayerInput.AddWaypoint);
            if (i.KeyTyped(Keys.L)) HandleInput(entity, PlayerInput.Pickup);

        }

        public void HandleInput(Entity player, PlayerInput input)
        {
            GameState game = player.GameState;
            var playerMovement = player.GetComponent<ComponentMove>();
            var energy = player.GetComponent<ComponentEnergy>();
            float movementSpeed = PLAYER_MOVE_SPEED;
            //Pour courrir
            if (Rise.Input.KeyDown(Keys.LeftShift) && energy != null && energy.Value > 1)
            {
                movementSpeed = Rise.Input.KeyDown(Keys.LeftShift) ? PLAYER_MOVE_SPEED * 2 : PLAYER_MOVE_SPEED;
                energy.Reduce(0.03f);
            }

            switch (input)
            {
                case PlayerInput.MoveLeft:
                    playerMovement.Do(-movementSpeed, 0f);
                    break;

                case PlayerInput.MoveRight:
                    playerMovement.Do(movementSpeed, 0f);
                    break;

                case PlayerInput.MoveUp:
                    playerMovement.Do(0f, -movementSpeed);
                    break;

                case PlayerInput.MoveDown:
                    playerMovement.Do(0f, movementSpeed);
                    break;

                case PlayerInput.Action:
                    if (player.GetComponent<ComponentInventory>().Content.Count(player.HoldedItem()) == 0)
                        player.HoldItem(null);
                    if (player.IsRiding())
                    {
                        player.UnMount();
                        //Puisque l'input ne updatais pas avant le prochain Update de cette classe
                        Rise.Input.Update(new GameTime());
                    }
                    else
                    {
                        player.GetComponent<ComponentInteract>().Do(player.HoldedItem());
                    }
                    break;

                case PlayerInput.Attack:
                    player.GetComponent<ComponentAttack>().Do(player.HoldedItem());
                    break;

                case PlayerInput.Pickup:
                    if (player.IsRiding())
                    {
                        player.UnMount();
                        //Puisque l'input n'updatais pas avant le prochain Update de cette classe
                        Rise.Input.Update(new GameTime());
                    }
                    player.GetComponent<ComponentPickup>().Do();

                    break;

                case PlayerInput.DropItem:
                    var level = player.Level;
                    var item = player.HoldedItem();
                    var facingTile = player.FacingCoordinates;

                    player.GetComponent<ComponentInventory>().Content.DropOnGround(level, item, facingTile, 1);

                    break;

                case PlayerInput.ZoomIn:
                    if (game.Camera.Zoom < 8) game.Camera.Zoom /= 0.8f;
                    break;

                case PlayerInput.ZoomOut:
                    if (game.Camera.Zoom > 2) game.Camera.Zoom *= 0.8f;
                    break;

                case PlayerInput.AddWaypoint:
                    game.CurrentMenu = new MenuAddMinimapWaypoint(game);

                    break;
            }
        }
    }
}