using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Sprint6.Sound.MarioSound;
using Microsoft.Xna.Framework.Media;
using Sprint6.Sound.BackgroundMusic;
using System.Diagnostics;
using Sprint6.SpriteFactories;
using Sprint6.HUDElements;

namespace Sprint6.ElementClasses
{
    public class MainCharacter
    {
        private Game1 myGame;
        public IState state { get; set; }

        public int marioAction { set; get; }
        public BeamMeter beamMeter { get; set; }
        public int marioState { set; get; }
        public Vector2 position { set; get; }
        public int gravity { get; set; }
        public bool jump { get; set; }
        public bool canMove { get; set; }
        public bool animated { get; set; }
        public int animation { get; set; }
        public bool isVisible { get; set; }
        private bool IsJumping;

        public bool isScored { get; set; }
        public int score { get; set; }
        public int totalScore { get; set; }
        public Vector2 textPosition { get; set; }
        public int CowCount { get; set; }


        private int JumpCounter, counter, scoreCounter;
  

        public MainCharacter(Game1 game, Vector2 position)
        {
            myGame = game;
            state = new FlyingState(this);
            state.Sprite = CharacterSpriteFactory.Instance.CreateFlyingUFOSprite();
            beamMeter = new BeamMeter(myGame);
            this.position = position;
            canMove = true;
            scoreCounter = 0;
            gravity = 6;
            animated = false;
            isVisible = true;
            isScored = false;
            IsJumping = false;
            JumpCounter = 0;
        }
        public void MarioIdle()
        {
        }
        public virtual void MarioChangeForm(int form)
        {

        }
        public void MainCharJump()
        {
                IsJumping = true;
                JumpCounter = 20;
                myGame.level.accel = 0;
                myGame.level.mainCharacter.state.Sprite = CharacterSpriteFactory.Instance.CreateJumpingUFOSprite();
        }

        public virtual void MainCharDraw()
        {
            state.Draw(position);
            if (isScored)
            {
                DrawScore();
            }            
        }
        public void MainCharUpdate()
        {
            if (canMove)
            {
                if (beamMeter.GetBeamPercent() < 100)
                {
                    beamMeter.IncrementBeamPercent();
                }
                state.Sprite.Update();
                if (IsJumping)
                {
                    position = new Vector2(position.X + GameConstants.UFOSpeedX, position.Y - (float)(JumpCounter / 1.5));
                    JumpCounter--;
                    if (JumpCounter == 0)
                    {
                        IsJumping = !IsJumping;
                        state.Sprite = CharacterSpriteFactory.Instance.CreateFlyingUFOSprite();
                    }
                }
                else
                {
                    position = new Vector2(position.X + GameConstants.UFOSpeedX, position.Y);
                }
            }
        }

        public void UFODie()
        {
            MediaPlayer.Stop();
            state.Die();
        }

        public void Attack(bool bomb)
        {
            if (bomb)
            {
                if (myGame.level.mainCharacter.state is FlyingState)
                {
                    FlyingState f = myGame.level.mainCharacter.state as FlyingState;
                    f.bomb = true;
                    myGame.level.mainCharacter.state = f;
                }
                else if (myGame.level.mainCharacter.state is JumpingState)
                {
                    JumpingState f = (JumpingState)myGame.level.mainCharacter.state;
                    f.bomb = true;
                    myGame.level.mainCharacter.state = f;
                }
            }
            else
            {
                if (beamMeter.GetBeamPercent() > GameConstants.Three)
                {
                    beamMeter.DecreaseBeamPercentBy(GameConstants.Three);
                    if (myGame.level.mainCharacter.state is FlyingState && beamMeter.GetBeamPercent() > GameConstants.Three)
                    {
                        FlyingState f = myGame.level.mainCharacter.state as FlyingState;
                        f.beam = true;
                        myGame.level.mainCharacter.state = f;
                    }
                    else if (myGame.level.mainCharacter.state is JumpingState && beamMeter.GetBeamPercent() > GameConstants.Three)
                    {
                        JumpingState f = (JumpingState)myGame.level.mainCharacter.state;
                        f.beam = true;
                        myGame.level.mainCharacter.state = f;
                    }
                }
            }
        }

        public void DrawScore()
        {
            Vector2 newPos;
            newPos.X = textPosition.X;
            newPos.Y = textPosition.Y;
            String output;
            output = "" + score;
           
            Vector2 FontOrigin = myGame.font.MeasureString(output) / GameConstants.Two;
            myGame.spriteBatch.Begin();

                if (scoreCounter <= GameConstants.Two* GameConstants.Ten)
                {
                    textPosition = new Vector2(newPos.X, newPos.Y - GameConstants.Three);
                    myGame.spriteBatch.DrawString(myGame.font, output, newPos, Color.White,
                0, FontOrigin, 1.0f, SpriteEffects.None, 1f);
                scoreCounter++;
                }
            else
            {
                scoreCounter = 0;
                isScored = false;
            }
               
            myGame.spriteBatch.End();
        }



    }
}
