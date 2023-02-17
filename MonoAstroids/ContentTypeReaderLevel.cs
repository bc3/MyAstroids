using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

// TODO: replace this with the type you want to read.
using LevelMyAstroids = System.String;

namespace MyAstroids
{
    /// <summary>
    /// This class will be instantiated by the XNA Framework Content
    /// Pipeline to read the specified data type from binary .xnb format.
    /// 
    /// Unlike the other Content Pipeline support classes, this should
    /// be a part of your main game project, and not the Content Pipeline
    /// Extension Library project.
    /// </summary>
    public class ContentTypeReaderLevel : ContentTypeReader<LevelMyAstroids>
    {
        protected override LevelMyAstroids Read(ContentReader input, LevelMyAstroids existingInstance)
        {
            existingInstance = new LevelMyAstroids();

            existingInstance.Number = input.ReadInt32();
            existingInstance.DurationOfBulletPowerUp = input.ReadInt32();
            existingInstance.DurationOfSpeedPowerup = input.ReadInt32();
            existingInstance.SeedOfSpeedPowerup = input.ReadInt32();
            existingInstance.SeedOfSpeedPowerup = input.ReadInt32();
            existingInstance.SpaceShipHealth = input.ReadInt32();
            existingInstance.NumberOfRocks = input.ReadInt32();
            return existingInstance;

        }
    }
}
