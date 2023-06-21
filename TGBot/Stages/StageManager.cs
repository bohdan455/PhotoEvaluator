using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGBot.Stages.Interfaces;
using TGBot.Stages.StageTypes;

namespace TGBot.Stages
{
    public class StageManager : IStageManager
    {
        private readonly AddAgeStage _addAgeStage;
        private readonly AddNameStage _addNameStage;
        private readonly AddPhotoStage _addPhotoStage;
        private readonly ChangeNameStage _changeNameStage;
        private readonly ChangePhotoStage _changePhotoStage;
        private readonly MenuStage _menuStage;
        private readonly RateStage _rateStage;
        private readonly SettingsStage _settingsStage;

        public StageManager(AddAgeStage addAgeStage,
            AddNameStage addNameStage,
            AddPhotoStage addPhotoStage,
            ChangeNameStage changeNameStage,
            ChangePhotoStage changePhotoStage,
            MenuStage menuStage,
            RateStage rateStage,
            SettingsStage settingsStage)
        {
            _addAgeStage = addAgeStage;
            _addNameStage = addNameStage;
            _addPhotoStage = addPhotoStage;
            _changeNameStage = changeNameStage;
            _changePhotoStage = changePhotoStage;
            _menuStage = menuStage;
            _rateStage = rateStage;
            _settingsStage = settingsStage;
        }
        /// <summary>
        ///SetName = 1,
        ///SetAge = 2,
        ///SetPhoto = 3,
        ///Menu = 4,
        ///Rate = 5,
        ///Settings = 6,
        ///ChangeName = 7,
        ///ChangePhoto = 8
        /// </summary>
        /// <returns></returns>
        public IStage GetStageInstance(int stageId)
        {
            return stageId switch
            {
                1 => _addNameStage,
                2 => _addAgeStage,
                3 => _addPhotoStage,
                4 => _menuStage,
                5 => _rateStage,
                6 => _settingsStage,
                7 => _changeNameStage,
                8 => _changePhotoStage,
                _ => throw new InvalidDataException($"Could not find {stageId}"),
            };
        }
    }
}
