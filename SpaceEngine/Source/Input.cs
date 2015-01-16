using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

    static class Input
    {
        static public KeyboardState PreviousKeyboard;
        static public MouseState PreviousMouse;

        public enum EClicks
        {
            LEFT,
            MIDDLE,
            RIGHT
        }

        static public bool KeyboardPressed(Keys key)
        {
            return Keyboard.GetState().IsKeyDown(key) & PreviousKeyboard.IsKeyUp(key);
        }
        static public bool KeyboardReleased(Keys key)
        {
            return Keyboard.GetState().IsKeyUp(key) & PreviousKeyboard.IsKeyDown(key);
        }
        static public bool KeyboardPress(Keys key)
        {
            return Keyboard.GetState().IsKeyDown(key);

        }
        static public bool KeyboardRelease(Keys key)
        {
            return Keyboard.GetState().IsKeyUp(key);
        }

        static public bool ClickPressed(EClicks click)
        {
            switch (click)
            {
                case EClicks.LEFT: return Mouse.GetState().LeftButton == ButtonState.Pressed & PreviousMouse.LeftButton == ButtonState.Released;
                case EClicks.MIDDLE: return Mouse.GetState().MiddleButton == ButtonState.Pressed & PreviousMouse.MiddleButton == ButtonState.Released;
                case EClicks.RIGHT: return Mouse.GetState().RightButton == ButtonState.Pressed & PreviousMouse.RightButton == ButtonState.Released;
            }
            return false;
        }
        static public bool ClickPress(EClicks click)
        {
            switch (click)
            {
                case EClicks.LEFT: return Mouse.GetState().LeftButton == ButtonState.Pressed;
                case EClicks.MIDDLE: return Mouse.GetState().MiddleButton == ButtonState.Pressed;
                case EClicks.RIGHT: return Mouse.GetState().RightButton == ButtonState.Pressed;
            }
            return false;
        }
        static public bool ClickReleased(EClicks click)
        {
            switch (click)
            {
                case EClicks.LEFT: return Mouse.GetState().LeftButton == ButtonState.Released & PreviousMouse.LeftButton == ButtonState.Pressed;
                case EClicks.MIDDLE: return Mouse.GetState().MiddleButton == ButtonState.Released & PreviousMouse.MiddleButton == ButtonState.Pressed;
                case EClicks.RIGHT: return Mouse.GetState().RightButton == ButtonState.Released & PreviousMouse.RightButton == ButtonState.Pressed;
            }
            return false;
        }
        static public bool ClickRelease(EClicks click)
        {
            switch (click)
            {
                case EClicks.LEFT: return Mouse.GetState().LeftButton == ButtonState.Released;
                case EClicks.MIDDLE: return Mouse.GetState().MiddleButton == ButtonState.Released;
                case EClicks.RIGHT: return Mouse.GetState().RightButton == ButtonState.Released;
            }
            return false;
        }

        static public void Update()
        {
            PreviousKeyboard = Keyboard.GetState();
            PreviousMouse = Mouse.GetState();
        }
    }
